using System.Collections;
using UnityEngine;
using SY;

public class Slime : EnemyBase
{
    SpriteRenderer sr;
    Vector3 diffScale;
    GameObject shoggoth;
    GameObject root;
    Color defColor;

    [SerializeField, ReadOnly] Shoggoth_SlimeType State = Shoggoth_SlimeType.None;
    [SerializeField, Tooltip("親オブジェクト名")] new string name = "Shoggoth";
    [SerializeField, Tooltip("死亡時与ダメージ")] float dieDmg = 1.0f;
    [SerializeField, Tooltip("ダメージ")] Damage dmgData;
    [SerializeField, Tooltip("ダメージエフェクト")] ParticleSetting dmgEffect;
    [SerializeField, Tooltip("ダメージサウンド")] AudioSetting dmgSE;
    [SerializeField, Tooltip("死亡時エフェクト")] ParticleSetting dieEffect;
    [SerializeField, Tooltip("死亡時サウンド")] AudioSetting dieSE;

    public GameObject Root { get { return root; } set { root = value; } }

    Vector3 TFPos(GameObject obj) { return obj.transform.position; }
    Quaternion TFRot(GameObject obj) { return obj.transform.rotation; }
    Vector3 TFScl(GameObject obj) { return obj.transform.localScale; }

    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        if (State == Shoggoth_SlimeType.Death) { Dead(); return; }

        hm.HitUpdate();

        transform.position = TFPos(root);
        transform.rotation = TFRot(root);
        diffScale = TFScl(obj) - TFScl(root);
        transform.localScale = TFScl(root) + diffScale;

        hm.PostUpdate();
    }

    public override void SetUp()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();

        obj = this.gameObject;
        pos = TFPos(obj);
        scale = TFScl(obj);

        shoggoth = GameObject.Find(name).gameObject;

        defColor = sr.color;

        hm.SetUp(Damage, Die);
    }

    public void Damage()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        int damage_Repeat = 0;  //繰り返し回数

        while (damage_Repeat < dmgData.Time)
        {
            //色変更
            sr.color = dmgData.Color;
            //待つ
            yield return new WaitForSeconds(dmgData.Interval);
            //色戻す
            sr.color = defColor;
            //待つ
            yield return new WaitForSeconds(dmgData.Interval);
            damage_Repeat++;    //繰り返し回数加算
        }
    }

    public override void Die()
    {
        State = Shoggoth_SlimeType.Death;
        dieSE.PlayAudio(se);
        dieEffect.PlayParticle();

        Shoggoth shoggothCS = shoggoth.GetComponent<Shoggoth>();
        HitMng shoggothHM = shoggoth.GetComponent<HitMng>();
        shoggothCS.SlimeObj.Remove(obj);
        shoggothHM.HP -= dieDmg;
        if (shoggothHM.HP <= 0) { shoggothHM.Result.SetDefFlag(HitResult.DefFlag.DefDeath); }
    }

    public void Dead()
    {
        if (dieEffect.Particle == null) { Destroy(obj); return; }
        dieEffect.StopParticle();
        if (dieEffect.IsValid == false) { return; }
        Destroy(obj);
    }
}

#if false
public class Slime : MonoBehaviour
{
    HitMng HMng;
    HitMng PlHMng;
    SpriteRenderer render;
    Rigidbody2D rb;
    Animator anim;
    AudioSource se;
    GameObject shoggothObj;
    Shoggoth shoggoth;
    GroundCheck GC;
    Circle circle = new Circle();

    public enum MoveType
    {
        First,  //初期行動
        Walk,   //基本
        Die,    //死亡
    }
    MoveType moveType;

    public enum WalkType
    {
        Crawl,
        Bound,
    }
    public WalkType walkType;

    enum MoveFlag
    {
        None = 0,
        Right = 1,
        Left = -1,
    }
    int moveFlag;
    int SlopeFlag;  //0 or 1
    int WallFlag;   //0 or 1

    int firstMove;

    int phase = 0;
    float timer = 0;

