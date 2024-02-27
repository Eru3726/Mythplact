using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Live2D.Cubism.Rendering;
using SY;

public class QilinBase : Enemy
{
    //----------パブリック変数----------
    //
    [System.NonSerialized] public CubismRenderController renderController;

    //
    [System.NonSerialized] public bool isHalfHPMove = false;        //HP半分時行動
    [System.NonSerialized] public float eruption_Space;             //炎柱間距離
    [System.NonSerialized] public Vector2 eruption_Generatev2;      //生成数   Vector2(Left, Right)
    [System.NonSerialized] public GameObject eruption_Last;         //
    [System.NonSerialized] public GameObject spin_Last;             //
    [System.NonSerialized] public GameObject meteor_Last;           //


    //----------パラメータ----------
    [SerializeField, Tooltip("デバック")] Qilin_MoveType debugMove = Qilin_MoveType.DebugOff;
    [SerializeField, Tooltip("パラメータ")] QilinParameter param;


    //----------プロパティ----------
    public QilinParameter Param { get { return param; } set { param = value; } }


    //----------オーバーライド関数----------
    public override void SetUp()
    {
        base.SetUp();

        StageRelated(param.Stage.Center, param.Stage.Range);
        SetUpBaseParam(param);

        //GetComponent
        renderController = GetComponent<CubismRenderController>();

        //画面オブジェクト
        if (param.UI != null) { param.UI.SetActive(false); }

        //当たり判定関連
        isHalfHPMove = false;
        AllHitActive(false);
        AllHitPower();

        //初期行動
        if (debugMove == Qilin_MoveType.DebugOff)
        {
            param.MoveType = Qilin_MoveType.Entry;
            pos = param.Entry_StartPos;
        }
        else
        {
            isDebug = true;
            param.MoveType = Qilin_MoveType.Idle;
        }
        rb.position = pos;
        AllVariableClear();
    }

    public override void ReNew()
    {
        if (param.MoveType == Qilin_MoveType.Death)
        {
            Dead();
            return;
        }
        hm.HitUpdate();

        pos = rb.position;
        plPos = param.Player.transform.position;

        body_Center = bc.bounds.center;
        body_Range = bc.bounds.max - bc.bounds.min;

        switch (param.MoveType)
        {
            case Qilin_MoveType.Entry:
                Entry();
                break;

            case Qilin_MoveType.Idle:
                Idle();
                break;

            case Qilin_MoveType.Breath:
                Breath();
                break;

            case Qilin_MoveType.Eruption:
                Eruption();
                break;

            case Qilin_MoveType.Rush:
                Rush();
                break;

            case Qilin_MoveType.PushUp:
                PushUp();
                break;

            case Qilin_MoveType.Spin:
                Spin();
                break;

            case Qilin_MoveType.Meteor:
                Meteor();
                break;
        }

        rb.position = pos;

        Direction();

        AnimBasis();
        hm.PostUpdate();
    }


    //行動
    public override void Entry()
    {
        switch (phase)
        {
            case 0:
                isDirection = false;
                AnimChange("Entry_SleepAir");
                phase++;
                break;
            case 1:
                if (!Timer(param.Entry_SleepTime)) { break; }
                AnimChange("Entry_SleepEnd");
                phase++;
                break;
            case 2:
                if (!AnimEndCheck("Entry_FireLessIdle")) { break; }
                phase++;
                break;
            case 3:
                if (!Timer(param.Entry_BreakTime)) { break; }
                AnimChange("Entry_End");
                phase++;
                break;
            case 4:
                if (!AnimEndCheck()) { break; }
                tableNo = Random.Range(0, param.MoveTable.Length);
                moveNo = 0;
                param.MoveType = param.MoveTable[tableNo].Move[moveNo];
                param.UI.SetActive(true);
                AllVariableClear();
                break;
        }
    }

