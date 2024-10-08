//ボス2：ファフニール

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;
using Cinemachine;
using Live2D.Cubism.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public enum Fafnir_MoveType
{
    Entry,      //登場
    Idle = 1,   //仮
    Pound,      //はたく
    Rush,       //突進
    Breath,     //ブレス
    Earthquake, //地震
}

public class Fafnir : MonoBehaviour
{

    Rigidbody2D rb;
    AudioSource se;
    CubismRenderController renderController;
    HitMng hm;      //当たり判定
    GroundCheck gc; //接地判定

    //
    GameObject obj; //自身自身
    Color defColor;
    [SerializeField, Tooltip("プレーヤー")] GameObject pl;
    [SerializeField, Tooltip("カメラ")] GameObject mainCamera;

    //
    int phase = 0;      //汎用行動番号
    float timer = 0;    //汎用タイマー
    int repeat = 0;     //汎用繰り返し回数
    int no = 0;         //汎用ナンバ
    //
    int phaseSub = 0;   //汎用行動番号
    float timerSub = 0; //汎用タイマー
    int repeatSub = 0;  //汎用繰り返し回数
    int noSub = 0;      //汎用ナンバ

    int tableNo = 0;    //テーブル指定
    int moveNo = 0;     //行動指定

    int defSortingOrder;


    [SerializeField, Tooltip("行動")] Fafnir_MoveType moveType = Fafnir_MoveType.Idle;
    [SerializeField, Tooltip("行動テーブル")] Fafnir_MoveTable[] moveTable;
    [SerializeField] float speed;

    [Header("本体")]
    [SerializeField, Tooltip("接触攻撃判定")] GameObject body;
    [SerializeField, Tooltip("接触威力")] float body_Power = 1.0f;
    [SerializeField, Tooltip("叫びエフェクト")] ParticleSetting roar_Effect;
    [SerializeField, Tooltip("ジャンプエフェクト")] ParticleSetting jumpEnd_Effect;
    [SerializeField, Tooltip("タックルエフェクト")] ParticleSetting tackle_Effect;
    [SerializeField, Tooltip("叩きつけエフェクト")] ParticleSetting earthpuake_Effect;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip Move_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float Move_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float Move_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool Move_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip jumpStart_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float jumpStart_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float jumpStart_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool jumpStart_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip jumpEnd_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float jumpEnd_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float jumpEnd_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool jumpEnd_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip attackAnticipation_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float attackAnticipation_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float attackAnticipation_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool attackAnticipation_SELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip die_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float die_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float die_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool die_SELoop;

    Vector2 pos;        //座標
    Vector2 plPos;      //プレーヤー座標
    Vector3 defScale;   //拡縮率保存
    Vector3 scale;      //拡縮率更新
    float dir;          //左右方向
    float gravity;      //重力強度保存
    int soundcount = 0;

    [Header("登場")]
    [SerializeField, Tooltip("初期位置")] Vector2 entry_StartPos = Vector2.zero;
    [SerializeField, Tooltip("速度")] float entry_Spd = 1.0f;
    [SerializeField, Tooltip("ベクトル")] Vector2 entry_Vector = Vector2.zero;
    [SerializeField, Tooltip("着地振動時間")] float entry_JumpVibrationTime = 1.0f;
    [SerializeField, Tooltip("咆哮時間")] float entry_RoarTime = 1.0f;
    [SerializeField, Tooltip("画面振動強さ")] float entry_Vibration = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting entry_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting entry_SE;

    [Header("待機")]
    [SerializeField, Tooltip("待機時間")] float idle_BreakTime = 1.0f;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip idle_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float idle_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float idle_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool idle_SELoop;

    [Header("はたく")]
    [SerializeField, Tooltip("はたく")] GameObject pound;
    [SerializeField, Tooltip("威力")] float pound_Power = 1.0f;
    [SerializeField, Tooltip("移動速度")] float pound_MoveSpd = 5.0f;
    [SerializeField, Tooltip("隙")] float[] pound_BreakTime = { 0.5f, 0.5f };
    [SerializeField, Tooltip("攻撃距離")] float pound_AtkDistance = 6.0f;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip pound_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float pound_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float pound_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool pound_SELoop;

