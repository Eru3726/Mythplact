using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{

    [SerializeField, Tooltip("�X���b�V���̃N�[���^�C��")] float SkillSlashCT;

    [SerializeField, Tooltip("�u�����N�����X�L��")] float SkillBrinkMove;
    [SerializeField, Tooltip("�W���X�g�K�[�h�X�L��")] float SkillJustGuard;
    [SerializeField, Tooltip("�X�s�[�h�A�b�v�X�L��")] int SkillMaxSpeed;


    public GameObject slash;

    void ActiveSkillController()
    {
        skillCount += Time.deltaTime;
        bool a = false;

        if (GameData.skillSlot1 == 1) { a = true; }

        Debug.Log("�X�L���X���b�V���Z�b�g" + GameData.setSkill1);
        Debug.Log("�X�L���X���b�g1�ɓ����Ă������" + GameData.skillSlot1);
        Debug.Log("�X�L���X���b�g1�ƃX�L���X���b�V��" + a);



        /* �A�N�e�B�u�X�L�� */

        if (GameData.setSkill1 && SkillSlashCT < skillCount)
        {
            if (GameData.skillSlot1 == 1)
            {
                if (skill1)
                {
                    SkillSlash();
                    skillCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 1)
            {
                if (skill2)
                {
                    SkillSlash();
                    skillCount = 0;

                }
            }
            else if (GameData.skillSlot3 == 1)
            {
                //if (skill3) 
                //{
                skillCount = 0;

                //}

            }
            else if (GameData.skillSlot4 == 1)
            {
                //if (skill4)
                //{
                skillCount = 0;

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
            maxSpeed = 12;
        }
    }
}
