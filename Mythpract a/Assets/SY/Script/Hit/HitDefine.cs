using UnityEngine;

namespace SY
{
    public class HitDefine
    {
        public const float PlHitInterval = 1.0f;  //Pl被ダメージ間隔
        public const float EnHitInterval = 0.3f;  //En被ダメージ間隔
    }

    public enum HitLayer { Player, Enemy, Neutral }
    public enum HitType { Attack, Defense }

    public enum Tag { Default, Player, Enemy, Ground }

    //ヒット結果
    public class HitResult
    {
        [System.Flags]
        public enum AtkFlag //攻撃フラグ
        {
            None        = 0,
            AtkHit      = 1 << 1,   //防御と当たった
            AtkDamage   = 1 << 2,   //ダメージを与えた
            AtkDeath    = 1 << 3,   //殺した
        }

        [System.Flags]
        public enum DefFlag //防御フラグ
        {
            None        = 0,
            DefHit      = 1 << 1,   //攻撃と当たった
            DefDamage   = 1 << 2,   //ダメージを受けた
            DefDeath    = 1 << 3,   //死んだ
        }

        //[System.Flags]
        //public enum RayFlag //レイフラグ
        //{
        //    None    = 0,
        //    Player  = 1 << 1,
        //    Enemy   = 1 << 2,
        //    Ground  = 1 << 3,
        //}

        AtkFlag atkFlag;
        DefFlag defFlag;
        //RayFlag rayFlag;

        //----------ダメージ----------
        /// <summary>
        /// プレイヤー -> エネミー
        /// </summary>
        /// <param name="atk">攻撃力</param>
        /// <param name="power">技威力</param>
        /// <returns></returns>
        public float Damage(float atk, float power)
        {
            float dmg = atk * power;
            return dmg;
        }
        /// <summary>
        /// エネミー -> プレイヤー
        /// </summary>
        /// <param name="atk">攻撃力</param>
        /// <param name="power">技威力</param>
        /// <param name="def">防御力</param>
        /// <returns></returns>
        public float Damage(float atk, float power, float def)
        {
            float dmg = (atk * power / 2.0f) - (def / 4.0f);
            return (dmg <= 0) ? 0 : dmg;
        }

        //----------全フラグ----------
        public void AllClearFlag() { ClearAtkFlag(); ClearDefFlag(); }

        //----------攻撃フラグ----------
        public AtkFlag LookAtkFlag() { return atkFlag; }
        public void SetAtkFlag(AtkFlag setFlag) { atkFlag |= setFlag; }
        public bool CheckAtkFlag(AtkFlag checkFlag) { return (atkFlag & checkFlag) != 0 ? true : false; }
        public void ClearAtkFlag() { atkFlag = 0; }

        //----------防御フラグ----------
        public DefFlag LookDefFlag() { return defFlag; }
        public void SetDefFlag(DefFlag setFlag) { defFlag |= setFlag; }
        public bool CheckDefFlag(DefFlag checkFlag) { return (defFlag & checkFlag) != 0 ? true : false; }
        public void ClearDefFlag() { defFlag = 0; }

        //----------レイフラグ----------
        //public void SetRayFlag(RayFlag setFlag) { rayFlag |= setFlag; }
        //public bool CheckRayFlag(RayFlag checkFlag) { return (rayFlag & checkFlag) != 0 ? true : false; }
        //public void ClearRayFlag() { rayFlag = 0; }
    }
}