    [Header("落石(未実装)")]
    [SerializeField, Tooltip("はたく")] GameObject rock;
    [SerializeField, Tooltip("威力")] float rock_Power = 1.0f;
    [SerializeField, Tooltip("落下速度")] float rock_FallSpd = 5.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 rock_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("攻撃範囲")] Vector2 rock_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("攻撃時間")] float rock_AtkTime = 5.0f;
    [SerializeField, Tooltip("生成数")] float rock_Generate = 10.0f;
    [SerializeField, Tooltip("生成数")] float rock_DieTime = 1.0f;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting rock_Gizmo;

    [Header("突進")]
    [SerializeField, Tooltip("移動速度")] float rush_MoveSpd = 20.0f;
    [SerializeField, Tooltip("威力")] float rush_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 rush_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("攻撃範囲")] Vector2 rush_AtkRange = new Vector2(40.0f, 10.0f);
    [SerializeField, Tooltip("叫び時間")] float rush_RoarTime = 1.0f;
    [SerializeField, Tooltip("隙")] float rush_BreakTime = 0.5f;
    [SerializeField, Tooltip("実行回数")] int rush_AtkTime = 3;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioSetting rush_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting rush_Gizmo;

    [Header("ブレス")]
    [SerializeField, Tooltip("ブレス")] GameObject breath;
    [SerializeField, Tooltip("威力")] float breath_Power = 1.0f;
    [SerializeField, Tooltip("ジャンプ高さ")] float breath_JumpHeight;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip breath_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float breath_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float breath_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool breath_SELoop;
    float breath_Save;          //変数保存

    [Header("地震")]
    [SerializeField, Tooltip("地震")] GameObject earthquake;
    [SerializeField, Tooltip("威力")] float earthquake_Power = 1.0f;
    [SerializeField, Tooltip("ジャンプ高さ")] float earthquake_JumpHeight;
    [SerializeField, Tooltip("継続時間")] float earthquake_Time = 3.0f;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip earthquake_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float earthquake_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float earthquake_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool earthquake_SELoop;

    [Header("被ダメージ")]
    [SerializeField, Tooltip("ダメージデータ")] Damage damage;
    [SerializeField, Tooltip("ダメージ時描画")] int sortingOrder = 0;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting damage_SE;
    float damage_Repeat = 0;

    [Header("死亡")]
    [SerializeField, Tooltip("変色前時間")] float dead_Time = 0.5f; 
    [SerializeField]
    [Tooltip("固まるスピード")]
    float dead_Speed;
    [SerializeField]
    [Tooltip("固まる最大値")]
    private float max;
    private float goldtime;
    private bool start = false;



    [Header("カメラ")]
    [SerializeField, Tooltip("画面情報")] SY.CameraData cameraData;
    Camera useCamera;       //使用カメラ
    Vector2 leftBottom;     //左下
    Vector2 leftTop;        //左上
    Vector2 rightBottom;    //右下
    Vector2 rightTop;       //右上
    Vector2 center;         //中央
    float screenWidth;      //幅
    float screenHeight;     //高さ

    float hScreenWidth;     //1/2幅
    float qScreenWidth;     //1/4幅
    float hScreenHeight;    //1/2高さ
    float qScreenHeight;    //1/4高さ

    GameObject ui;

    //アニメーション
    Anim anim;
    float anim_JumpFlag;
    [SerializeField] bool isLock;

    private readonly AchvMeasurement achv = new AchvMeasurement();

    [SerializeField]
    private Material fafgold;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        renderController = GetComponent<CubismRenderController>();
        anim = GetComponent<Anim>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        obj = this.gameObject;
        defColor = renderController.ModelScreenColor;
        pos = entry_StartPos;
        plPos = pl.transform.position;
        defScale = transform.localScale;
        scale = defScale;
        gravity = rb.gravityScale;
        ui = GameObject.Find("UI").gameObject;
        ui.SetActive(false);

        AllHitActive(false);
        SetPower(body, body_Power);
        //breath_DefScale = breath.transform.localScale;

        hm.SetUp(Damage, Die);
        CameraData();

        renderController.OverwriteFlagForModelScreenColors = true;
        defSortingOrder = renderController.SortingOrder;

        moveType = Fafnir_MoveType.Entry;
        AllVariableClear();
        rb.gravityScale = 0;
        rb.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.Action == AnimSetting.Type.Die) 
        {
            timer += Time.deltaTime;
            if (timer < dead_Time) { return; }
            start = true;
            if (start == true)
            {
                GameObject.Find("ArtMesh").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh2").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh3").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh4").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh5").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh6").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh7").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh8").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh9").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh10").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh11").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh12").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh13").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh14").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh15").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh16").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh17").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh18").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh19").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh20").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh21").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh22").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh23").GetComponent<CubismRenderer>().Material = fafgold;
                GameObject.Find("ArtMesh24").GetComponent<CubismRenderer>().Material = fafgold;
                if (goldtime <= max)
                {
                    goldtime += dead_Speed;
                    fafgold.SetFloat("time", goldtime);
                }
                else { GameData.FafnirDead = true; }
            }
            return; 
        }
        hm.HitUpdate();

        if (hm.HP <= 0) { return; }

        pos = rb.position;
        plPos = pl.transform.position;

        switch (moveType)
        {
            case Fafnir_MoveType.Entry:
                Entry();
                break;

            case Fafnir_MoveType.Idle:
                Idle();
                break;

            case Fafnir_MoveType.Pound:
                Pound();
                break;

            case Fafnir_MoveType.Rush:
                Rush();
                break;

            case Fafnir_MoveType.Breath:
                Breath();
                break;

            case Fafnir_MoveType.Earthquake:
                Earthquake();
                break;
        }
        //Debug.Log(phase);
        //Debug.Log(no);
        //Debug.Log(repeat);
        //Debug.Log(moveTable[tableNo].Name + " : " + moveNo);
        //Debug.Log("no " + no + " phase " + phase);

        rb.position = pos;
        if (moveType == Fafnir_MoveType.Idle || moveType == Fafnir_MoveType.Pound ||
            moveType == Fafnir_MoveType.Earthquake)
        {
            Direction();
        }

        Anim_Basis();
        Anim_Jump();
        hm.PostUpdate();
    }

    //----------アクション----------
    void Entry()
    {
        switch(phase)
        {
            case 0:
                anim.AnimChage("Entry_FallAir", isLock);
                rb.velocity = entry_Vector.normalized * entry_Spd;
                phase++;
                break;
            case 1:
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                rb.gravityScale = gravity;
                rb.velocity = Vector2.zero;
                anim.AnimChage("Entry_FallEnd", isLock);
                jumpEnd_Effect.PlayParticle();
                setVibration(entry_Vibration * 0.25f);
                phase++;
                break;
            case 2:
                VibrationSubtraction(((entry_Vibration * 0.25f) / 60.0f) / entry_JumpVibrationTime);
                timer += Time.deltaTime;
                if (timer < entry_JumpVibrationTime) { return; }
                setVibration(0);
                timer = 0;
                phase++;
                break;
            case 3:
                if (!AnimEndChange("Entry_RoarStart")) { break; }
                phase++;
                break;
            case 4:
                if (!AnimEndChange("Entry_RoarAir")) { break; }
                setVibration(entry_Vibration);
                entry_Effect.Particle.gameObject.SetActive(true);
                entry_Effect.PlayParticle();
                phase++;
                break;
            case 5:
                timer += Time.deltaTime;
                if (timer < entry_RoarTime) { break; }
                anim.AnimChage("Entry_RoarEnd", isLock);
                setVibration(0);
                entry_Effect.Particle.gameObject.SetActive(false);
                phase++;
                break;
            case 6:
                if (anim.NormalizedTime < 1.0f) { break; }
                moveType = Fafnir_MoveType.Idle;
                tableNo = Random.Range(0, moveTable.Length);
                moveNo = 0;
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
    CinemachineBasicMultiChannelPerlin vCamera2;
    Volume v;
    MotionBlur b;
    void setVibration(float vibration)  //画面振動
    {
        CinemachineVirtualCamera vCamera = mainCamera.GetComponent<CinemachineVirtualCamera>();
        vCamera2 = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamera2.m_AmplitudeGain = vibration;

        v = GameObject.Find("Global Volume").GetComponent<Volume>();
        v.profile.TryGet(out b);
        b.intensity.value = vibration;
    }
    void VibrationSubtraction(float value)
    {
        vCamera2.m_AmplitudeGain -= value;
        b.intensity.value -= value;
    }

    void Idle()
    {
        switch(phase)
        {
            case 0:
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                phase++;
                break;
            case 1:
                SetAudio(idle_SE, idle_SEVolume, idle_SEPitch, idle_SELoop);
                timer += Time.deltaTime;
                if(timer < idle_BreakTime) { break; }
                timer = 0;
                phase++;
                break;
            case 2:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;

        }
    }

    void Pound()        //はたく
    {
        switch(phase)
        {
            case 0:
                SetAudio(attackAnticipation_SE, attackAnticipation_SEVolume, attackAnticipation_SEPitch, attackAnticipation_SELoop);
                phase++;
                break;
            case 1:
                rb.velocity = (-dir * Vector2.right).normalized * pound_MoveSpd;
                if (pound_AtkDistance < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.velocity = Vector2.zero;
                phase++;
                break;
            case 2:
                timer += Time.deltaTime;
                if(timer < pound_BreakTime[no]) { break; }
                SetPower(pound, pound_Power);
                anim.AnimChage("Pound",isLock);
                //Debug.Log("攻撃処理");
                if (anim.Play != GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name || anim.NormalizedTime < 0.7f) { break; }
                //Debug.Log(anim.Play + " : " + GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name + " : " + anim.NormalizedTime);
                SetAudio(pound_SE, pound_SEVolume, pound_SEPitch, pound_SELoop);
                earthpuake_Effect.PlayParticle();
                timer = 0;
                no++;
                phase++;
                break;
            case 3:
                //FallRock();
                if (anim.Action != AnimSetting.Type.Idle) { /*Debug.Log(anim.Action);*/ break; }
                //Debug.Log(anim.Action);
                timer += Time.deltaTime;
                if(timer < pound_BreakTime[no]) { /*Debug.Log(pound_BreakTime[no]);*/ break; }
                //moveType = pound_NextMove;
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
                AnimChange("Rush_RoarStart");
                phase++;
                break;
            case 1:
                if (anim.NormalizedTime < 1.0f) { break; }
                AnimChange("Rush_RoarAir");
                roar_Effect.PlayParticle();
                phase++;
                break;
            case 2:
                timer += Time.deltaTime;
                if (timer < rush_RoarTime) { break; }
                roar_Effect.StopParticle();
                AnimChange("Rush_RoarEnd");
                timer = 0;
                phase++;
                break;
            case 3:
                if (anim.NormalizedTime < 1.0f) { break; }
                SetPower(body, rush_Power);
                SetAudio(attackAnticipation_SE, attackAnticipation_SEVolume, attackAnticipation_SEPitch, attackAnticipation_SELoop);
                AnimChange("Rush_Start");
                phase++;
                break;
            case 4:
                if (anim.NormalizedTime < 1.0f) { break; }
                body.SetActive(true);
                rush_SE.PlayAudio(se);
                tackle_Effect.PlayParticle();
                AnimChange("Rush_Air");
                repeat++;
                phase++;
                break;
            case 5:
                timer += Time.deltaTime;
                rb.velocity = (-dir * Vector2.right).normalized * rush_MoveSpd;
                if (timer < 0.2f) { break; }
                if (repeat == rush_AtkTime)
                {
                    if (pos.x > center.x + 5.0f || center.x - 5.0f > pos.x) { break; }
                }
                else
                {
                    if (pos.x < (rush_Center.x + rush_AtkRange.x * 0.5f) &&
                        (rush_Center.x - rush_AtkRange.x * 0.5f) < pos.x) { break; }
                }
                rb.velocity = Vector2.zero;
                body.SetActive(false);
                SetPower(body, body_Power);
                anim.AnimChage("Rush_End", isLock);
                tackle_Effect.StopParticle();
                timer = 0;
                phase++;
                break;
            case 6:     //終了アニメーション終了
                if (anim.NormalizedTime < 1.0f) { break; }
                phase++;
                break;
            case 7:     //折り返し時間→向き更新、回数に応じて次アクション定義
                timer += Time.deltaTime;
                if (timer < rush_BreakTime) { break; }
                Direction();
                timer = 0;
                if (repeat == rush_AtkTime) { phase++; }
                else { phase = 0; }
                break;
            case 8:
                //moveType = rush_NextMove;
                MoveEnd();
                break;
            default:    //行動遷移時汎用変数初期化
                AllVariableClear();
                break;
        }
    }

    void Breath()       //ブレス
    {
        switch(phase)
        {
            case 0:     //技威力設定
                SetPower(breath.transform.gameObject, breath_Power);
                phase++;
                break;
            case 1:     //プレーヤーの位置と地面位置から攻撃位置定義、ジャンプ行動
                CameraData();
                Vector2 target = (center.x - plPos.x <= 0) ? leftTop : rightTop;
                target = new Vector2(target.x, GroundPosition(target.x));
                //Debug.Log(target);
                Jump(target, breath_JumpHeight);
                if (anim_JumpFlag != 1) { break; }
                phase++;
                break;
            case 2:     //地面を離れたか
                if (CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                phase++;
                break;
            case 3:     //接地判定→プレーヤーの方向向く、ブレス攻撃
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                if (anim.Action == AnimSetting.Type.Jump) { break; }
                Direction();
                rb.velocity = Vector2.zero;
                if(soundcount == 0)
                {
                    SetAudio(breath_SE, breath_SEVolume, breath_SEPitch, breath_SELoop);
                    soundcount++;
                }
                anim.AnimChage("Breath", isLock);
                no++;
                phase++;
                break;
            case 4:     //現在のアクションがアイドル→行動遷移、ブレスオブジェクト回転初期化、汎用変数初期化
                if(anim.Action != AnimSetting.Type.Idle) { break; }
                breath.transform.localRotation = Quaternion.Euler(Vector3.zero);
                soundcount = 0;
                //moveType = breath_NextMove;
                MoveEnd();
                break;
            default:    //行動遷移時汎用変数初期化
                AllVariableClear();
                break;
        }

        /* ・ブレス攻撃時行動
         * プレーヤーが画面左右どちらにいるか確認
         * プレーヤーの反対の画面端に移動
         *      (プレーヤーの方向を向きながら  (重力強度0)→離陸→停止→移動→停止→(重力強度戻)→着陸)
         * ブレスチャージ開始→n秒後水平方向に発射
         * 徐々にx軸を大きく
         * 伸びきれば徐々に上方向に角度をつける
         * 約40度で停止
         * 終了
         */
    }

    void Earthquake()   //地震
    {
        switch(phase)
        {
            case 0:
                SetAudio(attackAnticipation_SE, attackAnticipation_SEVolume, attackAnticipation_SEPitch, attackAnticipation_SELoop);
                SetPower(earthquake, earthquake_Power);
                phase++;
                break;
            case 1:
                Vector2 target = new Vector2(center.x, GroundPosition(center.x));
                Debug.Log(target);
                Jump(target, earthquake_JumpHeight);
                if(anim_JumpFlag != 1) { break; }
                phase++;
                break;
            case 2:
                if (CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                phase++;
                break;
            case 3:
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                rb.velocity = Vector2.zero;
                SetAudio(earthquake_SE, earthquake_SEVolume, earthquake_SEPitch, earthquake_SELoop);
                earthquake.SetActive(true);
                phase++;
                break;
            case 4:
                //rb.velocity = Vector2.zero;
                timer += Time.deltaTime;
                //FallRock();
                if (timer < earthquake_Time) { break; }
                earthquake.SetActive(false);
                timer = 0;
                phase++;
                break;
            case 5:
                //moveType = earthquake_NextMove;
                MoveEnd();
                break;
            default:    //行動遷移時汎用変数初期化
                AllVariableClear();
                break;
        }
    }

    void FallRock()
    {
        if (phaseSub != 0) { return; }
        timerSub += Time.deltaTime;
        if (timerSub < rock_AtkTime / rock_Generate) { return; }
        GameObject obj = RandomInstantiate(rock, rock_Center, rock_AtkRange);   //オブジェクト生成
        GameObject atk = obj.transform.Find("Atk").gameObject;  //生成物攻撃判定
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();       //生成物物理演算
        SetPower(atk, rock_Power);          //威力設定
        rb.gravityScale *= rock_FallSpd;    //落下速度設定
        Destroy(obj, rock_DieTime);         //消去処理
        repeatSub++;    //生成回数
        timerSub = 0;   //タイマーリセット
        if (repeatSub != rock_Generate) { return; }
        phaseSub++;
    }

    GameObject RandomInstantiate(GameObject obj, Vector2 center, Vector2 range)
    {
        Vector2 instantiatePos;
        Vector2[] edge = EdgePossition(center, range);

        instantiatePos.x = Random.Range(edge[0].x, edge[1].x);
        instantiatePos.y = edge[1].y;

        return Instantiate(obj, instantiatePos, Quaternion.identity);
    }

    Vector2[] EdgePossition(Vector2 center, Vector2 range)
    {
        Vector2[] edge = new Vector2[2];

        Vector2 r = range * 0.5f;   //範囲半径
        edge[0] = center - r;       //左下
        edge[1] = center + r;       //右上

        return edge;
    }

    void MoveEnd()  //行動終了時処理
    {
        //Debug.Log("行動終了");
        moveNo++;
        if (moveNo == moveTable[tableNo].Move.Length)
        {
            tableNo = Random.Range(0, moveTable.Length);
            moveNo = 0;
        }
        moveType = moveTable[tableNo].Move[moveNo];
        AllVariableClear();
    }

    void Jump(Vector2 targetPos, float height)  //ジャンプ
    {
        float t1 = RiseorFallTime(pos, height);         //開始から最大高度までの時間
        float t2 = RiseorFallTime(targetPos, height);   //最大高度から着地までの時間

        float jumpTime = t1 + t2;   //ジャンプ時間

        if (jumpTime <= 0.0f)
        {
            Debug.LogError("ジャンプの時間が0秒");
            return;
        }

        float speed = VectorFromTime(targetPos, jumpTime);  //初速
        float angle = AngleFromTime(targetPos, jumpTime);   //角度

        if (speed <= 0.0f)
        {
            // その位置に着地させることは不可能のようだ！
            Debug.LogError("初速が与えられない");
            return;
        }

        Vector3 vec = ConvertVectorToVector3(speed, angle, targetPos);

        Vector2 force = vec * rb.mass;

        SetAudio(jumpStart_SE, jumpStart_SEVolume, jumpStart_SEPitch, jumpStart_SELoop);
        anim.AnimChage("Jump_Start", isLock);
        if (anim.NormalizedTime < 1.0f) { return; }

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Direction()    //向き(プレーヤーの方向)
    {
        dir = ((plPos.x - pos.x <= 0) ? defScale.x : -defScale.x);
        scale.x = dir;
        transform.localScale = scale;
    }

    void Damage()   //被ダメージ
    {
        Debug.Log(obj.name + "はダメージを受けた");
        StartCoroutine("Flash");
    }

    void Die()      //死亡
    {
        Debug.Log(obj.name + "は死んだ");
        hm.ATKActive = false;
        achv.DefeatedBoss(1);
        if (soundcount == 0)
        {
            rb.velocity = Vector2.zero;
            AllHitActive(false);
            timer = 0;
            SetAudio(die_SE, die_SEVolume, die_SEPitch, die_SELoop);
        }
        anim.AnimChage("Dead", isLock);
        soundcount++;
    }

    //----------アニメーション----------
    void AnimChange(string name)
    {
        anim.AnimChage(name, true);
    }

    void Anim_Basis()
    {
        if (CheckGroundFlag(GroundCheck.Flag.Ground))
        {
            if (anim.Action == AnimSetting.Type.Idle && 0.2f < rb.velocity.magnitude)
            {
                SetAudio(Move_SE, Move_SEVolume, Move_SEPitch, Move_SELoop);
                anim.AnimChage("Move", isLock);
            }
            else if (anim.Action == AnimSetting.Type.Move && rb.velocity.magnitude < 0.2f)
            {
                anim.AnimChage("Idle", false);
            }
        }
    }

    void Anim_Jump()
    {
        if (!CheckGroundFlag(GroundCheck.Flag.Ground) && anim.Action != AnimSetting.Type.Entry)
        {
            anim.AnimChage("Jump_Air", isLock);
            anim_JumpFlag = 1;
            Debug.Log("滞空アニメ");
        }
        else if (CheckGroundFlag(GroundCheck.Flag.Ground) && anim.Action == AnimSetting.Type.Jump)
        {
            if(anim_JumpFlag != 0)
            {
                Debug.Log("ジャンプ終わり");
                jumpEnd_Effect.PlayParticle();
                SetAudio(jumpEnd_SE, jumpEnd_SEVolume, jumpStart_SEPitch, jumpEnd_SELoop);
                anim.AnimChage("Idle", false);
                anim_JumpFlag = 0;
            }
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
        RaycastHit2D rayHit = 
            Physics2D.Raycast(new Vector2(axisX, leftTop.y), Vector2.down, screenHeight, gc.Ray[0].Layer);  //光線発射
        Debug.DrawRay(new Vector2(axisX, leftTop.y), Vector2.down * screenHeight, Color.green, 1.0f);
        if (rayHit.collider == null) { Debug.LogError(axisX + "に地面はない"); return 0; }
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
        int damage_Repeat = 0;  //繰り返し回数

        while (damage_Repeat < damage.Time)
        {
            //色変更
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = damage.Color;
            }
            renderController.Opacity = 0;
            renderController.SortingOrder = sortingOrder;
            Debug.Log("色：" + damage.Color + "　透明度：" + renderController.Opacity);
            //待つ
            yield return new WaitForSeconds(damage.Interval);
            //色戻す
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = Color.black;
            }
            renderController.Opacity = 1;
            renderController.SortingOrder = defSortingOrder;
            //待つ
            yield return new WaitForSeconds(damage.Interval);
            damage_Repeat++;    //繰り返し回数加算
        }
    }

    //上昇または落下時間
    float RiseorFallTime(Vector2 pos, float height)
    {
        float g = Physics.gravity.y * rb.gravityScale;
        float y = pos.y;

        float timeSquare = 2 * (y - height) / g;
        if (timeSquare <= 0.0f)
        {
            return 0.0f;
        }

        float time = Mathf.Sqrt(timeSquare);
        return time;
    }

    //時間からベクトルの大きさを計算
    float VectorFromTime(Vector2 targetPos, float time)
    {
        Vector2 vec = VectorXYFromTime(targetPos, time);

        float v_x = vec.x;
        float v_y = vec.y;

        float vecSquare = v_x * v_x + v_y * v_y;
        // 負数を平方根計算すると虚数になってしまう。
        // 虚数はfloatでは表現できない。
        // こういう場合はこれ以上の計算は打ち切ろう。
        if (vecSquare <= 0.0f)
        {
            Debug.LogError("虚数になる");
            //return 0.0f;
        }

        float v0 = Mathf.Sqrt(vecSquare);

        if (v0 <= 0.0f)
        {
            Debug.LogError("初速が与えられない");
        }

        return v0;
    }

    //時間から角度を計算
    float AngleFromTime(Vector2 targetPos, float time)
    {
        Vector2 vec = VectorXYFromTime(targetPos, time);

        float v_x = vec.x;
        float v_y = vec.y;

        float rad = Mathf.Atan2(v_y, v_x);
        float angle = rad * Mathf.Rad2Deg;

        return angle;
    }

    //時間からベクトルXYを計算
    private Vector2 VectorXYFromTime(Vector2 targetPos, float time)
    {
        // 瞬間移動はちょっと……。
        if (time <= 0.0f)
        {
            return Vector2.zero;
        }


        // xz平面の距離を計算。
        Vector2 startPos = new Vector2(pos.x, 0);
        Vector2 _targetPos = new Vector2(targetPos.x, 0);
        float distance = Vector2.Distance(targetPos, startPos);

        float x = distance;
        // な、なぜ重力を反転せねばならないのだ...
        float reGravity = -(Physics.gravity.y * rb.gravityScale);
        float sPosY = pos.y;
        float tPosY = targetPos.y;
        float t = time;

        float v_x = x / t;
        float v_y = (tPosY - sPosY) / t + (reGravity * t) / 2;

        return new Vector2(v_x, v_y);
    }

    private Vector3 ConvertVectorToVector3(float speed, float angle, Vector3 targetPos)
    {
        Vector3 startPos = pos;
        Vector3 _targetPos = targetPos;
        startPos.y = 0.0f;
        targetPos.y = 0.0f;

        Vector3 dir = (targetPos - startPos).normalized;
        Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
        Vector3 vec = speed * Vector3.right;

        vec = yawRot * Quaternion.AngleAxis(angle, Vector3.forward) * vec;

        return vec;
    }

    void CameraData()   //カメラ
    {
        leftBottom = cameraData.LeftBottom;
        leftTop = cameraData.LeftTop;
        rightBottom = cameraData.RightBottom;
        rightTop = cameraData.RightTop;
        center = cameraData.Center;
        screenWidth = cameraData.ScreenWidth;
        screenHeight = cameraData.ScreenHeight;

        hScreenWidth = cameraData.HalfScreenWidth;
        hScreenHeight = cameraData.HalfScreenHeight;
        qScreenWidth = cameraData.QuarterScreenWidth;
        qScreenHeight = cameraData.QuarterScreenHeight;
    }

    void AllVariableClear()     //変数初期化
    {
        GeneralVariableClear();
        SubGeneralVariableClear();

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

    void SubGeneralVariableClear()  //汎用変数初期化
    {
        phaseSub = 0;
        timerSub = 0;
        repeatSub = 0;
        noSub = 0;
    }

    void AllHitActive(bool value)
    {
        body.SetActive(value);
        pound.SetActive(value);
        breath.SetActive(value);
        earthquake.SetActive(value);
    }


    void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<HitData>().Power = power;
    }

    bool CheckGroundFlag(GroundCheck.Flag flag)
    {
        return gc.CheckFlag(flag);
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

    void ArraySetActive(GameObject[] obj, bool value)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(value);
        }
    }

    private void OnDrawGizmos()
    {
        if (rock_Gizmo.Display) { rock_Gizmo.Draw(rock_Center, rock_AtkRange); }
        if (rush_Gizmo.Display) { rush_Gizmo.Draw(rush_Center, rush_AtkRange); }
    }
}

[System.Serializable]
public class Fafnir_MoveTable
{
    [SerializeField] string name;
    [SerializeField] Fafnir_MoveType[] move;

    public string Name { get { return name; } }
    public Fafnir_MoveType[] Move { get { return move; } }
}



/*----------削ったコード(後に消去)----------

//飛翔

//[Header("飛翔")]
//[SerializeField, Tooltip("移動速度")] float flap_MoveSpd;
//[SerializeField, Tooltip("移動方向")] Vector2 flap_Direction;
//[SerializeField, Tooltip("落下速度")] float flap_FallSpd = 0.3f;
//[SerializeField, Tooltip("羽ばたき間隔")] float flap_Interval = 1.0f;
//[SerializeField, Range(0.0f, 90.0f), Tooltip("角度")] float jump_Angle;

//void Flap(float power, Vector2 vec)
//{
//    switch (flapPhase)
//    {
//        case 0: //上昇
//            rb.velocity = new Vector2(vec.x, vec.y * flap_FallSpd) * power;
//            flapTimer += Time.deltaTime;
//            if (flapTimer < flap_Interval / 2.0f) { return; }
//            flapTimer = 0; flapPhase++;
//            break;
//        case 1: //下降
//            rb.velocity = new Vector2(vec.x, -1.0f * flap_FallSpd) * power;
//            flapTimer += Time.deltaTime;
//            if (flapTimer < flap_Interval / 2.0f) { return; }
//            flapTimer = 0; flapPhase = 0;
//            break;
//    }
//}

//ブレス

//[SerializeField, Tooltip("移動速度")] float[] breath_MoveSpd = { 5.0f, 2.0f, 5.0f, 2.0f, 0.0f };
//[SerializeField, Tooltip("移動方向")] Vector2[] breath_MoveDir =
//    { new Vector2(0.0f, 3.0f), new Vector2(0.0f, 1.0f), new Vector2(1.0f, 1.0f), new Vector2(0.0f, 1.0f), new Vector2(0.0f, 0.0f) };
//[SerializeField, Tooltip("移動時間")] float[] breath_MoveTime = { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
//[SerializeField, Tooltip("発射点")] Vector2 breath_Origin = new Vector2(0.0f, 0.0f);
//[SerializeField, Tooltip("速度")] float breath_Speed = 20.0f;
//[SerializeField, Tooltip("角度速度")] float breath_AngleSpd = 10.0f;
//[SerializeField, Tooltip("溜め時間")] float breath_ChargeTime = 1.5f;
//[SerializeField, Tooltip("最終範囲")] float breath_MaxDistance = 10.0f;
//[SerializeField, Tooltip("最終角度")] float breath_MaxAngle = 40.0f;
//Vector3 breath_DefScale;    //ブレスオブジェクト各縮率保存

//case 1:     //no = 0 : breath_Time[no]秒間上昇   no = 1 : breath_Time[no]秒間停止→プレーヤーの位置から移動方向定義
//timer += Time.deltaTime;
//Flap(breath_MoveSpd[no], breath_MoveDir[no]);
//if (timer < breath_MoveTime[no]) { break; }
//timer = 0;
//no++;
//if (no < 2) { break; }
//breath_Save = breath_MoveDir[no].x;
//breath_MoveDir[no].x *= (center.x - plPos.x <= 0) ? -1 : 1;
//phase++;
//break;
//case 2:     //no = 2 : 画面端まで水平移動
//Flap(breath_MoveSpd[no], breath_MoveDir[no]);
//if (pos.x < rightTop.x && leftTop.x < pos.x) { break; }
//pos.x = (rightTop.x < pos.x) ? rightTop.x - 0.1f : leftTop.x + 0.1f;
//breath_MoveDir[no].x = breath_Save;
//no++;
//phase++;
//break;
//case 3:     //no = 3 : breath_Time[no]秒間停止→重力強度復元
//timer += Time.deltaTime;
//Flap(breath_MoveSpd[no], breath_MoveDir[no]);
//if (timer < breath_MoveTime[no]) { break; }
//rb.gravityScale = gravity;
//timer = 0;
//no++;
//phase++;
//break;
//case 5:     //breath_ChargeTime秒溜め動作
//timer += Time.deltaTime;
//if (timer < breath_ChargeTime) { break; }
//breath.transform.localPosition = breath_Origin;
//breath.transform.localScale = breath_DefScale;
//breath.SetActive(true);
//timer = 0;
//phase++;
//break;
//case 6:     //breath_MaxDistanceを超えるまで拡大
//timer += Time.deltaTime;
//breath.transform.localScale =
//new Vector3(breath_Speed * timer + breath_DefScale.x, breath_DefScale.y, breath_DefScale.z);
//if (breath.transform.localScale.x < breath_MaxDistance) { break; }
//timer = 0;
//phase++;
//break;
//case 7:     //breath_MaxAngleを超えるまで角度を付ける
//timer += Time.deltaTime;
//var quaternion = Quaternion.Euler(timer * breath_AngleSpd * Vector3.forward);
//breath.transform.localRotation = quaternion;
//if (quaternion.eulerAngles.z < breath_MaxAngle) { break; }
//breath.SetActive(false);
//timer = 0;
//phase++;
//break;

//地面

//[SerializeField, Tooltip("移動速度")] float[] earthquake_MoveSpd = { 20.0f, 1.0f };
//[SerializeField, Tooltip("移動方向")] Vector2[] earthquake_MoveDir =
//    { new Vector2(0.0f, 5.0f), new Vector2(0.0f, 1.0f) };
//[SerializeField, Tooltip("移動時間")] float[] earthquake_MoveTime = { 1.0f, 0.0f };

//case 1:
//timer += Time.deltaTime;
//Flap(earthquake_MoveSpd[no], earthquake_MoveDir[no]);
//if (timer < earthquake_MoveTime[no]) { break; }
//timer = 0;
//no++;
//if (no < 2) { break; }
//earthquake.transform.localScale = new Vector3(screenWidth, 1.0f, 1.0f);
//rb.position = new Vector2(center.x, pos.y);
//rb.gravityScale = gravity;
//phase++;
//break;
*/

/*----------参考----------
 * 斜方投射
 *  公式(wiki)   : https://ja.wikipedia.org/wiki/%E6%96%9C%E6%96%B9%E6%8A%95%E5%B0%84
 *  コード参考1  : https://qiita.com/_udonba/items/a71e11c8dd039171f86c
 *  コード参考2  : https://www.urablog.xyz/entry/2017/05/16/235548
*/