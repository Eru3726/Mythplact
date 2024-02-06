using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using SY;

public class Enemy : EnemyBase
{
    //----------パブリック変数----------
    //アタッチクラス(無いとエラー出す)
    [NonSerialized] public BoxCollider2D bc;                            //コライダー
    [NonSerialized] public GroundCheck gc;                              //地面判定
    [NonSerialized] public Anim anim;                                   //アニメーション
    [NonSerialized] public CinemachineBasicMultiChannelPerlin vCamera;  //カメラ
    [NonSerialized] public MotionBlur mBlur;                            //

    //汎用変数　サブ
    [NonSerialized] public int phaseSub;    //Switch文指定
    [NonSerialized] public float timerSub;  //タイマー
    [NonSerialized] public int repeatSub;   //繰り返し
    [NonSerialized] public int noSub;       //

    //行動指定
    [NonSerialized] public int tableNo; //テーブル指定
    [NonSerialized] public int moveNo;  //行動指定
    [NonSerialized] public bool isDebug = false;   //デバックモード

    //GameObject関連
    [NonSerialized] public int dir;             //左右方向(-1or1)
    [NonSerialized] public bool isDirection;    //向き変更許可

    //他オブジェクトtransform関連
    [NonSerialized] public Vector2 plPos;   //プレーヤーの位置

    //
    [NonSerialized] public float gPos;          //地面高度
    [NonSerialized] public Vector2 body_Center; //身体中心座標
    [NonSerialized] public Vector2 body_Range;  //身体幅

    //アニメーション
    [NonSerialized] public bool anim_IsPriority = true; //優先度設定有効

    //ステージ
    [NonSerialized] public Vector2 stage_LeftBottom;    //左下
    [NonSerialized] public Vector2 stage_RightTop;      //右下


    //----------プライベート変数----------
    float defGravity;    //重力保存

    private readonly AchvMeasurement achv = new AchvMeasurement();


    //----------バーチャル関数----------
    //行動
    /// <summary>
    /// 登場
    /// </summary>
    public virtual void Entry() { }

    /// <summary>
    /// 待機
    /// </summary>
    public virtual void Idle() { }

    /// <summary>
    /// ダメージ
    /// </summary>
    public virtual void Damage()
    {
        Debug.Log(obj.name + "はダメージを受けた");
        StartCoroutine("Flash");
    }

    /// <summary>
    /// 死亡状態(複数回実行)
    /// </summary>
    public virtual void Dead()
    {
        Debug.Log(obj.name + "は死んでいる");
    }

    //サポート
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="mode">処理方法</param>
    /// <param name="velocity">ベクトル</param>
    /// <param name="speed">速度</param>
    public virtual void Move(Vector2 velocity, float speed)
    {
        pos += velocity.normalized * speed;
    }

    /// <summary>
    /// 行動終了
    /// </summary>
    public virtual void MoveEnd()
    {
        AllVariableClear();
        Debug.Log("行動終了");
    }

    /// <summary>
    /// 点滅
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Flash()
    {
        yield return 0;
    }

    /// <summary>
    /// 当たり判定一括変更
    /// </summary>
    /// <param name="value"></param>
    public virtual void AllHitActive(bool value) { }

    public virtual void AllHitPower() { }

    /// <summary>
    /// 変数初期化
    /// </summary>
    public void VariableClear()
    {
        isDirection = true;
        ClearGravity();
    }

    /// <summary>
    /// 全汎用変数初期化
    /// </summary>
    public virtual void AllVariableClear()
    {
        VariableClear();
        GeneralVariableClear();
        GeneralVariableClearSub();
    }

    /// <summary>
    /// 基本アニメーション
    /// </summary>
    public virtual void AnimBasis() { }


    //----------オーバーライド関数----------
    /// <summary>
    /// セットアップ
    /// </summary>
    public override void SetUp()
    {
        //GetComponent
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        se = GetComponent<AudioSource>();
        hm = GetComponent<HitMng>();
        gc = GetComponent<GroundCheck>();
        anim = GetComponent<Anim>();

        //自オブジェクトTransform
        obj = this.gameObject;
        pos = transform.position;
        defScale = transform.localScale;
        scale = defScale;
        isDirection = true;

        //自オブジェクトその他変数
        //Direction();
        defGravity = rb.gravityScale;
        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        //当たり判定関連
        hm.SetUp(Damage, Die);
        hm.IsHalfHP = false;

        //DebugLog
        NullReferenceLog();
    }

    /// <summary>
    /// 死亡(1回実行)
    /// </summary>
    public override void Die()
    {
        Debug.Log(obj.name + "は死んだ");
        rb.velocity = Vector2.zero;
        AllHitActive(false);
    }


