using UnityEngine;

namespace SY
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField, Tooltip("レイ可視化")] bool isDisplay;
        [SerializeField, Tooltip("接地判定レイ")] GroundRaySetting[] ray;   //要素数は5以下

        [System.Flags]
        public enum Flag
        {
            None        = 0,        //非接地
            Ground      = 1 << 0,   //接地
            Slope_Left  = 1 << 1,   //左に坂判定
            Slope_Right = 1 << 2,   //右に坂判定
            Wall_Left   = 1 << 3,   //左に壁判定
            Wall_Right  = 1 << 4,   //右に壁判定
        }
        [SerializeField, ReadOnly] Flag groundFlag;

        Vector2 pos;    //座標
        int i;          //繰り返し

        public GroundRaySetting[] Ray { get { return ray; } }
        public Flag GroundFlag() { return groundFlag; }
        public void SetFlag(Flag setFlag) { groundFlag |= setFlag; }
        public void RemoveFlag(Flag removeFlag) { groundFlag &= ~removeFlag; }
        public bool CheckFlag(Flag checkFlag) { return (groundFlag & checkFlag) != 0 ? true : false; }
        public void ClearFlag() { groundFlag = 0; }

        void Awake()    //消すかも
        {
            ray[0].IsActive = true;
        }

        public void Update()
        {
            pos = transform.position;
            for (i = 0; i < ray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        FlagUpdate(Flag.Ground);
                        break;
                    case 1:
                        FlagUpdate(Flag.Slope_Left);
                        break;
                    case 2:
                        FlagUpdate(Flag.Slope_Right);
                        break;
                    case 3:
                        FlagUpdate(Flag.Wall_Left);
                        break;
                    case 4:
                        FlagUpdate(Flag.Wall_Right);
                        break;
                }
            }
        }

        void FlagUpdate(Flag flag)
        {
            if (RayHit()) { SetFlag(flag); }
            else { RemoveFlag(flag); }
        }

        bool RayHit()
        {
            if (!ray[i].IsActive) { return false; }
            if (!ray[i].Raycast(pos).collider) { return false; }
            if (ray[i].Raycast(pos).collider.tag == ray[i].Tag.ToString()) { return true; }
            return false;
        }


        private void OnDrawGizmos()
        {
            pos = transform.position;
            if (isDisplay)
            {
                DrawGizmo(0);  //接地
                if (ray.Length <= 1) { return; }
                DrawGizmo(1);    //坂
                if (ray.Length <= 2) { return; }
                DrawGizmo(2);   //坂
                if (ray.Length <= 3) { return; }
                DrawGizmo(3);  //壁
                if (ray.Length <= 4) { return; }
                DrawGizmo(4); //壁
            }

            if (ray.Length <= 5) { return; }
            Debug.LogError(gameObject.name + " > GroundCheck : Rayの要素数を5以下にしてください");
        }

        void DrawGizmo(int rayNo)
        {
            ray[rayNo].Gizmo.Draw(pos + ray[rayNo].Offset, ray[rayNo].Radius);
            if (ray[rayNo].Distance == 0 || ray[rayNo].Direction.magnitude == 0) { return; }
            ray[rayNo].Gizmo.Draw(pos + ray[rayNo].Offset + ray[rayNo].Direction.normalized * ray[rayNo].Distance,
                ray[rayNo].Radius);
        }
    }

    [System.Serializable]
    public class GroundRaySetting
    {
        [SerializeField, Tooltip("名前")] string name;
        [SerializeField, Tooltip("オフセット")] Vector2 offset;
        [SerializeField, Tooltip("半径")] float radius;
        [SerializeField, Tooltip("方向")] Vector2 direction;
        [SerializeField, Tooltip("距離")] float distance;
        [SerializeField, Tooltip("レイヤー")] LayerMask layer;
        [SerializeField, Tooltip("タグ")] Tag tag;
        [SerializeField, Tooltip("有効")] bool isActive;
        [SerializeField, Tooltip("ギズモ")] GizmoSetting gizmo;

        //----------プロパティ----------
        public string Name { get { return name; } }
        public Vector2 Offset { get { return offset; } set { offset = value; } }
        public float Radius { get { return radius; } set { radius = value; } }
        public Vector2 Direction { get { return direction; } set { direction = value; } }
        public float Distance { get { return distance; } set { distance = value; } }
        public LayerMask Layer { get { return layer; } }
        public Tag Tag { get { return tag; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public GizmoSetting Gizmo { get { return gizmo; } }

        //----------サービス----------
        //当たり判定
        public RaycastHit2D Raycast(Vector2 origin)
        {
            return Physics2D.CircleCast(origin + Offset, Radius, Direction, Distance, Layer);

            //CircleCast引数概要 (円より太い線のイメージ)
            //  origin...原点
            //  radius...円半径
            //  direction...線を引く方向
            //  distance...線を引く距離
            //  layer...レイヤー
        }

        //可視化
        //public void DrawRay()
        //{
        //    Debug.DrawRay(Origin, Direction.normalized * Distance, Color.green, Time.deltaTime, false);
        //}
    }
}
