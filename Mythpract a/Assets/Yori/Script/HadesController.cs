
using UnityEngine;

public class HadesController : MonoBehaviour
{
    [SerializeField, Header("行動番号")]
    private int actNo = 0;      // 行動番号
    [SerializeField, Header("メソッド用汎用番号")]
    private int methodNo = 0;   // メソッド用汎用番号

    enum ActNo
    {
        App,
        LodAttack,
        ShockWave,
        Num         // 総数
    }

    // デリゲード
    // 関数を型にするためのもの
    private delegate void ActFunc();
    // 関数の配列
    private ActFunc[] actFuncTbl;

    private Animator anim;

    private float timer = 0;

    [SerializeField, Header("Player")]
    GameObject playerObj;

    private Vector3 pos;

    private Vector3 firstPos;

    [SerializeField, Header("テレポで行くときの時間")]
    private float teleGoTime = 0.5f;

    [SerializeField, Header("テレポでもどるときの時間")]
    private float teleBackTime = 0.5f;

    [SerializeField, Header("テレポ攻撃するときの時間")]
    private float teleAttackTime = 0.5f;

    [SerializeField, Header("デバッグボタン好きな行動の番号をここに入れるとEを押したときに反応する")]
    private int debugActNum = 0;

    SY.HitMng hitmng;

    [SerializeField, Header("弾のオブジェクト")]
    GameObject waveObj;

    [SerializeField]
    private float Genetime;

    private Vector3 wavePos;

    private float waveTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        hitmng = GetComponent<SY.HitMng>();
        anim = GetComponent<Animator>();
        actFuncTbl = new ActFunc[(int)ActNo.Num];
        actFuncTbl[(int)ActNo.App] = ActApp;
        actFuncTbl[(int)ActNo.LodAttack] = ActLodAttack;
        actFuncTbl[(int)ActNo.ShockWave] = ActShockWave;
        firstPos = this.gameObject.transform.position;
        timer = teleBackTime;

        hitmng.SetUp(hit, die);

        anim.Play("08_TRBoss_appearance");
    }

    // Update is called once per frame
    void Update()
    {
        hitmng.HitUpdate();
        // 関数配列を用いた関数の呼び出し
        actFuncTbl[actNo]();
        if (Input.GetKeyDown(KeyCode.E))
        {
            actNo = debugActNum;
        }
        hitmng.PostUpdate();
    }

    void ActApp()
    {
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animInfo.normalizedTime > 1.0f)
        {
            anim.Play("01_TRBoss_stay");
            hitmng.DEFActive = true;
            hitmng.ATKActive = true;
        }

    }

    void ActLodAttack()
    {
        switch (methodNo)
        {
            case 0:
                AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animInfo.normalizedTime > 1.0f)
                {
                    anim.Play("03_TRBoss_step");
                    timer = teleGoTime;
                    pos.x = playerObj.transform.position.x;
                    pos.x += 2;
                    pos.y = firstPos.y;
                    hitmng.DEFActive = false;
                    hitmng.ATKActive = false;
                    methodNo++;
                }

                break;
            case 1:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    this.gameObject.transform.position = pos;
                    timer = teleAttackTime;
                    anim.Play("02b_TRBoss_attack_morefast");
                    hitmng.DEFActive = true;
                    hitmng.ATKActive = true;
                    methodNo++;
                }
                break;
            case 2:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    animInfo = anim.GetCurrentAnimatorStateInfo(0);
                    if (animInfo.normalizedTime > 1.0f)
                    {
                        anim.Play("03_TRBoss_step");
                        timer = teleBackTime;
                        hitmng.DEFActive = false;
                        hitmng.ATKActive = false;
                        methodNo++;
                    }
                }
                break;
            case 3:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    this.gameObject.transform.position = firstPos;
                    methodNo = 0;
                    actNo = (int)ActNo.App;
                }
                break;
        }
    }

    void ActShockWave()
    {
        switch (methodNo)
        {
            case 0:
                AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animInfo.normalizedTime > 1.0f)
                {
                    anim.Play("07_TRBoss_RodUse");
                    timer = teleGoTime;

                    wavePos = transform.position;
                    wavePos.y -= 4;

                    
                    methodNo++;
                }
                break;
            case 1:
                if (waveTime >= Genetime)
                {
                    WaveCreate();
                    waveTime = 0;
                }
                waveTime += 0.017f;
                methodNo++;
                break;
            case 2:
                break;
        }
    }

    void hit()
    {

    }

    void die()
    {

    }

    void WaveCreate()
    {
        Instantiate(waveObj, wavePos, Quaternion.identity);
        wavePos += new Vector3(0.2f, 0, 0);
    }
}
