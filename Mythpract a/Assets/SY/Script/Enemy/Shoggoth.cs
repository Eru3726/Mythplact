//�{�X1�F�V���S�X

using System.Collections.Generic;
using UnityEngine;
using SY;

public enum Shoggoth_MoveType
{
    Eight,      //��{
    Rotation,   //���L�����p�^�[��2
    UpDown,     //���L�����p�^�[��3
    Rush,       //���L�����p�^�[��4
}

public class Shoggoth : MonoBehaviour
{
    Rigidbody2D rb;                 //�������Z
    AudioSource se;                 //�T�E���h
    HitMng hm;                      //�����蔻��
    Circle circle = new Circle();   //�~

    //
    [SerializeField, Tooltip("�v���C���[")] GameObject pl;
    [SerializeField, Tooltip("�X���C��")] GameObject slime;

    //
    int phase = 0;      //�ėp�s���ԍ�
    float timer = 0;    //�ėp�^�C�}�[
    int repeat = 0;     //�ėp�J��Ԃ���
    int no = 0;         //�ėp�i���o

    int tableNo = 0;    //�e�[�u���w��
    int moveNo = 0;     //�s���w��

    //
    [SerializeField, Tooltip("�s��"), ReadOnly] Shoggoth_MoveType moveType = Shoggoth_MoveType.Eight;
    [SerializeField, Tooltip("�s���e�[�u��")] Shoggoth_MoveTable[] moveTable;
    [SerializeField, Tooltip("���x")] float speed;
    const float speed_save = 0.05f;

    [Header("�{��")]
    [SerializeField, Tooltip("���U������")] GameObject head;
    [SerializeField, Tooltip("�̍U������")] GameObject[] body;
    [SerializeField, Tooltip("���U������")] GameObject tail;
    [SerializeField, Tooltip("���ڐG�З�")] float head_Power = 1.0f;
    [SerializeField, Tooltip("�̐ڐG�З�")] float body_Power = 1.0f;
    [SerializeField, Tooltip("���ڐG�З�")] float tail_Power = 1.0f;

    GameObject obj;     //���g
    GameObject headObj; //��
    Vector2 pos;        //���W
    Vector2 plPos;      //�v���[���[���W
    Quaternion rot;     //�p�x�ۑ�
    Vector3 defScale;   //�g�k���ۑ�
    Vector3 scale;      //�g�k���X�V
    float gravity;      //�d�͋��x�ۑ�
    Vector2 dir;        //�ړ�����

    Vector2 beforePos;  //�ړ��O�̈ʒu
    Vector2 afterPos;   //�ړ���̈ʒu
    Vector2 targetPos;  //�ڕW�ʒu
    float groundPosY;   //�n�ʂ̍���

    [Header("���̎�")]
    [SerializeField, Tooltip("���x")] float eight_Speed;
    [SerializeField, Tooltip("���S���W")] Vector2 eight_Center;
    [SerializeField, Tooltip("���a")] Vector2 eight_Radius;
    [SerializeField, Tooltip("�ҋ@����")] float eight_BreakTime;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip eight_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float eight_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float eight_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool eight_SELoop;
    [SerializeField, Tooltip("�ړ��͈͉���")] bool eight_MoveRangeDisplay;

    [Header("����")]
    [SerializeField, Tooltip("����")] GameObject[] rotation;
    [SerializeField, Tooltip("���x")] float rotation_Speed;
    [SerializeField, Tooltip("���S���W")] Vector2 rotation_Center;
    [SerializeField, Tooltip("���a")] Vector2 rotation_Radius;
    [SerializeField, Tooltip("�X���C��������")] int rotation_SlimeGenerate;
    [SerializeField, Tooltip("�З�")] float rotation_Power;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip rotation_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float rotation_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float rotation_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool rotation_SELoop;
    [SerializeField, Tooltip("�ړ��͈͉���")] bool rotation_MoveRangeDisplay;

