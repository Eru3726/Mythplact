using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Spin : PillarBase
{
    enum LR { L, R }
    float rL;   //範囲左端
    float rR;   //範囲右端

    //----------パラメータ----------
    [Header("Spinパラメータ")]
    [SerializeField, Tooltip("移動速度")] float speed;
    [SerializeField, ReadOnly, Tooltip("左右判定")] LR lr;


    //----------プロパティ----------
    public float Speed { get { return speed; } }


    //
    Vector3 TFPos(GameObject obj) { return obj.transform.position; }


    // Start is called before the first frame update
    void Start()
    {
        SetUp();

        rL = qP.Spin_Center.x - (qP.Spin_AtkRange.x * 0.5f);
        rR = qP.Spin_Center.x + (qP.Spin_AtkRange.x * 0.5f);

        pre = Instantiate(qP.Prediction, pos, Quaternion.identity);
        pre.GetComponent<SpriteRenderer>().color = qP.Spin_Prediction.Color;
        pre.transform.localScale = qP.Spin_Prediction.Scale;

        lr = (rL - TFPos(pre).x < TFPos(pre).x - rR) ? LR.R : LR.L;

        SetPower(Atk, qP.Spin_Power);
    }

    // Update is called once per frame
    void Update()
    {
        ReNew();

        switch (state)
        {
            case Qilin_PillarType.Generate:
                if (AtkAnticipation()) { state = Qilin_PillarType.Up; }
                break;
            case Qilin_PillarType.Up:
                if (Up()) { state = Qilin_PillarType.Move; }
                break;
            case Qilin_PillarType.Move:
                if (Move()) { state = Qilin_PillarType.Keep; }
                break;
            case Qilin_PillarType.Keep:
                if (Keep()) { state = Qilin_PillarType.Death; }
                break;
            case Qilin_PillarType.Death:
                Die();
                break;
        }
    }

    bool Move()
    {
        if (pos.x < rL || rR < pos.x) { return false; }
        rb.velocity = Vector2.zero;
        return true;
    }


    //----------上書き関数----------
    public override bool AtkAnticipation()
    {
        if (!Timer(AtkAnticipationTime)) { return false; }
        Vector2 prePos = Vector2.zero;
        switch(lr)
        {
            case LR.L:
                prePos = new Vector2(pos.x + (rL - pos.x) * 0.5f, pos.y);
                break;
            case LR.R:
                prePos = new Vector2(pos.x + (rR - pos.x) * 0.5f, pos.y);
                break;
        }
        pre = Instantiate(qP.Prediction, prePos, Quaternion.identity);
        pre.GetComponent<SpriteRenderer>().color = qP.Spin_Prediction.Color;
        switch (lr)
        {
            case LR.L:
                pre.transform.localScale = new Vector2(rL - pos.x, qP.Spin_Prediction.Scale.y);
                break;
            case LR.R:
                pre.transform.localScale = new Vector2(pos.x - rR, qP.Spin_Prediction.Scale.y);
                break;
        }
        Effect.PlayParticle();
        Sound.PlayAudio(se);
        return true;
    }

    public override bool Up()
    {
        if (!Timer(UpTime)) { return false; }
        Vector2 vec = new Vector2((Mathf.Abs(rL - pos.x) < Mathf.Abs(rR - pos.x)) ? 1 : -1, 0);
        rb.velocity = vec * speed;
        return true;
    }
}