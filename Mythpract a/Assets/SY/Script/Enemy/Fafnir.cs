//�{�X2�F�t�@�t�j�[��

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public enum Fafnir_MoveType
{
    Idle = 1,   //��
    Pound,      //�͂���
    Rush,       //�ːi
    Breath,     //�u���X
    Earthquake, //�n�k
}

public class Fafnir : MonoBehaviour
{

    Rigidbody2D rb;
    AudioSource se;
    HitMng hm;      //�����蔻��
    GroundCheck gc; //�ڒn����

    //
    GameObject obj; //���g
    [SerializeField, Tooltip("�v���[���[")] GameObject pl;

    //
    int phase = 0;      //�ėp�s���ԍ�
    float timer = 0;    //�ėp�^�C�}�[
    int repeat = 0;     //�ėp�J��Ԃ���
    int no = 0;         //�ėp�i���o

    int tableNo = 0;    //�e�[�u���w��
    int moveNo = 0;     //�s���w��

    
    [SerializeField, Tooltip("�s��")] Fafnir_MoveType moveType = Fafnir_MoveType.Idle;
    [SerializeField, Tooltip("�s���e�[�u��")] Fafnir_MoveTable[] moveTable;  //�e�e�[�u���̍ŏ��̍s����Idle�ɂ���K�v������
    [SerializeField] float speed;

    [Header("�{��")]
    [SerializeField, Tooltip("�ڐG�U������")] GameObject body;
    [SerializeField, Tooltip("�ڐG�З�")] float body_Power = 1.0f;
    [SerializeField, Tooltip("�W�����v�G�t�F�N�g")] ParticleSystem jumpEnd_Effect;
    [SerializeField, Tooltip("�^�b�N���G�t�F�N�g")] ParticleSystem tackle_Effect;
    [SerializeField, Tooltip("�@�����G�t�F�N�g")] ParticleSystem earthpuake_Effect;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip Move_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float Move_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float Move_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool Move_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip jumpStart_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float jumpStart_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float jumpStart_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool jumpStart_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip jumpEnd_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float jumpEnd_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float jumpEnd_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool jumpEnd_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip attackAnticipation_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float attackAnticipation_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float attackAnticipation_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool attackAnticipation_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip die_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float die_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float die_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool die_SELoop;

    Vector2 pos;        //���W
    Vector2 plPos;      //�v���[���[���W
    Vector3 defScale;   //�g�k���ۑ�
    Vector3 scale;      //�g�k���X�V
    float dir;          //���E����
    float gravity;      //�d�͋��x�ۑ�
    int soundcount = 0;

    [Header("�ҋ@")]
    [SerializeField, Tooltip("�ҋ@����")] float idle_BreakTime = 1.0f;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip idle_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float idle_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float idle_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool idle_SELoop;

    [Header("�͂���")]
    [SerializeField, Tooltip("�͂���")] GameObject pound;
    [SerializeField, Tooltip("�З�")] float pound_Power = 1.0f;
    [SerializeField, Tooltip("�ړ����x")] float pound_MoveSpd = 5.0f;
    [SerializeField, Tooltip("��")] float[] pound_BreakTime = { 0.5f, 0.5f };
    [SerializeField, Tooltip("�U������")] float pound_AtkDistance = 6.0f;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip pound_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float pound_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float pound_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool pound_SELoop;

    [Header("�ːi")]
    [SerializeField, Tooltip("�ړ����x")] float rush_MoveSpd = 20.0f;
    [SerializeField, Tooltip("�З�")] float rush_Power = 1.0f;
    [SerializeField, Tooltip("��")] float rush_BreakTime = 0.5f;
    [SerializeField, Tooltip("���s��")] int rush_AtkTime = 3;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip rush_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float rush_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float rush_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool rush_SELoop;

    [Header("�u���X")]
    [SerializeField, Tooltip("�u���X")] GameObject breath;
    [SerializeField, Tooltip("�З�")] float breath_Power = 1.0f;
    [SerializeField, Tooltip("�W�����v����")] float breath_JumpHeight;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip breath_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float breath_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float breath_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool breath_SELoop;
    float breath_Save;          //�ϐ��ۑ�

