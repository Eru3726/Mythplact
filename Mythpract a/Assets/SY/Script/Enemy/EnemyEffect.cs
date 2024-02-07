using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class EnemyEffect : EnemyBase
{
    //----------パブリック変数----------
    //
    [NonSerialized] public GameObject en;


    //----------パラメータ----------
    [Header("EffectBaseパラメータ")]
    [SerializeField, Tooltip("敵名前")] string enemyName;
    [SerializeField, Tooltip("攻撃判定")] GameObject atk;


    //----------プロパティ----------
    public string EnemyName { get { return enemyName; } }
    public GameObject Atk { get { return atk; } }


    //----------オーバーライド関数----------
    public override void SetUp()
    {
        GeneralVariableClear();

        rb = GetComponent<Rigidbody2D>();
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();

        obj = this.gameObject;
        pos = transform.position;
        defScale = transform.localScale;
        scale = defScale;

        en = GameObject.Find(EnemyName);
    }

    public override void ReNew()
    {
        pos = rb.position;
    }

    public override void Die()
    {
        Debug.Log(obj.name + "は死んだ");
        Destroy(gameObject);
    }
}