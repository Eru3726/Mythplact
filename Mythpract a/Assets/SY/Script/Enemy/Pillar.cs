using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Pillar : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource se;
    //HitMng hm;
    Qilin qilin;

    enum State
    {
        None        = 0,    //��A�N�e�B�u
        Generate    = 1,    //����
        Up          = 2,    //�㏸
        Move        = 3,    //�ړ�
        Keep        = 4,    //���
        Die         = 5,    //����
    }
    State state = State.None;
    [SerializeField, Tooltip("�U������")] GameObject attack;
    [SerializeField, Tooltip("���x")] float speed = 5.0f;
    [SerializeField, Tooltip("�㏸����")] float upTime = 1.0f;
    [SerializeField, Tooltip("�U������")] float time = 5.0f;
    [SerializeField, Tooltip("�G�t�F�N�g")] ParticleSetting effect;
    [SerializeField, Tooltip("�T�E���h")] AudioSetting sound;

    float timer = 0;
    Vector2 pos;
    Vector2 scale;

    Qilin_MoveType move;
    Vector2 center;
    Vector2 range;
    float rangeLeft;
    float rangeRight;

    public ParticleSetting Effect { get { return effect; } set { effect = value; } }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Generate;
        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        //hm = GetComponent<HitMng>();
        qilin = transform.root.gameObject.GetComponent<Qilin>();
        pos = transform.position;
        scale = transform.localScale;
        move = qilin.MoveType;

        effect.PlayParticle();
        sound.PlayAudio(se);

        switch (move)
        {
            case Qilin_MoveType.Eruption:
                qilin.SetPower(attack, qilin.Eruption_Power); //�З͐ݒ�
                break;
            case Qilin_MoveType.Spin:
                qilin.SetPower(attack, qilin.Spin_Power);
                center = qilin.Spin_Center;
                range = qilin.Spin_AtkRange;
                rangeLeft = center.x - (range.x * 0.5f);
                rangeRight = center.x + (range.x * 0.5f);
                break;
        }
        state = State.Up;
    }

    // Update is called once per frame
    void Update()
    {
        effect.StopCheck();
        pos = rb.position;

        switch (state)
        {
            case State.Up:
                timer += Time.deltaTime;
                if (Up())
                {
                    switch(move)
                    {
                        case Qilin_MoveType.Eruption:
                            state = State.Keep;
                            break;
                        case Qilin_MoveType.Spin:
                            state = State.Move;
                            break;
                    }
                }
                break;
            case State.Move:
                if (Move()) { state = State.Keep; }
                break;
            case State.Keep:
                timer += Time.deltaTime;
                if (Keep()) { Die(); }
                break;
        }
    }

    bool Up()
    {
        if (timer < upTime) { return false; }
        Vector2 vec = new Vector2((Mathf.Abs(rangeLeft - pos.x) < Mathf.Abs(rangeRight - pos.x)) ? 1 : -1, 0);
        rb.velocity = vec * speed;
        timer = 0;
        return true;
    }

    bool Move()
    {
        if (pos.x < rangeLeft || rangeRight < pos.x) { return false; }
        rb.velocity = Vector2.zero;
        return true;
    }

    bool Keep()
    {
        if (effect.IsValid) { return false; }
        if (timer < time) { return false; }
        return true;
    }

    void Die()
    {
        Destroy(gameObject);
        state = State.Die;
    }
}