using UnityEngine;

namespace SY
{
    public enum GizmoMode
    {
        Cube,
        WireCube,
        Sphere,
        WireSphere,
    }

    [System.Serializable]
    public class GizmoSetting
    {
        [SerializeField, Tooltip("形")] GizmoMode mode = GizmoMode.Cube;
        [SerializeField, Tooltip("中心座標"), ReadOnly] Vector3 center = Vector3.zero;
        [SerializeField, Tooltip("サイズ(四角)"), ReadOnly] Vector3 size = Vector3.one;
        [SerializeField, Tooltip("半径(球)"), ReadOnly] float radius = 1.0f;
        [SerializeField, Tooltip("色")] Color color = Color.black;
        [SerializeField, Tooltip("可視化")] bool display = false;

        //----------プロパティ----------
        public GizmoMode Mode { get { return mode; } }
        public Vector3 Center { get { return center; } set { center = value; } }
        public Vector3 Size { get { return size; } set { size = value; } }
        public float Radius { get { return radius; } set { radius = value; } }
        public Color Color { get { return color; } }
        public bool Display { get { return display; } }

        //----------サービス----------
        public void Draw(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
            this.radius = 0;
            DrawGizmo();
        }
        public void Draw(Vector3 center, float radius)
        {
            this.center = center;
            this.size = Vector3.zero;
            this.radius = radius;
            DrawGizmo();
        }

        void DrawGizmo()
        {
            Gizmos.color = color;
            switch(mode)
            {
                case GizmoMode.Cube:
                    Gizmos.DrawCube(center, size);
                    break;
                case GizmoMode.WireCube:
                    Gizmos.DrawWireCube(center, size);
                    break;
                case GizmoMode.Sphere:
                    Gizmos.DrawSphere(center, radius);
                    break;
                case GizmoMode.WireSphere:
                    Gizmos.DrawWireSphere(center, radius);
                    break;
            }
        }
    }
}