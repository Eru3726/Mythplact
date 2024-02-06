//ボス3 : 麒麟

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qilin : QilinBase
{
    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        ReNew();
    }

    private void OnDrawGizmos()
    {
        if (Param.Body_Gizmo.Display)
        {
            bc = GetComponent<BoxCollider2D>();
            Param.Body_Gizmo.Draw(bc.bounds.center, bc.bounds.max - bc.bounds.min);
        }
        if (Param.Rush_Gizmo.Display) { Param.Rush_Gizmo.Draw(Param.Rush_Center, Param.Rush_AtkRange); }
        if (Param.Eruption_Gizmo.Display) { Param.Eruption_Gizmo.Draw(Param.Eruption_Center, Param.Eruption_AtkRange); }
        if (Param.Spin_Gizmo.Display) { Param.Spin_Gizmo.Draw(Param.Spin_Center, Param.Spin_AtkRange); }
        if (Param.Meteor_Gizmo.Display) { Param.Meteor_Gizmo.Draw(Param.Meteor_Center, Param.Meteor_AtkRange); }

        if (Param.Stage_Gizmo.Display) { Param.Stage_Gizmo.Draw(Param.Stage.Center, Param.Stage.Range); }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;
using Live2D.Cubism.Rendering;

public enum Qilin_MoveType
{
    Entry,      //登場
    Idle = 1,   //仮
    Breath,     //ブレス
    Eruption,   //炎柱
    PushUp,     //突き上げ
    Rush,       //突進
    Spin,       //炎渦
    Meteor,     //隕石
    Die,        //死
}

public class Qilin : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    AudioSource se;
    CubismRenderController renderController;
    HitMng hm;      //当たり判定
    GroundCheck gc; //接地判定

    //
    GameObject obj; //自身
    Color defColor;
    [SerializeField, Tooltip("プレーヤー")] GameObject pl;

    //
    int phase = 0;      //汎用行動番号
    float timer = 0;    //汎用タイマー
    int repeat = 0;     //汎用繰り返し回数
    int no = 0;         //汎用ナンバ

    int tableNo = 0;    //テーブル指定
    int moveNo = 0;     //行動指定

    //
    Vector2 pos;        //座標
    Vector3 defScale;   //拡縮率保存
    Vector3 scale;      //拡縮率更新
    float dir;          //左右方向
    int plDir;          //プレイヤー位置方向(-1or0or1)
    float gPos;         //地面位置
    float gravity;      //重力強度保存

    Vector2 plPos;      //プレーヤー座標

    [SerializeField, Tooltip("行動")] Qilin_MoveType moveType = Qilin_MoveType.Idle;
    [SerializeField, Tooltip("行動テーブル")] Qilin_MoveTable[] moveTable;  //各テーブルの最初の行動はIdleにする必要がある
    bool isHalfHP = false;

    [Header("登場")]
    [SerializeField, Tooltip("初期位置")] Vector2 entry_StartPos = Vector2.zero;
    [SerializeField, Tooltip("寝時間")] float entry_SleepTime = 1.0f;
    [SerializeField, Tooltip("待機時間")] float entry_BreakTime = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting entry_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting entry_SE;

    [Header("本体")]
    [SerializeField, Tooltip("接触攻撃判定")] GameObject body;
    [SerializeField, Tooltip("接触威力")] float body_Power = 1.0f;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting body_Gizmo;
    GameObject def;
    Vector2 body_Center;
    Vector2 body_Range;

    [Header("待機")]
    [SerializeField, Tooltip("待機時間")] float idle_BreakTime = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting idle_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting idle_SE;
    [SerializeField, Tooltip("攻撃前隙")] float attackAnticipation_Time = 1.0f;
    [SerializeField, Tooltip("攻撃前エフェクト")] ParticleSetting attackAnticipation_Effect;
    [SerializeField, Tooltip("攻撃前サウンド")] AudioSetting attackAnticipation_SE;

    [Header("移動")]
    [SerializeField, Tooltip("速度")] float move_Speed = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting move_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting move_SE;

    [Header("ブレス")]
    [SerializeField, Tooltip("ブレス")] GameObject breath;
    [SerializeField, Tooltip("威力")] float breath_Power = 1.0f;
    [SerializeField, Tooltip("攻撃距離")] float breath_AtkDis = 5.0f;
    [SerializeField, Tooltip("クールタイム")] float breath_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting breath_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting breath_SE;

    [Header("炎柱")]
    [SerializeField, Tooltip("炎柱")] GameObject eruption;
    [SerializeField, Tooltip("威力")] float eruption_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 eruption_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 eruption_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("攻撃間隙")] float eruption_AtkBreakTime = 1.0f;
    [SerializeField, Tooltip("生成数")] int eruption_Generate = 10;
    [SerializeField, Tooltip("クールタイム")] float eruption_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting eruption_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting eruption_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting eruption_Gizmo;
    float eruption_Space;           //炎柱間距離
    Vector2 eruption_Generatev2;    //生成数   Vector2(Left, Right)
    GameObject eruption_Last;

    [Header("突き上げ")]
    [SerializeField, Tooltip("突き上げ")] GameObject pushUp;
    [SerializeField, Tooltip("威力")] float pushUp_Power = 1.0f;
    [SerializeField, Tooltip("移動速度")] float pushUp_MoveSpd = 10.0f;
    [SerializeField, Tooltip("攻撃距離")] float pushUp_AtkDis = 5.0f;
    [SerializeField, Tooltip("クールタイム")] float pushUp_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting pushUp_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting pushUp_SE;

    [Header("突進")]
    [SerializeField, Tooltip("突き上げ")] GameObject rush;
    [SerializeField, Tooltip("威力")] float rush_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 rush_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 rush_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("移動速度")] float rush_MoveSpd = 10.0f;
    [SerializeField, Tooltip("回数")] int rush_AtkTime = 4;
    [SerializeField, Tooltip("攻撃間隙")] float rush_AtkBreakTime = 1.0f;
    [SerializeField, Tooltip("クールタイム")] float rush_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting rush_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting rush_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting rush_Gizmo;

    [Header("炎渦")]
    [SerializeField, Tooltip("炎渦")] GameObject spin;
    [SerializeField, Tooltip("威力")] float spin_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 spin_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 spin_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("クールタイム")] float spin_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting spin_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting spin_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting spin_Gizmo;
    GameObject spin_Last;

    [Header("隕石")]
    [SerializeField, Tooltip("隕石")] GameObject meteor;
    [SerializeField, Tooltip("威力")] float meteor_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 meteor_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("攻撃範囲")] Vector2 meteor_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("攻撃時間")] float meteor_AtkTime = 5.0f;
    [SerializeField, Tooltip("生成数")] float meteor_Generate = 10.0f;
    [SerializeField, Tooltip("クールタイム")] float meteor_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting meteor_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting meteor_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting meteor_Gizmo;
    GameObject meteor_Last;

    [Header("被ダメージ")]
    [SerializeField, Tooltip("色")] Color damage_Color = Color.white;
    [SerializeField, Tooltip("点滅回数")] int damage_Number = 10;
    [SerializeField, Tooltip("時間")] float damage_Time = 0.05f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting damage_SE;
    //float damage_Repeat = 0;

    [Header("死")]
    [SerializeField, Tooltip("エフェクト")] ParticleSetting die_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting die_SE;

    [Header("画面情報")]
    [SerializeField, Tooltip("ステージ中心座標")] Vector2 stage_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("ステージ範囲")] Vector2 stage_Range = new Vector2(20.0f, 10.0f);
    [SerializeField, Tooltip("ギズモ")] GizmoSetting stage_Gizmo;
    Vector2 stage_LeftTop;      //ステージ左上
    Vector2 stage_RightDown;    //ステージ右下
    GameObject ui;

    [Header("アニメーション")]
    [SerializeField] bool isLock;
    Anim anim;

    public GameObject Player { get { return pl; } }
    public int PlDir { get { return plDir; } }
    public Qilin_MoveType MoveType { get { return moveType; } }
    public bool IsHalfHP { get { return isHalfHP; } set { isHalfHP = value; } }
    public Vector2 Spin_Center { get { return spin_Center; } }
    public Vector2 Spin_AtkRange { get { return spin_AtkRange; } }
    public float Spin_Power { get { return spin_Power; } }
    public float Eruption_Power { get { return eruption_Power; } }
    public Vector2 Meteor_Center { get { return meteor_Center; } }
    public Vector2 Meteor_AtkRange { get { return meteor_AtkRange; } }
    public float Meteor_Power { get { return meteor_Power; } }

    private readonly AchvMeasurement achv = new AchvMeasurement();

    // Start is called before the first frame update
    void Start()
    {
        //定義
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        se = GetComponent<AudioSource>();
        anim = GetComponent<Anim>();
        renderController = GetComponent<CubismRenderController>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        obj = this.gameObject;
        //def = GameObject.Find("def").gameObject;
        pos = entry_StartPos;
        plPos = pl.transform.position;
        defScale = transform.localScale;
        scale = defScale;
        defColor = renderController.ModelScreenColor;
        gravity = rb.gravityScale;
        ui = GameObject.Find("UI").gameObject;
        ui.SetActive(false);

        //行動
        moveType = Qilin_MoveType.Entry;
        AllVariableClear();

        //体範囲
        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        //攻撃判定関連
        AllHitActive(false);
        SetPower(body, body_Power);
        SetPower(breath, breath_Power);
        SetPower(pushUp, pushUp_Power);
        SetPower(rush, rush_Power);

        isHalfHP = false;
        hm.SetUp(Damage, Die);
        hm.IsHalfHP = false;
        //CameraData();
        StageData();

        gPos = GroundPosition(stage_Center.x);
        renderController.OverwriteFlagForModelScreenColors = true;

        rb.position = pos;
        Direction();

        //pl.GetComponent<Player>().IsFleet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveType == Qilin_MoveType.Die) 
        {
            die_Effect.StopCheck();
            if (0.5f <= anim.NormalizedTime) { renderController.Opacity = 0; }
            if (!die_Effect.IsValid)
            {
                GameData.QilinDead = true;
            }
            return; 
        }
        hm.HitUpdate();

        pos = rb.position;
        plPos = pl.transform.position;

        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        switch (moveType)
        {
            case Qilin_MoveType.Entry:
                Entry();
                break;

            case Qilin_MoveType.Idle:
                Idle();
                break;

            case Qilin_MoveType.Breath:
                Breath();
                break;

            case Qilin_MoveType.Eruption:
                Eruption();
                break;

            case Qilin_MoveType.Rush:
                Rush();
                break;

            case Qilin_MoveType.PushUp:
                PushUp();
                break;

            case Qilin_MoveType.Spin:
                Spin();
                break;

            case Qilin_MoveType.Meteor:
                Meteor();
                break;
        }
        //Debug.Log(phase);
        //Debug.Log(no);
        //Debug.Log(repeat);
        //Debug.Log(moveTable[tableNo].Name + " : " + moveNo);
        //Debug.Log("no " + no + " phase " + phase);
        //Debug.Log(CheckGroundFlag(GroundCheck.Flag.Ground));
        //Debug.Log(gc.GroundFlag());

        rb.position = pos;

        //if (moveType == Qilin_MoveType.Idle || moveType == Qilin_MoveType.Breath ||
        //    moveType == Qilin_MoveType.Eruption || moveType == Qilin_MoveType.PushUp)
        {
            Direction();
        }
        //Debug.Log(plDir);

        Anim_Basis();
        hm.PostUpdate();
    }

    //----------アクション----------
    void Entry()
    {
        switch(phase)
        {
            case 0:
                anim.AnimChage("Entry_SleepAir", isLock);
                //def.SetActive(false);
                phase++;
                break;
            case 1:
                timer += Time.deltaTime;
                if (timer < entry_SleepTime) { break; }
                anim.AnimChage("Entry_SleepEnd", isLock);
                timer = 0;
                phase++;
                break;
            case 2:
                if (!AnimEndChange("Entry_FireLessIdle")) { break; }
                phase++;
                break;
            case 3:
                timer += Time.deltaTime;
                if (timer < entry_BreakTime) { break; }
                anim.AnimChage("Entry_End", isLock);
                phase++;
                break;
            case 4:
                if (anim.NormalizedTime < 1.0f) { break; }
                moveType = Qilin_MoveType.Idle;
                tableNo = Random.Range(0, moveTable.Length);
                moveNo = 0;
                //def.SetActive(true);
                ui.SetActive(true);
                AllVariableClear();
                break;
        }
    }
    bool AnimEndChange(string nextAnim) //アニメーション終了時遷移
    {
        if (anim.NormalizedTime < 1.0f) { return false; }
        anim.AnimChage(nextAnim, isLock);
        return true;
    }

    void Idle()
    {
        switch (phase)
        {
            case 0:
                timer += Time.deltaTime;
                if(timer < idle_BreakTime) { break; }
                phase++;
                break;
            case 1:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void Breath()
    {
        switch(phase)
        {
            case 0: //重力0、速度代入
                Direction();
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * plDir * move_Speed;
                phase++;
                break;
            case 1: //移動→重力復元、停止
                if (breath_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.gravityScale = gravity;
                rb.velocity = Vector2.zero;
                Direction();
                phase++;
                break;
            case 2: //攻撃前隙→ブレス調整、ブレスアニメ実行
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                Vector3 bScale = breath_Effect.Particle.gameObject.transform.localScale;
                switch (plDir)
                {
                    case -1:
                        bScale.x = 1.0f;
                        break;
                    case 0:
                    case 1:
                        bScale.x = -1.0f;
                        break;
                }
                anim.AnimChage("Breath", isLock);
                breath_Effect.Particle.gameObject.transform.localScale = bScale;
                timer = 0;
                phase++;
                break;
            case 3: //アニメ3割→ブレスパーティクル実行
                if (anim.NormalizedTime < 0.3f) { break; }
                breath_Effect.Particle.gameObject.SetActive(true);
                //breath.SetActive(true);
                breath_Effect.PlayParticle();
                phase++;
                break;
            case 4: //パーティクル終了
                breath_Effect.StopCheck();
                if (breath_Effect.IsValid) { break; }
                breath.SetActive(false);
                breath_Effect.Particle.gameObject.SetActive(false);
                phase++;
                break;
            case 5: //クールタイム
                timer += Time.deltaTime;
                if (timer < breath_CoolTime) { break; }
                phase++;
                break;
            case 6:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void Eruption()
    {
        Debug.Log(phase);

        switch (phase)
        {
            case 0: //前隙
                timer += Time.deltaTime;
                if(timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 1:
                float Range = eruption_AtkRange.x - body_Range.x;   //炎柱生成可能幅

                Vector2 eruption_Range = Vector2.zero;
                eruption_Range.x =  //左距離
                    ((body_Center.x) - (body_Range.x * 0.5f)) - 
                    (eruption_Center.x - (eruption_AtkRange.x * 0.5f));
                eruption_Range.y =  //右距離
                    (eruption_Center.x + (eruption_AtkRange.x * 0.5f)) - 
                    ((body_Center.x) + (body_Range.x * 0.5f));

                //比　炎柱生成可能幅：左距離：右距離 = 1：x：y
                Vector2 eruption_Ratio = Vector2.zero;
                eruption_Ratio.x = eruption_Range.x / Range;
                eruption_Ratio.y = eruption_Range.y / Range;
                if (eruption_Ratio.x < 0) { eruption_Ratio = Vector2.up; }
                else if (eruption_Ratio.y < 0) { eruption_Ratio = Vector2.right; }

                Vector2 empty = new Vector2 //比から左右の炎柱生成数定義(小数点あり)
                    (eruption_Generate * eruption_Ratio.x, eruption_Generate * eruption_Ratio.y);
                //炎柱生成数を整数に
                eruption_Generatev2.x = Mathf.Round(empty.x);
                eruption_Generatev2.y = Mathf.Round(empty.y);

                //炎柱間距離定義
                eruption_Space = Range / (eruption_Generate + 1);

                //アニメーション再生
                anim.AnimChage("Pillar", isLock);
                phase++;
                break;
            case 2: //炎柱生成
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                Vector2 genPos = Vector2.zero;
                if (repeat < eruption_Generatev2.x)
                { 
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) - 
                        (eruption_Space * (repeat + 1)), 
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                repeat++;
                phase++;
                break;
            case 3: //攻撃間隙
                timer += Time.deltaTime;
                if (timer < eruption_AtkBreakTime) { break; }
                timer = 0;
                if (eruption_Generate != no) { phase--; }   //戻る
                else { phase = 5; }   //進む
                break;
            //case 4:
            //    if (repeat < eruption_Generatev2.x)
            //    {
            //        genPos = new Vector2(
            //            (body_Center.x - (body_Range.x * 0.5f)) -
            //            (eruption_Space * (repeat + 1)),
            //            gPos);
            //        eruption_Last =
            //            Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
            //    }
            //    if (repeat < eruption_Generatev2.y)
            //    {
            //        genPos = new Vector2(
            //            (body_Center.x + (body_Range.x * 0.5f)) +
            //            (eruption_Space * (repeat + 1)),
            //            gPos);
            //        eruption_Last =
            //            Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
            //    }
            //    phase++;
            //    break;
            case 5:
                if (eruption_Last != null) { break; }
                phase++;
                break;
            case 6:
                timer += Time.deltaTime;
                if (timer < eruption_CoolTime) { break; }
                timer = 0;
                phase++;
                break;
            case 7:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void PushUp()
    {
        switch (phase)
        {
            case 0: //重力0、速度代入、体当たり判定付、突進パーティクル実行
                Direction();
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * PlDir * pushUp_MoveSpd;
                body.SetActive(true);
                pushUp_Effect.Particle.gameObject.SetActive(true);
                pushUp_Effect.PlayParticle();
                Direction();
                phase++;
                break;
            case 1: //移動→停止、体当たり判定外、突進パーティクル設定変更
                if (pushUp_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.velocity = Vector2.zero;
                body.SetActive(false);
                var main = pushUp_Effect.Particle.main;
                main.loop = false;
                rb.gravityScale = gravity;
                Direction();
                phase = 3;
                break;
            //case 2: //パーティクル終了
            //    pushUp_Effect.StopCheck();
            //    if (pushUp_Effect.IsValid) { break; }
            //    pushUp_Effect.Particle.gameObject.SetActive(false);
            //    timer = 0;
            //    phase++;
            //    break;
            case 3: //攻撃前隙
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 4: //突き上げアニメ実行
                anim.AnimChage("PushUp", isLock);
                //pushUp.SetActive(true);
                phase++;
                break;
            case 5: //クールタイム
                if(anim.Action != AnimSetting.Type.Idle) { break; }
                //pushUp.SetActive(false);
                timer += Time.deltaTime;
                if (timer < pushUp_CoolTime) { break; }
                phase++;
                break;
            case 6:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void Rush()
    {
        switch (phase)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                Direction();
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * PlDir * rush_MoveSpd;
                rush.SetActive(true);
                rush_Effect.Particle.gameObject.SetActive(true);
                rush_Effect.PlayParticle();
                repeat++;
                timer = 0;
                phase++;
                break;
            case 1:
                if (pos.x < (rush_Center.x + rush_AtkRange.x * 0.5f) + 3.0f &&
                        (rush_Center.x - rush_AtkRange.x * 0.5f) - 3.0f < pos.x) { break; }
                rush.SetActive(false);
                var main = rush_Effect.Particle.main;
                main.loop = false;
                rb.velocity = Vector2.zero;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 2:
                timer += Time.deltaTime;
                if (timer < rush_AtkBreakTime) { break; }
                Direction();
                timer = 0;
                if (repeat == rush_AtkTime) { phase++; }
                else 
                {
                    rb.velocity = Vector2.right * PlDir * rush_MoveSpd;
                    repeat++;
                    rush.SetActive(true);
                    rush_Effect.Particle.gameObject.SetActive(true);
                    rush_Effect.PlayParticle();
                    phase--; 
                }
                break;
            case 3:
                timer += Time.deltaTime;
                if (timer < rush_CoolTime) { break; }
                phase++;
                break;
            case 4:
                moveType = Qilin_MoveType.PushUp;
                AllVariableClear();
                break;
            default:    //行動遷移時汎用変数初期化
                AllVariableClear();
                break;
        }
    }

    void Spin()
    {
        switch (phase)
        {
            case 0:
                rb.gravityScale = 0;
                Vector2 vec = new Vector2(stage_Center.x, gPos) - pos;
                scale.x = defScale.x * ((vec.x <= 0) ? -1 : 1);
                transform.localScale = scale;
                rb.velocity = vec.normalized * move_Speed;
                phase++;
                break;
            case 1:
                if (pos.x < stage_Center.x - 2.5f || stage_Center.x + 2.5f < pos.x) { return; }
                rb.velocity = Vector2.zero;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 2://前隙
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                Direction();
                timer = 0;
                phase++;
                break;
            case 3:
                anim.AnimChage("Pillar", isLock);
                phase++;
                break;
            case 4:
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                Vector2 spin1Pos = new Vector2(stage_LeftTop.x, gPos);
                Vector2 spin2Pos = new Vector2(stage_RightDown.x, gPos);
                //Instantiate(spin, spin1Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                //spin_Last =
                //    Instantiate(spin, spin2Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                phase++;
                break;
            //case 5:
            //    if (spin_Last != null) { break; }
            //    phase++;
            //    break;
            case 5:
                timer += Time.deltaTime;
                if (timer < spin_CoolTime) { break; }
                timer = 0;
                phase++;
                break;
            case 6:
                //MoveEnd();
                moveType = Qilin_MoveType.Meteor;
                AllVariableClear();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void Meteor()
    {
        switch (phase)
        {
            case 0:
                rb.gravityScale = 0;
                Vector2 vec = Vector2.zero;
                switch (plDir)
                {
                    case -1:
                        vec = new Vector2(stage_LeftTop.x, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y)) - pos;
                        break;
                    case 0:
                    case 1:
                        vec = new Vector2(stage_RightDown.x, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y)) - pos;
                        break;
                }
                rb.velocity = vec.normalized * move_Speed;
                phase++;
                break;
            case 1:
                switch(plDir)
                {
                    case -1:
                        if (pos.x < stage_LeftTop.x - 7.5f) { rb.velocity = Vector2.zero; phase++; }
                        break;
                    case 0:
                    case 1:
                        if (stage_RightDown.x + 7.5f < pos.x) { rb.velocity = Vector2.zero; phase++; }
                        break;
                }
                break;
            case 2:
                timer += Time.deltaTime;
                if(timer < attackAnticipation_Time) { break; }
                switch (plDir)
                {
                    case -1:
                        pos = new Vector2(stage_RightDown.x + 10.0f, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
                        break;
                    case 0:
                    case 1:
                        pos = new Vector2(stage_LeftTop.x - 10.0f, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
                        break;
                }
                timer = meteor_AtkTime / meteor_Generate;
                phase++;
                break;
            case 3:
                timer += Time.deltaTime;
                if (timer < meteor_AtkTime / meteor_Generate) { break; }
                Instantiate(meteor, new Vector2(50.0f, 0.0f), Quaternion.identity);
                repeat++;
                timer = 0;
                if (meteor_Generate - 1 != repeat) { break; }
                meteor_Last = Instantiate(meteor, new Vector2(50.0f, 0.0f), Quaternion.identity);
                timer = 0;
                repeat = 0;
                phase++;
                break;
            case 4:
                if (meteor_Last != null) { break; }
                phase++;
                break;
            case 5:
                vec = new Vector2(stage_Center.x, gPos) - 
                    new Vector2(pos.x, pos.y - Mathf.Abs(gc.Ray[0].Offset.y));
                rb.velocity = vec.normalized * move_Speed;
                phase++;
                break;
            case 6:
                Debug.Log(CheckGroundFlag(GroundCheck.Flag.Ground));
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                rb.gravityScale = gravity;
                rb.velocity = new Vector2(0, rb.velocity.y);
                phase++;
                break;
            case 7:
                timer += Time.deltaTime;
                if (timer < meteor_CoolTime) { break; }
                phase++;
                break;
            case 8:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void MoveEnd()  //行動終了時処理
    {
        Debug.Log("行動終了");
        if (!isHalfHP)
        {
            moveNo++;
            if (moveNo == moveTable[tableNo].Move.Length)
            {
                tableNo = Random.Range(0, moveTable.Length);
                moveNo = 0;
            }
            moveType = moveTable[tableNo].Move[moveNo];
        }
        else { moveType = Qilin_MoveType.Spin; isHalfHP = false; }
        AllVariableClear();
    }

    void Direction()    //向き(プレーヤーの方向)
    {
        if (0 < plPos.x - pos.x) { plDir = 1; }         //右
        else if (plPos.x - pos.x < 0) { plDir = -1; }   //左
        else { plDir = 0; }                             //同一

        switch (plDir)
        {
            case -1:
                scale.x = -defScale.x;
                break;
            case 0:
            case 1:
                scale.x = defScale.x;
                break;
        }
        transform.localScale = scale;
    }

    void Damage()   //被ダメージ
    {
        Debug.Log(obj.name + "はダメージを受けた");
        damage_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
        StartCoroutine("Flash");
        if ((hm.HP == hm.MaxHP * 0.5f) && !hm.IsHalfHP) { isHalfHP = true; }
    }

    void Die()      //死亡
    {
        Debug.Log(obj.name + "は死んだ");
        rb.velocity = Vector2.zero;
        AllHitActive(false);
        achv.DefeatedBoss(2);
        moveType = Qilin_MoveType.Die;
        anim.AnimChage("Dead", isLock);
        die_Effect.Particle.gameObject.SetActive(true);
        die_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
    }

    //----------アニメーション----------
    void Anim_Basis()
    {
        //Debug.Log(rb.velocity.magnitude);
        if(0.2f < rb.velocity.magnitude)
        {
            Debug.Log(CheckGroundFlag(GroundCheck.Flag.Ground));
            if (CheckGroundFlag(GroundCheck.Flag.Ground))
            {
                move_SE.PlayAudio(se);
                anim.AnimChage("Move", isLock);
            }
            else if (!CheckGroundFlag(GroundCheck.Flag.Ground))
            {
                move_SE.PlayAudio(se);
                anim.AnimChage("Hover", isLock);
            }
        }
        else if ((anim.Action == AnimSetting.Type.Move || anim.Action == AnimSetting.Type.Jump) && 
            rb.velocity.magnitude <= 0.2f)
        {
            anim.AnimChage("Idle", false);
        }
    }

    //----------各種データ管理----------
    Vector2 Distance(Vector3 target)
    {
        Vector2 distance = target - transform.position;
        return distance;
    }

    float GroundPosition(float axisX)
    {
        //LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D rayHit = Physics2D.Raycast
            (new Vector2(axisX, stage_LeftTop.y), Vector2.down,
            stage_LeftTop.y - stage_RightDown.y, gc.Ray[0].Layer);  //光線発射
        Debug.DrawRay(new Vector2(axisX, stage_LeftTop.y), Vector2.down * (stage_LeftTop.y - stage_RightDown.y), Color.green, 1.0f);
        if (rayHit.collider.tag == gc.Ray[0].Tag.ToString())
        {
            Vector2 groundPos = rayHit.point;   //地面位置確認
            return groundPos.y;
        }
        Debug.LogError(axisX + "に地面はない");
        return 0;
    }

    IEnumerator Flash()
    {
        int damage_Repeat = 0;

        while (damage_Repeat < damage_Number)
        {
            //色変更
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = damage_Color;
            }
            renderController.Opacity = damage_Color.a;
            //待つ
            yield return new WaitForSeconds(damage_Time);
            //色戻す
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = defColor;
            }
            renderController.Opacity = 1;
            //待つ
            yield return new WaitForSeconds(damage_Time);
            damage_Repeat++;
        }
    }

    void StageData()    //ステージ
    {
        stage_LeftTop = new Vector2(stage_Center.x - (stage_Range.x * 0.5f), stage_Center.y + (stage_Range.y * 0.5f));
        stage_RightDown = new Vector2(stage_Center.x + (stage_Range.x * 0.5f), stage_Center.y - (stage_Range.y * 0.5f));
    }

    void AllVariableClear()     //変数初期化
    {
        GeneralVariableClear();

        //円
        //circle.DataClear();
    }

    void GeneralVariableClear() //汎用変数初期化
    {
        phase = 0;
        timer = 0;
        repeat = 0;
        no = 0;
    }

    bool CheckGroundFlag(GroundCheck.Flag flag)
    {
        return gc.CheckFlag(flag);
    }

    void AllHitActive(bool value)
    {
        body.SetActive(value);
        breath.SetActive(value);
        pushUp.SetActive(value);
    }

    public void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<HitData>().Power = power;
    }

    private void OnDrawGizmos()
    {
        if (body_Gizmo.Display)
        {
            bc = GetComponent<BoxCollider2D>();
            body_Gizmo.Draw(bc.bounds.center, bc.bounds.max - bc.bounds.min);
        }
        if (rush_Gizmo.Display) { rush_Gizmo.Draw(rush_Center, rush_AtkRange); }
        if (eruption_Gizmo.Display) { eruption_Gizmo.Draw(eruption_Center, eruption_AtkRange); }
        if (spin_Gizmo.Display) { spin_Gizmo.Draw(spin_Center, spin_AtkRange); }
        if (meteor_Gizmo.Display) { meteor_Gizmo.Draw(meteor_Center, meteor_AtkRange); }

        if (stage_Gizmo.Display) { stage_Gizmo.Draw(stage_Center, stage_Range); }
    }

    //void DrawWireGizmo(Vector2 center, Vector2 size, Color color)
    //{
    //    Gizmos.color = color;
    //    Gizmos.DrawWireCube(center, size);
    //}
}

[System.Serializable]
public class Qilin_MoveTable
{
    [SerializeField] string name;
    [SerializeField] Qilin_MoveType[] move;

    public string Name { get { return name; } }
    public Qilin_MoveType[] Move { get { return move; } }
}
*/