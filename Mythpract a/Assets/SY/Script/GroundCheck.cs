using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField, Tooltip("���C����")] bool rayDisplay;
        [SerializeField, Tooltip("�ڒn���背�C")] GroundCheckRay[] ray;   //�v�f����5�ȉ�

        [System.Flags]
        public enum GroundCheckFlag
        {
            None        = 0,        //��ڒn
            Ground      = 1 << 0,   //�ڒn
            Slope_Left  = 1 << 1,   //���ɍ┻��
            Slope_Right = 1 << 2,   //�E�ɍ┻��
            Wall_Left   = 1 << 3,   //���ɕǔ���
            Wall_Right  = 1 << 4,   //�E�ɕǔ���
        }
        GroundCheckFlag groundCheckFlag;

        Vector2 pos;    //���W
        int i;          //�J��Ԃ�

        public GroundCheckRay[] Ray { get { return ray; } }
        public GroundCheckFlag GCFlag() { return groundCheckFlag; }
        public void SetGCFlag(GroundCheckFlag setFlag) { groundCheckFlag |= setFlag; }
        public void RemoveGCFlag(GroundCheckFlag removeFlag) { groundCheckFlag &= ~removeFlag; }
        public bool CheckGCFlag(GroundCheckFlag checkFlag) { return (groundCheckFlag & checkFlag) != 0 ? true : false; }
        public void ClearGCFlag() { groundCheckFlag = 0; }

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
                DrawGizmo(Color.white, 0);  //�ڒn
                if (ray.Length <= 1) { return; }
                DrawGizmo(Color.red, 1);    //��
                if (ray.Length <= 2) { return; }
                DrawGizmo(Color.blue, 2);   //��
                if (ray.Length <= 3) { return; }
                DrawGizmo(Color.green, 3);  //��
                if (ray.Length <= 4) { return; }
                DrawGizmo(Color.yellow, 4); //��
            }

            if (ray.Length <= 5) { return; }
            Debug.LogError(gameObject.name + " > GroundCheck : Ray�̗v�f����5�ȉ��ɂ��Ă�������");
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
        [SerializeField, Tooltip("���O")] string name;
        [SerializeField, Tooltip("�I�t�Z�b�g")] Vector2 offset;
        [SerializeField, Tooltip("���a")] float radius;
        [SerializeField, Tooltip("����")] Vector2 direction;
        [SerializeField, Tooltip("����")] float distance;
        [SerializeField, Tooltip("���C���[")] LayerMask layer;
        [SerializeField, Tooltip("�^�O")] Tag tag;
        [SerializeField, Tooltip("�L��")] bool isActive;

        //----------�v���p�e�B----------
        public string Name { get { return name; } }
        public Vector2 Offset { get { return offset; } set { offset = value; } }
        public float Radius { get { return radius; } set { radius = value; } }
        public Vector2 Direction { get { return direction; } set { direction = value; } }
        public float Distance { get { return distance; } set { distance = value; } }
        public LayerMask Layer { get { return layer; } }
        public SY.Tag Tag { get { return tag; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }

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