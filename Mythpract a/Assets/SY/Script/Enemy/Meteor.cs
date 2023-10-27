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
        None        = 0,    //非アクティブ
        Generate    = 1,    //生成
        Fall        = 2,    //落下
        Impact      = 3,    //爆発
        Die         = 4,    //消滅
    }
    State state = State.None;
    [SerializeField, Tooltip("攻撃判定")] GameObject attack;
    [SerializeField, Tooltip("速度")] float speed = 5.0f;
    [SerializeField, Tooltip("落下エフェクト")] ParticleSetting fall_Effect;
    [SerializeField, Tooltip("落下サウンド")] AudioSetting fall_SE;
    [SerializeField, Tooltip("ダメージエフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("ダメージサウンド")] AudioSetting damage_SE;
    [SerializeField, Tooltip("爆発エフェクト")] ParticleSetting impact_Effect;
    [SerializeField, Tooltip("爆発サウンド")] AudioSetting impact_SE;
    [SerializeField, Tooltip("爆発時間")] float impact_Time = 0.5f;

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

        hm.SetUp(Damage, Impact);   //当たり判定初期設定

        qilin.SetPower(attack, qilin.Meteor_Power); //威力設定

        //範囲
        Vector2 center = qilin.Meteor_Center;
        Vector2 Range = qilin.Meteor_AtkRange;

        //初期位置、目標位置定義
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

        pos = startPos; //初期位置
        vec = (goalPos - startPos).normalized * speed;  //ベクトル

        Quaternion rot = MoveDirection(vec);            //移動方向に向く
        Vector3 euler = rot.eulerAngles;                //オイラー角に変換
        euler.z += 90.0f;                               //方向調整
        //if (Mathf.Abs(euler.z) <= 180.0f) { euler.z += (euler.z < 0) ? 180.0f : -180.0f; }  //左右調整
        transform.rotation = Quaternion.Euler(euler);   //クォータニオンに変換し代入

        //実行
        rb.position = pos;
        rb.velocity = vec;
        fall_Effect.PlayParticle();
        state = State.Fall;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.Fall) { rb.constraints = RigidbodyConstraints2D.FreezePosition; return; }    //落下時以外拒否
        if (gc.CheckFlag(GroundCheck.Flag.Ground)) { Impact(); }    //地面接触時

        hm.HitUpdate();
        pos = rb.position;

        if (pos.y < goalPos.y) { Die(0); }  //攻撃範囲超過時、消去
        hm.PostUpdate();
    }

    void Damage()   //被ダメージ
    {
        damage_Effect.PlayParticle();
        damage_SE.PlayAudio(se);
    }

    void Impact()   //地面接触、許容被ダメ超過
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
