using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{
    // �X�L���̃N�[���^�C��
    [SerializeField, Tooltip("�X���b�V���N�[���^�C��")] float skillslashCT;

    float skillCount = 0;
    public GameObject slash;

    void SkillController()
    {

        if (GameData.setSkill1)
        {
            Debug.Log("�X���b�V���X�L���L��");

            skillCount += Time.deltaTime;


            if (skill2 && skillslashCT < skillCount)
            {
                SkillDoubleSlash();

                skillCount = 0;
            }


        }
    }
    public void SkillDoubleSlash()
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
}
