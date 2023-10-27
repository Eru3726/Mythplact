//�{�X3 : �i��

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;
using Live2D.Cubism.Rendering;

public enum Qilin_MoveType
{
    Idle = 1,   //��
    Breath,     //�u���X
    Eruption,   //����
    PushUp,     //�˂��グ
    Spin,       //���Q
    Meteor,     //覐�
    Die,        //��
}

public class Qilin : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    AudioSource se;
    CubismRenderController renderController;
    HitMng hm;      //�����蔻��
    GroundCheck gc; //�ڒn����

    //
    GameObject obj; //���g
    Color defColor;
    [SerializeField, Tooltip("�v���[���[")] GameObject pl;

    //
    int phase = 0;      //�ėp�s���ԍ�
    float timer = 0;    //�ėp�^�C�}�[
    int repeat = 0;     //�ėp�J��Ԃ���
    int no = 0;         //�ėp�i���o

    int tableNo = 0;    //�e�[�u���w��
    int moveNo = 0;     //�s���w��

    //
    Vector2 pos;        //���W
    Vector3 defScale;   //�g�k���ۑ�
    Vector3 scale;      //�g�k���X�V
    float dir;          //���E����
    int plDir;          //�v���C���[�ʒu����(-1or0or1)
    float gPos;         //�n�ʈʒu
    float gravity;      //�d�͋��x�ۑ�

    Vector2 plPos;      //�v���[���[���W

    [SerializeField, Tooltip("�s��")] Qilin_MoveType moveType = Qilin_MoveType.Idle;
    [SerializeField, Tooltip("�s���e�[�u��")] Qilin_MoveTable[] moveTable;  //�e�e�[�u���̍ŏ��̍s����Idle�ɂ���K�v������

    [Header("�{��")]
    [SerializeField, Tooltip("�ڐG�U������")] GameObject body;
    [SerializeField, Tooltip("�ڐG�З�")] float body_Power = 1.0f;
    [SerializeField, Tooltip("�M�Y��")] GizmoSetting body_Gizmo;
    Vector2 body_Center;
    Vector2 body_Range;

    [Header("�ҋ@")]
    [SerializeField, Tooltip("�ҋ@����")] float idle_BreakTime = 1.0f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting idle_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting idle_SE;
    [SerializeField, Tooltip("�U���O��")] float attackAnticipation_Time = 1.0f;
    [SerializeField, Tooltip("�U���O�G�t�F�N�g")] ParticleSetting attackAnticipation_Effect;
    [SerializeField, Tooltip("�U���O�T�E���h")] AudioSetting attackAnticipation_SE;

    [Header("�ړ�")]
    [SerializeField, Tooltip("���x")] float move_Speed = 1.0f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting move_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting move_SE;

    [Header("�u���X")]
    [SerializeField, Tooltip("�u���X")] GameObject breath;
    [SerializeField, Tooltip("�З�")] float breath_Power = 1.0f;
    [SerializeField, Tooltip("�U������")] float breath_AtkDis = 5.0f;
    [SerializeField, Tooltip("�N�[���^�C��")] float breath_CoolTime = 0.5f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting breath_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting breath_SE;

    [Header("����")]
    [SerializeField, Tooltip("����")] GameObject eruption;
    [SerializeField, Tooltip("�З�")] float eruption_Power = 1.0f;
    [SerializeField, Tooltip("���S���W")] Vector2 eruption_Center;
    [SerializeField, Tooltip("�U���͈�")] Vector2 eruption_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("�U���Ԍ�")] float eruption_AtkBreakTime = 1.0f;
    [SerializeField, Tooltip("������")] int eruption_Generate = 10;
    [SerializeField, Tooltip("�N�[���^�C��")] float eruption_CoolTime = 0.5f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting eruption_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting eruption_SE;
    [SerializeField, Tooltip("�M�Y��")] GizmoSetting eruption_Gizmo;
    float eruption_Space;           //�����ԋ���
    Vector2 eruption_Generatev2;    //������   Vector2(Left, Right)
    GameObject eruption_Last;

    [Header("�˂��グ")]
    [SerializeField, Tooltip("�˂��グ")] GameObject pushUp;
    [SerializeField, Tooltip("�З�")] float pushUp_Power = 1.0f;
    [SerializeField, Tooltip("�ړ����x")] float pushUp_MoveSpd = 10.0f;
    [SerializeField, Tooltip("�U������")] float pushUp_AtkDis = 5.0f;
    [SerializeField, Tooltip("�N�[���^�C��")] float pushUp_CoolTime = 0.5f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting pushUp_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting pushUp_SE;

    [Header("���Q")]
    [SerializeField, Tooltip("���Q")] GameObject spin;
    [SerializeField, Tooltip("�З�")] float spin_Power = 1.0f;
    [SerializeField, Tooltip("���S���W")] Vector2 spin_Center;
    [SerializeField, Tooltip("�U���͈�")] Vector2 spin_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("�N�[���^�C��")] float spin_CoolTime = 0.5f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting spin_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting spin_SE;
    [SerializeField, Tooltip("�M�Y��")] GizmoSetting spin_Gizmo;
    GameObject spin_Last;

    [Header("覐�")]
    [SerializeField, Tooltip("覐�")] GameObject meteor;
    [SerializeField, Tooltip("�З�")] float meteor_Power = 1.0f;
    [SerializeField, Tooltip("���S���W")] Vector2 meteor_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("�U���͈�")] Vector2 meteor_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("�U������")] float meteor_AtkTime = 5.0f;
    [SerializeField, Tooltip("������")] float meteor_Generate = 10.0f;
    [SerializeField, Tooltip("�N�[���^�C��")] float meteor_CoolTime = 0.5f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting meteor_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting meteor_SE;
    [SerializeField, Tooltip("�M�Y��")] GizmoSetting meteor_Gizmo;
    GameObject meteor_Last;

    [Header("��_���[�W")]
    [SerializeField, Tooltip("�F")] Color damage_Color = Color.white;
    [SerializeField, Tooltip("�_�ŉ�")] int damage_Number = 10;
    [SerializeField, Tooltip("����")] float damage_Time = 0.05f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting damage_SE;
    float damage_Repeat = 0;

    [Header("��")]
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting die_Effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting die_SE;

    [Header("��ʏ��")]
    [SerializeField, Tooltip("�X�e�[�W���S���W")] Vector2 stage_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("�X�e�[�W�͈�")] Vector2 stage_Range = new Vector2(20.0f, 10.0f);
    [SerializeField, Tooltip("�M�Y��")] GizmoSetting stage_Gizmo;
    Vector2 stage_LeftTop;      //�X�e�[�W����
    Vector2 stage_RightDown;    //�X�e�[�W�E��

    [Header("�A�j���[�V����")]
    [SerializeField] bool isLock;
    Anim anim;

    public GameObject Player { get { return pl; } }
    public int PlDir { get { return plDir; } }
    public Qilin_MoveType MoveType { get { return moveType; } }
    public Vector2 Spin_Center { get { return spin_Center; } }
    public Vector2 Spin_AtkRange { get { return spin_AtkRange; } }
    public float Spin_Power { get { return spin_Power; } }
    public float Eruption_Power { get { return eruption_Power; } }
    public Vector2 Meteor_Center { get { return meteor_Center; } }
    public Vector2 Meteor_AtkRange { get { return meteor_AtkRange; } }
    public float Meteor_Power { get { return meteor_Power; } }


    // Start is called before the first frame update
    void Start()
    {
        //��`
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        se = GetComponent<AudioSource>();
        anim = GetComponent<Anim>();
        renderController = GetComponent<CubismRenderController>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        obj = this.gameObject;
        pos = rb.position;
        plPos = pl.transform.position;
        defScale = transform.localScale;
        scale = defScale;
        defColor = renderController.ModelScreenColor;
        gravity = rb.gravityScale;

        //�s��
        tableNo = Random.Range(0, moveTable.Length);
        moveNo = 0;

        //�͈̔�
        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        //�U������֘A
        body.SetActive(true);
        breath.SetActive(false);
        pushUp.SetActive(false);
        SetPower(body, body_Power);
        SetPower(breath, breath_Power);
        SetPower(pushUp, pushUp_Power);

        hm.SetUp(Damage, Die);
        //CameraData();
        StageData();

        gPos = GroundPosition(stage_Center.x);
        renderController.OverwriteFlagForModelScreenColors = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveType == Qilin_MoveType.Die) { return; }

        hm.HitUpdate();

        pos = rb.position;
        plPos = pl.transform.position;

        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        switch (moveType)
        {
            case Qilin_MoveType.Idle:
                Idle();
                break;

            case Qilin_MoveType.Breath:
                Breath();
                break;

            case Qilin_MoveType.Eruption:
                Eruption();
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

        if (moveType == Qilin_MoveType.Idle || moveType == Qilin_MoveType.Breath ||
            moveType == Qilin_MoveType.Eruption || moveType == Qilin_MoveType.PushUp)
        {
            Direction();
        }
        //Debug.Log(plDir);

        Anim_Basis();
        hm.PostUpdate();
    }

    //----------�A�N�V����----------
    void Idle()
    {
        switch (phase)
        {
            case 0:
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
            case 0:
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * plDir * move_Speed;
                phase++;
                break;
            case 1:
                if (breath_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.gravityScale = gravity;
                rb.velocity = Vector2.zero;
                phase++;
                break;
            case 2:
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
            case 3:
                if (anim.NormalizedTime < 0.3f) { break; }
                breath_Effect.Particle.gameObject.SetActive(true);
                breath.SetActive(true);
                breath_Effect.PlayParticle();
                phase++;
                break;
            case 4:
                breath_Effect.StopCheck();
                if (breath_Effect.IsValid) { break; }
                breath.SetActive(false);
                breath_Effect.Particle.gameObject.SetActive(false);
                phase++;
                break;
            case 5:
                timer += Time.deltaTime;
                if (timer < breath_CoolTime) { break; }
                phase++;
                break;
            case 6:
                moveType = Qilin_MoveType.Idle;
                AllVariableClear();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    void Eruption()
    {
        switch (phase)
        {
            case 0: //�O��
                timer += Time.deltaTime;
                if(timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 1:
                float Range = eruption_AtkRange.x - body_Range.x;   //���������\��

                Vector2 eruption_Range = Vector2.zero;
                eruption_Range.x =  //������
                    ((body_Center.x) - (body_Range.x * 0.5f)) - 
                    (eruption_Center.x - (eruption_AtkRange.x * 0.5f));
                eruption_Range.y =  //�E����
                    (eruption_Center.x + (eruption_AtkRange.x * 0.5f)) - 
                    ((body_Center.x) + (body_Range.x * 0.5f));

                //��@���������\���F�������F�E���� = 1�Fx�Fy
                Vector2 eruption_Ratio = Vector2.zero;
                eruption_Ratio.x = eruption_Range.x / Range;
                eruption_Ratio.y = eruption_Range.y / Range;
                if (eruption_Ratio.x < 0) { eruption_Ratio = Vector2.up; }
                else if (eruption_Ratio.y < 0) { eruption_Ratio = Vector2.right; }

                Vector2 empty = new Vector2 //�䂩�獶�E�̉�����������`(�����_����)
                    (eruption_Generate * eruption_Ratio.x, eruption_Generate * eruption_Ratio.y);
                //�����������𐮐���
                eruption_Generatev2.x = Mathf.Round(empty.x);
                eruption_Generatev2.y = Mathf.Round(empty.y);

                //�����ԋ�����`
                eruption_Space = Range / (eruption_Generate + 1);

                //�A�j���[�V�����Đ�
                anim.AnimChage("Pillar", isLock);
                phase++;
                break;
            case 2: //��������
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                Vector2 genPos = Vector2.zero;
                if (repeat < eruption_Generatev2.x)
                { 
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) - 
                        (eruption_Space * (repeat + 1)), 
                        gPos);
                    Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                repeat++;
                phase++;
                break;
            case 3: //�U���Ԍ�
                timer += Time.deltaTime;
                if (timer < eruption_AtkBreakTime) { break; }
                timer = 0;
                if (eruption_Generate - 1 != no) { phase--; }   //�߂�
                else { phase++; }   //�i��
                break;
            case 4:
                if (repeat < eruption_Generatev2.x)
                {
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) -
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                }
                phase++;
                break;
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
                AllVariableClear();
                moveType = Qilin_MoveType.Idle;
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
            case 0:
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * PlDir * pushUp_MoveSpd;
                pushUp_Effect.Particle.gameObject.SetActive(true);
                pushUp_Effect.PlayParticle();
                //renderController.Opacity = 0;
                phase++;
                break;
            case 1:
                if (pushUp_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.velocity = Vector2.zero;
                var main = pushUp_Effect.Particle.main;
                main.loop = false;
                phase++;
                break;
            case 2:
                Debug.Log(pushUp_Effect.IsValid);
                pushUp_Effect.StopCheck();
                if (pushUp_Effect.IsValid) { break; }
                pushUp_Effect.Particle.gameObject.SetActive(false);
                //renderController.Opacity = 1;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 3:
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 4:
                anim.AnimChage("PushUp", isLock);
                pushUp.SetActive(true);
                phase++;
                break;
            case 5:
                if(anim.Action != AnimSetting.Type.Idle) { break; }
                pushUp.SetActive(false);
                timer += Time.deltaTime;
                if (timer < pushUp_CoolTime) { break; }
                phase++;
                break;
            case 6:
                moveType = Qilin_MoveType.Idle;
                AllVariableClear();
                break;
            default:
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
                rb.velocity = vec.normalized * move_Speed;
                phase++;
                break;
            case 1:
                if (pos.x < stage_Center.x - 2.5f || stage_Center.x + 2.5f < pos.x) { return; }
                rb.velocity = Vector2.zero;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 2://�O��
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
                Instantiate(spin, spin1Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                spin_Last =
                    Instantiate(spin, spin2Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                phase++;
                break;
            case 5:
                if (spin_Last != null) { break; }
                phase++;
                break;
            case 6:
                timer += Time.deltaTime;
                if (timer < spin_CoolTime) { break; }
                timer = 0;
                phase++;
                break;
            case 7:
                AllVariableClear();
                moveType = Qilin_MoveType.Idle;
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
                        pos = new Vector2(stage_RightDown.x + 7.5f, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
                        break;
                    case 0:
                    case 1:
                        pos = new Vector2(stage_LeftTop.x - 7.5f, stage_Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
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
                AllVariableClear();
                moveType = Qilin_MoveType.Idle;
                break;
            default:
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

    void Direction()    //����(�v���[���[�̕���)
    {
        if (0 < plPos.x - pos.x) { plDir = 1; }         //�E
        else if (plPos.x - pos.x < 0) { plDir = -1; }   //��
        else { plDir = 0; }                             //����

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

    void Damage()   //��_���[�W
    {
        damage_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
        StartCoroutine("Flash");
        Debug.Log(obj.name + "�̓_���[�W���󂯂�");
    }

    void Die()      //���S
    {
        moveType = Qilin_MoveType.Die;
        anim.AnimChage("Dead", isLock);
        die_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
        //GameSceneDirector2.Bossdead2 = true;
        Debug.Log(obj.name + "�͎���");
    }

    //----------�A�j���[�V����----------
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

    //----------�e��f�[�^�Ǘ�----------
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
            stage_LeftTop.y - stage_RightDown.y, gc.Ray[0].Layer);  //��������
        Debug.DrawRay(new Vector2(axisX, stage_LeftTop.y), Vector2.down * (stage_LeftTop.y - stage_RightDown.y), Color.green, 1.0f);
        if (rayHit.collider.tag == gc.Ray[0].Tag.ToString())
        {
            Vector2 groundPos = rayHit.point;   //�n�ʈʒu�m�F
            return groundPos.y;
        }
        Debug.LogError(axisX + "�ɒn�ʂ͂Ȃ�");
        return 0;
    }

    IEnumerator Flash()
    {
        while (damage_Repeat < damage_Number)
        {
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = damage_Color;
            }
            //�҂�
            yield return new WaitForSeconds(damage_Time);
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = defColor;
            }
            //�҂�
            yield return new WaitForSeconds(damage_Time);
            damage_Repeat++;
        }
        damage_Repeat = 0;
    }

    void StageData()    //�X�e�[�W
    {
        stage_LeftTop = new Vector2(stage_Center.x - (stage_Range.x * 0.5f), stage_Center.y + (stage_Range.y * 0.5f));
        stage_RightDown = new Vector2(stage_Center.x + (stage_Range.x * 0.5f), stage_Center.y - (stage_Range.y * 0.5f));
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

    bool CheckGroundFlag(GroundCheck.Flag flag)
    {
        return gc.CheckFlag(flag);
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

/*
public class Qilin : QilinBase
{
    public override void Start()
    {
        base.Start();

        //�s��
        tableNo = Random.Range(0, moveTable.Length);
        moveNo = 0;

        //�͈̔�
        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        //�U������֘A
        body.SetActive(true);
        breath.SetActive(false);
        pushUp.SetActive(false);
        SetPower(body, body_Power);
        SetPower(breath, breath_Power);
        SetPower(pushUp, pushUp_Power);

        hm.SetUp(Damage, Dead);
        StageData();

        gPos = Altitude(stage_Center.x);
        renderController.OverwriteFlagForModelScreenColors = true;

    }

    public override void Update()
    {
        if (moveType == Qilin_MoveType.Die) { return; }

        hm.HitUpdate();

        pos = rb.position;
        plPos = pl.transform.position;

        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        switch (moveType)
        {
            case Qilin_MoveType.Idle:
                Idle();
                break;

            case Qilin_MoveType.Breath:
                Breath();
                break;

            case Qilin_MoveType.Eruption:
                Eruption();
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

        rb.position = pos;

        if (moveType == Qilin_MoveType.Idle || moveType == Qilin_MoveType.Breath ||
            moveType == Qilin_MoveType.Eruption || moveType == Qilin_MoveType.PushUp)
        {
            Direction();
        }

        Anim_Basis();
        hm.PostUpdate();


        //Debug.Log(plDir);
        //Debug.Log(phase);
        //Debug.Log(no);
        //Debug.Log(repeat);
        //Debug.Log(moveTable[tableNo].Name + " : " + moveNo);
        //Debug.Log("no " + no + " phase " + phase);
        //Debug.Log(CheckGroundFlag(GroundCheck.Flag.Ground));
        //Debug.Log(gc.GroundFlag());
    }
}

/*
public class QilinAction : QilinBase
{
    public override void Idle()
    {

    }

    public override void Breath()
    {
        switch (phase)
        {
            case 0:
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * plDir * move_Speed;
                phase++;
                break;
            case 1:
                if (breath_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.gravityScale = gravity;
                rb.velocity = Vector2.zero;
                phase++;
                break;
            case 2:
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
            case 3:
                if (anim.NormalizedTime < 0.3f) { break; }
                breath_Effect.Particle.gameObject.SetActive(true);
                breath.SetActive(true);
                breath_Effect.PlayParticle();
                phase++;
                break;
            case 4:
                breath_Effect.StopCheck();
                if (breath_Effect.IsValid) { break; }
                breath.SetActive(false);
                breath_Effect.Particle.gameObject.SetActive(false);
                phase++;
                break;
            case 5:
                timer += Time.deltaTime;
                if (timer < breath_CoolTime) { break; }
                phase++;
                break;
            case 6:
                moveType = Qilin_MoveType.Idle;
                AllVariableClear();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    public override void Eruption()
    {
        switch (phase)
        {
            case 0: //�O��
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 1:
                float Range = eruption_AtkRange.x - body_Range.x;   //���������\��

                Vector2 eruption_Range = Vector2.zero;
                eruption_Range.x =  //������
                    ((body_Center.x) - (body_Range.x * 0.5f)) -
                    (eruption_Center.x - (eruption_AtkRange.x * 0.5f));
                eruption_Range.y =  //�E����
                    (eruption_Center.x + (eruption_AtkRange.x * 0.5f)) -
                    ((body_Center.x) + (body_Range.x * 0.5f));

                //��@���������\���F�������F�E���� = 1�Fx�Fy
                Vector2 eruption_Ratio = Vector2.zero;
                eruption_Ratio.x = eruption_Range.x / Range;
                eruption_Ratio.y = eruption_Range.y / Range;
                if (eruption_Ratio.x < 0) { eruption_Ratio = Vector2.up; }
                else if (eruption_Ratio.y < 0) { eruption_Ratio = Vector2.right; }

                Vector2 empty = new Vector2 //�䂩�獶�E�̉�����������`(�����_����)
                    (eruption_Generate * eruption_Ratio.x, eruption_Generate * eruption_Ratio.y);
                //�����������𐮐���
                eruption_Generatev2.x = Mathf.Round(empty.x);
                eruption_Generatev2.y = Mathf.Round(empty.y);

                //�����ԋ�����`
                eruption_Space = Range / (eruption_Generate + 1);

                //�A�j���[�V�����Đ�
                anim.AnimChage("Pillar", isLock);
                phase++;
                break;
            case 2: //��������
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                Vector2 genPos = Vector2.zero;
                if (repeat < eruption_Generatev2.x)
                {
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) -
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                    no++;
                }
                repeat++;
                phase++;
                break;
            case 3: //�U���Ԍ�
                timer += Time.deltaTime;
                if (timer < eruption_AtkBreakTime) { break; }
                timer = 0;
                if (eruption_Generate - 1 != no) { phase--; }   //�߂�
                else { phase++; }   //�i��
                break;
            case 4:
                if (repeat < eruption_Generatev2.x)
                {
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) -
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(eruption, genPos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                }
                phase++;
                break;
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
                AllVariableClear();
                moveType = Qilin_MoveType.Idle;
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    public override void PushUp()
    {
        switch (phase)
        {
            case 0:
                rb.gravityScale = 0;
                rb.velocity = Vector2.right * plDir * pushUp_MoveSpd;
                pushUp_Effect.Particle.gameObject.SetActive(true);
                pushUp_Effect.PlayParticle();
                //renderController.Opacity = 0;
                phase++;
                break;
            case 1:
                if (pushUp_AtkDis < Mathf.Abs(Distance(plPos).x)) { break; }
                rb.velocity = Vector2.zero;
                var main = pushUp_Effect.Particle.main;
                main.loop = false;
                phase++;
                break;
            case 2:
                Debug.Log(pushUp_Effect.IsValid);
                pushUp_Effect.StopCheck();
                if (pushUp_Effect.IsValid) { break; }
                pushUp_Effect.Particle.gameObject.SetActive(false);
                //renderController.Opacity = 1;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 3:
                timer += Time.deltaTime;
                if (timer < attackAnticipation_Time) { break; }
                timer = 0;
                phase++;
                break;
            case 4:
                anim.AnimChage("PushUp", isLock);
                pushUp.SetActive(true);
                phase++;
                break;
            case 5:
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                pushUp.SetActive(false);
                timer += Time.deltaTime;
                if (timer < pushUp_CoolTime) { break; }
                phase++;
                break;
            case 6:
                moveType = Qilin_MoveType.Idle;
                AllVariableClear();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    public override void Spin()
    {
        switch (phase)
        {
            case 0:
                rb.gravityScale = 0;
                Vector2 vec = new Vector2(stage_Center.x, gPos) - pos;
                rb.velocity = vec.normalized * move_Speed;
                phase++;
                break;
            case 1:
                if (pos.x < stage_Center.x - 2.5f || stage_Center.x + 2.5f < pos.x) { return; }
                rb.velocity = Vector2.zero;
                rb.gravityScale = gravity;
                phase++;
                break;
            case 2://�O��
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
                Vector2 spin2Pos = new Vector2(stage_RightBottom.x, gPos);
                Instantiate(spin, spin1Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                spin_Last =
                    Instantiate(spin, spin2Pos, Quaternion.identity, transform.Find("HitandEffect").gameObject.transform);
                phase++;
                break;
            case 5:
                if (spin_Last != null) { break; }
                phase++;
                break;
            case 6:
                timer += Time.deltaTime;
                if (timer < spin_CoolTime) { break; }
                timer = 0;
                phase++;
                break;
            case 7:
                AllVariableClear();
                moveType = Qilin_MoveType.Idle;
                break;
            default:
                AllVariableClear();
                break;
        }
    }
}
*/