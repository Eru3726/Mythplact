using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using SY;

public partial class Player : MonoBehaviour
{
    Vector3 inputDir = Vector3.zero;
    Vector3 dir;
    Rigidbody2D PlayerRb;

    [SerializeField,Tooltip("最高速度")] int maxSpeed;              // プレイヤーの最高速度
    [SerializeField, Tooltip("ジャンプ力")] float jumpPow;             // ジャンプ時に加える力
    [SerializeField, Tooltip("ダブルジャンプ力")] float doubleJumpPow;       // ダブルジャンプ時に加える力
    [SerializeField, Tooltip("ため攻撃の溜め時間")] float chargeAttackTime;
    [SerializeField, Tooltip("スタミナの最大値")] float maxStamina;            // スタミナの最大値
    [SerializeField, Tooltip("スタミナの回復速度")] float healStamina;         // スタミナの回復速度
    [SerializeField, Tooltip("ブリンクの消費スタミナ")] float brinkStamina;    // ブリンクの消費スタミナ(瞬時)
    [SerializeField, Tooltip("ガードの消費スタミナ(毎時)")] float guardStamina;     // ガード時の消費スタミナ(毎秒)
    [SerializeField, Tooltip("ブリンクの距離")] float brinkMove;    // ブリンクの距離
    [SerializeField, Tooltip("ブリンクのクールタイム")] float brinkCoolTimeSec;    // ブリンクのクールタイム
    [SerializeField, Tooltip("ガードのクールタイム")] float guardCoolTimeSec;    // ガードのクールタイム
    [SerializeField, Tooltip("ジャストガードの許容時間")] float justGuardTime;
    [SerializeField, Tooltip("ノックバック時間")] float knockbuckTime;  // ノックバックする時間
    [SerializeField, Tooltip("ジャンプ下攻撃のCT")]float atkJumpDownCT;
    [SerializeField, Tooltip("ジャンプ上攻撃のCT")] float atkJumpUpCT;



    SpriteRenderer plsp;
    Image brinkSlider;
    float jumpPowPlus;
    float attackCount = 0;
    float atkJumpDownCount = 0;
    float atkJumpUpCount = 0;
    float brinkCTCount = 0;            // ブリンクのクールダウンのカウント
    float guardCTCount = 0;             // ガードのクールタイムのカウント
    float guardCount = 0;
    float knockbuckCount = 0;        // ノックバックする時間のカウント
    float damageBlinkCount = 0;
    float stamina = 0;              // 現在のスタミナの値

    bool jumping = false;       // ジャンプ落下時の判定
    bool doublejump = false;    // ダブルジャンプ使用判定
    bool isbrinkUp;             // ジャンプ時のブリンク判定 
    bool isbrink;               // ブリンクのクールタイム判定
    bool canGuard;              // ガードのクールタイム判定
    bool speedreset;            // 切り返し時の速度リセット判定
    bool attack;                // 攻撃判定
    bool guardbreak;            // ガードスタミナ使い切り時のboolian
    bool ltDown;
    bool rtDown;
    bool ltup;
    bool rtup;

    bool deadStop;
    bool gameover;
    bool isAttack;
    bool isGuard;
    bool guardEnd;
    bool attackEnd;
    bool normalAttack;
    bool chargeAttack;
 
    bool space;
    bool spaceDown;
    bool guard;
    bool brink;
    bool skill1;
    bool skill2;
    bool skill3;
    bool skill4;

    bool deathDirection;

    bool shoggothDeadAchvOnce;
    bool fafnirDeadAchvOnce;
    bool qilinDeadAchvOnce;

    bool achvNoGuard;
    float achvComboTime = 0;
    int achvComboCount;

    private readonly AchvMeasurement achv = new AchvMeasurement();

    HitMng HMng;
    AtkJumpDown atkJumpDown;
    DeadEffectEnd deadEffectEnd;
    Controllerconnect conconect;
    Keyconfig keycon;


    [SerializeField, Header("攻撃")]
    private InputActionReference attackInp;

    [SerializeField, Header("防御")]
    private InputActionReference guardInp;

