
using UnityEngine;

public class HadesController : MonoBehaviour
{
    [SerializeField, Header("行動番号")]
    public int actNo = 0;      // 行動番号
    [SerializeField, Header("メソッド用汎用番号")]
    private int methodNo = 0;   // メソッド用汎用番号

    enum ActNo
    {
        App,
        Wait,
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

    [SerializeField, Header("ショック")]
    GameObject shockEffect;

    [SerializeField, Header("スラッシュエフェクト")]
    private GameObject slashEffect;

    public bool dieFlg;

    private bool AttackType;
    // Start is called before the first frame update
    void Start()
    {
        hitmng = GetComponent<SY.HitMng>();
        anim = GetComponent<Animator>();
        actFuncTbl = new ActFunc[(int)ActNo.Num];
        actFuncTbl[(int)ActNo.App] = ActApp;
        actFuncTbl[(int)ActNo.Wait] = ActWait;
        actFuncTbl[(int)ActNo.LodAttack] = ActLodAttack;
        actFuncTbl[(int)ActNo.ShockWave] = ActShockWave;
        firstPos = this.gameObject.transform.position;
        timer = teleBackTime;

        hitmng.SetUp(hit, die);

        actNo = (int)ActNo.App;

        dieFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        hitmng.HitUpdate();
        if (dieFlg)
        {
            anim.Play("01_TRBoss_stay");
            return;
        }
        // 関数配列を用いた関数の呼び出し
        actFuncTbl[actNo]();
        
        hitmng.PostUpdate();
    }

    void ActApp()
    {
        switch (methodNo)
        {
            case 0:
                anim.Play("08_TRBoss_appearance");
                hitmng.DEFActive = false;
                hitmng.ATKActive = false;
                methodNo++;
                break;
            case 1:
                AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animInfo.normalizedTime > 0.8f)
                {
                    anim.Play("01_TRBoss_stay");
                }
                break;
        }
    }

    void ActWait()
    {
        switch (methodNo)
        {
            case 0:
                AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animInfo.normalizedTime > 1.0f)
                {
                    anim.Play("01_TRBoss_stay");
                    hitmng.DEFActive = true;
                    hitmng.ATKActive = true;
                    methodNo++;
                }
                break;
            case 1:
                if (AttackType)
                {
                    methodNo = 0;
                    actNo = (int)ActNo.LodAttack;
                }
                else
                {
                    methodNo = 0;
                    actNo = (int)ActNo.ShockWave;
                }
                break;
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
                    Instantiate(slashEffect,new Vector3( transform.position.x, transform.position.y+1,transform.position.z), Quaternion.Euler(0, 0, 120));
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
                    AttackType = false;
                    actNo = (int)ActNo.Wait;
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
                    wavePos.y -= 3f;
                    wavePos.x -= 2.5f;


                    methodNo++;
                }
                break;
            case 1:

                break;
            case 2:
                waveTime += 0.017f;
                if (waveTime >= Genetime)
                {
                    WaveCreate();
                    waveTime = 0;
                }
                if (wavePos.x <= -20)
                {
                    AttackType = true;
                    actNo = (int)ActNo.Wait;
                    methodNo = 0;
                }

                break;
        }
    }

    void hit()
    {

    }

    void die()
    {
        dieFlg = true;
    }

    void WaveCreate()
    {
        Instantiate(waveObj, wavePos, Quaternion.identity);
        wavePos -= new Vector3(0.2f, 0, 0);
    }

    void WaveStart()
    {
        Instantiate(shockEffect, wavePos, Quaternion.Euler(-90, 0, 0));
        methodNo++;
    }
}
