using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Meteor : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource se;
    HitMng hm;
    GroundCheck gc;
    Qilin qilin;

    enum State
    {
        None        = 0,    //��A�N�e�B�u
        Generate    = 1,    //����
        Fall        = 2,    //����
        Impact      = 3,    //����
        Die         = 4,    //����
    }
    State state = State.None;
    [SerializeField, Tooltip("�U������")] GameObject attack;
    [SerializeField, Tooltip("���x")] float speed = 5.0f;
    [SerializeField, Tooltip("�����G�t�F�N�g")] ParticleSetting fall_Effect;
    [SerializeField, Tooltip("�����T�E���h")] AudioSetting fall_SE;
    [SerializeField, Tooltip("�_���[�W�G�t�F�N�g")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("�_���[�W�T�E���h")] AudioSetting damage_SE;
    [SerializeField, Tooltip("�����G�t�F�N�g")] ParticleSetting impact_Effect;
    [SerializeField, Tooltip("�����T�E���h")] AudioSetting impact_SE;
    [SerializeField, Tooltip("��������")] float impact_Time = 0.5f;

    Vector2 pos;
    Vector2 vec;
    Vector2 startPos;
    Vector2 goalPos;
    Vector2 plPos;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Generate;

        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        qilin = GameObject.Find("Qilin").GetComponent<Qilin>();
        plPos = qilin.Player.transform.position;

        hm.SetUp(Damage, Impact);   //�����蔻�菉���ݒ�

        qilin.SetPower(attack, qilin.Meteor_Power); //�З͐ݒ�

        //�͈�
        Vector2 center = qilin.Meteor_Center;
        Vector2 Range = qilin.Meteor_AtkRange;

        //�����ʒu�A�ڕW�ʒu��`
        switch(qilin.PlDir)
        {
            case -1:
                startPos.x = Random.Range(center.x - Range.x * 0.5f, center.x);
                goalPos.x = Random.Range(startPos.x, center.x + Range.x * 0.5f);
                break;
            case 0:
            case 1:
                startPos.x = Random.Range(center.x, center.x + Range.x * 0.5f);
                goalPos.x = Random.Range(center.x - Range.x * 0.5f, startPos.x);
                break;
        }
        startPos.y = center.y + Range.y * 0.5f;
        goalPos.y = center.y - Range.y * 0.5f;

        pos = startPos; //�����ʒu
        vec = (goalPos - startPos).normalized * speed;  //�x�N�g��

        Quaternion rot = MoveDirection(vec);            //�ړ������Ɍ���
        Vector3 euler = rot.eulerAngles;                //�I�C���[�p�ɕϊ�
        euler.z += 90.0f;                               //��������
        //if (Mathf.Abs(euler.z) <= 180.0f) { euler.z += (euler.z < 0) ? 180.0f : -180.0f; }  //���E����
        transform.rotation = Quaternion.Euler(euler);   //�N�H�[�^�j�I���ɕϊ������

        //���s
        rb.position = pos;
        rb.velocity = vec;
        fall_Effect.PlayParticle();
        state = State.Fall;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.Fall) { rb.constraints = RigidbodyConstraints2D.FreezePosition; return; }    //�������ȊO����
        if (gc.CheckFlag(GroundCheck.Flag.Ground)) { Impact(); }    //�n�ʐڐG��

        hm.HitUpdate();
        pos = rb.position;

        if (pos.y < goalPos.y) { Die(0); }  //�U���͈͒��ߎ��A����
        hm.PostUpdate();
    }

    void Damage()   //��_���[�W
    {
        damage_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
    }

    void Impact()   //�n�ʐڐG�A���e��_������
    {
        state = State.Impact;
        impact_Effect.PlayParticle();
        impact_SE.PlayAudio(se);
        Die(impact_Time);
    }

    void Die(float time)
    {
        Destroy(gameObject, time);
        state = State.Die;
    }

    Quaternion MoveDirection(Vector2 vec)
    {
        Vector2 after = pos;
        Vector2 before = pos + vec;

        Vector2 dir = after - before;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);
        return rot;
    }
}