    [Header("�n�k")]
    [SerializeField, Tooltip("�n�k")] GameObject earthquake;
    [SerializeField, Tooltip("�З�")] float earthquake_Power = 1.0f;
    [SerializeField, Tooltip("�W�����v����")] float earthquake_JumpHeight;
    [SerializeField, Tooltip("�p������")] float earthquake_Time = 3.0f;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip earthquake_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float earthquake_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float earthquake_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool earthquake_SELoop;


    [Header("�J����")]
    [SerializeField, Tooltip("��ʏ��")] CameraData cameraData;
    Camera useCamera;       //�g�p�J����
    Vector2 leftBottom;     //����
    Vector2 leftTop;        //����
    Vector2 rightBottom;    //�E��
    Vector2 rightTop;       //�E��
    Vector2 center;         //����
    float screenWidth;      //��
    float screenHeight;     //����

    float hScreenWidth;     //1/2��
    float qScreenWidth;     //1/4��
    float hScreenHeight;    //1/2����
    float qScreenHeight;    //1/4����

    //�A�j���[�V����
    Anim anim;
    float anim_JumpFlag;
    [SerializeField] bool isLock;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        anim = GetComponent<Anim>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        obj = this.gameObject;
        pos = rb.position;
        plPos = pl.transform.position;
        defScale = transform.localScale;
        scale = defScale;
        gravity = rb.gravityScale;

        tableNo = Random.Range(0, moveTable.Length);
        moveNo = 0;

        SetPower(body, body_Power);
        pound.SetActive(false);
        breath.SetActive(false);
        //breath_DefScale = breath.transform.localScale;
        earthquake.SetActive(false);