    Vector2 pos;    //transform.position
    Vector2 vel;    //rb.velocity
    Vector2 plPos;
    Vector2 startPos;
    Vector2 radPos;
    Vector2 dir;
    int idir;
    Vector2 r;  //半径
    Vector2 o;  //中心

    [SerializeField, Tooltip("速度")] float speed = 2;
    [SerializeField, Tooltip("ノックバック速度")] float knockBackSpd;
    [SerializeField, Tooltip("消去時間")] float dieTime;
    [SerializeField, Tooltip("死時ショゴスダメージ")] float dieDamage;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip Move_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float Move_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float Move_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool Move_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip damage_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float damage_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float damage_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool damage_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip die_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float die_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float die_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool die_SELoop;

    //[SerializeField] string animName;
    //[SerializeField] bool debug;

    // Start is called before the first frame update
    void Start()
    {
        HMng = GetComponent<HitMng>();
        PlHMng = GameObject.Find("Player").GetComponent<HitMng>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        se = GetComponent<AudioSource>();
        startPos = transform.position;
        GC = GetComponent<GroundCheck>();
        pos =　rb.position;
        moveType = MoveType.Walk;

        HMng.SetUp(Damage, Die);

        shoggothObj = GameObject.Find("Shoggoth_2.0");
        shoggoth = shoggothObj.GetComponent<Shoggoth>();
        moveType = MoveType.First;
        firstMove = (int)shoggoth.MoveType;
    }

    //Update is called once per frame
    void Update()
    {
        if (moveType == MoveType.Die) { Destroy(gameObject, dieTime); return; }

        HMng.HitUpdate();

        pos = rb.position;
        plPos = shoggoth.Player.transform.position;

        GroundFlagMng();

        switch (moveType)
        {
            case MoveType.First:    //生成初期行動
                switch (firstMove)
                {
                    case (int)Shoggoth_MoveType.Rotation:
                        if (GC.CheckFlag(GroundCheck.Flag.Ground)) { moveType = MoveType.Walk; }
                        break;
                    case (int)Shoggoth_MoveType.UpDown:
                        Parabola();
                        rb.position = pos;
                        break;
                    default:
                        if (GC.CheckFlag(GroundCheck.Flag.Ground)) { moveType = MoveType.Walk; }
                        break;
                }
                break;

            case MoveType.Walk:
                switch(walkType)
                {
                    case WalkType.Crawl:
                        Crawl();    //這いながら移動
                        break;
                    case WalkType.Bound:
                        Bound();    //跳ねながら移動
                        break;
                }
                break;
        }

        rb.position = pos;
        //Debug.Log(moveFlag + " : " + SlopeFlag + " : " + WallFlag);
        //Debug.Log(GC.GCFlag());
        HMng.PostUpdate();
    }

    //距離
    Vector2 Distance(Vector2 currentPos, Vector2 targetPos)
    {
        Vector2 distance = targetPos - currentPos;
        return distance;
    }

    void Crawl()
    {
        switch (phase)
        {
            case 0:
                if (!GC.CheckFlag(GroundCheck.Flag.Ground)) { return; }
                timer += Time.deltaTime;
                if (2.0f < timer) { rb.velocity = Vector2.zero; phase++; }
                break;
            case 1:
                Debug.Log(moveFlag + "：" + WallFlag);
                rb.AddForce(speed * new Vector2(moveFlag, SlopeFlag) * ((WallFlag) == 1 ? 0 : 1), ForceMode2D.Impulse);
                SetAudio(Move_SE, Move_SEVolume, Move_SEPitch, Move_SELoop);
                GeneralClear();
                break;
        }
    }

    void Bound()
    {
        switch(phase)
        {
            case 0:
                if (!GC.CheckFlag(GroundCheck.Flag.Ground)) { return; }
                SetAudio(Move_SE, Move_SEVolume, Move_SEPitch, Move_SELoop);
                timer += Time.deltaTime;
                if (2.3f < timer) { phase++; }
                break;
            case 1:
                rb.AddForce(speed * new Vector2(moveFlag, 1.0f + (speed * 0.5f * SlopeFlag)).normalized, ForceMode2D.Impulse);
                anim.Play("Slime01_Idle", 0, 0);
                GeneralClear();
                break;
        }
    }