    [Header("�㉺")]
    [SerializeField, Tooltip("����")] GameObject[] upDown;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSystem upDown_Effect;
    [SerializeField, Tooltip("���x")] float upDown_Speed;
    [SerializeField, Tooltip("���S���W")] Vector2 upDown_Center;
    [SerializeField, Tooltip("���a")] Vector2 upDown_Radius;
    [SerializeField, Tooltip("�U����")] float upDown_AtkTime;
    [SerializeField, Tooltip("�X���C��������")] int upDown_SlimeGenerate;
    [SerializeField, Tooltip("�З�")] float upDown_Power;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip upDown_InSE;
    [SerializeField, Range(0, 1), Tooltip("����")] float upDown_InSEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float upDown_InSEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool upDown_InSELoop;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip upDown_OutSE;
    [SerializeField, Range(0, 1), Tooltip("����")] float upDown_OutSEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float upDown_OutSEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool upDown_OutSELoop;
    [SerializeField, Tooltip("�ړ��͈͉���")] bool upDown_MoveRangeDisplay;

    [Header("�ːi")]
    [SerializeField, Tooltip("����")] GameObject[] rush;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSystem rush_Effect;
    [SerializeField, Tooltip("���x")] float rush_Speed;
    [SerializeField, Tooltip("���S���W"), ReadOnly] string rush_Center = "�v���C���[�̈ʒu";
    [SerializeField, Tooltip("�I�t�Z�b�g")] Vector2 rush_Offset;
    [SerializeField, Tooltip("���a")] Vector2 rush_Radius;
    [SerializeField, Tooltip("�З�")] float rush_Power;
    [SerializeField, Tooltip("�T�E���h�G�t�F�N�g")] AudioClip rush_SE;
    [SerializeField, Range(0, 1), Tooltip("����")] float rush_SEVolume;
    [SerializeField, Range(-3, 3), Tooltip("�Đ����x")] float rush_SEPitch;
    [SerializeField, Tooltip("�T�E���h���[�v��")] bool rush_SELoop;
    [SerializeField, Tooltip("�ړ��͈͉���")] bool rush_MoveRangeDisplay;

    [Header("�X���C��")]
    [SerializeField, Tooltip("�����Ԋu")] float slime_GenerateTime;