    public override void Idle()
    {
        switch (phase)
        {
            case 0:
                if (!Timer(param.Idle_Time)) { break; }
                phase++;
                break;
            case 1:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    public override void Damage()
    {
        base.Damage();
        param.Damage_Effect.PlayParticle();
        param.Damage_SE.PlayAudio(se);
        if ((hm.HP == hm.MaxHP * 0.5f) && !hm.IsHalfHP) { isHalfHPMove = true; }
    }

    public override void Die()
    {
        base.Die();
        //achv.DefeatedBoss(2);
        param.MoveType = Qilin_MoveType.Death;
        AnimChange("Dead");
        param.Die_Effect.Particle.gameObject.SetActive(true);
        param.Die_Effect.PlayParticle();
        param.Damage_SE.PlayAudio(se);
    }

    public override void Dead()
    {
        base.Dead();
        param.Die_Effect.StopCheck();
        if (0.5f <= anim.NormalizedTime) { renderController.Opacity = 0; }
        if (!param.Die_Effect.IsValid)
        {
            GameData.QilinDead = true;
        }
    }


    //行動補佐
    public override void Move(Vector2 velocity, float speed)
    {
        rb.velocity = velocity.normalized * speed;
    }

    public override void MoveEnd()
    {
        base.MoveEnd();

        if (isDebug == true) { param.MoveType = debugMove; return; }
        if (!isHalfHPMove)
        {
            moveNo++;
            if (moveNo == param.MoveTable[tableNo].Move.Length)
            {
                tableNo = Random.Range(0, param.MoveTable.Length);
                moveNo = 0;
            }
            param.MoveType = param.MoveTable[tableNo].Move[moveNo];
        }
        else { MoveChange(Qilin_MoveType.Spin); isHalfHPMove = false; }
    }

    public override IEnumerator Flash()
    {
        int damage_Repeat = 0;  //繰り返し回数

        while (damage_Repeat < param.DamageData.Time)
        {
            //色変更
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = param.DamageData.Color;
            }
            renderController.Opacity = param.DamageData.Color.a;
            //待つ
            yield return new WaitForSeconds(param.DamageData.Interval);
            //色戻す
            for (int i = 0; i < renderController.Renderers.Length; i++)
            {
                renderController.Renderers[i].ScreenColor = Color.black;
            }
            renderController.Opacity = 1;
            //待つ
            yield return new WaitForSeconds(param.DamageData.Interval);
            damage_Repeat++;    //繰り返し回数加算
        }
    }


    //当たり判定関連
    public override void AllHitActive(bool value)
    {
        param.Body.SetActive(value);
        param.Breath.SetActive(value);
        param.PushUp.SetActive(value);
    }

    public override void AllHitPower()
    {
        SetPower(param.Body, param.Body_Power);
        SetPower(param.Breath, param.Breath_Power);
        SetPower(param.PushUp, param.PushUp_Power);
        SetPower(param.Rush, param.Rush_Power);
    }


    //アニメーション
    public override void AnimBasis()
    {
        if (0.2f < rb.velocity.magnitude)
        {
            //Debug.Log(CheckGroundFlag(GroundCheck.Flag.Ground));
            if (CheckGroundFlag(GroundCheck.Flag.Ground))
            {
                param.Move_SE.PlayAudio(se);
                AnimChange("Move");
            }
            else if (!CheckGroundFlag(GroundCheck.Flag.Ground))
            {
                param.Move_SE.PlayAudio(se);
                AnimChange("Hover");
            }
        }
        if ((anim.Action == AnimSetting.Type.Move || anim.Action == AnimSetting.Type.Jump) &&
            rb.velocity.magnitude <= 0.2f)
        {
            AnimChange("Idle", false);
        }
    }


    //----------プライベート関数----------
    //行動
    /// <summary>
    /// ブレス
    /// </summary>
    void Breath()
    {
        switch (phase)
        {
            case 0: //重力0、速度代入
                isDirection = false;
                SetGravity(0);
                Move(Vector2.right * dir, param.Move_Speed);
                phase++;
                break;
            case 1: //移動→重力復元、停止
                if (param.Breath_AtkDis < Mathf.Abs(Distance(pos, plPos).x)) { break; }
                Stop();
                ClearGravity();
                isDirection = true;
                phase++;
                break;
            case 2: //攻撃前隙→ブレス調整、ブレスアニメ実行
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                isDirection = false;
                Vector3 bScale = param.Breath_Effect.Particle.gameObject.transform.localScale;
                switch (dir)
                {
                    case -1:
                        bScale.x = 1.0f;
                        break;
                    case 0:
                    case 1:
                        bScale.x = -1.0f;
                        break;
                }
                AnimChange("Breath");
                param.Breath_Effect.Particle.gameObject.transform.localScale = bScale;
                phase++;
                break;
            case 3: //アニメ3割→ブレスパーティクル実行
                if (anim.NormalizedTime < 0.3f) { break; }
                param.Breath_Effect.PlayParticle();
                phase++;
                break;
            case 4: //パーティクル終了
                param.Breath_Effect.StopCheck();
                if (param.Breath_Effect.IsValid) { break; }
                param.Breath.SetActive(false);
                param.Breath_Effect.Particle.gameObject.SetActive(false);
                phase++;
                break;
            case 5: //クールタイム
                if (!Timer(param.Breath_CoolTime)) { break; }
                phase++;
                break;
            case 6:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    /// <summary>
    /// 火柱
    /// </summary>
    void Eruption()
    {
        switch (phase)
        {
            case 0: //前隙
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                phase++;
                break;
            case 1:
                float Range = param.Eruption_AtkRange.x - body_Range.x;   //炎柱生成可能幅

                Vector2 eruption_Range = Vector2.zero;
                eruption_Range.x =  //左距離
                    ((body_Center.x) - (body_Range.x * 0.5f)) -
                    (param.Eruption_Center.x - (param.Eruption_AtkRange.x * 0.5f));
                eruption_Range.y =  //右距離
                    (param.Eruption_Center.x + (param.Eruption_AtkRange.x * 0.5f)) -
                    ((body_Center.x) + (body_Range.x * 0.5f));

                //比　炎柱生成可能幅：左距離：右距離 = 1：x：y
                Vector2 eruption_Ratio = Vector2.zero;
                eruption_Ratio.x = eruption_Range.x / Range;
                eruption_Ratio.y = eruption_Range.y / Range;
                if (eruption_Ratio.x < 0) { eruption_Ratio = Vector2.up; }
                else if (eruption_Ratio.y < 0) { eruption_Ratio = Vector2.right; }

                Vector2 empty = new Vector2 //比から左右の炎柱生成数定義(小数点あり)
                    (param.Eruption_Generate * eruption_Ratio.x, param.Eruption_Generate * eruption_Ratio.y);
                //炎柱生成数を整数に
                eruption_Generatev2.x = Mathf.Round(empty.x);
                eruption_Generatev2.y = Mathf.Round(empty.y);

                //炎柱間距離定義
                eruption_Space = Range / (param.Eruption_Generate + 1);

                //アニメーション再生
                AnimChange("Pillar");
                phase++;
                break;
            case 2: //炎柱生成
                if (anim.Action != AnimSetting.Type.Idle) { break; }
                Vector2 genPos = Vector2.zero;
                if (repeat < eruption_Generatev2.x)
                {
                    genPos = new Vector2(
                        (body_Center.x - (body_Range.x * 0.5f)) -
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(param.Eruption, genPos, Quaternion.identity/*, transform.Find("HitandEffect").gameObject.transform*/);
                    GameObject pre = Instantiate(param.Prediction, new Vector2(genPos.x, gPos), Quaternion.identity);
                    pre.GetComponent<SpriteRenderer>().color = param.Eruption_Prediction.Color;
                    pre.transform.localScale = param.Eruption_Prediction.Scale;
                    no++;
                }
                if (repeat < eruption_Generatev2.y)
                {
                    genPos = new Vector2(
                        (body_Center.x + (body_Range.x * 0.5f)) +
                        (eruption_Space * (repeat + 1)),
                        gPos);
                    eruption_Last =
                        Instantiate(param.Eruption, genPos, Quaternion.identity/*, transform.Find("HitandEffect").gameObject.transform*/);
                    GameObject pre = Instantiate(param.Prediction, new Vector2(genPos.x, gPos), Quaternion.identity);
                    pre.GetComponent<SpriteRenderer>().color = param.Eruption_Prediction.Color;
                    pre.transform.localScale = param.Eruption_Prediction.Scale;
                    no++;
                }
                repeat++;
                phase++;
                break;
            case 3: //攻撃間隙
                if (!Timer(param.Eruption_AtkBreakTime)) { break; }
                if (param.Eruption_Generate != no) { phase--; }   //戻る
                else { phase++; }   //進む
                break;
            case 4:
                if (eruption_Last != null) { break; }
                phase++;
                break;
            case 5:
                if (!Timer(param.Eruption_CoolTime)) { break; }
                phase++;
                break;
            case 6:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    /// <summary>
    /// 突き上げ
    /// </summary>
    void PushUp()
    {
        switch (phase)
        {
            case 0: //重力0、速度代入、体当たり判定付、突進パーティクル実行
                SetGravity(0);
                Move(Vector2.right * dir, param.PushUp_MoveSpd);
                param.Body.SetActive(true);
                param.PushUp_Effect.PlayParticle();
                phase++;
                break;
            case 1: //移動→停止、体当たり判定外、突進パーティクル設定変更
                if (param.PushUp_AtkDis < Mathf.Abs(Distance(pos, plPos).x)) { break; }
                Stop();
                param.Body.SetActive(false);
                var main = param.PushUp_Effect.Particle.main;
                main.loop = false;
                ClearGravity();
                isDirection = false;
                phase++;
                break;
            case 2: //攻撃前隙
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                phase++;
                break;
            case 3: //突き上げアニメ実行
                AnimChange("PushUp");
                phase++;
                break;
            case 4: //アニメーション終了判定
                if (!AnimEndCheck()) { break; }
                phase++;
                break;
            case 5: //クールタイム
                if (!Timer(param.PushUp_CoolTime)) { break; }
                phase++;
                break;
            case 6:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    /// <summary>
    /// 突進
    /// </summary>
    void Rush()
    {
        switch (phase)
        {
            case 0:
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                Rush_MoveSupport();
                repeat++;
                phase++;
                break;
            case 1:
                if (pos.x < (param.Rush_Center.x + param.Rush_AtkRange.x * 0.5f) + 3.0f &&
                    (param.Rush_Center.x - param.Rush_AtkRange.x * 0.5f) - 3.0f < pos.x) { break; }
                param.Rush.SetActive(false);
                var main = param.Rush_Effect.Particle.main;
                main.loop = false;
                Stop();
                ClearGravity();
                isDirection = true;
                phase++;
                break;
            case 2:
                if (!Timer(param.Rush_AtkBreakTime)) { break; }
                if (repeat == param.Rush_AtkTime) { phase++; }
                else
                {
                    Rush_MoveSupport();
                    repeat++;
                    phase--;
                }
                break;
            case 3:
                if (!Timer(param.Rush_CoolTime)) { break; }
                phase++;
                break;
            case 4:
                MoveChange(Qilin_MoveType.PushUp);
                break;
            default:    //行動遷移時汎用変数初期化
                AllVariableClear();
                break;
        }
    }

    /// <summary>
    /// 炎渦
    /// </summary>
    void Spin()
    {
        switch (phase)
        {
            case 0:
                SetGravity(0);
                Vector2 vec = new Vector2(param.Stage.Center.x - pos.x, 0);
                scale.x = defScale.x * ((vec.x <= 0) ? -1 : 1);
                transform.localScale = scale;
                Move(vec, param.Move_Speed);
                phase++;
                break;
            case 1:
                if (pos.x < param.Stage.Center.x - 2.5f || param.Stage.Center.x + 2.5f < pos.x) { return; }
                Stop();
                ClearGravity();
                phase++;
                break;
            case 2://前隙
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                isDirection = false;
                phase++;
                break;
            case 3:
                AnimChange("Pillar");
                phase++;
                break;
            case 4:
                if (!AnimEndCheck()) { break; }
                Vector2 spin1Pos = new Vector2(stage_LeftBottom.x, gPos);
                Vector2 spin2Pos = new Vector2(stage_RightTop.x, gPos);
                Instantiate(param.Spin, spin1Pos, Quaternion.identity);
                spin_Last =
                    Instantiate(param.Spin, spin2Pos, Quaternion.identity);
                phase++;
                break;
            case 5:
                if (!Timer(param.Spin_CoolTime)) { break; }
                phase++;
                break;
            case 6:
                MoveChange(Qilin_MoveType.Meteor);
                break;
            default:
                AllVariableClear();
                break;
        }
    }

    /// <summary>
    /// 隕石
    /// </summary>
    void Meteor()
    {
        switch (phase)
        {
            case 0:
                SetGravity(0);
                isDirection = false;
                Vector2 vec = Vector2.zero;
                switch (dir)
                {
                    case -1:
                        vec = new Vector2(stage_LeftBottom.x, param.Stage.Center.y + Mathf.Abs(gc.Ray[0].Offset.y)) - pos;
                        break;
                    case 0:
                    case 1:
                        vec = new Vector2(stage_RightTop.x, param.Stage.Center.y + Mathf.Abs(gc.Ray[0].Offset.y)) - pos;
                        break;
                }
                Move(vec, param.Move_Speed);
                phase++;
                break;
            case 1:
                switch (dir)
                {
                    case -1:
                        if (pos.x < stage_LeftBottom.x - 7.5f) { Stop(); phase++; }
                        break;
                    case 0:
                    case 1:
                        if (stage_RightTop.x + 7.5f < pos.x) { Stop(); phase++; }
                        break;
                }
                break;
            case 2:
                if (!Timer(param.AttackAnticipation_Time)) { break; }
                switch (dir)
                {
                    case -1:
                        pos = new Vector2(stage_RightTop.x + 10.0f, param.Stage.Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
                        break;
                    case 0:
                    case 1:
                        pos = new Vector2(stage_LeftBottom.x - 10.0f, param.Stage.Center.y + Mathf.Abs(gc.Ray[0].Offset.y));
                        break;
                }
                timer = param.Meteor_AtkTime / param.Meteor_Generate;
                phase++;
                break;
            case 3:
                if (!Timer(param.Meteor_AtkTime / param.Meteor_Generate)) { break; }
                meteor_Last = Instantiate(param.Meteor, Meteor_GenePos(), Quaternion.identity);
                meteor_Last.GetComponent<Meteor>().SetGoal(dir, param.Meteor_Center, param.Meteor_AtkRange);
                repeat++;
                if (param.Meteor_Generate != repeat) { break; }
                repeat = 0;
                phase++;
                break;
            case 4:
                if (meteor_Last != null) { break; }
                phase++;
                break;
            case 5:
                //ベクトル = Vector2(ステージ中央, 高度) - Vector2(自身, 自身の足元)
                vec = new Vector2(param.Stage.Center.x, gPos) -
                    new Vector2(pos.x, pos.y - Mathf.Abs(gc.Ray[0].Offset.y));
                Debug.Log(vec);
                Move(vec, param.Move_Speed);
                phase++;
                break;
            case 6:
                if (!CheckGroundFlag(GroundCheck.Flag.Ground)) { break; }
                ClearGravity();
                Stop();
                phase++;
                break;
            case 7:
                if (!Timer(param.Meteor_CoolTime)) { break; }
                phase++;
                break;
            case 8:
                MoveEnd();
                break;
            default:
                AllVariableClear();
                break;
        }
    }


    //行動補佐
    /// <summary>
    /// 停止
    /// </summary>
    void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    /// <summary>
    /// 突進、当たり判定、エフェクト有効化 & 向き変更、重力無効化
    /// </summary>
    void Rush_MoveSupport()
    {
        isDirection = false;
        SetGravity(0);
        Move(Vector2.right * dir, param.Rush_MoveSpd);
        param.Rush.SetActive(true);
        param.Rush_Effect.PlayParticle();
    }

    /// <summary>
    /// 隕石初期位置算出
    /// </summary>
    /// <returns></returns>
    Vector2 Meteor_GenePos()
    {
        Vector2 pos = Vector2.zero;

        //初期位置定義
        switch (dir)
        {
            case -1:
                pos.x = Random.Range(param.Meteor_Center.x - param.Meteor_AtkRange.x * 0.5f, param.Meteor_Center.x);
                break;
            case 0:
            case 1:
                pos.x = Random.Range(param.Meteor_Center.x, param.Meteor_Center.x + param.Meteor_AtkRange.x * 0.5f);
                break;
        }
        pos.y = param.Meteor_Center.y + (param.Meteor_AtkRange.x * 0.5f);

        return pos;
    }

    /// <summary>
    /// 行動遷移
    /// </summary>
    /// <param name="next">次行動</param>
    void MoveChange(Qilin_MoveType next)
    {
        param.MoveType = next;
        AllVariableClear();
    }
}