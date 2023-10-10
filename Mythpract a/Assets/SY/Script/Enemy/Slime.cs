using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Slime : MonoBehaviour
{
    HitMng HMng;
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
        First,  //�����s��
        Walk,   //��{
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
    Vector2 r;  //���a
    Vector2 o;  //���S

    [SerializeField, Tooltip("���x")] float speed = 2;
    [SerializeField, Tooltip("�m�b�N�o�b�N���x")] float knockBackSpd;
    [SerializeField, Tooltip("��������")] float dieTime;
    [SerializeField, Tooltip("�����V���S�X�_���[�W")] float dieDamage;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip Move_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float Move_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float Move_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool Move_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip damage_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float damage_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float damage_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool damage_SELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip die_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float die_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float die_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool die_SELoop;

    //[SerializeField] string animName;
    //[SerializeField] bool debug;

    // Start is called before the first frame update
    void Start()
    {
        HMng = GetComponent<HitMng>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        se = GetComponent<AudioSource>();
        startPos = transform.position;
        GC = GetComponent<GroundCheck>();
        pos =�@rb.position;
        moveType = MoveType.Walk;

        HMng.SetUp(Damage, Die);

        shoggothObj = GameObject.Find("Shoggoth");
        shoggoth = GameObject.Find("Shoggoth").GetComponent<Shoggoth>();
        moveType = MoveType.First;
        firstMove = (int)shoggoth.MoveType;
    }

    //Update is called once per frame
    void Update()
    {
        HMng.HitUpdate();

        if (HMng.HP <= 0) { return; }

        pos = rb.position;
        plPos = shoggoth.Player.transform.position;

        GroundFlagMng();

        switch (moveType)
        {
            case MoveType.First:    //���������s��
                switch (firstMove)
                {
                    case (int)Shoggoth_MoveType.Rotation:
                        if (GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Ground)) { moveType = MoveType.Walk; }
                        break;
                    case (int)Shoggoth_MoveType.UpDown:
                        Parabola();
                        rb.position = pos;
                        break;
                    default:
                        if (GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Ground)) { moveType = MoveType.Walk; }
                        break;
                }
                break;

            case MoveType.Walk:
                switch(walkType)
                {
                    case WalkType.Crawl:
                        Crawl();    //�����Ȃ���ړ�
                        break;
                    case WalkType.Bound:
                        Bound();    //���˂Ȃ���ړ�
                        break;
                }
                break;
        }

        rb.position = pos;
        //Debug.Log(moveFlag + " : " + SlopeFlag + " : " + WallFlag);
        //Debug.Log(GC.GCFlag());
        HMng.PostUpdate();
    }

    //����
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
                if (!GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Ground)) { return; }
                timer += Time.deltaTime;
                if (2.0f < timer) { phase++; }
                break;
            case 1:
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
                if (!GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Ground)) { return; }
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
        MoveDir();
        if (!GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Ground))
        {
            transform.localScale = Vector3.one;
            anim.enabled = false;
            moveFlag = (int)MoveFlag.None;
            SlopeFlag = 0; WallFlag = 0; return;
        }
        if (GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Slope_Left) ||
        GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Slope_Right)) { SlopeFlag = 1; }
        else { SlopeFlag = 0; }
        if (GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Wall_Left) ||
            GC.CheckGCFlag(GroundCheck.GroundCheckFlag.Wall_Right)) { WallFlag = 1; }
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
        rb.AddForce(knockBackSpd * (moveFlag * -1) * Vector2.right, ForceMode2D.Impulse);
    }

    void Die()
    {
        anim.enabled = true;
        Constraints(RigidbodyConstraints2D.FreezeAll);
        SetAudio(die_SE, die_SEVolume, die_SEPitch, die_SELoop);
        anim.Play("Slime01_Die");
        shoggothObj.GetComponent<HitMng>().HP -= dieDamage;
        Destroy(gameObject, dieTime);
    }

    //----------�����s��----------
    //��юU��
    void Parabola()
    {
        switch(phase)
        {
            case 0:
                anim.enabled = false;   //�A�j���[�^�[������
                rb.gravityScale = 0;
                int ran = (Random.value < 0.5f) ? -1 : 1;   //���˕���
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
                pos = circle.Move(timer, 4.0f);  //�X�s�[�h�͉�
                if (pos.y < startPos.y) { phase++; }
                break;
            case 2:
                GeneralClear();
                Destroy(gameObject);
                break;
        }
    }

    //----------���̑�----------
    //�ėp�ϐ�������
    void GeneralClear()
    {
        //�ėp
        phase = 0;
        timer = 0;
        //repeat = 0;
        //No = 0;

        //�~
        circle.DataClear();
    }

    //
    RigidbodyConstraints2D Constraints(RigidbodyConstraints2D set)
    {
        rb.constraints |= set;
        return rb.constraints;
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
