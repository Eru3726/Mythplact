using UnityEngine;

partial class Player
{

    [SerializeField, Tooltip("スラッシュのクールタイム")] float skillSlashCT;
    [SerializeField, Tooltip("フリートのクールタイム")] float skillFleetCT;
    [SerializeField, Tooltip("ローンウォーリアのクールタイム")] float skillLoneWarriorCT;
    [SerializeField, Tooltip("グリームのクールタイム")] float skillGreemCT;
    [SerializeField, Tooltip("ディスピレイションストライクのクールタイム")] float skillDStrikeCT;


    [SerializeField, Tooltip("ブリンク距離スキル")] float SkillBrinkMove;
    [SerializeField, Tooltip("ジャストガードスキル")] float SkillJustGuard;
    [SerializeField, Tooltip("スピードアップスキル")] int SkillMaxSpeed;
    [SerializeField, Tooltip("火事場攻撃力アップ")] float SkillKajibaAtk;

    Vector2 fleetStartPos;

    float skillSlashCount = 0;
    float skillFleetCount = 0;
    float skillLoneWarriorCount = 0;
    float skillGreemCount = 0;
    float skillDStrikeCount = 0;


    public GameObject slash;

    public float SkillSlashCT { get { return skillSlashCT; } }
    public float SkillSlashCount { get { return skillSlashCount; } }

    public float SkillFleetCT { get { return skillFleetCT; } }
    public float SkillFleetCount { get { return skillFleetCount; } }

    public float SkillLoneWarrirorCT { get { return skillLoneWarriorCT; } }
    public float SkillLoneWarrirorCount { get { return skillLoneWarriorCount; } }

    public float SkillGreemCT { get { return skillGreemCT; } }
    public float SkillGreemCount { get { return skillGreemCount; } }

    public float SkillDStrikeCT { get { return skillDStrikeCT; } }
    public float SkillDStrikeCount { get { return skillDStrikeCount; } }

    void ActiveSkillController()
    {
        skillSlashCount += Time.deltaTime;
        skillFleetCount += Time.deltaTime;

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
                if (skill3)
                {
                    SkillSlash();
                    skillSlashCount = 0;

                }

            }
            else if (GameData.skillSlot4 == 1)
            {
                if (skill4)
                {
                    SkillSlash();
                    skillSlashCount = 0;

                }

            }

        }
        if (GameData.setSkill2 && skillFleetCT < skillFleetCount)
        {
            if (GameData.skillSlot1 == 2)
            {
                if (skill1)
                {
                    SkillFleet();
                    skillFleetCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 2)
            {
                if (skill2)
                {
                    SkillFleet();
                    skillFleetCount = 0;
                }
            }
            else if (GameData.skillSlot3 == 2)
            {
                if (skill3)
                {
                    SkillFleet();
                    skillFleetCount = 0;
                }

            }
            else if (GameData.skillSlot4 == 2)
            {
                if (skill4)
                {
                    SkillFleet();
                    skillFleetCount = 0;

                }

            }

        }
        if (GameData.setSkill3 && skillLoneWarriorCT < skillLoneWarriorCount)
        {
            if (GameData.skillSlot1 == 3)
            {
                if (skill1)
                {
                    SkillLoneWarrior();
                    skillLoneWarriorCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 3)
            {
                if (skill2)
                {
                    SkillLoneWarrior();
                    skillLoneWarriorCount = 0;
                }
            }
            else if (GameData.skillSlot3 == 3)
            {
                if (skill3)
                {
                    SkillLoneWarrior();
                    skillLoneWarriorCount = 0;
                }

            }
            else if (GameData.skillSlot4 == 3)
            {
                if (skill4)
                {
                    SkillLoneWarrior();
                    skillLoneWarriorCount = 0;

                }

            }

        }
        if (GameData.setSkill4 && skillGreemCT < skillGreemCount)
        {
            if (GameData.skillSlot1 == 4)
            {
                if (skill1)
                {
                    SkillGreem();
                    skillGreemCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 4)
            {
                if (skill2)
                {
                    SkillGreem();
                    skillGreemCount = 0;
                }
            }
            else if (GameData.skillSlot3 == 4)
            {
                if (skill3)
                {
                    SkillGreem();
                    skillGreemCount = 0;
                }

            }
            else if (GameData.skillSlot4 == 4)
            {
                if (skill4)
                {
                    SkillGreem();
                    skillGreemCount = 0;
                }

            }

        }
        if (GameData.setSkill5 && skillDStrikeCT < skillDStrikeCount)
        {
            if (GameData.skillSlot1 == 5)
            {
                if (skill1)
                {
                    SkillDeathPrationStrike();
                    skillDStrikeCount = 0;


                }
            }
            else if (GameData.skillSlot2 == 5)
            {
                if (skill2)
                {
                    SkillDeathPrationStrike();
                    skillDStrikeCount = 0;
                }
            }
            else if (GameData.skillSlot3 == 5)
            {
                if (skill3)
                {
                    SkillDeathPrationStrike();
                    skillDStrikeCount = 0;
                }

            }
            else if (GameData.skillSlot4 == 5)
            {
                if (skill4)
                {
                    SkillDeathPrationStrike();
                    skillDStrikeCount = 0;

                }

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
        if(GameData.setSkill15 == true)
        {
            SkillStrength();
        }
        if (GameData.setSkill17)
        {
            Debug.Log("スキルエレクト発動");
            SkillElect();
        }
        if(GameData.setSkill18 == true)
        {
            SkillCarse();
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

    /* アクティブスキル */
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
    public void SkillFleet()
    {
        GameData.SkillCount++;

        int fleetPow = 50;

        PlayerRb.AddForce(Vector2.right * dir.x * fleetPow,ForceMode2D.Impulse);
    }
    public void SkillLoneWarrior()
    {

    }
    public void SkillGreem()
    {

    }
    public void SkillDeathPrationStrike()
    {

    }
    /* パッシブスキル */
    public void SkillHPPlus()   // スキル10
    {
        HMng.MaxHP = 20;
        HMng.HP = HMng.MaxHP;
    }
    public void SkillBrinkMovePlus()    // スキル11
    {
        brinkMove = SkillBrinkMove;
    }
    public void SkillJustGuardPlus()    // スキル12
    {
        justGuardTime = SkillJustGuard;
    }
    public void SkillSpeedUpHpMax()     // スキル13
    {
        if(HMng.HP == HMng.MaxHP)
        {
            maxSpeed = SkillMaxSpeed;
        }
        else
        {
            maxSpeed = 12;  // めんどいので初期数値手入力
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
            HMng.ATK = 100;     // めんどいので初期数値手入力
        }
    }
    public void SkillStrength() // スキル15
    {
        maxStamina *= 2;
    }
    public void SkillWise()     // スキル16
    {
        if (GameData.setSkill17 == true)
        {
            HMng.HP += 1;

        }

    }
    public void SkillElect()    // スキル17
    {
        healStamina *= 1.5f;
    }
    public void SkillCarse()    // スキル18
    {
        HMng.MaxHP = 1;
        HMng.HP = HMng.MaxHP;

    }
    public void SkillHeep()     // スキル19
    {

    }
}