    //----------パブリック関数----------
    /// <summary>
    /// セットアップ時ベースパラメータ関連
    /// </summary>
    /// <param name="parameter">パラメータ</param>
    public void SetUpBaseParam(EnemyParameter parameter)
    {
        plPos = parameter.Player.transform.position;

        if (parameter.VirtualCamera != null)
        { vCamera = parameter.VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); }
        if (parameter.Volume != null) { parameter.Volume.profile.TryGet(out mBlur); }
    }

    /// <summary>
    /// FPS取得
    /// </summary>
    /// <returns></returns>
    float FPS()
    {
        return 1f / Time.deltaTime;
    }

    /// <summary>
    /// 距離
    /// </summary>
    /// <param name="pos">自身</param>
    /// <param name="target">相手</param>
    /// <returns>Vector2</returns>
    public Vector2 Distance(Vector2 pos, Vector2 target)
    {
        return target - pos;
    }
    /// <summary>
    /// 距離
    /// </summary>
    /// <param name="pos">自身</param>
    /// <param name="target">相手</param>
    /// <returns>float</returns>
    public float Distance(float pos, float target)
    {
        return target - pos;
    }
    /// <summary>
    /// 向き
    /// </summary>
    public void Direction()
    {
        if (!isDirection) { return; }
        dir = (Distance(pos.x, plPos.x) < 0) ? -1 : 1;

        scale.x = defScale.x * dir;
        transform.localScale = scale;
    }
    /// <summary>
    /// ステージ関連算出
    /// </summary>
    /// <param name="center">中心座標</param>
    /// <param name="range">範囲</param>
    public void StageRelated(Vector2 center, Vector2 range)
    {
        Vector2 hRange = range * 0.5f;      //範囲半分
        stage_LeftBottom = center - hRange; //左下座標
        stage_RightTop = center + hRange;   //右上座標

        gPos = Altitude(center.x);  //標高算出
    }
    /// <summary>
    /// 標高
    /// </summary>
    /// <param name="axisX">X軸</param>
    /// <returns></returns>
    public float Altitude(float axisX)
    {
        RaycastHit2D rayHit = Physics2D.Raycast
            (new Vector2(axisX, stage_RightTop.y), Vector2.down,
            stage_RightTop.y - stage_LeftBottom.y, gc.Ray[0].Layer);  //光線発射
        Debug.DrawRay(new Vector2(axisX, stage_RightTop.y),
            Vector2.down * (stage_RightTop.y - stage_LeftBottom.y), Color.green, 1.0f);
        if (rayHit.collider.tag == gc.Ray[0].Tag.ToString())
        {
            Debug.Log(rayHit.point);
            Vector2 groundPos = rayHit.point;   //地面位置確認
            return groundPos.y;
        }
        Debug.LogError(axisX + "に地面はない");
        return 0;
    }
    /// <summary>
    /// 画面振動
    /// </summary>
    /// <param name="amplitude">振幅</param>
    public void SetVibration(float amplitude)
    {
        vCamera.m_AmplitudeGain = amplitude;

        if (mBlur == null) { return; }
        mBlur.intensity.value = amplitude;
    }
    /// <summary>
    /// 画面振動減少
    /// </summary>
    /// <param name="value">振動減少率</param>
    public void DeclineVibration(float value)
    {
        vCamera.m_AmplitudeGain -= value;

        if (mBlur == null) { return; }
        mBlur.intensity.value -= value;
    }
    /// <summary>
    /// 振動減少率
    /// </summary>
    /// <param name="amplitude">振幅</param>
    /// <param name="time">継続時間</param>
    /// <returns></returns>
    public float VDR(float amplitude, float time)
    {

        return amplitude / FPS() / time;
    }

    /// <summary>
    /// 重力変更
    /// </summary>
    /// <param name="value">代入値</param>
    public void SetGravity(float value)
    {
        rb.gravityScale = value;
    }
    /// <summary>
    /// 重力初期化
    /// </summary>
    public void ClearGravity()
    {
        rb.gravityScale = defGravity;
    }

    /// <summary>
    /// 接地判定
    /// </summary>
    /// <param name="flag">地面種類</param>
    /// <returns></returns>
    public bool CheckGroundFlag(GroundCheck.Flag flag)
    {
        return gc.CheckFlag(flag);
    }

    /// <summary>
    /// アニメーション遷移
    /// </summary>
    /// <param name="anim">遷移アニメ名</param>
    public void AnimChange(string anim)
    {
        this.anim.AnimChage(anim, anim_IsPriority);
    }
    public void AnimChange(string anim, bool isPriority)
    {
        this.anim.AnimChage(anim, isPriority);
    }
    /// <summary>
    /// アニメーション終了判定
    /// </summary>
    /// <returns></returns>
    public bool AnimEndCheck()
    {
        if (anim.NormalizedTime < 1.0f) { return false; }
        return true;
    }
    /// <summary>
    /// アニメーション終了判定
    /// </summary>
    /// <param name="anim">次アニメーション</param>
    /// <returns></returns>
    public bool AnimEndCheck(string anim)
    {
        if (this.anim.NormalizedTime < 1.0f) { return false; }
        AnimChange(anim);
        return true;
    }

    /// <summary>
    /// サブ汎用変数初期化
    /// </summary>
    public void GeneralVariableClearSub()
    {
        phaseSub = 0;
        timerSub = 0;
        repeatSub = 0;
        noSub = 0;
    }


    //----------プライベート関数----------
    void NullReferenceLog()
    {
        ClassNullLog();
        ObjectNullLog();
    }
    void ClassNullLog()
    {
        if (rb == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".rb"); }
        if (bc == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".bc"); }
        if (se == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".se"); }
        if (hm == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".hm"); }
        if (gc == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".gc"); }
        if (anim == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".anim"); }
    }
    void ObjectNullLog()
    {
        if (obj == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".obj"); }
        if (pos == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".pos"); }
        if (scale == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".scale"); }
        if (defScale == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".defScale"); }
        if (plPos == null) { Debug.LogError("NullReferenceLog：" + gameObject.name + ".plPos"); }
    }
}