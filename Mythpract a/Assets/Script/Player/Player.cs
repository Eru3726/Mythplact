using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SY;

public partial class Player : MonoBehaviour
{
    Vector3 inputDir = Vector3.zero;
    Vector3 dir;
    Rigidbody2D PlayerRb;

    [SerializeField,Tooltip("�ō����x")] int maxSpeed;              // �v���C���[�̍ō����x
    [SerializeField, Tooltip("�W�����v��")] float jumpPow;             // �W�����v���ɉ������
    [SerializeField, Tooltip("�_�u���W�����v��")] float doubleJumpPow;       // �_�u���W�����v���ɉ������
    [SerializeField, Tooltip("�u�����N�̋���")] float brinkMove;    // �u�����N�̃N�[���^�C��
    [SerializeField, Tooltip("�u�����N�̃N�[���^�C��")] float brinkCoolTimeSec;    // �u�����N�̃N�[���^�C��
    [SerializeField, Tooltip("�X�L���̃N�[���^�C��")] float skillCoolTimeSec;    // �u�����N�̃N�[���^�C��
    [SerializeField, Tooltip("�K�[�h�̎�������")] float guardTime;
    [SerializeField, Tooltip("�W���X�g�K�[�h�̋��e����")] float justGuardTime;
    [SerializeField, Tooltip("�K�[�h�̃N�[���^�C��")] float guardCoolTime;
    [SerializeField, Tooltip("�m�b�N�o�b�N����")] float knockbuckTime;  // �m�b�N�o�b�N���鎞��
    Image brinkSlider;
    float jumpPowPlus;
    float brinkCount = 0;            // �u�����N�̃N�[���_�E���̃J�E���g
    float guardCount = 0;
    float skillCount = 0;
    float knockbuckCount = 0;        // �m�b�N�o�b�N���鎞�Ԃ̃J�E���g

    bool jumping = false;       // �W�����v�������̔���
    bool doublejump = false;    // �_�u���W�����v�g�p����
    bool isbrinkUp;             // �W�����v���̃u�����N���� 
    bool isbrink;               // �u�����N�̃N�[���^�C������
    bool speedreset;            // �؂�Ԃ����̑��x���Z�b�g����
    bool attack;                // �U������
    bool ltDown;
    bool rtDown;
    bool ltup;
    bool rtup;

    bool gameover;
    bool isAttack;
    bool isGuard;
    bool guardEnd;
 
    bool space;
    bool spaceDown;
    bool guard;
    bool brink;
    bool skill1;
    bool skill2;

    bool deathDirection;

    HitMng HMng;
    Controllerconnect conconect;
    Keyconfig keycon;

    public bool IsGuard { get { return isGuard; } set { isGuard = value; } }

    public bool GameOver { get { return gameover; } set { gameover = value; } }


    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();

        conconect = GameObject.Find("keycon").GetComponent<Controllerconnect>();
        keycon = GameObject.Find("keycon").GetComponent<Keyconfig>();
        HMng = GetComponent<HitMng>();
        brinkSlider = GameObject.Find("UI/BrinkGauge/Gauge").GetComponent<Image>();

