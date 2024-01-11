using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class EnemyBase : MonoBehaviour
{
    //----------パブリック変数----------
    //クラス
    [NonSerialized] public Rigidbody2D rb;  //物理演算
    [NonSerialized] public AudioSource se;  //音声
    [NonSerialized] public HitMng hm;       //当たり判定

    //汎用変数
    [NonSerialized] public int phase;   //Switch文指定
    [NonSerialized] public float timer; //タイマー
    [NonSerialized] public int repeat;  //繰り返し
    [NonSerialized] public int no;      //

    //GameObject関連(自身)
    [NonSerialized] public GameObject obj;      //自身
    [NonSerialized] public Vector2 pos;         //位置
    [NonSerialized] public Vector3 scale;       //拡縮率
    [NonSerialized] public Vector3 defScale;    //拡縮率保存


    //----------バーチャル関数----------
    /// <summary>
    /// 最初フレーム
    /// </summary>
    public virtual void SetUp() { }

    /// <summary>
    /// 毎フレーム更新
    /// </summary>
    public virtual void ReNew() { }

    /// <summary>
    /// 死亡処理(一回のみ)
    /// </summary>
    public virtual void Die() { }


    //----------パブリック関数----------
    /// <summary>
    /// タイマー
    /// </summary>
    /// <param name="timer">秒数</param>
    /// <returns></returns>
    public bool Timer(float timer)
    {
        this.timer += Time.deltaTime;
        if (this.timer < timer) { return false; }
        this.timer = 0;
        return true;
    }

    /// <summary>
    /// 威力設定
    /// </summary>
    /// <param name="obj">オブジェクト</param>
    /// <param name="power">威力</param>
    public void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<HitData>().Power = power;
    }

    /// <summary>
    /// 汎用変数初期化
    /// </summary>
    public void GeneralVariableClear()
    {
        phase = 0;
        timer = 0;
        repeat = 0;
        no = 0;
    }
}