    public GameObject Player { get { return pl; } }
    public Shoggoth_MoveType MoveType { get { return moveType; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();
        obj = this.gameObject;
        headObj = transform.Find("Model/Head").gameObject;
        pos = rb.position;
        plPos = pl.transform.position;
        scale = headObj.transform.localScale;
        gravity = rb.gravityScale;
        groundPosY = GroundPosition(eight_Center.x);

        tableNo = Random.Range(0, moveTable.Length);
        moveNo = 0;

        PowerReset();
        rush_Effect.Clear();

        hm.SetUp(Damage, Die);
        AllVariableClear();
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log(moveTable[tableNo].Name + " : " + moveTable[tableNo].Move[moveNo]);
        //Debug.Log(moveType);
        hm.HitUpdate();

        plPos = pl.transform.position;   //�v���C���[�̈ʒu

        beforePos = rb.position; //�ړ��O�̈ʒu�ۑ�(�����Z�o�̂���)

        switch (moveType)
        {
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

        afterPos = rb.position;  //�ړ��ړ���̈ʒu�ۑ�

        //�ړ������Ɍ���
        transform.rotation = MoveDirection(beforePos, afterPos);
        BodyRot();

        //Debug.Log(phase);
        hm.PostUpdate();
    }

    //----------�A�N�V����----------
    //8�̎��ړ�
    void Eight()
    {
        switch (phase)
        {
            case 0: //�З͐ݒ�A�ڕW�ʒu�A�ړ�������`
                circle.Data(eight_Center.x, eight_Center.y, eight_Radius.x, eight_Radius.y, 1.0f, 1.0f, 1, 0);
                targetPos = circle.Move(0, 0);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1: //�ړ��A�ڕW�ʒu��������
                pos = Trac(pos, targetPos, dir, speed);
                if (pos == targetPos)
                {
                    circle.Data(eight_Center.x, eight_Center.y, eight_Radius.x, eight_Radius.y, 1.0f, 2.0f);
                    SetAudio(eight_SE, eight_SEVolume, eight_SEPitch, eight_SELoop);
                    phase++;
                }
                break;
            case 2:    //�ړ�����
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

    
    //����s��
    void Rotation()
    {
        switch (phase)
        {
            case 0: //����J�n�ʒu�A�ړ�����
                circle.Data
                    (rotation_Center.x, rotation_Center.y, rotation_Radius.x, rotation_Radius.y, 1.0f, 1.0f, 1, 0);
                targetPos = circle.Move(0, 0);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1: //�ړ��A����J�n�ʒu�������З͐ݒ�
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
            case 2:    //����s���A�X���C���������ԁ������A�w�萶���񐔒B������
                timer += Time.deltaTime;
                pos = circle.Move(timer, rotation_Speed);
                if ((timer % slime_GenerateTime) + Time.deltaTime > slime_GenerateTime)
                {
                    Instantiate(slime, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                    no++;
                    if (no > rotation_SlimeGenerate) { phase++; }
                }
                break;
            case 3: //�I������
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    int No;
    //�㉺�s��
    void UpDown()
    {
        switch (phase)
        {
            case 0:     //�w�蒆�S���W�㕔�A�ړ�������`
                targetPos = new Vector2(upDown_Center.x, upDown_Center.y + upDown_Radius.y);
                dir = Distance(pos, targetPos).normalized;
                phase++;
                break;
            case 1:     //�ړ��A�ڕW�ʒu���B�����A�ړ������Ē�`
                pos = Trac(pos, targetPos, dir, speed);
                if (pos == targetPos)
                {
                    dir = Distance(pos, pos + Vector2.up).normalized;
                    phase++;
                }
                break;
            case 2:     //�w��b�ԏ㕔�ֈړ�
                timer += Time.deltaTime;    //�^�C�}�[�N��
                pos = Trac(pos, dir, speed);       //��Ɍ�����
                if (timer > 1)              //1�b��
                {
                    timer = 0;              //�^�C�}�[���Z�b�g
                    phase++;
                }
                break;
            case 3: //1�t���[������
                upDown_Effect.Stop();
                if (upDown != null || upDown.Length != 0)
                {
                    SetPower(upDown, upDown_Power);                             //�З͐ݒ�
                }
                float width = upDown_Radius.x * 2.0f;                           //��
                pos = new Vector2(                                              //�ːi�J�n�ʒu��`
                    (upDown_Center.x - upDown_Radius.x) + ((width / (upDown_AtkTime + 1)) * (repeat + 1)),
                    (pos.y > upDown_Center.y + upDown_Radius.y) ? upDown_Center.y + upDown_Radius.y : upDown_Center.y - upDown_Radius.y);
                dir = (pos.y == upDown_Center.y + upDown_Radius.y) ? Vector2.down : Vector2.up; //�ːi������`
                Quaternion q = (dir == Vector2.down) ?
                    Quaternion.Euler(90.0f, 0, 0) : Quaternion.Euler(-90.0f, 0, 0);
                upDown_Effect.transform.localRotation = q;
                //SetAudio(upDown_SE, upDown_SEVolume, upDown_SEPitch, upDown_SELoop);
                phase++;
                repeat++;
                no = 0;                                                         //�X���C�������񐔃��Z�b�g
                No = 0; //�T�E���h�Đ�
                break;
            case 4: //�J��Ԃ�����
                pos = Trac(pos, dir, upDown_Speed);   //�ړ�
                if (pos.y > upDown_Center.y + upDown_Radius.y || pos.y < upDown_Center.y - upDown_Radius.y)   //��ʏ㕔�܂������ɏo��
                {
                    if (repeat == upDown_AtkTime) { phase++; break; }    //�ːi���s�񐔂��w���񐔂Ɠ���̎��������i��
                    phase--;                                            //���̏����𖞂����Ȃ����������߂�Ē�`
                }

                if (dir == Vector2.down)            //�ړ���������
                {
                    if (pos.y < groundPosY)        //�n�\����
                    {
                        if(No == 0)
                        {
                            SetAudio(upDown_InSE, upDown_InSEVolume, upDown_InSEPitch, upDown_InSELoop);
                            No++;

                        }
                        upDown_Effect.Play();
                        upDown_Effect.transform.position = new Vector2
                            (upDown_Effect.transform.position.x, groundPosY + 2.0f);
                        if (no == upDown_SlimeGenerate) { return; }   //�X���C�������񐔂��w���񐔂Ɠ���
                        Instantiate(slime, new Vector3(pos.x, groundPosY, 0), Quaternion.identity); //�X���C������
                        no++;                       //�X���C��������
                    }
                }
                else if (dir == Vector2.up)         //�ړ���������
                {
                    if (pos.y > groundPosY)        //�n������o��
                    {
                        if (No == 0)
                        {
                            SetAudio(upDown_OutSE, upDown_OutSEVolume, upDown_OutSEPitch, upDown_OutSELoop);
                            No++;

                        }
                        upDown_Effect.Play();
                        upDown_Effect.transform.position = new Vector2
                            (upDown_Effect.transform.position.x, groundPosY + 2.0f);
                        if (no == upDown_SlimeGenerate) { return; }   //�X���C�������񐔂��w���񐔂Ɠ���
                        Instantiate(slime, new Vector3(pos.x, groundPosY, 0), Quaternion.identity);
                        no++;
                    }
                }
                break;
            case 5: //1�t���[������
                upDown_Effect.Stop();
                MoveEnd();
                break;
            default:    //1�t���[������ (�s���J�ڎ��������p)
                AllVariableClear();
                break;
        }
    }

    //�ʂ�`���ăv���C���[�֓ːi
    void Rush()
    {
        switch (phase)
        {
            case 0: //�ڕW�ʒu�A�ړ�������`
                if (plPos.x > eight_Center.x)         //�v���C���[�̈ʒu���������E
                { targetPos = eight_Center + eight_Radius; }
                else if (plPos.x <= eight_Center.x)   //�v���C���[�̈ʒu��������荶
                { targetPos = eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y); }
                else { Debug.LogError("targetPos��null"); }
                dir = Distance(pos, targetPos).normalized;
                phase++; break;
            case 1: //�ړ��A�ڕW�ʒu��������
                pos = Trac(pos, targetPos, dir, speed * 1.5f);
                if (pos == targetPos)
                {
                    phase++;
                    dir = Distance(pos, pos + Vector2.up).normalized;
                }
                break;
            case 2: //1�b�ԏ�Ɍ�����(���ꂢ��Ȃ�����)
                timer += Time.deltaTime;
                pos = Trac(pos, dir, speed * 2.0f);
                if (timer > 1.0f)
                {
                    pos = new Vector2(eight_Center.x, 100.0f);
                    phase++;
                    timer = 0;
                }
                break;
            case 3:     //�ːi�J�n�ʒu�Ɉړ�
                if (targetPos == eight_Center + eight_Radius)   //�E����͂�����
                { pos = eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y) + (Vector2.up * 15.0f); }
                else if (targetPos == eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y))   //������͂�����
                { pos = eight_Center + eight_Radius + (Vector2.up * 15.0f); }
                phase++;
                break;
            case 4:     //�̂̌����X�V
                timer += Time.deltaTime;
                float moveDir = (targetPos == eight_Center + eight_Radius) ? 1.0f : -1.0f;
                pos += new Vector2(moveDir, -1.0f).normalized * 2.0f * speed_save;
                if (timer < 1.0f) { break; }
                timer = 0;
                phase++;
                break;
            case 5:     //�З͐ݒ�A�U���J�n�ʒu�A�v���C���[�̈ʒu�A�ړ������A�ړ�����(���a)��`
                if (rush != null || rush.Length != 0)
                {
                    SetPower(rush, rush_Power);
                }
                if (targetPos == eight_Center + eight_Radius)       //�E����͂����獶����ːi
                { circle.Direction = 1; }
                else if (targetPos == eight_Center + new Vector2(eight_Radius.x * -1.0f, eight_Radius.y))   //������͂�����E����ːi
                { circle.Direction = -1; }
                circle.RadPos = (circle.Direction == 1) ? 1 : 0;
                circle.Data(plPos.x + rush_Offset.x, plPos.y + rush_Offset.y, rush_Radius.x, rush_Radius.y, 1.0f, 1.0f);
                SetAudio(rush_SE, rush_SEVolume, rush_SEPitch, rush_SELoop);
                rush_Effect.Play();
                //rush_Effect.transform.rotation = new Quaternion(transform.rotation.x, 90, 0, 1);
                phase++;
                break;
            case 6: //�ړ��A�I������
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

    void MoveEnd()  //�s���I��������
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

    //������������Ȃ��悤��
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

    void Damage()
    {
        Debug.Log(gameObject.name + "�̓_���[�W�󂯂�");
    }

    void Die()
    {
        Debug.Log(gameObject.name + "�͎���");
        GameSceneDirector.Bossdead = true;
    }

    //----------�e��f�[�^�Ǘ�----------
    void AllVariableClear()     //�ϐ�������
    {
        GeneralVariableClear();
        PowerReset();

        //�~
        circle.DataClear();
    }

    void GeneralVariableClear() //�ėp�ϐ�������
    {
        phase = 0;
        timer = 0;
        repeat = 0;
        no = 0;
    }

    void PowerReset()        //�З͏�����
    {
        SetPower(head, head_Power);
        SetPower(body, body_Power);
        SetPower(tail, tail_Power);
    }

    float GroundPosition(float axisX)
    {
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D rayHit =
            Physics2D.Raycast(new Vector2(axisX, eight_Center.y + eight_Radius.y), Vector2.down,
            eight_Center.y + eight_Radius.y * 5.0f, layerMask);  //��������
        Debug.DrawRay(new Vector2(axisX, eight_Center.y + eight_Radius.y),
            Vector2.down * (eight_Center.y + eight_Radius.y) * 5.0f, Color.green, 1.0f);
        if (rayHit.collider.tag == "Ground")
        {
            Vector2 groundPos = rayHit.point;   //�n�ʈʒu�m�F
            return groundPos.y;
        }
        Debug.LogError(axisX + "�ɒn�ʂ͂Ȃ�");
        return 0;
    }

    //����
    Vector2 Distance(Vector2 currentPos, Vector2 targetPos)
    {
        Vector2 distance = targetPos - currentPos;
        return distance;
    }

    //�ǔ�
    Vector2 Trac(Vector2 pos, Vector2 direction, float speed)
    {
        pos += direction * (speed * speed_save);
        return pos;
    }

    //�ǔ�2   �ڕW�ʒu�Ŏ~�܂�
    Vector2 Trac(Vector2 pos, Vector2 targetPos, Vector2 direction, float speed)
    {
        pos += direction * (speed * speed_save);
        if (Distance(pos, targetPos).normalized == direction * -1.0f)
        {
            pos = targetPos;
        }
        return pos;
    }

    //�ړ�����(�ړ��O�̈ʒu,�ړ���̈ʒu)
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

    //�T�E���h
    void SetAudio(AudioClip audio, float Volume, float Pitch, bool isLoop)
    {
        se.clip = audio;
        se.volume = Volume;
        se.pitch = Pitch;
        se.loop = isLoop;
        se.Play();
    }

    //----------�M�Y��----------
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