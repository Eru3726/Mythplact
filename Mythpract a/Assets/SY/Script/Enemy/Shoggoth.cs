//ボス1：ショゴス

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using Cinemachine;
using SY;

public enum Shoggoth_MoveType
{
    Entry,      //登場
    Eight,      //基本
    Rotation,   //共有メモパターン2
    UpDown,     //共有メモパターン3
    Rush,       //共有メモパターン4
    Dead,       //死亡
}

public class Shoggoth : MonoBehaviour
{
    Rigidbody2D rb;                 //物理演算
    AudioSource se;                 //サウンド
    SnakeRig sRig;
    HitMng hm;                      //当たり判定
    GroundCheck gc; //接地判定
    Circle circle = new Circle();   //円

    //
    Color defColor;
    [SerializeField, Tooltip("メインカメラ")] GameObject mainCamera;
    [SerializeField, Tooltip("プレイヤー")] GameObject pl;
    [SerializeField, Tooltip("スライム")] GameObject slime;
    [SerializeField, Tooltip("予測")] GameObject prediction;

    //
    int phase = 0;      //汎用行動番号
    float timer = 0;    //汎用タイマー
    int repeat = 0;     //汎用繰り返し回数
    int no = 0;         //汎用ナンバ

    int tableNo = 0;    //テーブル指定
    int moveNo = 0;     //行動指定

    //
    [SerializeField, Tooltip("行動"), ReadOnly] Shoggoth_MoveType moveType = Shoggoth_MoveType.Eight;
    [SerializeField, Tooltip("行動テーブル")] Shoggoth_MoveTable[] moveTable;
    [SerializeField, Tooltip("速度")] float speed;
    const float speed_save = 0.05f;

    [Header("本体")]
    [SerializeField, Tooltip("頭攻撃判定")] GameObject head;
    [SerializeField, Tooltip("体攻撃判定")] GameObject[] body;
    [SerializeField, Tooltip("尾攻撃判定")] GameObject tail;
    [SerializeField, Tooltip("頭接触威力")] float head_Power = 1.0f;
    [SerializeField, Tooltip("体接触威力")] float body_Power = 1.0f;
    [SerializeField, Tooltip("尾接触威力")] float tail_Power = 1.0f;

    GameObject obj;     //自身
    GameObject headObj; //頭
    GameObject effect;  //エフェクト親オブジェクト
    Vector2 pos;        //座標
    Vector2 plPos;      //プレーヤー座標
    Quaternion rot;     //角度保存
    Vector3 defScale;   //拡縮率保存
    Vector3 scale;      //拡縮率更新
    float gravity;      //重力強度保存
    Vector2 dir;        //移動方向

    Vector2 beforePos;  //移動前の位置
    Vector2 afterPos;   //移動後の位置
    Vector2 targetPos;  //目標位置
    float groundPosY;   //地面の高さ

    [Header("登場")]
    [SerializeField, Tooltip("初期位置")] Vector2 startPosition;
    [SerializeField, Tooltip("速度")] float entry_Speed;
    [SerializeField, Tooltip("動き")] Shoggoth_EntryMove[] entryMove;
    [SerializeField, Tooltip("咆哮エフェクト")] float entry_RoarTime = 1.0f;
    [SerializeField, Tooltip("画面振動強度")] float entry_Vibration = 1.0f;
    [SerializeField, Tooltip("咆哮エフェクト")] ParticleSetting entry_RoarEffect;
    [SerializeField, Tooltip("咆哮サウンド")] AudioSetting entry_RoarSE;

    [Header("八の字")]
    [SerializeField, Tooltip("速度")] float eight_Speed;
    [SerializeField, Tooltip("中心座標")] Vector2 eight_Center;
    [SerializeField, Tooltip("半径")] Vector2 eight_Radius;
    [SerializeField, Tooltip("待機時間")] float eight_BreakTime;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip eight_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float eight_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float eight_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool eight_SELoop;
    [SerializeField, Tooltip("移動範囲可視化")] bool eight_MoveRangeDisplay;

