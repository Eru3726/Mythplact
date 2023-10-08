using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField, Tooltip("レイ可視化")] bool rayDisplay;
        [SerializeField, Tooltip("接地判定レイ")] GroundCheckRay[] ray;   //要素数は5以下

        [System.Flags]
        public enum GroundCheckFlag
        {
            None        = 0,        //非接地
            Ground      = 1 << 0,   //接地
            Slope_Left  = 1 << 1,   //左に坂判定
            Slope_Right = 1 << 2,   //右に坂判定
            Wall_Left   = 1 << 3,   //左に壁判定
            Wall_Right  = 1 << 4,   //右に壁判定
        }
        GroundCheckFlag groundCheckFlag;

        Vector2 pos;    //座標
        int i;          //繰り返し

        public GroundCheckRay[] Ray { get { return ray; } }
        public GroundCheckFlag GCFlag() { return groundCheckFlag; }
        public void SetGCFlag(GroundCheckFlag setFlag) { groundCheckFlag |= setFlag; }
        public void RemoveGCFlag(GroundCheckFlag removeFlag) { groundCheckFlag &= ~removeFlag; }
        public bool CheckGCFlag(GroundCheckFlag checkFlag) { return (groundCheckFlag & checkFlag) != 0 ? true : false; }
        public void ClearGCFlag() { groundCheckFlag = 0; }

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
                        FlagUpdate(GroundCheckFlag.Ground);
                        break;
                    case 1:
                        FlagUpdate(GroundCheckFlag.Slope_Left);
                        break;
                    case 2:
                        FlagUpdate(GroundCheckFlag.Slope_Right);
                        break;
                    case 3:
                        FlagUpdate(GroundCheckFlag.Wall_Left);
                        break;
                    case 4:
                        FlagUpdate(GroundCheckFlag.Wall_Right);
                        break;
                }
            }
        }

        void FlagUpdate(GroundCheckFlag flag)
        {
            if (RayHit()) { SetGCFlag(flag); }
            else { RemoveGCFlag(flag); }
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
            if (rayDisplay)
            {
                DrawGizmo(Color.white, 0);  //接地
                if (ray.Length <= 1) { return; }
                DrawGizmo(Color.red, 1);    //坂
                if (ray.Length <= 2) { return; }
                DrawGizmo(Color.blue, 2);   //坂
                if (ray.Length <= 3) { return; }
                DrawGizmo(Color.green, 3);  //壁
                if (ray.Length <= 4) { return; }
                DrawGizmo(Color.yellow, 4); //壁
            }

            if (ray.Length <= 5) { return; }
            Debug.LogError(gameObject.name + " > GroundCheck : Rayの要素数を5以下にしてください");
        }

        void DrawGizmo(Color color,int rayNo)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(pos + ray[rayNo].Offset, ray[rayNo].Radius);
            if (ray[rayNo].Distance == 0 || ray[rayNo].Direction.magnitude == 0) { return; }
            Gizmos.DrawSphere(pos + ray[rayNo].Offset + ray[rayNo].Direction.normalized * ray[rayNo].Distance,
                ray[rayNo].Radius);
        }
    }

    [System.Serializable]
    public class GroundCheckRay
    {
        [SerializeField, Tooltip("名前")] string name;
        [SerializeField, Tooltip("オフセット")] Vector2 offset;
        [SerializeField, Tooltip("半径")] float radius;
        [SerializeField, Tooltip("方向")] Vector2 direction;
        [SerializeField, Tooltip("距離")] float distance;
        [SerializeField, Tooltip("レイヤー")] LayerMask layer;
        [SerializeField, Tooltip("タグ")] Tag tag;
        [SerializeField, Tooltip("有効")] bool isActive;

        //----------プロパティ----------
        public string Name { get { return name; } }
        public Vector2 Offset { get { return offset; } set { offset = value; } }
        public float Radius { get { return radius; } set { radius = value; } }
        public Vector2 Direction { get { return direction; } set { direction = value; } }
        public float Distance { get { return distance; } set { distance = value; } }
        public LayerMask Layer { get { return layer; } }
        public SY.Tag Tag { get { return tag; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }

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