        hm.SetUp(Damage, Die);
        CameraData();

    }

    // Update is called once per frame
    void Update()
    {
        hm.HitUpdate();

        if (hm.HP <= 0) { return; }

        pos = rb.position;
        plPos = pl.transform.position;

        switch (moveType)
        {
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
        Debug.Log(moveTable[tableNo].Name + " : " + moveNo);
        Debug.Log("no " + no + " phase " + phase);

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

    //----------�A�N�V����----------
    void Idle()
    {
        switch(phase)
        {
            case 0:
                if (!CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground)) { break; }
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

    void Pound()        //�͂���
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
                Debug.Log("�U������");
                if (anim.Play != GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name || anim.NormalizedTime < 0.7f) { break; }
                Debug.Log(anim.Play + " : " + GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name + " : " + anim.NormalizedTime);
                SetAudio(pound_SE, pound_SEVolume, pound_SEPitch, pound_SELoop);
                earthpuake_Effect.Play();
                timer = 0;
                no++;
                phase++;
                break;
            case 3:
                if (anim.Action != Products.Type.Idle) { Debug.Log(anim.Action); break; }
                Debug.Log(anim.Action);
                timer += Time.deltaTime;
                if(timer < pound_BreakTime[no]) { Debug.Log(pound_BreakTime[no]); break; }
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
        switch(phase)
        {
            case 0:     //�ːi�З͐ݒ�A�n���A�j���[�V�����J�n
                SetPower(body, rush_Power);
                SetAudio(attackAnticipation_SE, attackAnticipation_SEVolume, attackAnticipation_SEPitch, attackAnticipation_SELoop);
                anim.AnimChage("Rush_Start", isLock);   //�A�j���[�V�����K�p��1�t���[���K�v�炵��
                phase++;
                break;
            case 1:     //�n���A�j���[�V�����I�����ːi�A�j���[�V�����J�n
                tackle_Effect.Play();
                if (anim.NormalizedTime < 1.0f) { break; }
                SetAudio(rush_SE, rush_SEVolume, rush_SEPitch, rush_SELoop);
                anim.AnimChage("Rush_Air", isLock);
                repeat++;
                phase++;
                break;
            case 2:     //�ːi�J�n�A��ʒ[�܂���ʒ����t�߂ɓ��B����~�A�З͐ݒ�A�I���A�j���[�V�����J�n
                timer += Time.deltaTime;
                rb.velocity = (-dir * Vector2.right).normalized * rush_MoveSpd;
                if (timer < 0.5f) { break; }
                if (repeat == rush_AtkTime)
                {
                    if (pos.x > center.x + 5.0f || center.x - 5.0f > pos.x) { break; }
                }
                else
                {
                    if (pos.x < rightTop.x + 3.0f && leftTop.x - 3.0f < pos.x) { break; }
                }
                rb.velocity = Vector2.zero;
                SetPower(body, body_Power);
                anim.AnimChage("Rush_End", isLock);
                timer = 0;
                phase++;
                break;
            case 3:     //�I���A�j���[�V�����I��
                if (anim.NormalizedTime < 1.0f) { break; }
                phase++;
                break;
            case 4:     //�܂�Ԃ����ԁ������X�V�A�񐔂ɉ����Ď��A�N�V������`
                timer += Time.deltaTime;
                if (timer < rush_BreakTime) { break; }
                Direction();
                timer = 0;
                if (repeat == rush_AtkTime) { phase++; }
                else { phase = 0; }
                break;
            case 5:
                //moveType = rush_NextMove;
                MoveEnd();
                break;
            default:    //�s���J�ڎ��ėp�ϐ�������
                AllVariableClear();
                break;
        }
    }

    void Breath()       //�u���X
    {
        switch(phase)
        {
            case 0:     //�Z�З͐ݒ�
                SetPower(breath.transform.gameObject, breath_Power);
                phase++;
                break;
            case 1:     //�v���[���[�̈ʒu�ƒn�ʈʒu����U���ʒu��`�A�W�����v�s��
                Vector2 target = (center.x - plPos.x <= 0) ? leftTop : rightTop;
                target = new Vector2(target.x, GroundPosition(target.x));
                Jump(target, breath_JumpHeight);
                if (anim_JumpFlag != 1) { break; }
                phase++;
                break;
            case 2:     //�n�ʂ𗣂ꂽ��
                if (CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground)) { break; }
                phase++;
                break;
            case 3:     //�ڒn���聨�v���[���[�̕��������A�u���X�U��
                if (!CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground)) { break; }
                if (anim.Action == Products.Type.Jump) { break; }
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
            case 4:     //���݂̃A�N�V�������A�C�h�����s���J�ځA�u���X�I�u�W�F�N�g��]�������A�ėp�ϐ�������
                if(anim.Action != Products.Type.Idle) { break; }
                breath.transform.localRotation = Quaternion.Euler(Vector3.zero);
                soundcount = 0;
                //moveType = breath_NextMove;
                MoveEnd();
                break;
            default:    //�s���J�ڎ��ėp�ϐ�������
                AllVariableClear();
                break;
        }

        /* �E�u���X�U�����s��
         * �v���[���[����ʍ��E�ǂ���ɂ��邩�m�F
         * �v���[���[�̔��΂̉�ʒ[�Ɉړ�
         *      (�v���[���[�̕����������Ȃ���  (�d�͋��x0)����������~���ړ�����~��(�d�͋��x��)������)
         * �u���X�`���[�W�J�n��n�b�㐅�������ɔ���
         * ���X��x����傫��
         * �L�т���Ώ��X�ɏ�����Ɋp�x������
         * ��40�x�Œ�~
         * �I��
         */
    }

    void Earthquake()   //�n�k
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
                Jump(target, earthquake_JumpHeight);
                Debug.Log(anim_JumpFlag);
                if(anim_JumpFlag != 1) { break; }
                phase++;
                break;
            case 2:
                if (CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground)) { break; }
                phase++;
                break;
            case 3:
                if (!CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground)) { break; }
                rb.velocity = Vector2.zero;
                SetAudio(earthquake_SE, earthquake_SEVolume, earthquake_SEPitch, earthquake_SELoop);
                earthquake.SetActive(true);
                phase++;
                break;
            case 4:
                rb.velocity = Vector2.zero;
                timer += Time.deltaTime;
                if (timer < earthquake_Time) { break; }
                earthquake.SetActive(false);
                timer = 0;
                phase++;
                break;
            case 5:
                //moveType = earthquake_NextMove;
                MoveEnd();
                break;
            default:    //�s���J�ڎ��ėp�ϐ�������
                AllVariableClear();
                break;
        }
    }

    void MoveEnd()  //�s���I��������
    {
        Debug.Log("�s���I��");
        moveNo++;
        if (moveNo == moveTable[tableNo].Move.Length)
        {
            tableNo = Random.Range(0, moveTable.Length);
            moveNo = 0;
        }
        moveType = moveTable[tableNo].Move[moveNo];
        AllVariableClear();
    }

    void Jump(Vector2 targetPos, float height)  //�W�����v
    {
        float t1 = RiseorFallTime(pos, height);         //�J�n����ő卂�x�܂ł̎���
        float t2 = RiseorFallTime(targetPos, height);   //�ő卂�x���璅�n�܂ł̎���

        float jumpTime = t1 + t2;   //�W�����v����

        if (jumpTime <= 0.0f)
        {
            Debug.LogError("�W�����v�̎��Ԃ�0�b");
            return;
        }

        float speed = VectorFromTime(targetPos, jumpTime);  //����
        float angle = AngleFromTime(targetPos, jumpTime);   //�p�x

        if (speed <= 0.0f)
        {
            // ���̈ʒu�ɒ��n�����邱�Ƃ͕s�\�̂悤���I
            Debug.LogError("�������^�����Ȃ�");
            return;
        }

        Vector3 vec = ConvertVectorToVector3(speed, angle, targetPos);

        Vector2 force = vec * rb.mass;

        SetAudio(jumpStart_SE, jumpStart_SEVolume, jumpStart_SEPitch, jumpStart_SELoop);
        anim.AnimChage("Jump_Start", isLock);
        if (anim.NormalizedTime < 1.0f) { return; }

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void Direction()    //����(�v���[���[�̕���)
    {
        dir = ((plPos.x - pos.x <= 0) ? defScale.x : -defScale.x);
        scale.x = dir;
        transform.localScale = scale;
    }

    void Damage()   //��_���[�W
    {
        Debug.Log(obj.name + "�̓_���[�W���󂯂�");
    }

    void Die()      //���S
    {
        if (soundcount == 0)
        {
            SetAudio(die_SE, die_SEVolume, die_SEPitch, die_SELoop);
        }
        soundcount++;
        GameSceneDirector2.Bossdead2 = true;
        Debug.Log(obj.name + "�͎���");
    }

    //----------�A�j���[�V����----------
    void Anim_Basis()
    {
        if (CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground))
        {
            if (anim.Action == Products.Type.Idle && 0.2f < rb.velocity.magnitude)
            {
                SetAudio(Move_SE, Move_SEVolume, Move_SEPitch, Move_SELoop);
                anim.AnimChage("Move", isLock);
            }
            else if (anim.Action == Products.Type.Move && rb.velocity.magnitude < 0.2f)
            {
                anim.AnimChage("Idle", false);
            }
        }
    }

    void Anim_Jump()
    {
        Debug.Log("jumpFlag " + anim_JumpFlag);
        Debug.Log("CheckGround"+CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground));
        if (!CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground))
        {
            anim.AnimChage("Jump_Air", isLock);
            anim_JumpFlag = 1;
            Debug.Log("�؋�A�j��");
        }
        else if (CheckGroundFlag(GroundCheck.GroundCheckFlag.Ground) && anim.Action == Products.Type.Jump)
        {
            if(anim_JumpFlag != 0)
            {
                Debug.Log("�W�����v�I���");
                jumpEnd_Effect.Play();
                SetAudio(jumpEnd_SE, jumpEnd_SEVolume, jumpStart_SEPitch, jumpEnd_SELoop);
                anim.AnimChage("Idle", false);
                anim_JumpFlag = 0;
            }
        }
    }

    //----------�e��f�[�^�Ǘ�----------
    Vector2 Distance(Vector3 target)
    {
        Vector2 distance = target - transform.position;
        return distance;
    }

    float GroundPosition(float axisX)
    {
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D rayHit = 
            Physics2D.Raycast(new Vector2(axisX, leftTop.y), Vector2.down, screenHeight, layerMask);  //��������
        Debug.DrawRay(new Vector2(axisX, leftTop.y), Vector2.down * screenHeight, Color.green, 1.0f);
        if (rayHit.collider.tag == "Ground")
        {
            Vector2 groundPos = rayHit.point;   //�n�ʈʒu�m�F
            return groundPos.y;
        }
        Debug.LogError(axisX + "�ɒn�ʂ͂Ȃ�");
        return 0;
    }

    //�㏸�܂��͗�������
    float RiseorFallTime(Vector2 pos, float height)
    {
        float g = Physics.gravity.y;
        float y = pos.y;

        float timeSquare = 2 * (y - height) / g;
        if (timeSquare <= 0.0f)
        {
            return 0.0f;
        }

        float time = Mathf.Sqrt(timeSquare);
        return time;
    }

    //���Ԃ���x�N�g���̑傫�����v�Z
    float VectorFromTime(Vector2 targetPos, float time)
    {
        Vector2 vec = VectorXYFromTime(targetPos, time);

        float v_x = vec.x;
        float v_y = vec.y;

        float vecSquare = v_x * v_x + v_y * v_y;
        // �����𕽕����v�Z����Ƌ����ɂȂ��Ă��܂��B
        // ������float�ł͕\���ł��Ȃ��B
        // ���������ꍇ�͂���ȏ�̌v�Z�͑ł��؂낤�B
        if (vecSquare <= 0.0f)
        {
            Debug.LogError("�����ɂȂ�");
            //return 0.0f;
        }

        float v0 = Mathf.Sqrt(vecSquare);

        if (v0 <= 0.0f)
        {
            Debug.LogError("�������^�����Ȃ�");
        }

        return v0;
    }

    //���Ԃ���p�x���v�Z
    float AngleFromTime(Vector2 targetPos, float time)
    {
        Vector2 vec = VectorXYFromTime(targetPos, time);

        float v_x = vec.x;
        float v_y = vec.y;

        float rad = Mathf.Atan2(v_y, v_x);
        float angle = rad * Mathf.Rad2Deg;

        return angle;
    }

    //���Ԃ���x�N�g��XY���v�Z
    private Vector2 VectorXYFromTime(Vector2 targetPos, float time)
    {
        // �u�Ԉړ��͂�����Ɓc�c�B
        if (time <= 0.0f)
        {
            return Vector2.zero;
        }


        // xz���ʂ̋������v�Z�B
        Vector2 startPos = new Vector2(pos.x, 0);
        Vector2 _targetPos = new Vector2(targetPos.x, 0);
        float distance = Vector2.Distance(targetPos, startPos);

        float x = distance;
        // �ȁA�Ȃ��d�͂𔽓]���˂΂Ȃ�Ȃ��̂�...
        float reGravity = -Physics.gravity.y;
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

    void CameraData()   //�J����
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

    void AllVariableClear()     //�ϐ�������
    {
        GeneralVariableClear();

        //�~
        //circle.DataClear();
    }

    void GeneralVariableClear() //�ėp�ϐ�������
    {
        phase = 0;
        timer = 0;
        repeat = 0;
        no = 0;
    }

    void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<HitData>().Power = power;
    }

    bool CheckGroundFlag(GroundCheck.GroundCheckFlag flag)
    {
        return gc.CheckGCFlag(flag);
    }

    //�T�E���h
    void SetAudio(AudioClip audio, float Volume, float Pitch, bool isLoop)
    {
        se.clip = audio;
        se.volume = Volume;
        se.pitch = Pitch;
        se.loop = isLoop;
        se.Play();
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



/*----------������R�[�h(��ɏ���)----------

//����

//[Header("����")]
//[SerializeField, Tooltip("�ړ����x")] float flap_MoveSpd;
//[SerializeField, Tooltip("�ړ�����")] Vector2 flap_Direction;
//[SerializeField, Tooltip("�������x")] float flap_FallSpd = 0.3f;
//[SerializeField, Tooltip("�H�΂����Ԋu")] float flap_Interval = 1.0f;
//[SerializeField, Range(0.0f, 90.0f), Tooltip("�p�x")] float jump_Angle;

//void Flap(float power, Vector2 vec)
//{
//    switch (flapPhase)
//    {
//        case 0: //�㏸
//            rb.velocity = new Vector2(vec.x, vec.y * flap_FallSpd) * power;
//            flapTimer += Time.deltaTime;
//            if (flapTimer < flap_Interval / 2.0f) { return; }
//            flapTimer = 0; flapPhase++;
//            break;
//        case 1: //���~
//            rb.velocity = new Vector2(vec.x, -1.0f * flap_FallSpd) * power;
//            flapTimer += Time.deltaTime;
//            if (flapTimer < flap_Interval / 2.0f) { return; }
//            flapTimer = 0; flapPhase = 0;
//            break;
//    }
//}

//�u���X

//[SerializeField, Tooltip("�ړ����x")] float[] breath_MoveSpd = { 5.0f, 2.0f, 5.0f, 2.0f, 0.0f };
//[SerializeField, Tooltip("�ړ�����")] Vector2[] breath_MoveDir =
//    { new Vector2(0.0f, 3.0f), new Vector2(0.0f, 1.0f), new Vector2(1.0f, 1.0f), new Vector2(0.0f, 1.0f), new Vector2(0.0f, 0.0f) };
//[SerializeField, Tooltip("�ړ�����")] float[] breath_MoveTime = { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
//[SerializeField, Tooltip("���˓_")] Vector2 breath_Origin = new Vector2(0.0f, 0.0f);
//[SerializeField, Tooltip("���x")] float breath_Speed = 20.0f;
//[SerializeField, Tooltip("�p�x���x")] float breath_AngleSpd = 10.0f;
//[SerializeField, Tooltip("���ߎ���")] float breath_ChargeTime = 1.5f;
//[SerializeField, Tooltip("�ŏI�͈�")] float breath_MaxDistance = 10.0f;
//[SerializeField, Tooltip("�ŏI�p�x")] float breath_MaxAngle = 40.0f;
//Vector3 breath_DefScale;    //�u���X�I�u�W�F�N�g�e�k���ۑ�

//case 1:     //no = 0 : breath_Time[no]�b�ԏ㏸   no = 1 : breath_Time[no]�b�Ԓ�~���v���[���[�̈ʒu����ړ�������`
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
//case 2:     //no = 2 : ��ʒ[�܂Ő����ړ�
//Flap(breath_MoveSpd[no], breath_MoveDir[no]);
//if (pos.x < rightTop.x && leftTop.x < pos.x) { break; }
//pos.x = (rightTop.x < pos.x) ? rightTop.x - 0.1f : leftTop.x + 0.1f;
//breath_MoveDir[no].x = breath_Save;
//no++;
//phase++;
//break;
//case 3:     //no = 3 : breath_Time[no]�b�Ԓ�~���d�͋��x����
//timer += Time.deltaTime;
//Flap(breath_MoveSpd[no], breath_MoveDir[no]);
//if (timer < breath_MoveTime[no]) { break; }
//rb.gravityScale = gravity;
//timer = 0;
//no++;
//phase++;
//break;
//case 5:     //breath_ChargeTime�b���ߓ���
//timer += Time.deltaTime;
//if (timer < breath_ChargeTime) { break; }
//breath.transform.localPosition = breath_Origin;
//breath.transform.localScale = breath_DefScale;
//breath.SetActive(true);
//timer = 0;
//phase++;
//break;
//case 6:     //breath_MaxDistance�𒴂���܂Ŋg��
//timer += Time.deltaTime;
//breath.transform.localScale =
//new Vector3(breath_Speed * timer + breath_DefScale.x, breath_DefScale.y, breath_DefScale.z);
//if (breath.transform.localScale.x < breath_MaxDistance) { break; }
//timer = 0;
//phase++;
//break;
//case 7:     //breath_MaxAngle�𒴂���܂Ŋp�x��t����
//timer += Time.deltaTime;
//var quaternion = Quaternion.Euler(timer * breath_AngleSpd * Vector3.forward);
//breath.transform.localRotation = quaternion;
//if (quaternion.eulerAngles.z < breath_MaxAngle) { break; }
//breath.SetActive(false);
//timer = 0;
//phase++;
//break;

//�n��

//[SerializeField, Tooltip("�ړ����x")] float[] earthquake_MoveSpd = { 20.0f, 1.0f };
//[SerializeField, Tooltip("�ړ�����")] Vector2[] earthquake_MoveDir =
//    { new Vector2(0.0f, 5.0f), new Vector2(0.0f, 1.0f) };
//[SerializeField, Tooltip("�ړ�����")] float[] earthquake_MoveTime = { 1.0f, 0.0f };

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

/*----------�Q�l----------
 * �Ε�����
 *  ����(wiki)   : https://ja.wikipedia.org/wiki/%E6%96%9C%E6%96%B9%E6%8A%95%E5%B0%84
 *  �R�[�h�Q�l1  : https://qiita.com/_udonba/items/a71e11c8dd039171f86c
 *  �R�[�h�Q�l2  : https://www.urablog.xyz/entry/2017/05/16/235548
*/