    [Header("旋回")]
    [SerializeField, Tooltip("判定")] GameObject[] rotation;
    [SerializeField, Tooltip("速度")] float rotation_Speed;
    [SerializeField, Tooltip("中心座標")] Vector2 rotation_Center;
    [SerializeField, Tooltip("半径")] Vector2 rotation_Radius;
    [SerializeField, Tooltip("スライム生成数")] int rotation_SlimeGenerate;
    [SerializeField, Tooltip("威力")] float rotation_Power;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip rotation_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float rotation_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float rotation_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool rotation_SELoop;
    [SerializeField, Tooltip("移動範囲可視化")] bool rotation_MoveRangeDisplay;

    [Header("上下")]
    [SerializeField, Tooltip("判定")] GameObject[] upDown;
    [SerializeField, Tooltip("エフェクト")] ParticleSystem upDown_Effect;
    [SerializeField, Tooltip("速度")] float upDown_Speed;
    [SerializeField, Tooltip("中心座標")] Vector2 upDown_Center;
    [SerializeField, Tooltip("半径")] Vector2 upDown_Radius;
    [SerializeField, Tooltip("攻撃回数")] float upDown_AtkTime;
    [SerializeField, Tooltip("スライム生成数")] int upDown_SlimeGenerate;
    [SerializeField, Tooltip("威力")] float upDown_Power;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip upDown_InSE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float upDown_InSEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float upDown_InSEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool upDown_InSELoop;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip upDown_OutSE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float upDown_OutSEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float upDown_OutSEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool upDown_OutSELoop;
    [SerializeField, Tooltip("移動範囲可視化")] bool upDown_MoveRangeDisplay;
    [SerializeField, Tooltip("攻撃予測")] PredictionSetting upDown_Prediction;