    void GroundFlagMng()
    {
        if (moveType == MoveType.Die) { return; }

        MoveDir();
        if (!GC.CheckFlag(GroundCheck.Flag.Ground))
        {
            transform.localScale = Vector3.one;
            anim.enabled = false;
            moveFlag = (int)MoveFlag.None;
            SlopeFlag = 0; WallFlag = 0; return;
        }
        if (GC.CheckFlag(GroundCheck.Flag.Slope_Left) ||
        GC.CheckFlag(GroundCheck.Flag.Slope_Right)) { SlopeFlag = 1; }
        else { SlopeFlag = 0; }
        if (GC.CheckFlag(GroundCheck.Flag.Wall_Left) ||
            GC.CheckFlag(GroundCheck.Flag.Wall_Right)) { WallFlag = 1; }
        else { WallFlag = 0; }
        anim.enabled = true;
    }

    void MoveDir()
    {
        if (plPos.x - pos.x < 0)
        {
            moveFlag = -1;
            GroundFlagActivator(1, true); GroundFlagActivator(3, true);
            GroundFlagActivator(2, false); GroundFlagActivator(4, false);
        }
        else if (plPos.x - pos.x > 0)
        {
            moveFlag = 1;
            GroundFlagActivator(2, true); GroundFlagActivator(4, true);
            GroundFlagActivator(1, false); GroundFlagActivator(3, false);
        }
    }

    void GroundFlagActivator(int rayNo, bool isActive)
    {
        GC.Ray[rayNo].IsActive = isActive;
    }

    void Damage()
    {
        Debug.Log("dm");
        SetAudio(damage_SE, damage_SEVolume, damage_SEPitch, damage_SELoop);
        rb.velocity = Vector2.zero;
        rb.AddForce(knockBackSpd * (moveFlag * -1) * Vector2.right, ForceMode2D.Impulse);
    }

    void Die()
    {
        anim.enabled = true;
        Constraints(RigidbodyConstraints2D.FreezeAll);
        SetAudio(die_SE, die_SEVolume, die_SEPitch, die_SELoop);
        anim.Play("Slime01_Die");
        shoggothObj.GetComponent<HitMng>().HP -= dieDamage * PlHMng.ATK;
        shoggoth.Damage();
        moveType = MoveType.Die;

        Debug.Log("スライム死んだ");
    }

    //----------初期行動----------
    //飛び散る
    void Parabola()
    {
        switch(phase)
        {
            case 0:
                anim.enabled = false;   //アニメーター無効化
                rb.gravityScale = 0;
                int ran = (Random.value < 0.5f) ? -1 : 1;   //発射方向
                idir = (ran == 1) ? -1 : 1;
                r.x = (Random.value * 4) / 2;
                r.y = (Random.value * 6) / 2;
                o.x = pos.x + (r.x * ran);
                o.y = pos.y;
                circle.Data(o.x, o.y,
                    r.x, r.y,
                    1.0f, 1.0f,
                    idir, (ran == 1) ? 1 : 0);
                phase++;
                break;
            case 1:
                timer += Time.deltaTime;
                pos = circle.Move(timer, 4.0f);  //スピードは仮
                if (pos.y < startPos.y) { phase++; }
                break;
            case 2:
                GeneralClear();
                anim.enabled = true;   //アニメーター有効化
                rb.gravityScale = 1;
                moveType = MoveType.Walk;
                //Destroy(gameObject);
                break;
        }
    }

    //----------その他----------
    //汎用変数初期化
    void GeneralClear()
    {
        //汎用
        phase = 0;
        timer = 0;
        //repeat = 0;
        //No = 0;

        //円
        circle.DataClear();
    }

    //
    RigidbodyConstraints2D Constraints(RigidbodyConstraints2D set)
    {
        rb.constraints |= set;
        return rb.constraints;
    }

    //サウンド
    void SetAudio(AudioClip audio, float Volume, float Pitch, bool isLoop)
    {
        se.clip = audio;
        se.volume = Volume;
        se.pitch = Pitch;
        se.loop = isLoop;
        se.Play();
    }
}
#endif