    [SerializeField, Header("右移動")]
    private InputActionReference rightInp;

    [SerializeField, Header("左移動")]
    private InputActionReference leftInp;

    [SerializeField, Header("上入力")]
    private InputActionReference upInp;

    [SerializeField, Header("下入力")]
    private InputActionReference downInp;


    [SerializeField, Header("ジャンプ")]
    private InputActionReference jumpInp;

    [SerializeField, Header("ブリンク")]
    private InputActionReference blinkInp;

    [SerializeField, Header("スキル1")]
    private InputActionReference skill1Inp;

    [SerializeField, Header("スキル2")]
    private InputActionReference skill2Inp;

    [SerializeField, Header("スキル3")]
    private InputActionReference skill3Inp;

    [SerializeField, Header("スキル4")]
    private InputActionReference skill4Inp;


    public bool IsGuard { get { return isGuard; } set { isGuard = value; } }

    public bool GameOver { get { return gameover; } set { gameover = value; } }


    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();

        conconect = GameObject.Find("keycon").GetComponent<Controllerconnect>();
        keycon = GameObject.Find("keycon").GetComponent<Keyconfig>();
        HMng = GetComponent<HitMng>();
        plsp = gameObject.GetComponent<SpriteRenderer>();
        atkJumpDown = transform.GetChild(4).GetComponent<AtkJumpDown>();
        deadEffectEnd = transform.GetChild(7).GetComponent<DeadEffectEnd>();
        brinkSlider = GameObject.Find("UI/BrinkGauge/Gauge").GetComponent<Image>();

        deadStop = false;
        AchvInit();

