using UnityEngine;

namespace SY
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField, Tooltip("���C����")] bool isDisplay;
        [SerializeField, Tooltip("�ڒn���背�C")] GroundRaySetting[] ray;   //�v�f����5�ȉ�

        [System.Flags]
        public enum Flag
        {
            None        = 0,        //��ڒn
            Ground      = 1 << 0,   //�ڒn
            Slope_Left  = 1 << 1,   //���ɍ┻��
            Slope_Right = 1 << 2,   //�E�ɍ┻��
            Wall_Left   = 1 << 3,   //���ɕǔ���
            Wall_Right  = 1 << 4,   //�E�ɕǔ���
        }
        Flag groundFlag;

        Vector2 pos;    //���W
        int i;          //�J��Ԃ�

        public GroundRaySetting[] Ray { get { return ray; } }
        public Flag GroundFlag() { return groundFlag; }
        public void SetFlag(Flag setFlag) { groundFlag |= setFlag; }
        public void RemoveFlag(Flag removeFlag) { groundFlag &= ~removeFlag; }
        public bool CheckFlag(Flag checkFlag) { return (groundFlag & checkFlag) != 0 ? true : false; }
        public void ClearFlag() { groundFlag = 0; }

        void Awake()    //��������
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
                DrawGizmo(0);  //�ڒn
                if (ray.Length <= 1) { return; }
                DrawGizmo(1);    //��
                if (ray.Length <= 2) { return; }
                DrawGizmo(2);   //��
                if (ray.Length <= 3) { return; }
                DrawGizmo(3);  //��
                if (ray.Length <= 4) { return; }
                DrawGizmo(4); //��
            }

            if (ray.Length <= 5) { return; }
            Debug.LogError(gameObject.name + " > GroundCheck : Ray�̗v�f����5�ȉ��ɂ��Ă�������");
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
        [SerializeField, Tooltip("���O")] string name;
        [SerializeField, Tooltip("�I�t�Z�b�g")] Vector2 offset;
        [SerializeField, Tooltip("���a")] float radius;
        [SerializeField, Tooltip("����")] Vector2 direction;
        [SerializeField, Tooltip("����")] float distance;
        [SerializeField, Tooltip("���C���[")] LayerMask layer;
        [SerializeField, Tooltip("�^�O")] Tag tag;
        [SerializeField, Tooltip("�L��")] bool isActive;
        [SerializeField, Tooltip("�M�Y��")] GizmoSetting gizmo;

        //----------�v���p�e�B----------
        public string Name { get { return name; } }
        public Vector2 Offset { get { return offset; } set { offset = value; } }
        public float Radius { get { return radius; } set { radius = value; } }
        public Vector2 Direction { get { return direction; } set { direction = value; } }
        public float Distance { get { return distance; } set { distance = value; } }
        public LayerMask Layer { get { return layer; } }
        public Tag Tag { get { return tag; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public GizmoSetting Gizmo { get { return gizmo; } }

        //----------�T�[�r�X----------
        //�����蔻��
        public RaycastHit2D Raycast(Vector2 origin)
        {
            return Physics2D.CircleCast(origin + Offset, Radius, Direction, Distance, Layer);

            //CircleCast�����T�v (�~��葾�����̃C���[�W)
            //  origin...���_
            //  radius...�~���a
            //  direction...������������
            //  distance...������������
            //  layer...���C���[
        }

        //����
        //public void DrawRay()
        //{
        //    Debug.DrawRay(Origin, Direction.normalized * Distance, Color.green, Time.deltaTime, false);
        //}
    }
}
