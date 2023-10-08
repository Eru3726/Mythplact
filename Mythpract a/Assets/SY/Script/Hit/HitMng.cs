using UnityEngine;
using static SY.HitResult;

namespace SY
{
    public class HitMng : MonoBehaviour
    {
        //----------�ϐ�----------
        [SerializeField] HitLayer layer;
        //�X�e�[�^�X
        [SerializeField, Tooltip("�ő�̗�")] float maxHp;
        [SerializeField, Tooltip("���ݑ̗�"), ReadOnly] float hp;
        [SerializeField, Tooltip("�U����")] float atk;
        [SerializeField, Tooltip("�h���")] float def;
        [SerializeField, Tooltip("�U���g���K�[")] bool atkActive;
        [SerializeField, Tooltip("�h��g���K�[")] bool defActive;
        float hitInterval;  //�q�b�g�㖳�G����

        HitResult result = new HitResult();

        //�O���֐�(�f���Q�[�g)
        public delegate void DmgFunc();
        private DmgFunc dmgFunc;
        public delegate void DieFunc();
        private DieFunc dieFunc;

        //----------�v���p�e�B----------
        public HitLayer Layer { get { return layer; } }
        public float MaxHP { get { return maxHp; } set { maxHp = value; } }
        public float HP { get { return hp; } set { hp = value; } }
        public float ATK { get { return atk; } set { atk = value; } }
        public float DEF { get { return def; } set { def = value; } }
        public bool ATKActive { get { return atkActive; } set { atkActive = value; } }
        public bool DEFActive { get { return defActive; } set { defActive = value; } }
        public float HitInterval { get { return hitInterval; } set { hitInterval = value; } }
        public HitResult Result { get { return result; } }

        //----------�֐�----------
        void Awake()
        {
            HP = MaxHP;
            atkActive = true;
            defActive = true;
        }

        //������
        public void SetUp(DmgFunc damage, DieFunc die)
        {
            dmgFunc = damage;
            dieFunc = die;
        }

        //���t���[���X�V(�擪)
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

            //�A���q�b�g�h�~
            hitInterval -= Time.deltaTime;
        }

        //���t���[���X�V(���)
        public void PostUpdate()
        {
            Result.AllClearFlag();
        }

        //�_���[�W���󂯂���
        public bool CheckDamage() { return Result.CheckDefFlag(DefFlag.DefDamage); }
    }
}