        InitCol();
        InitAudio();
        InitAnim();
        InitEffect();
        PassiveSkillStart();

    }
    void Start()
    {
        dir.x = 1;
        InitHP();

    }

    void Update()
    {
        if (!gameover)
        {
            HMng.HitUpdate();

            CheckGround();  // �n�ʂɂ��邩�̔���

            MoveInput();        // ����
            MoveController();   // �v���C���[����
            ActiveSkillController();    // �X�L���Ǘ�
            PassiveSkillUpdate();       // ���I�ɔ����������ς��p�b�V�u�X�L���̊Ǘ�
                                //EnemyLockon();      
            ChangeAnim();       // �A�j���[�V�����Ǘ�

            CheckRightHit();
            CheckLeftHit();

            DamageReaction();   // �U���q�b�g���̃��A�N�V����


            HMng.PostUpdate();
        }
    }

    void MoveInput()
    {

        if (conconect.ConConnect == true)
        {
            float lsh = Input.GetAxis("L_stick_H");�@�@�@�@//���X�e�B�b�N��
            float lsv = Input.GetAxis("L_stick_V");        //���X�e�B�b�N�c


            
            if (lsh > 0)
            {
                inputDir.x = 1;
            }
            else if(lsh < 0)
            {
                inputDir.x = -1;
            }
            else
            {
                inputDir.x = 0;
            }

            if (lsv > 0)
            {
                inputDir.y = 1;
            }
            else if (lsv < 0)
            {
                inputDir.y = -1;
            }
            else
            {
                inputDir.y = 0;
            }
            if (Input.GetKeyDown(GameData.rightkey) || Input.GetKeyDown(GameData.leftkey) || lsh == 0)
            {
                speedreset = true;
            }
            else
            {
                speedreset = false;
            }
            if (GameData.jumpkey == (KeyCode)CustomKeycode.LT)  // L�g���K�[�g�p���̃W�����v
            {
                float lt = Input.GetAxis("LT");

                if(lt > 0 && !ltDown)
                {
                    spaceDown = true;
                    ltDown = true;
                }
                else
                {
                    spaceDown = false;
                }
                if (lt == 0)
                {
                    ltDown = false;
                }
            }
            else if(GameData.jumpkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if(rt > 0 && !rtDown)
                {
                    spaceDown = true;
                    rtDown = true;
                }
                else
                {
                    spaceDown = false;
                }
                if (rt == 0)
                {
                    rtDown = false;
                }

            }

            else
            {
                if (Input.GetKeyDown(GameData.jumpkey))
                {
                    spaceDown = true;
                }
                else
                {
                    spaceDown = false;
                }

            }

            if (GameData.jumpkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                Debug.Log("ltAxis = " + lt);

                if (lt > 0)
                {
                    space = true;
                }
                else
                {
                    space = false;
                }

            }
            else if (GameData.jumpkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                Debug.Log("rtAxis = " + rt);

                if (rt > 0)
                {
                    space = true;
                }
                else
                {
                    space = false;
                }

            }
            else
            {
                if (Input.GetKey(GameData.jumpkey))
                {
                    space = true;
                }
                else
                {
                    space = false;
                }

            }
            if (GameData.dashkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                if (lt > 0 && !ltDown)
                {
                    brink = true;
                    ltDown = true;
                }
                else
                {
                    brink = false;
                }
                if (lt == 0)
                {
                    ltDown = false;
                }

            }
            else if (GameData.dashkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if (rt > 0 && !rtDown)
                {
                    brink = true;
                    rtDown = true;
                }
                else
                {
                    brink = false;
                }
                if (rt == 0)
                {
                    rtDown = false;
                }

            }
            else
            {
                if (Input.GetKeyDown(GameData.dashkey))
                {
                    brink = true;
                }
                else
                {
                    brink = false;
                }

            }
            if (GameData.attackkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                if (lt > 0 && !ltDown)
                {
                    attack = true;
                    ltDown = true;
                }
                else
                {
                    attack = false;
                }
                if (lt == 0)
                {
                    ltDown = false;
                }

            }
            else if (GameData.attackkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if (rt > 0 && !rtDown)
                {
                    attack = true;
                    rtDown = true;
                }
                else
                {
                    attack = false;
                }
                if (rt == 0)
                {
                    rtDown = false;
                }

            }
            else
            {
                if (Input.GetKey(GameData.attackkey))
                {
                    attack = true;
                }
                else
                {
                    attack = false;

                }
            }
            if (GameData.downkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                Debug.Log("ltAxis = " + lt);

                if (lt > 0)
                {
                    guard = true;
                }
                else
                {
                    guard = false;
                }
            }
            else if (GameData.downkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                Debug.Log("rtAxis = " + rt);

                if (rt > 0)
                {
                    guard = true;
                }
                else
                {
                    guard = false;
                }

            }
            else
            {
                if (Input.GetKey(GameData.downkey))
                {
                    guard = true;
                }
                else
                {
                    guard = false;
                }

            }

            if (GameData.downkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                if (lt > 0 && !ltDown)
                {
                    guardEnd = false;
                    ltDown = true;
                }
                else if(!rtup)
                {
                    guardEnd = true;
                    ltup = true;
                }
                if (lt == 0)
                {
                    ltDown = false;
                    ltup = false;
                    guardEnd = false;
                }


            }
            else if (GameData.downkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if (rt > 0 && !ltDown)
                {
                    guardEnd = false;
                    rtDown = true;
                }
                else if (!rtup)
                {
                    guardEnd = true;
                    rtup = true;
                }
                if (rt == 0)
                {
                    rtDown = false;
                    rtup = false;
                    guardEnd = false;
                }

            }
            else
            {
                if (Input.GetKeyUp(GameData.downkey))
                {
                    guardEnd = true;
                }
                else
                {
                    guardEnd = false;
                }

            }
            if (GameData.healkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                if (lt > 0 && !ltDown)
                {
                    skill1 = true;
                    ltDown = true;
                }
                else
                {
                    skill1 = false;
                }
                if (lt == 0)
                {
                    ltDown = false;
                }

            }
            else if (GameData.healkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if (rt > 0 && !rtDown)
                {
                    skill1 = true;
                    rtDown = true;
                }
                else
                {
                    skill1 = false;
                }
                if (rt == 0)
                {
                    rtDown = false;
                }

            }
            else
            {
                if (Input.GetKeyDown(GameData.healkey))
                {
                    skill1 = true;
                }
                else
                {
                    skill1 = false;
                }

            }


            if (GameData.interactkey == (KeyCode)CustomKeycode.LT)
            {
                float lt = Input.GetAxis("LT");

                if (lt > 0 && !ltDown)
                {
                    skill2 = true;
                    ltDown = true;
                }
                else
                {
                    skill2 = false;
                }
                if (lt == 0)
                {
                    ltDown = false;
                }

            }
            else if (GameData.interactkey == (KeyCode)CustomKeycode.RT)
            {
                float rt = Input.GetAxis("RT");

                if (rt > 0 && !rtDown)
                {
                    skill2 = true;
                    rtDown = true;
                }
                else
                {
                    skill2 = false;
                }
                if (rt == 0)
                {
                    rtDown = false;
                }

            }
            else
            {
                if (Input.GetKeyDown(GameData.interactkey))
                {
                    skill2 = true;
                }
                else
                {
                    skill2 = false;
                }

            }



        }
        else
        {
            if (Input.GetKeyDown(GameData.rightkey) || Input.GetKeyDown(GameData.leftkey))
            {
                speedreset = true;
            }
            else
            {
                speedreset = false;
            }
            if (Input.GetKey(GameData.rightkey))
            {
                inputDir.x = 1;
            }
            else if (Input.GetKey(GameData.leftkey))
            {
                inputDir.x = -1;
            }
            else
            {
                inputDir.x = 0;
            }

            if (Input.GetKeyDown(GameData.jumpkey))
            {
                spaceDown = true;
            }
            else
            {
                spaceDown = false;
            }
            if (Input.GetKey(GameData.jumpkey))
            {
                space = true;
            }
            else
            {
                space = false;
            }
            if (Input.GetKeyDown(GameData.dashkey))
            {
                brink = true;
            }
            else
            {
                brink = false;
            }
            if (Input.GetKey(GameData.attackkey))
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
            if (Input.GetKey(GameData.downkey))
            {
                guard = true;
            }
            else
            {
                guard = false;
            }
            if (Input.GetKeyUp(GameData.downkey))
            {
                guardEnd = true;
            }
            else
            {
                guardEnd = false;
            }
            if (Input.GetKeyDown(GameData.healkey))
            {
                skill1 = true;
            }
            else
            {
                skill1 = false;
            }

            if (Input.GetKeyDown(GameData.interactkey))
            {
                skill2 = true;
            }
            else
            {
                skill2 = false;
            }


        }

    }
    void MoveController()
    {
        int speed;

        if (isGround)
        {
            jumping = false;       // ��W�����v����
            doublejump = false;    // �_�u���W�����v����
            isbrinkUp = false;     // �󒆃u�����N����]

            // �W�����v
            if (spaceDown && !isGuard && !hitAnim)
            {
                PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, 0);
                PlayerRb.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);

                JumpEffect();
                JumpSE();
            }
            // ����~��
            if(inputDir.x == 0)
            {
                PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);

            }
        }
        // �؂�Ԃ��ő��x���Z�b�g
        if (speedreset)
        {
            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);
        }

        // ��i�W�����v
        if (spaceDown && doublejump && !isGuard && !hitAnim)
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
        // speed(�����x)
        if (inputDir.magnitude != 0)
         {
            speed = 4000;
            dir.x = inputDir.x;
        }
        else
        {
            speed = 0;
        }
        // �������ŃW�����v�����A�b�v
        if (space && !jumping)  
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




        // �ړ����x
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

        // �v���C���[�̈ړ�

        if (!isAttack && !isGuard &&!hitAnim) {
            PlayerRb.AddForce(Vector2.right * inputDir.x * speed * Time.deltaTime);            // �v���C���[�̈ړ�
        }

        // �v���C���[�̌���
        
        if (dir.x != 0 && !isAttack && !isGuard && !hitAnim)
        {
            transform.localScale = new Vector3(dir.x, 1, 1);
        }



        // �󒆃u�����N
        if (brink && !isGround && !isbrink && !isbrinkUp && !isAttack && !isGuard && !hitAnim)
        {

            BrinkEffect();
            BrinkSE();

            transform.position = new Vector3(transform.position.x + (brinkMove * dir.x), transform.position.y, 0);
            PlayerRb.velocity = new Vector2(0, 0);

            BrinkEffect();

            isbrink = true;
            isbrinkUp = true;
            brinkCount = 0;
        }
        // �n��u�����N
        if(brink && isGround && !isbrink && !isAttack && !isGuard && !hitAnim)
        {
            BrinkEffect();
            BrinkSE();


            transform.position = new Vector3(transform.position.x + (brinkMove * dir.x), transform.position.y, 0);
            PlayerRb.velocity = new Vector2(0, 0);
            BrinkEffect();

            isbrink = true;
            brinkCount = 0;

        }
        // �u�����N�̃N�[���^�C��
        if (isbrink && !isGuard)
        {
            brinkCount += Time.deltaTime;
            if(brinkCount >= brinkCoolTimeSec)
            {
                isbrink = false;
                brinkCount = 0;
            }
        }

        if (isbrink)
        {
            brinkSlider.fillAmount = brinkCount / brinkCoolTimeSec;

        }
        else
        {
            brinkSlider.fillAmount = 1;
        }



        if (isAttack)
        {
            PlayerRb.velocity = new Vector2(0, 0);
        }
        if (HMng.CheckDamage())
        {
            HitSE();
            HitStopManager.hitstop.StartHitStop(0.1f);

        }

        if (guard && !attack && !isAttack && !isbrink)
        {
            isGuard = true;

        }
        else        // �K�[�h�̃N�[���^�C��(�u�����N�Ƌ��L)
        {
            isGuard = false;
            guardCount = 0;
            brinkCount += Time.deltaTime;
            if (brinkCount >= brinkCoolTimeSec)
            {
                isbrink = false;
                brinkCount = 0;
            }



        }
        if (isGuard)
        {

            PlayerRb.velocity = new Vector2(0, PlayerRb.velocity.y);

            HMng.DEF = 10000;

            brinkSlider.fillAmount = 1 - (guardCount / guardTime) ;
            guardCount += Time.deltaTime;
            if (!EffectGuard.isPlaying)
            {
                EffectGuard.Play();
                GuardSE();
            }

            if(HMng.CheckDamage() == true)
            {

                isbrink = true;
                brinkCount = 0;



            }

            if (justGuardTime > guardCount)
            {
                if(HMng.CheckDamage() == true)
                {
                    Debug.Log("�W���X�g�K�[�h����");

                    EffectJustGuard.Play();
                    guardCount = 0;
                    HitStopManager.hitstop.StartHitStop(0.3f);


                    isbrink = true;
                    brinkCount = 0;

                    if (HMng.HP < HMng.MaxHP && HMng.HP > 0)
                    {
                        EffectHeal.Play();
                        HMng.HP += 1;
                    }

                }
            }
            else if(guardTime >= guardCount)
            {
                if (HMng.CheckDamage() == true)
                {
                    guardCount = 0;


                    isbrink = true;
                    brinkCount = 0;

                    isGuard = false;
                }
            }
            else 
            {
                isbrink = true;

            }

        }
        else
        {
            HMng.DEF = 1;

            EffectGuard.Stop();
            EffectGuard.Clear();
            EffectJustGuard.Stop();

            if (guardEnd)
            {
                isbrink = true;
            }


        }

        if (HMng.HP <= 0)
        {
            if(deathDirection == false)
            {
                EffectDeath.Play();
                deathDirection = true;
                SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.enabled = false;

            }
            else
            {


                EffectDeath.Stop();
                if (!EffectDeath.isPlaying)
                {


                    gameover = true;

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


    void DamageReaction()
    {
        Animation anim;

        anim = gameObject.GetComponent<Animation>();

        // �m�b�N�o�b�N
        if (HMng.CheckDamage() == true && !isGuard)
        {
            hitAnim = true;
            GameData.HitCount++;
            if (CheckRightHit() == true)
            {
                PlayerRb.velocity = Vector2.zero;
                PlayerRb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);

                PlayerRb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
            }
            else if (CheckLeftHit() == true)
            {
                PlayerRb.velocity = Vector2.zero;

                PlayerRb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);

                PlayerRb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);

            }
            else
            {
                PlayerRb.velocity = Vector2.zero;

                PlayerRb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);

                PlayerRb.AddForce(Vector2.right * 15, ForceMode2D.Impulse);

            }
            HitStopManager.hitstop.StartHitStop(0.2f);
        }
        if(hitAnim == true)
        {
            knockbuckCount += Time.deltaTime;
        }
        if(knockbuckCount >= knockbuckTime  || isGround)
        {
            hitAnim = false;
            knockbuckCount = 0;
        }



    }
    

    void EnemyLockon()
    {
        // �v���C���[�̌���
        GameObject[] TargetEnemy;
        int EnemyCount;

        TargetEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCount = TargetEnemy.Length;

        Debug.Log("�G�l�~�[��" + EnemyCount);
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
                transform.localScale = new Vector3(dir.x, 1, 1);    // �v���C���[�̌���
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