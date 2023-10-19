using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{

    [SerializeField, Tooltip("�X���b�V���̃N�[���^�C��")] float skillSlashCT;

    [SerializeField, Tooltip("�u�����N�����X�L��")] float SkillBrinkMove;
    [SerializeField, Tooltip("�W���X�g�K�[�h�X�L��")] float SkillJustGuard;
    [SerializeField, Tooltip("�X�s�[�h�A�b�v�X�L��")] int SkillMaxSpeed;
    [SerializeField, Tooltip("�Ύ���U���̓A�b�v")] float SkillKajibaAtk;

    float skillSlashCount = 0;

    public GameObject slash;

    public float SkillSlashCT { get { return skillSlashCT; } }
    
    public float SkillSlashCount { get { return skillSlashCount; } }
    void ActiveSkillController()
    {
        skillSlashCount += Time.deltaTime;
        bool a = false;

        if (GameData.skillSlot1 == 1) { a = true; }

        Debug.Log("�X�L���X���b�V���Z�b�g" + GameData.setSkill1);
        Debug.Log("�X�L���X���b�g1�ɓ����Ă������" + GameData.skillSlot1);
        Debug.Log("�X�L���X���b�g1�ƃX�L���X���b�V��" + a);



        /* �A�N�e�B�u�X�L�� */

        if (GameData.setSkill1 && skillSlashCT < skillSlashCount)
        {
            if (GameData.skillSlot1 == 1)
            {
                if (skill1)
                {
                    SkillSlash();
                    skillSlashCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 1)
            {
                if (skill2)
                {
                    SkillSlash();
                    skillSlashCount = 0;

                }
            }
            else if (GameData.skillSlot3 == 1)
            {
                //if (skill3) 
                //{
                skillSlashCount = 0;

                //}

            }
            else if (GameData.skillSlot4 == 1)
            {
                //if (skill4)
                //{
                skillSlashCount = 0;

                //}

            }

        }
    }
    public void PassiveSkillStart()
    {
        if (GameData.setSkill10 == true)
        {
            SkillHPPlus();
        }
        if(GameData.setSkill11 == true)
        {
            SkillBrinkMovePlus();
        }
        if(GameData.setSkill12 == true)
        {
            SkillJustGuardPlus();
        }
 

    }
    public void PassiveSkillUpdate()
    {
        if(GameData.saveSkill13 == true)
        {
            SkillSpeedUpHpMax();
        }
        if(GameData.saveSkill14 == true)
        {
            SkillKajiba();
        }
    }

    /* �A�N�e�B�u�X�L�� */
    public void SkillSlash()
    {

        SkillSE();

        GameData.SkillCount++;
        
        if(dir.x == 1)
        {
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(-127.798f, -55.60699f, 94.236f));

        }
        else if(dir.x == -1)
        {
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(50, 50, -90));

        }

    }

    /* �p�b�V�u�X�L�� */
    public void SkillHPPlus()   // �X�L��10
    {
        HMng.MaxHP = 20;
        HMng.HP = HMng.MaxHP;
    }
    public void SkillBrinkMovePlus()    // �X�L��11
    {
        brinkMove = SkillBrinkMove;
    }
    public void SkillJustGuardPlus()    // �X�L��12
    {
        justGuardTime = SkillJustGuard;
    }
    public void SkillSpeedUpHpMax()     // �X�L��13
    {
        if(HMng.HP == HMng.MaxHP)
        {
            maxSpeed = SkillMaxSpeed;
        }
        else
        {
            maxSpeed = 12;  // �߂�ǂ��̂ŏ������l�����
        }
    }
    public void SkillKajiba()
    {
        SkillKajibaAtk = HMng.ATK * 2;
        if(HMng.HP == 1)
        {
            HMng.ATK = SkillKajibaAtk;
        }
        else
        {
            HMng.ATK = 100;     // �߂�ǂ��̂ŏ������l�����
        }
    }
}
