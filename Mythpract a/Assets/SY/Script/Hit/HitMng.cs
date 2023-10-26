using UnityEngine;
using static SY.HitResult;

namespace SY
{
    public class HitMng : MonoBehaviour
    {
        //----------変数----------
        [SerializeField] HitLayer layer;
        //ステータス
        [SerializeField, Tooltip("最大体力")] float maxHp;
        [SerializeField, Tooltip("現在体力"), ReadOnly] float hp;
        [SerializeField, Tooltip("攻撃力")] float atk;
        [SerializeField, Tooltip("防御力")] float def;
        [SerializeField, Tooltip("攻撃トリガー")] bool atkActive;
        [SerializeField, Tooltip("防御トリガー")] bool defActive;
        float hitInterval;  //ヒット後無敵時間

        HitResult result = new HitResult();

        //外部関数(デリゲート)
        public delegate void DmgFunc();
        private DmgFunc dmgFunc;
        public delegate void DieFunc();
        private DieFunc dieFunc;

        //----------プロパティ----------
        public HitLayer Layer { get { return layer; } }
        public float MaxHP { get { return maxHp; } set { maxHp = value; } }
        public float HP { get { return hp; } set { hp = value; } }
        public float ATK { get { return atk; } set { atk = value; } }
        public float DEF { get { return def; } set { def = value; } }
        public bool ATKActive { get { return atkActive; } set { atkActive = value; } }
        public bool DEFActive { get { return defActive; } set { defActive = value; } }
        public float HitInterval { get { return hitInterval; } set { hitInterval = value; } }
        public HitResult Result { get { return result; } }

        //----------関数----------
        void Awake()
        {
            HP = MaxHP;
            atkActive = true;
            defActive = true;
        }

        //初期化
        public void SetUp(DmgFunc damage, DieFunc die)
        {
            dmgFunc = damage;
            dieFunc = die;
        }

        //毎フレーム更新(先頭)
        public void HitUpdate()
        {
            if (HP <= 0)
            {
                if (dieFunc != null) { dieFunc(); }
            }
            else if (CheckDamage() == true)
            {
                if (dmgFunc != null) { dmgFunc(); }
            }

            //連続ヒット防止
            hitInterval -= Time.deltaTime;
        }

        //毎フレーム更新(後尾)
        public void PostUpdate()
        {
            Result.AllClearFlag();
        }

        //ダメージを受けたか
        public bool CheckDamage() { return Result.CheckDefFlag(DefFlag.DefDamage); }
        
        // ダメージを与えたか
        public bool CheckAttack() { return Result.CheckAtkFlag(AtkFlag.AtkDamage); }
    }
}