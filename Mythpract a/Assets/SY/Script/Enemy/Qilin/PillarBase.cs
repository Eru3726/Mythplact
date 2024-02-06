using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class PillarBase : EnemyEffect
{
    //----------変数----------
    [NonSerialized] CapsuleCollider2D col;
    [NonSerialized] public Qilin_PillarType state;
    [NonSerialized] public QilinParameter qP;


    //----------パラメータ----------
    [Header("Pillarパラメータ")]
    [SerializeField, Tooltip("上昇時間")] float upTime = 1.0f;
    [SerializeField, Tooltip("攻撃時間")] float atkTime = 5.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting sound;


    //----------プロパティ----------
    public float UpTime { get { return upTime; } }
    public float AtkTime { get { return atkTime; } }
    public ParticleSetting Effect { get { return effect; } }
    public AudioSetting Sound { get { return sound; } }


    //----------上書き許可関数----------
    public virtual bool Up()
    {
        if (!Timer(upTime)) { return false; }
        return true;
    }

    public virtual bool Keep()
    {
        Debug.Log(timer);
        if (!Timer(atkTime)) { return false; }
        col.enabled = false;
        if (effect.IsValid) { return false; }
        return true;
    }


    //----------上書き関数----------
    public override void SetUp()
    {
        base.SetUp();

        state = Qilin_PillarType.Generate;
        col = Atk.GetComponent<CapsuleCollider2D>();
        qP = en.GetComponent<Qilin>().Param;

        effect.PlayParticle();
        sound.PlayAudio(se);

        state = Qilin_PillarType.Up;
    }

    public override void ReNew()
    {
        base.ReNew();

        effect.StopCheck();
    }
}