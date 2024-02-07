using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Spin : PillarBase
{
    float rL;   //範囲左端
    float rR;   //範囲右端


    //----------パラメータ----------
    [Header("Spinパラメータ")]
    [SerializeField, Tooltip("移動速度")] float speed;


    //----------プロパティ----------
    public float Speed { get { return speed; } }


    // Start is called before the first frame update
    void Start()
    {
        SetUp();

        rL = qP.Spin_Center.x - (qP.Spin_AtkRange.x * 0.5f);
        rR = qP.Spin_Center.x + (qP.Spin_AtkRange.x * 0.5f);

        SetPower(Atk, qP.Spin_Power);
    }

    // Update is called once per frame
    void Update()
    {
        ReNew();

        switch (state)
        {
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
    public override bool Up()
    {
        if (!Timer(UpTime)) { return false; }
        Vector2 vec = new Vector2((Mathf.Abs(rL - pos.x) < Mathf.Abs(rR - pos.x)) ? 1 : -1, 0);
        rb.velocity = vec * speed;
        return true;
    }
}