        InitCol();
        InitAudio();
        InitAnim();
        InitEffect();

    }
    void Start()
    {
        PlayerRb.gravityScale = 7;
        dir.x = 1;
        stamina = maxStamina;

        InitHP();
        PassiveSkillStart();


        //有効化
        attackInp.action.Enable();
        guardInp.action.Enable();
        rightInp.action.Enable();
        leftInp.action.Enable();
        upInp.action.Enable();
        downInp.action.Enable();
        jumpInp.action.Enable();
        blinkInp.action.Enable();
        skill1Inp.action.Enable();
        skill2Inp.action.Enable();
        skill3Inp.action.Enable();
        skill4Inp.action.Enable();

        // 実績
        if(!GameData.ShoggothDead && !GameData.FafnirDead && !GameData.QilinDead)
        {
            shoggothDeadAchvOnce = false;
            fafnirDeadAchvOnce = false;
            qilinDeadAchvOnce = false;
        }
    }

    void Update()
    {
        if (!gameover || !deadStop)
        {
            HMng.HitUpdate();

            CheckGround();  // 地面にいるかの判定

            MoveInput();        // 入力
            MoveController();   // プレイヤー操作
            ActiveSkillController();    // スキル管理
            ActiveSkillUpdate();
            PassiveSkillUpdate();       // 動的に発動条件が変わるパッシブスキルの管理
                                //EnemyLockon();      
            ChangeAnim();       // アニメーション管理

            CheckRightHit();
            CheckLeftHit();

            DamageReaction();   // 攻撃ヒット時のリアクション

            PlayerAchv();   // 実績の開放


            HMng.PostUpdate();
        }
    }

    void MoveInput()
    {
#if false
        //if (conconect.ConConnect == true)
        //{
        //    float lsh = Input.GetAxis("L_stick_H");　　　　//左スティック横
        //    float lsv = Input.GetAxis("L_stick_V");        //左スティック縦



        //    if (lsh > 0)
        //    {
        //        inputDir.x = 1;
        //    }
        //    else if(lsh < 0)
        //    {
        //        inputDir.x = -1;
        //    }
        //    else
        //    {
        //        inputDir.x = 0;
        //    }

        //    if (lsv > 0.1f)
        //    {
        //        inputDir.y = 1;
        //    }
        //    else if (lsv < -0.1f)
        //    {
        //        inputDir.y = -1;
        //    }
        //    else
        //    {
        //        inputDir.y = 0;
        //    }
        //    if (Input.GetKeyDown(GameData.rightkey) || Input.GetKeyDown(GameData.leftkey) || lsh == 0)
        //    {
        //        speedreset = true;
        //    }
        //    else
        //    {
        //        speedreset = false;
        //    }
        //    if (GameData.jumpkey == (KeyCode)CustomKeycode.LT)  // Lトリガー使用時のジャンプ
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if(lt > 0 && !ltDown)
        //        {
        //            spaceDown = true;
        //            ltDown = true;
        //        }
        //        else
        //        {
        //            spaceDown = false;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //        }
        //    }
        //    else if(GameData.jumpkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if(rt > 0 && !rtDown)
        //        {
        //            spaceDown = true;
        //            rtDown = true;
        //        }
        //        else
        //        {
        //            spaceDown = false;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //        }

        //    }

        //    else
        //    {
        //        if (Input.GetKeyDown(GameData.jumpkey))
        //        {
        //            spaceDown = true;
        //        }
        //        else
        //        {
        //            spaceDown = false;
        //        }

        //    }

        //    if (GameData.jumpkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        Debug.Log("ltAxis = " + lt);

        //        if (lt > 0)
        //        {
        //            space = true;
        //        }
        //        else
        //        {
        //            space = false;
        //        }

        //    }
        //    else if (GameData.jumpkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        Debug.Log("rtAxis = " + rt);

        //        if (rt > 0)
        //        {
        //            space = true;
        //        }
        //        else
        //        {
        //            space = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKey(GameData.jumpkey))
        //        {
        //            space = true;
        //        }
        //        else
        //        {
        //            space = false;
        //        }

        //    }
        //    if (GameData.dashkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if (lt > 0 && !ltDown)
        //        {
        //            brink = true;
        //            ltDown = true;
        //        }
        //        else
        //        {
        //            brink = false;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //        }

        //    }
        //    else if (GameData.dashkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if (rt > 0 && !rtDown)
        //        {
        //            brink = true;
        //            rtDown = true;
        //        }
        //        else
        //        {
        //            brink = false;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKeyDown(GameData.dashkey))
        //        {
        //            brink = true;
        //        }
        //        else
        //        {
        //            brink = false;
        //        }

        //    }
        //    if (GameData.attackkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if (lt > 0 && !ltDown)
        //        {
        //            attack = true;
        //            ltDown = true;
        //        }
        //        else
        //        {
        //            attack = false;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //        }

        //    }
        //    else if (GameData.attackkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if (rt > 0 && !rtDown)
        //        {
        //            attack = true;
        //            rtDown = true;
        //        }
        //        else
        //        {
        //            attack = false;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKey(GameData.attackkey))
        //        {
        //            attack = true;
        //        }
        //        else
        //        {
        //            attack = false;

        //        }
        //    }
        //    if (GameData.downkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        Debug.Log("ltAxis = " + lt);

        //        if (lt > 0)
        //        {
        //            guard = true;
        //        }
        //        else
        //        {
        //            guard = false;
        //        }
        //    }
        //    else if (GameData.downkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        Debug.Log("rtAxis = " + rt);

        //        if (rt > 0)
        //        {
        //            guard = true;
        //        }
        //        else
        //        {
        //            guard = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKey(GameData.downkey))
        //        {
        //            guard = true;
        //        }
        //        else
        //        {
        //            guard = false;
        //        }

        //    }

        //    if (GameData.downkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if (lt > 0 && !ltDown)
        //        {
        //            guardEnd = false;
        //            ltDown = true;
        //        }
        //        else if(!ltup)
        //        {
        //            guardEnd = true;
        //            ltup = true;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //            ltup = false;
        //            guardEnd = false;
        //        }


        //    }
        //    else if (GameData.downkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if (rt > 0 && !ltDown)
        //        {
        //            guardEnd = false;
        //            rtDown = true;
        //        }
        //        else if (!rtup)
        //        {
        //            guardEnd = true;
        //            rtup = true;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //            rtup = false;
        //            guardEnd = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKeyUp(GameData.downkey))
        //        {
        //            guardEnd = true;
        //        }
        //        else
        //        {
        //            guardEnd = false;
        //        }

        //    }
        //    if (GameData.healkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if (lt > 0 && !ltDown)
        //        {
        //            skill1 = true;
        //            ltDown = true;
        //        }
        //        else
        //        {
        //            skill1 = false;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //        }

        //    }
        //    else if (GameData.healkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if (rt > 0 && !rtDown)
        //        {
        //            skill1 = true;
        //            rtDown = true;
        //        }
        //        else
        //        {
        //            skill1 = false;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKeyDown(GameData.healkey))
        //        {
        //            skill1 = true;
        //        }
        //        else
        //        {
        //            skill1 = false;
        //        }

        //    }


        //    if (GameData.interactkey == (KeyCode)CustomKeycode.LT)
        //    {
        //        float lt = Input.GetAxis("LT");

        //        if (lt > 0 && !ltDown)
        //        {
        //            skill2 = true;
        //            ltDown = true;
        //        }
        //        else
        //        {
        //            skill2 = false;
        //        }
        //        if (lt == 0)
        //        {
        //            ltDown = false;
        //        }

        //    }
        //    else if (GameData.interactkey == (KeyCode)CustomKeycode.RT)
        //    {
        //        float rt = Input.GetAxis("RT");

        //        if (rt > 0 && !rtDown)
        //        {
        //            skill2 = true;
        //            rtDown = true;
        //        }
        //        else
        //        {
        //            skill2 = false;
        //        }
        //        if (rt == 0)
        //        {
        //            rtDown = false;
        //        }

        //    }
        //    else
        //    {
        //        if (Input.GetKeyDown(GameData.interactkey))
        //        {
        //            skill2 = true;
        //        }
        //        else
        //        {
        //            skill2 = false;
        //        }

        //    }



        //}
        // キーボード時のインプット
        //else
        //{
#endif
        if (rightInp.action.WasPressedThisFrame() || leftInp.action.WasPressedThisFrame())
        {
            speedreset = true;
        }
        else
        {
            speedreset = false;
        }
        if (rightInp.action.IsPressed())
        {
            inputDir.x = 1;
        }
        else if (leftInp.action.IsPressed())
        {
            inputDir.x = -1;
        }
        else
        {
            inputDir.x = 0;
        }
        if (upInp.action.IsPressed())
        {
            inputDir.y = 1;
        }
        else if (downInp.action.IsPressed())
        {
            inputDir.y = -1;

        }
        else
        {
            inputDir.y = 0;
        }

        if (jumpInp.action.WasPressedThisFrame())
        {
            spaceDown = true;
        }
        else
        {
            spaceDown = false;
        }
        if (jumpInp.action.IsPressed())
        {
            space = true;
        }
        else
        {
            space = false;
        }
        if (blinkInp.action.WasPressedThisFrame())
        {
            brink = true;
        }
        else
        {
            brink = false;
        }
        if (attackInp.action.IsPressed())
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
        if (attackInp.action.WasReleasedThisFrame())
        {
            attackEnd = true;
        }
        else
        {
            attackEnd = false;

        }
        if (guardInp.action.IsPressed())
        {
            guard = true;
        }
        else
        {
            guard = false;
        }
        if (guardInp.action.WasReleasedThisFrame())
        {
            guardEnd = true;
        }
        else
        {
            guardEnd = false;
        }
        if (skill1Inp.action.WasPressedThisFrame())
        {
            skill1 = true;
        }
        else
        {
            skill1 = false;
        }

        if (skill2Inp.action.WasPressedThisFrame())
        {
            skill2 = true;
        }
        else
        {
            skill2 = false;
        }
        if (skill3Inp.action.WasPressedThisFrame())
        {
            skill3 = true;
        }
        else
        {
            skill3 = false;
        }
        if (skill4Inp.action.WasPressedThisFrame())
        {
            skill4 = true;
        }
        else
        {
            skill4 = false;
        }


        //}

    }
    void MoveController()
    {
        int speed;

        if (isGround)
        {
            jumping = false;       // 大ジャンプ判定
            doublejump = false;    // ダブルジャンプ判定
            isbrinkUp = false;     // 空中ブリンク判定]

            // ジャンプ
            if (spaceDown && !isGuard && !isSkill && !isAttack &&!hitAnim)
            {
                PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, 0);
                PlayerRb.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);

                JumpSE();
            }
            // 滑り止め
            if(inputDir.x == 0)
            {
                PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);

            }
        }
        // 切り返しで速度リセット
        if (speedreset)
        {
            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);
        }

        // 二段ジャンプ
        if (spaceDown && doublejump && !isGuard && !isSkill && !isAttack && !hitAnim)
        {
            doublejumpAnim = true;
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, 0);
            PlayerRb.AddForce(Vector2.up * doubleJumpPow, ForceMode2D.Impulse);
            doublejump = false;

            JumpEffect();
            JumpSE();

        }
        else
        {
            doublejumpAnim = false;
        }
        // speed(加速度)
        if (inputDir.magnitude != 0)
         {
            speed = 8000;
            dir.x = inputDir.x;
        }
        else
        {
            speed = 0;
        }
        // 長押しでジャンプ高さアップ
        if (space && !jumping && PlayerRb.velocity.y > 0 )  
        {
            jumpPowPlus = 30;
            doublejump = true;

        }
        else
        {
            jumpPowPlus = 0;
            jumping = true;
        }

        PlayerRb.AddForce(Vector2.up * jumpPowPlus);

        // ジャンプ下攻撃ヒットでジャンプ
        if(atkJumpDown.HitAtkJumpDown == true)
        {
            hitJumpDown = true;     // アニメーション移行判定
            doublejump = true;    // ダブルジャンプ判定
            isbrinkUp = false;     // 空中ブリンク判定

            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, 0);
            PlayerRb.AddForce(Vector2.up * doubleJumpPow, ForceMode2D.Impulse);

            atkJumpDown.HitAtkJumpDown = false;
            canHitDown = false;
        }

        atkJumpDownCount += Time.deltaTime;
        if(atkJumpDownCT <= atkJumpDownCount)
        {
            canHitDown = true;
        }
        atkJumpUpCount += Time.deltaTime;
        if(atkJumpUpCT <= atkJumpUpCount)
        {
            canHitUp = true;
        }

        // 移動速度
        if (PlayerRb.velocity.magnitude <= maxSpeed)
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, PlayerRb.velocity.y);
        }
        else
        {
            if (PlayerRb.velocity.x >= maxSpeed)
            {
                PlayerRb.velocity = new Vector2(maxSpeed, PlayerRb.velocity.y);
            }
            else if (PlayerRb.velocity.x <= -maxSpeed)
            {
                PlayerRb.velocity = new Vector2(-maxSpeed, PlayerRb.velocity.y);
            }
        }

        // プレイヤーの移動

        if (!isAttack && !isGuard && !isSkill && !isCharge && !hitAnim && !attack) {
            PlayerRb.AddForce(Vector2.right * inputDir.x * speed * Time.deltaTime);            // プレイヤーの移動
        }

        // プレイヤーの向き
        
        if (dir.x != 0 && !isAttack && !isGuard && !hitAnim && !isSkill)
        {
            transform.localScale = new Vector3(dir.x, 1, 1);
        }



        // 空中ブリンク
        if (brink && !isGround && !isbrink && !isbrinkUp && !isAttack && !isGuard && !hitAnim && !isSkill && !isCharge && stamina >= brinkStamina)
        {

            BrinkEffect();
            BrinkSE();
            achv.UseBlink();

            transform.position = new Vector3(transform.position.x + (brinkMove * dir.x), transform.position.y, 0);
            PlayerRb.velocity = new Vector2(0, 0);

            BrinkEffect();

            stamina -= brinkStamina;

            isbrink = true;
            isbrinkUp = true;
            brinkCTCount = 0;
        }
        // 地上ブリンク
        if(brink && isGround && !isbrink && !isAttack && !isGuard && !hitAnim && !isSkill && !isCharge && stamina >= brinkStamina)
        {
            BrinkEffect();
            BrinkSE();
            achv.UseBlink();

            transform.position = new Vector3(transform.position.x + (brinkMove * dir.x), transform.position.y, 0);
            PlayerRb.velocity = new Vector2(0, 0);
            BrinkEffect();

            stamina -= brinkStamina;


            isbrink = true;
            brinkCTCount = 0;

        }
        // ブリンクのクールタイム
        if (isbrink && !isGuard)
        {
            brinkCTCount += Time.deltaTime;
            if(brinkCTCount >= brinkCoolTimeSec)
            {
                isbrink = false;
                brinkCTCount = 0;
            }
        }

        //if (isbrink)
        //{
        //    brinkSlider.fillAmount = brinkCount / brinkCoolTimeSec;

        //}
        //else
        //{
        //    brinkSlider.fillAmount = 1;
        //}
        


        if (isAttack)
        {
            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);
        }
        if (HMng.CheckDamage())
        {
            HitStopManager.hitstop.StartHitStop(0.1f);

        }      
        // スタミナの処理 
        if (maxStamina > stamina)
        {
            if (!IsGuard)
            {
                stamina += Time.deltaTime * healStamina;

            }
            brinkSlider.fillAmount = stamina / maxStamina;
        }
        else
        {
            stamina = maxStamina;
            brinkSlider.fillAmount = 1;

            guardbreak = false;
        }



        if (guard && !attack && !isAttack && !isSkill && !isCharge && !hitAnim && canGuard && !guardbreak)
        {
            isGuard = true;

            achvNoGuard = false;
        }
        else        // ガードのクールタイム
        {
            isGuard = false;
            guardCount = 0;
            guardCTCount += Time.deltaTime;
            if (guardCTCount >= guardCoolTimeSec)
            {
                canGuard = true;
                guardCTCount = 0;
            }



        }
        if (isGuard)
        {

            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);

            HMng.DEF = 10000;

            stamina -= guardStamina * Time.deltaTime;
            guardCount += Time.deltaTime;
            if (!EffectGuard.isPlaying)
            {
                EffectGuard.Play();
                GuardSE();
            }


            if(stamina > 0)
            {
                // 普通のガード 
                if (HMng.CheckDamage() == true)
                {
                    
                    stamina -= 50;
                    audioSource.PlayOneShot(guardHitSE);
                    achv.GuardNum();
                    EffectGuardBreak.Play();
                    //guardCount = 0;
                    //canGuard = false;
                    //guardCTCount = 0;

                    //isGuard = false;
                }

            }
            
            else
            {
                guardCTCount = 0;
                canGuard = false;

                guardbreak = true;  // ガードブレイクし、スタミナ最大までガード不可
                audioSource.PlayOneShot(guardbreakSE);
                EffectGuardBreak.Play();

                isGuard = false;


            }

            if (justGuardTime > guardCount)
            {
                if (HMng.CheckDamage() == true)
                {
                    Debug.Log("ジャストガード成功");
                    achv.JustGuardNum();

                    GameData.justGuardCount++;
                    EffectJustGuard.Play();
                    audioSource.PlayOneShot(justguardSE);
                    //guardCount = 0;
                    HitStopManager.hitstop.StartHitStop(0.3f);

                    stamina += 30;
                    //canGuard = false;
                    //guardCTCount = 0;

                    if (HMng.HP < HMng.MaxHP && HMng.HP > 0)
                    {
                        SkillWise();
                    }

                }
            }

        }
        else
        {
            HMng.DEF = 1;

            EffectGuard.Stop();
            EffectGuard.Clear();
            EffectJustGuard.Stop();
            EffectGuardBreak.Stop();

            if (guardEnd)
            {
                canGuard = false;
            }


        }

        if (HMng.HP <= 0)
        {
            PlayerRb.velocity = new Vector2(0, 0);
            PlayerRb.gravityScale = 0;
            deadStop = true;
            if(deathDirection == false)
            {
                EffectDeath.Play();
                audioSource.PlayOneShot(deadSE);
                achv.PlayerDie();
                deathDirection = true;
                SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.enabled = false;

            }
            else
            {


                if (deadEffectEnd.DeadEffectStoped)
                {


                    gameover = true;
                    deadStop = false;
                }

            }

        }


        if (RestManager.heal)
        {
            EffectHeal.Play();
            HMng.HP = HMng.MaxHP;
            RestManager.heal = false;
        }
    }

    void AttackReset()
    {
        normalAttack = false;
        chargeAttack = false;
    }
    void DamageReaction()
    {
        Animation anim;

        anim = gameObject.GetComponent<Animation>();
        Debug.Log(hitAnim + "HitAnim");


        // ノックバック
        if (HMng.CheckDamage() == true && !isGuard)
        {
            hitAnim = true;
            knockbuckCount = 0;
            GameData.HitCount++;
            PlayerRb.gravityScale = 7f;

            HitSE();
            EffectDamage.Play();

            PlayerRb.velocity = Vector2.zero;
            PlayerRb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);

            if (CheckRightHit() == true)
            {
                PlayerRb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
            }
            else if (CheckLeftHit() == true)
            {

                PlayerRb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);

            }
            HitStopManager.hitstop.StartHitStop(0.2f);
        }
        else
        {
            EffectDamage.Stop();

        }
        if (hitAnim == true)
        {

            knockbuckCount += Time.deltaTime;

            damageBlinkCount += Time.deltaTime;
            if(damageBlinkCount > 0.1f)
            {
                plsp.color = new Color(1, 1, 1, 0);
                damageBlinkCount = 0;

            }
            else if(damageBlinkCount > 0.05f)
            {
                plsp.color = new Color(1, 1, 1, 1);

            }
            if (knockbuckCount >= knockbuckTime /*  || isGround*/)
            {
                hitAnim = false;
                plsp.color = new Color(1, 1, 1, 1);

            }

        }



    }
    
    void AchvInit()
    {
        achvNoGuard = true;
    }
    void PlayerAchv()
    {
        if (GameData.ShoggothDead && !shoggothDeadAchvOnce)
        {

            if (GameData.HitCount == 0) achv.NoDamageClear();

            if (GameData.ClearTime < AchvManager.instance.timeAttackCount) achv.TimeAttack();

            if (HMng.HP == 1) achv.OneHpClear();

            if (settingPassive == false) achv.ActiveSkillOnlyClear();

            if (achvNoGuard == true) achv.NoGuardClear();

            shoggothDeadAchvOnce = true;
        }
        if(GameData.FafnirDead && !fafnirDeadAchvOnce)
        {
            if (GameData.HitCount == 0) achv.NoDamageClear();

            if (GameData.ClearTime < AchvManager.instance.timeAttackCount) achv.TimeAttack();

            if (HMng.HP == 1) achv.OneHpClear();

            if (settingPassive == false) achv.ActiveSkillOnlyClear();

            if (achvNoGuard == true) achv.NoGuardClear();

            fafnirDeadAchvOnce = true;
        }

        if (GameData.QilinDead && !qilinDeadAchvOnce)
        {
            if (GameData.HitCount == 0) achv.NoDamageClear();

            if (GameData.ClearTime < AchvManager.instance.timeAttackCount) achv.TimeAttack();

            if (HMng.HP == 1) achv.OneHpClear();

            if (settingPassive == false) achv.ActiveSkillOnlyClear();

            if (achvNoGuard == true) achv.NoGuardClear();

            qilinDeadAchvOnce = true;
        }

        achvComboTime += Time.deltaTime;
        if (HMng.CheckAttack())
        {
            achvComboCount++;
            achvComboTime = 0;
        }
        if(achvComboTime >= SkillLoneComboSpan || HMng.CheckDamage())
        {
            achvComboCount = 0;
        }

        if (achvComboCount >= 10) achv.AttackCombo();

    }
    void EnemyLockon()
    {
        // プレイヤーの向き
        GameObject[] TargetEnemy;
        int EnemyCount;

        TargetEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCount = TargetEnemy.Length;

        Debug.Log("エネミー数" + EnemyCount);
        if(EnemyCount != 0)
        {
            if (TargetEnemy[0].transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

        }
        else
        {
            if (dir.x != 0)
            {
                transform.localScale = new Vector3(dir.x, 1, 1);    // プレイヤーの向き
            }

        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Ground")
        {
            LandingSE();
        }
    }


}