    [Header("突進")]
    [SerializeField, Tooltip("判定")] GameObject[] rush;
    [SerializeField, Tooltip("エフェクト")] ParticleSystem rush_Effect;
    [SerializeField, Tooltip("速度")] float rush_Speed;
    [SerializeField, Tooltip("中心座標"), ReadOnly] string rush_Center = "プレイヤーの位置";
    [SerializeField, Tooltip("オフセット")] Vector2 rush_Offset;
    [SerializeField, Tooltip("半径")] Vector2 rush_Radius;
    [SerializeField, Tooltip("威力")] float rush_Power;
    [SerializeField, Tooltip("サウンドエフェクト")] AudioClip rush_SE;
    [SerializeField, Range(0, 1), Tooltip("音量")] float rush_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("再生速度")] float rush_SEPitch;
    [SerializeField, Tooltip("サウンドループ化")] bool rush_SELoop;
    [SerializeField, Tooltip("移動範囲可視化")] bool rush_MoveRangeDisplay;
    [SerializeField, Tooltip("攻撃予測")] PredictionSetting rush_Prediction;

    [Header("被ダメージ")]
    [SerializeField, Tooltip("色")] Color damage_Color = Color.white;
    [SerializeField, Tooltip("点滅回数")] int damage_Number = 10;
    [SerializeField, Tooltip("時間")] float damage_Time = 0.05f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting damage_SE;
    float damage_Repeat = 0;

    [Header("死")]
    [SerializeField, Tooltip("エフェクト")] ParticleSetting[] die_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting die_SE;
    GameObject LastParticle;

    [Header("スライム")]
    [SerializeField, Tooltip("生成間隔")] float slime_GenerateTime;
    [SerializeField, Tooltip("最大数")] float slime_MaxNum;
    List<GameObject> slimeObj = new List<GameObject>();

    private readonly AchvMeasurement achv = new AchvMeasurement();


    public GameObject Player { get { return pl; } }
    public Shoggoth_MoveType MoveType { get { return moveType; } }
    public float HP { get { return hm.HP; } set { hm.HP = value; } }
    public List<GameObject> SlimeObj { get { return slimeObj; } set { slimeObj = value; } }

    private void Start()
    {
        sRig = GetComponent<SnakeRig>();
        headObj = sRig.Root;
        effect = GameObject.Find("Effect").gameObject;
        rb = headObj.GetComponent<Rigidbody2D>();
        rb.position = startPosition;
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();
        obj = this.gameObject;
        defColor = Color.white;
        pos = rb.position;
        plPos = pl.transform.position;
        scale = headObj.transform.localScale;
        gravity = rb.gravityScale;
        groundPosY = GroundPosition(eight_Center.x);

        moveType = Shoggoth_MoveType.Entry;

        PowerReset();
        rush_Effect.Clear();

        hm.SetUp(Damage, Die);
        AllVariableClear();
    }

    // Update is called once per frame
    public void Update()
    {
        if (moveType == Shoggoth_MoveType.Dead)
        {
            //LastParticle.GetComponent<ParticleSetting>().StopCheck();
            rush_Effect.gameObject.SetActive(false);
            upDown_Effect.gameObject.SetActive(false);
            Debug.Log(LastParticle.GetComponent<ParticleStopCheck>().IsStop);
            if (!LastParticle.GetComponent<ParticleStopCheck>().IsStop) { return; }
            GameData.ShoggothDead = true;
            return;
        }
        //Debug.Log(moveTable[tableNo].Name + " : " + moveTable[tableNo].Move[moveNo]);
        //Debug.Log(moveType);
        hm.HitUpdate();

        plPos = pl.transform.position;   //プレイヤーの位置

        beforePos = rb.position; //移動前の位置保存(方向算出のため)

        switch (moveType)
        {
            case Shoggoth_MoveType.Entry:
                Entry(); break;
            case Shoggoth_MoveType.Eight:
                Eight(); break;
            case Shoggoth_MoveType.Rotation:
                Rotation(); break;
            case Shoggoth_MoveType.UpDown:
                UpDown(); break;
            case Shoggoth_MoveType.Rush:
                Rush(); break;
        }
        rb.position = pos;
        effect.transform.position = pos;

        afterPos = rb.position;  //移動移動後の位置保存

        //移動方向に向く
        //transform.rotation = MoveDirection(beforePos, afterPos);
        //BodyRot();

        //スライム
        SlimeGene();

        //Debug.Log(phase);
        hm.PostUpdate();
    }

    //----------アクション----------
    //登場
    void Entry()
    {
        switch(phase)
        {
            case 0:
                pos = entryMove[repeat].Start;  //スタート位置に移動(転移)
                dir = Distance(entryMove[repeat].Start, entryMove[repeat].Target).normalized;   //移動方向定義
                phase++;
                break;
            case 1:
                pos += dir * (entry_Speed * speed_save);    //移動
                if (dir == (entryMove[repeat].Target - pos).normalized) { break; }  //目標座標を通過
                phase++;
                break;
            case 2:
                pos += dir * (entry_Speed * speed_save);    //移動
                timer += Time.deltaTime;
                if (timer < entryMove[repeat].Interval) { break; }
                repeat++;
                timer = 0;
                if (repeat == entryMove.Length) //突進回数が指定回数と同値
                {
                    targetPos = Vector2.up * 5.0f;
                    dir = Distance(pos, targetPos).normalized;
                    phase++; break; 
                }
                phase = 0;
                break;
            case 3:
                pos += dir * (speed * speed_save);  //移動
                if (dir == (targetPos - pos).normalized) { break; } //目標座標を通過
                phase++;
                break;
            case 4:
                timer += Time.deltaTime;
                if (timer < 0.5f) { return; }
                entry_RoarEffect.PlayParticle();
                entry_RoarSE.PlayAudio(se);
                setVibration(entry_Vibration * 0.25f);
                timer = 0;
                phase++;
                break;
            case 5:
                VibrationSubtraction(((entry_Vibration * 0.25f) / 60.0f) / entry_RoarTime);
                timer += Time.deltaTime;
                if (timer < entry_RoarTime) { return; }
                entry_RoarEffect.StopParticle();
                setVibration(0);
                phase++;
                break;
            case 6:
                tableNo = Random.Range(0, moveTable.Length);
                moveNo = 0;
                moveType = moveTable[tableNo].Move[moveNo];
                AllVariableClear();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    //8の字移動
    void Eight()
    {
        switch (phase)
        {
            case 0: //威力設定、目標位置、移動方向定義
                circle.Data(eight_Center.x, eight_Center.y, eight_Radius.x, eight_Radius.y, 1.0f, 1.0f, 1, 0);
                targetPos = circle.Move(0, 0);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1: //移動、目標位置到着処理
                pos = Trac(pos, targetPos, dir, speed);
                if (pos == targetPos)
                {
                    circle.Data(eight_Center.x, eight_Center.y, eight_Radius.x, eight_Radius.y, 1.0f, 2.0f);
                    SetAudio(eight_SE, eight_SEVolume, eight_SEPitch, eight_SELoop);
                    phase++;
                }
                break;
            case 2:    //移動処理
                timer += Time.deltaTime;
                pos = circle.Move(timer, eight_Speed);
                if (timer < eight_BreakTime) { return; }
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    
    //旋回行動
    void Rotation()
    {
        switch (phase)
        {
            case 0: //旋回開始位置、移動方向
                circle.Data
                    (rotation_Center.x, rotation_Center.y, rotation_Radius.x, rotation_Radius.y, 1.0f, 1.0f, 1, 0);
                targetPos = circle.Move(0, 0);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1: //移動、旋回開始位置到着→威力設定
                pos = Trac(pos, targetPos, dir, speed);
                if (pos == targetPos)
                {
                    if (rotation != null || rotation.Length != 0)
                    {
                        SetPower(rotation, rotation_Power);
                    }
                    SetAudio(rotation_SE, rotation_SEVolume, rotation_SEPitch, rotation_SELoop);
                    phase = 2;
                }
                break;
            case 2:    //旋回行動、スライム生成時間→生成、指定生成回数達成処理
                timer += Time.deltaTime;
                pos = circle.Move(timer, rotation_Speed);
                if ((timer % slime_GenerateTime) + Time.deltaTime > slime_GenerateTime)
                {
                    //Instantiate(slime, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                    no++;
                    if (no > rotation_SlimeGenerate) { phase++; }
                }
                break;
            case 3: //終了処理
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    int No;
    //上下行動
    void UpDown()
    {
        switch (phase)
        {
            case 0:     //指定中心座標上部、移動方向定義
                targetPos = new Vector2(upDown_Center.x, upDown_Center.y + upDown_Radius.y);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1:     //移動、目標位置到達処理、移動方向再定義
                pos = Trac(pos, targetPos, dir, speed);
                if (pos == targetPos)
                {
                    dir = Distance(pos, pos + Vector2.up).normalized;
                    phase++;
                }
                break;
            case 2:     //指定秒間上部へ移動
                timer += Time.deltaTime;    //タイマー起動
                pos = Trac(pos, dir, speed);       //上に向かう
                if (timer > 1)              //1秒後
                {
                    timer = 0;              //タイマーリセット
                    phase++;
                }
                break;
            case 3: //1フレーム処理
                upDown_Effect.Stop();
                if (upDown != null || upDown.Length != 0)
                {
                    SetPower(upDown, upDown_Power);                             //威力設定
                }
                float width = upDown_Radius.x * 2.0f;                           //幅
                //pos = new Vector2(                                              //突進開始位置定義
                //    (upDown_Center.x - upDown_Radius.x) + ((width / (upDown_AtkTime + 1)) * (repeat + 1)),
                //    (pos.y > upDown_Center.y + upDown_Radius.y) ? upDown_Center.y + upDown_Radius.y : upDown_Center.y - upDown_Radius.y);
                pos = new Vector2(
                    plPos.x,
                    (pos.y > upDown_Center.y + upDown_Radius.y) ? upDown_Center.y + upDown_Radius.y : upDown_Center.y - upDown_Radius.y);
                dir = (pos.y == upDown_Center.y + upDown_Radius.y) ? Vector2.down : Vector2.up; //突進方向定義
                Quaternion q = (dir == Vector2.down) ?
                    Quaternion.Euler(90.0f, 0, 0) : Quaternion.Euler(-90.0f, 0, 0);
                upDown_Effect.transform.localRotation = q;

                float y = (dir == Vector2.down) ?
                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y :
                    groundPosY;
                GameObject p;
                if (y == groundPosY) { p = Instantiate(prediction, new Vector2(plPos.x, y), Quaternion.identity); }
                else { p = Instantiate(prediction, new Vector2(plPos.x, y), Quaternion.identity/*, Camera.main.transform*/); }
                p.GetComponent<SpriteRenderer>().color = upDown_Prediction.Color;
                p.transform.localScale = upDown_Prediction.Scale;
                //SetAudio(upDown_SE, upDown_SEVolume, upDown_SEPitch, upDown_SELoop);
                phase++;
                repeat++;
                no = 0;                                                         //スライム生成回数リセット
                No = 0; //サウンド再生
                break;
            case 4: //繰り返し処理
                pos = Trac(pos, dir, upDown_Speed);   //移動
                if (pos.y > upDown_Center.y + upDown_Radius.y || pos.y < upDown_Center.y - upDown_Radius.y)   //画面上部また下部に出る
                {
                    if (repeat == upDown_AtkTime) { phase++; break; }    //突進実行回数が指示回数と同一の時処理が進む
                    phase--;                                            //↑の条件を満たさない時処理が戻り再定義
                }

                if (dir == Vector2.down)            //移動方向が下
                {
                    if (pos.y < groundPosY)        //地表潜る
                    {
                        if(No == 0)
                        {
                            SetAudio(upDown_InSE, upDown_InSEVolume, upDown_InSEPitch, upDown_InSELoop);
                            No++;

                        }
                        upDown_Effect.Play();
                        upDown_Effect.transform.position = new Vector2
                            (upDown_Effect.transform.position.x, groundPosY + 2.0f);
                        if (no == upDown_SlimeGenerate) { return; }   //スライム生成回数が指示回数と同一
                        //Instantiate(slime, new Vector3(pos.x, groundPosY, 0), Quaternion.identity); //スライム生成
                        no++;                       //スライム生成回数
                    }
                }
                else if (dir == Vector2.up)         //移動方向が上
                {
                    if (pos.y > groundPosY)        //地中から出た
                    {
                        if (No == 0)
                        {
                            SetAudio(upDown_OutSE, upDown_OutSEVolume, upDown_OutSEPitch, upDown_OutSELoop);
                            No++;

                        }
                        upDown_Effect.Play();
                        upDown_Effect.transform.position = new Vector2
                            (upDown_Effect.transform.position.x, groundPosY + 2.0f);
                        if (no == upDown_SlimeGenerate) { return; }   //スライム生成回数が指示回数と同一
                        //Instantiate(slime, new Vector3(pos.x, groundPosY, 0), Quaternion.identity);
                        no++;
                    }
                }
                break;
            case 5: //1フレーム処理
                upDown_Effect.Stop();
                MoveEnd();
                break;
            default:    //1フレーム処理 (行動遷移時初期化用)
                AllVariableClear();
                break;
        }
    }

    //弧を描いてプレイヤーへ突進
    void Rush()
    {
        switch (phase)
        {
            case 0: //目標位置、移動方向定義
                if (plPos.x > eight_Center.x)         //プレイヤーの位置が中央より右
                { targetPos = eight_Center + eight_Radius; }
                else if (plPos.x <= eight_Center.x)   //プレイヤーの位置が中央より左
                { targetPos = eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y); }
                else { Debug.LogError("targetPosがnull"); }
                dir = Distance(pos, targetPos).normalized;
                phase++; break;
            case 1: //移動、目標位置到着処理
                pos = Trac(pos, targetPos, dir, speed * 1.5f);
                if (pos == targetPos)
                {
                    phase++;
                    dir = Distance(pos, pos + Vector2.up).normalized;
                }
                break;
            case 2: //1秒間上に向かう(これいらないかも)
                timer += Time.deltaTime;
                pos = Trac(pos, dir, speed * 2.0f);
                if (timer > 1.0f)
                {
                    pos = new Vector2(eight_Center.x, 100.0f);
                    phase++;
                    timer = 0;
                }
                break;
            case 3:     //突進開始位置に移動
                if (targetPos == eight_Center + eight_Radius)   //右からはけたら
                { pos = eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y) + (Vector2.up * 15.0f); }
                else if (targetPos == eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y))   //左からはけたら
                { pos = eight_Center + eight_Radius + (Vector2.up * 15.0f); }
                phase++;
                break;
            case 4:     //体の向き更新
                timer += Time.deltaTime;
                float moveDir = (targetPos == eight_Center + eight_Radius) ? 1.0f : -1.0f;
                pos += new Vector2(moveDir, -1.0f).normalized * 2.0f * speed_save;
                if (timer < 1.0f) { break; }
                timer = 0;
                phase++;
                break;
            case 5:     //威力設定、攻撃開始位置、プレイヤーの位置、移動方向、移動距離(半径)定義
                if (rush != null || rush.Length != 0)
                {
                    SetPower(rush, rush_Power);
                }
                if (targetPos == eight_Center + eight_Radius)       //右からはけたら左から突進
                { circle.Direction = 1; }
                else if (targetPos == eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y))   //左からはけたら右から突進
                { circle.Direction = -1; }
                circle.RadPos = (circle.Direction == 1) ? 1 : 0;
                circle.Data(plPos.x + rush_Offset.x, plPos.y + rush_Offset.y, rush_Radius.x, rush_Radius.y, 1.0f, 1.0f);
                SetAudio(rush_SE, rush_SEVolume, rush_SEPitch, rush_SELoop);
                rush_Effect.Play();

                float x = (circle.Direction == 1) ?
                    Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).x :
                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
                Quaternion q = Quaternion.Euler(0, 0, 90);
                GameObject p = Instantiate(prediction, new Vector2(x, plPos.y), q/*, Camera.main.transform*/);
                p.GetComponent<SpriteRenderer>().color = rush_Prediction.Color;
                p.transform.localScale = rush_Prediction.Scale;
                //rush_Effect.transform.rotation = new Quaternion(transform.rotation.x, 90, 0, 1);
                phase++;
                break;
            case 6: //移動、終了処理
                pos = circle.Move(timer, rush_Speed);
                timer += Time.deltaTime;
                if (pos.y > circle.Move(0, 0).y + rush_Radius.y / 2.0f)
                {
                    rush_Effect.Stop();
                    MoveEnd();
                }
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void MoveEnd()  //行動終了時処理
    {
        moveNo++;
        if (moveNo == moveTable[tableNo].Move.Length)
        {
            tableNo = Random.Range(0, moveTable.Length);
            moveNo = 0;
        }
        moveType = moveTable[tableNo].Move[moveNo];
        AllVariableClear();
    }

    //腹が上を向かないように
    void BodyRot()
    {
        if ((transform.localEulerAngles.z < 0 && transform.localEulerAngles.z > -180) ||
            (transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 360))
        {
            scale.y = -1.0f;
        }
        else if ((transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 180) ||
            (transform.localEulerAngles.z < -180 && transform.localEulerAngles.z > -360))
        {
            scale.y = 1.0f;
        }
        headObj.transform.localScale = scale;
    }

    public void Damage()
    {
        Debug.Log(gameObject.name + "はダメージ受けた");
        StartCoroutine(Flash());
    }

    void Die()
    {
        Debug.Log(gameObject.name + "は死んだ");
        achv.DefeatedBoss(0);
        moveType = Shoggoth_MoveType.Dead;
        //head.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        head.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log(head.transform.parent.gameObject.name);
        LastParticle = Instantiate(die_Effect[0].Particle.gameObject, 
            head.transform.parent.gameObject.transform.position, Quaternion.identity);
        LastParticle.GetComponent<ParticleSystem>().Play();
        for (int i = 0; i < body.Length; i++)
        {
            //body[i].transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            body[i].transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            LastParticle = Instantiate(die_Effect[1].Particle.gameObject,
                body[i].transform.parent.gameObject.transform.position, Quaternion.identity);
            LastParticle.GetComponent<ParticleSystem>().Play();
        }
        //tail.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        tail.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        LastParticle = Instantiate(die_Effect[2].Particle.gameObject,
            tail.transform.parent.gameObject.transform.position, Quaternion.identity);
        LastParticle.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < slimeObj.Count; i++)
        {
            Destroy(slimeObj[i]);
        }
    }

    float slimeTimer = 0;
    void SlimeGene()
    {
        if (slime_MaxNum <= slimeObj.Count) { return; }
        slimeTimer += Time.deltaTime;
        if (slimeTimer < slime_GenerateTime) { return; }
        int slimePos = Random.Range(1, sRig.Model.Length);

        if (GameObject.Find(slime.name) != null) { return; }
        Transform bodyTF = sRig.Model[slimePos].transform;
        GameObject s = Instantiate(slime, bodyTF.position, bodyTF.rotation);
        s.GetComponent<Slime>().Root = sRig.Model[slimePos];
        slimeObj.Add(s);
        slimeTimer = 0;
    }

    //----------各種データ管理----------
    void AllVariableClear()     //変数初期化
    {
        GeneralVariableClear();
        PowerReset();

        //円
        circle.DataClear();
    }

    void GeneralVariableClear() //汎用変数初期化
    {
        phase = 0;
        timer = 0;
        repeat = 0;
        no = 0;
    }

    void PowerReset()        //威力初期化
    {
        SetPower(head, head_Power);
        SetPower(body, body_Power);
        SetPower(tail, tail_Power);
    }

    IEnumerator Flash()
    {
        while (damage_Repeat < damage_Number)
        {
            head.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = damage_Color;
            for (int i = 0; i < body.Length; i++)
            {
                body[i].transform.parent.gameObject.GetComponent<SpriteRenderer>().color = damage_Color;
            }
            tail.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = damage_Color;
            for (int i = 0; i < slimeObj.Count; i++)
            {
                slimeObj[i].GetComponent<SpriteRenderer>().color = damage_Color;
            }
            //待つ
            yield return new WaitForSeconds(damage_Time);
            head.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = defColor;
            for (int i = 0; i < body.Length; i++)
            {
                body[i].transform.parent.gameObject.GetComponent<SpriteRenderer>().color = defColor;
            }
            tail.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = defColor;
            for (int i = 0; i < slimeObj.Count; i++)
            {
                slimeObj[i].GetComponent<SpriteRenderer>().color = defColor;
            }
            //待つ
            yield return new WaitForSeconds(damage_Time);
            damage_Repeat++;
        }
        damage_Repeat = 0;
    }

    float GroundPosition(float axisX)
    {
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D rayHit =
            Physics2D.Raycast(new Vector2(axisX, eight_Center.y + eight_Radius.y), Vector2.down,
            eight_Center.y + eight_Radius.y * 5.0f, layerMask);  //光線発射
        Debug.DrawRay(new Vector2(axisX, eight_Center.y + eight_Radius.y),
            Vector2.down * (eight_Center.y + eight_Radius.y) * 5.0f, Color.green, 1.0f);
        if (rayHit.collider.tag == "Ground")
        {
            Vector2 groundPos = rayHit.point;   //地面位置確認
            return groundPos.y;
        }
        Debug.LogError(axisX + "に地面はない");
        return 0;
    }

    //距離
    Vector2 Distance(Vector2 currentPos, Vector2 targetPos)
    {
        Vector2 distance = targetPos - currentPos;
        return distance;
    }

    //追尾
    Vector2 Trac(Vector2 pos, Vector2 direction, float speed)
    {
        pos += direction * (speed * speed_save);
        return pos;
    }

    //追尾2   目標位置で止まる
    Vector2 Trac(Vector2 pos, Vector2 targetPos, Vector2 direction, float speed)
    {
        pos += direction * (speed * speed_save);
        if (Distance(pos, targetPos).normalized == direction * -1.0f)
        {
            pos = targetPos;
        }
        return pos;
    }

    //移動方向(移動前の位置,移動後の位置)
    Quaternion MoveDirection(Vector2 before, Vector2 after)
    {
        Vector2 dir = after - before;
        rot = Quaternion.FromToRotation(Vector3.up, dir);
        headObj.transform.localScale = scale;
        return rot;
    }

    void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<HitData>().Power = power;
    }

    void SetPower(GameObject[] obj, float power)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].GetComponent<HitData>().Power = power;
        }
    }

    CinemachineBasicMultiChannelPerlin vCamera2;
    Volume v;
    MotionBlur b;
    void setVibration(float vibration)  //画面振動
    {
        CinemachineVirtualCamera vCamera = mainCamera.GetComponent<CinemachineVirtualCamera>();
        vCamera2 = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamera2.m_AmplitudeGain = vibration;

        v = GameObject.Find("Volume").GetComponent<Volume>();
        v.profile.TryGet(out b);
        b.intensity.value = vibration;
    }
    void VibrationSubtraction(float value)
    {
        vCamera2.m_AmplitudeGain -= value;
        b.intensity.value -= value;
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

    //----------ギズモ----------
    private void OnDrawGizmos()
    {
        if (eight_MoveRangeDisplay) { DrawWireGizmo(eight_Center, eight_Radius * 2, Color.white); }
        if (rotation_MoveRangeDisplay) { DrawWireGizmo(rotation_Center, rotation_Radius * 2, Color.red); }
        if (upDown_MoveRangeDisplay) { DrawWireGizmo(upDown_Center, upDown_Radius * 2, Color.green); }
        if (rush_MoveRangeDisplay) { DrawWireGizmo(plPos + rush_Offset, rush_Radius * 2, Color.blue); }
    }

    void DrawWireGizmo(Vector2 center, Vector2 size, Color color)
    {
        plPos = pl.transform.position;
        Gizmos.color = color;
        Gizmos.DrawWireCube(center, size);
    }
}

[System.Serializable]
public class Shoggoth_MoveTable
{
    [SerializeField] string name;
    [SerializeField] Shoggoth_MoveType[] move;

    public string Name { get { return name; } }
    public Shoggoth_MoveType[] Move { get { return move; } }
}

[System.Serializable]
public class Shoggoth_EntryMove
{
    [SerializeField, Tooltip("スタート座標")] Vector2 start;
    [SerializeField, Tooltip("目標座標")] Vector2 target;
    [SerializeField, Tooltip("間隙")] float interval;

    public Vector2 Start { get { return start; } }
    public Vector2 Target { get { return target; } }
    public float Interval { get { return interval; } }
}