using UnityEngine;
using static SY.HitResult;

namespace SY
{
    public class HitData : MonoBehaviour
    {
        [SerializeField] HitType type;
        float power;    //技威力
        float dmg;      //ダメージ

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
                else if (player.IsFleet)
                {
                    defMng.HP -= 0;
                    player.IsFleet = false;

                }
                else
                {
                    dmg = defMng.Result.Damage(atkMng.ATK, atkData.Power);
                }
            }
            if(defMng.Layer == HitLayer.Enemy)
            {
                Debug.Log(atkMng.ATK + "：攻撃力　" + atkData.Power + "：技威力\n" + 
                    "オブジェクト名：" + atkData.transform.root.name + ".");

                dmg = defMng.Result.Damage(atkMng.ATK, atkData.Power, defMng.DEF);
            }

            //ダメージチェック
            if (dmg == 0) { return; }
            defMng.HP -= dmg;

            //ダメージフラグを立てる
            atkMng.Result.SetAtkFlag(AtkFlag.AtkDamage);
            defMng.Result.SetDefFlag(DefFlag.DefDamage);

            //死亡チェック
            if (0 < defMng.HP) { return; }
            defMng.HP = 0;

            //死亡フラグを立てる
            atkMng.Result.SetAtkFlag(AtkFlag.AtkDeath);
            defMng.Result.SetDefFlag(DefFlag.DefDeath);
        }

        bool CheckMng(HitMng atkMng, HitMng defMng, GameObject col)
        {
            //nullチェック
            if (atkMng == null)
            { Debug.LogError(col.transform.root.gameObject.name + "にHitMngがアタッチされていない"); return false; }
            if (defMng == null)
            { Debug.LogError(this.transform.root.gameObject.name + "にHitMngがアタッチされていない"); return false; }

            //レイヤーチェック
            if (CheckLayer(atkMng.Layer, defMng.Layer) == false) { return false; }

            //当たり判定フラグを立てる
            atkMng.Result.SetAtkFlag(AtkFlag.AtkHit);
            defMng.Result.SetDefFlag(DefFlag.DefHit);

            //有効チェック
            if (atkMng.ATKActive == false) { return false; }
            if (defMng.DEFActive == false) { return false; }

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
            { Debug.LogError(gameObject.transform.parent.name + "にHitDataがアタッチされていない"); return false; }

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