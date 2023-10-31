using UnityEngine;
using static SY.HitResult;

namespace SY
{
    public class HitData : MonoBehaviour
    {
        [SerializeField] HitType type;
        float power;        //技威力

        Player player;

        public HitType Type { get { return type; } }
        public float Power { get { return power; } set { power = value; } }

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        private void OnTriggerStay2D(Collider2D col)
        {
            //HitData確認
            HitData colHitData = col.gameObject.GetComponent<HitData>();
            if (CheckData(colHitData) == false) { return; }

            //親確認
            HitMng defMng = this.transform.root.gameObject.GetComponent<HitMng>();
            HitMng atkMng = col.transform.root.gameObject.GetComponent<HitMng>();
            if (CheckMng(atkMng, defMng, col.gameObject) == false) { return; }

            //攻撃処理
            Attack(atkMng, defMng, colHitData);
        }

        void Attack(HitMng atkMng, HitMng defMng, HitData atkData)
        {
            //HP計算
            if(defMng.Layer == HitLayer.Player)
            {
                if (player.IsGuard)
                {

                    defMng.HP -= 0;
                    player.IsGuard = false;
                }
                if (player.IsFleet)
                {
                    defMng.HP -= 0;
                    player.IsFleet = false;

                }
                else
                {
                    defMng.HP -= defMng.Result.Dmage_Player(atkMng.ATK, atkData.Power);

                }
            }
            if(defMng.Layer == HitLayer.Enemy)
            {
                defMng.HP -= (defMng.Result.Dmage_Enemy(atkMng.ATK, defMng.DEF) >= 0) ?
                    defMng.Result.Dmage_Enemy(atkMng.ATK, defMng.DEF) : 0;
            }
            if (defMng.HP < 0) { defMng.HP = 0; }

            //ダメージフラグを立てる
            atkMng.Result.SetAtkFlag(AtkFlag.AtkDamage);
            defMng.Result.SetDefFlag(DefFlag.DefDamage);
        }

        bool CheckMng(HitMng atkMng, HitMng defMng, GameObject col)
        {
            //nullチェック
            if (atkMng == null)
            { Debug.LogError(col.transform.root.gameObject.name + "にHitMngがアタッチされていない"); return false; }
            if (defMng == null)
            { Debug.LogError(this.transform.root.gameObject.name + "にHitMngがアタッチされていない"); return false; }

            //有効チェック
            if (atkMng.ATKActive == false) { return false; }
            if (defMng.DEFActive == false) { return false; }

            //レイヤーチェック
            if (CheckLayer(atkMng.Layer, defMng.Layer) == false) { return false; }

            //当たり判定フラグを立てる
            atkMng.Result.SetAtkFlag(AtkFlag.AtkHit);
            defMng.Result.SetDefFlag(DefFlag.DefHit);

            //連続ヒット防止
            if (defMng.HitInterval > 0) { return false; }

            //被ダメージ時無敵時間
            if(defMng.Layer == HitLayer.Player)
            { defMng.HitInterval = HitDefine.PlHitInterval; }
            else if(defMng.Layer == HitLayer.Enemy)
            { defMng.HitInterval = HitDefine.EnHitInterval; }
            

            return true;
        }

        bool CheckData(HitData data)
        {
            //nullチェック
            if (data == null)
            { Debug.LogError(data.gameObject.name + "にHitDataがアタッチされていない"); return false; }

            //タイプチェック
            if (this.Type != HitType.Defense) { return false; }
            if (data.Type != HitType.Attack) { return false; }

            return true;
        }

        bool CheckLayer(HitLayer atk, HitLayer def)
        {
            switch (atk)
            {
                case HitLayer.Player:
                    if (def != HitLayer.Player) { return true; }
                    break;
                case HitLayer.Enemy:
                    if (def != HitLayer.Enemy) { return true; }
                    break;
                case HitLayer.Neutral:
                    if (def != HitLayer.Neutral) { return true; }
                    break;
            }

            return false;
        }
    }
}