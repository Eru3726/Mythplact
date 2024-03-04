using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Meteor : EnemyEffect
{

    //----------変数----------
    GroundCheck gc;
    Qilin_MeteorType state;
    QilinParameter qP;

    Vector2 goal;
    Vector2 vec;


    //----------パラメータ----------
    [Header("Meteorパラメータ")]
    [SerializeField, Tooltip("速度")] float speed = 5.0f;
    [SerializeField, Tooltip("落下エフェクト")] ParticleSetting fall_Effect;
    [SerializeField, Tooltip("落下サウンド")] AudioSetting fall_SE;
    [SerializeField, Tooltip("ダメージエフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("ダメージサウンド")] AudioSetting damage_SE;
    [SerializeField, Tooltip("爆発エフェクト")] ParticleSetting impact_Effect;
    [SerializeField, Tooltip("爆発サウンド")] AudioSetting impact_SE;
    [SerializeField, Tooltip("爆発時間")] float impact_Time = 0.5f;


    //----------プロパティ----------
    public float Speed { get { return speed; } }
    public ParticleSetting Fall_Effect { get { return fall_Effect; } }
    public AudioSetting Fall_SE { get { return fall_SE; } }
    public ParticleSetting Damage_Effect { get { return damage_Effect; } }
    public AudioSetting Damage_SE { get { return damage_SE; } }
    public ParticleSetting Impact_Effect { get { return impact_Effect; } }
    public AudioSetting Impact_SE { get { return impact_SE; } }
    public float Impact_Time { get { return impact_Time; } }


    void Start()
    {
        base.SetUp();

        state = Qilin_MeteorType.Generate;
        gc = GetComponent<GroundCheck>();
        qP = en.GetComponent<Qilin>().Param;

        hm.SetUp(Damage, Impact);   //当たり判定初期設定

        SetPower(Atk, qP.Meteor_Power); //威力設定

        if (goal == null) { Debug.Log("goalが設定されていない"); Start(); }  //再実行

        vec = (goal - pos).normalized * speed;  //ベクトル

        Quaternion rot = MoveDirection(vec);            //移動方向に向く
        Vector3 euler = rot.eulerAngles;                //オイラー角に変換
        euler.z += 90.0f;                               //方向調整
        //if (Mathf.Abs(euler.z) <= 180.0f) { euler.z += (euler.z < 0) ? 180.0f : -180.0f; }  //左右調整
        transform.rotation = Quaternion.Euler(euler);   //クォータニオンに変換し代入

        GameObject p = Instantiate(qP.Prediction, pos, rot);
        p.GetComponent<SpriteRenderer>().color = qP.Meteor_Prediction.Color;
        p.transform.localScale = qP.Meteor_Prediction.Scale;

        //実行
        rb.velocity = vec;
        fall_Effect.PlayParticle();
        state = Qilin_MeteorType.Fall;
    }

    void Update()
    {
        if (state != Qilin_MeteorType.Fall) { rb.constraints = RigidbodyConstraints2D.FreezePosition; return; }    //落下時以外拒否
        if (gc.CheckFlag(GroundCheck.Flag.Ground)) { Impact(); }    //地面接触時

        hm.HitUpdate();
        pos = rb.position;

        if (pos.y < goal.y) { Die(0); }  //攻撃範囲超過時、消去
        hm.PostUpdate();
    }


    //----------パブリック関数----------
    /// <summary>
    /// 目標設定
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="center">中心座標</param>
    /// <param name="range">範囲</param>
    public void SetGoal(int dir, Vector2 center, Vector2 range)
    {
        switch (dir)
        {
            case -1:
                goal.x = Random.Range(pos.x, center.x + range.x * 0.5f);
                break;
            case 0:
            case 1:
                goal.x = Random.Range(center.x - range.x * 0.5f, pos.x);
                break;
        }
        goal.y = center.y - range.y * 0.5f;
    }


    //----------プライベート関数----------
    void Damage()
    {
        damage_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
    }

    void Impact()   //地面接触、許容被ダメ超過
    {
        state = Qilin_MeteorType.Impact;
        impact_Effect.PlayParticle();
        impact_SE.PlayAudio(se);
        Die(impact_Time);
    }

    void Die(float time)
    {
        Destroy(gameObject, time);
        state = Qilin_MeteorType.Death;
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