using UnityEngine;

partial class Player
{

    [SerializeField, Tooltip("スラッシュのクールタイム")] float skillSlashCT;
    [SerializeField, Tooltip("フリートのクールタイム")] float skillFleetCT;
    [SerializeField, Tooltip("ローンウォーリアのクールタイム")] float skillLoneWarriorCT;
    [SerializeField, Tooltip("ローンウォーリアの持続時間")] float skillLoneWarriorTime;
    [SerializeField, Tooltip("グリームのクールタイム")] float skillGreemCT;
    [SerializeField, Tooltip("ディスピレイションストライクのクールタイム")] float skillDStrikeCT;

    [SerializeField, Tooltip("ローンウォーリアの初期攻撃力")] float SkillLoneAtk;
    [SerializeField, Tooltip("ローンウォーリアの一回の追加攻撃力")] float SkillLoneAtkPlus;
    [SerializeField, Tooltip("ローンウォーリアのコンボの許容時間")] float SkillLoneComboSpan;


    [SerializeField, Tooltip("ブリンク距離スキル")] float SkillBrinkMove;
    [SerializeField, Tooltip("ジャストガードスキル")] float SkillJustGuard;
    [SerializeField, Tooltip("スピードアップスキル")] int SkillMaxSpeed;
    [SerializeField, Tooltip("火事場攻撃力アップ")] float SkillKajibaAtk;

    Vector2 fleetStartPos;

    float skillSlashCount = 100;
    float skillFleetCount = 100;
    float skillLoneWarriorCount = 100;
    float skillGreemCount = 100;
    float skillDStrikeCount = 100;
    float skillLoneWarriorDuration= 0;
    float skillLoneWarriorComboCount = 0;

    float exAtk = 0;




    public GameObject slash;
    public GameObject greem;
    public GameObject dstrike;

    bool isLoneWarrior = false;
    bool LoneWarriorReset = false;

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
        skillLoneWarriorCount += Time.deltaTime;
        skillGreemCount += Time.deltaTime;
        skillDStrikeCount += Time.deltaTime;

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
        if (GameData.setSkill3 && skillLoneWarriorCT < skillLoneWarriorCount )
        {

            if (GameData.skillSlot1 == 3)
            {
                if (skill1)
                {

                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = SkillLoneAtk;                        // 攻撃力を上昇

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化


                }
            }
            else if (GameData.skillSlot2 == 3)
            {
                if (skill2)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = SkillLoneAtk;                        // 攻撃力を上昇

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化


                }
            }
            else if (GameData.skillSlot3 == 3)
            {
                if (skill3)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = SkillLoneAtk;                        // 攻撃力を上昇

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化

                }

            }
            else if (GameData.skillSlot4 == 3)
            {
                if (skill4)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = SkillLoneAtk;                        // 攻撃力を上昇

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化



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
 
    void ActiveSkillUpdate()
    {
        // ローンウォーリア
        SkillLoneWarrior();
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
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject sheriffObj = GameObject.Find("Sheriff(Clone)");
            sheriffObj.transform.localScale = new Vector3(5, 5, 5);
        }
        else if(dir.x == -1)
        {
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject sheriffObj = GameObject.Find("Sheriff(Clone)");
            sheriffObj.transform.localScale = new Vector3(-5, -5, -5);

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

        if (isLoneWarrior == true && skillLoneWarriorTime >= skillLoneWarriorDuration)   
        {
            Debug.Log("ローンウォーリア発動中");
            Debug.Log(skillLoneWarriorComboCount.ToString("F3") + "秒");
            skillLoneWarriorComboCount += Time.deltaTime;   // コンボ継続のカウント
            skillLoneWarriorDuration += Time.deltaTime;     // ローンウォーリアの継続時間
            if (HMng.CheckAttack() == true)
            {
                Debug.Log("攻撃ヒット");

                HMng.ATK += SkillLoneAtkPlus;
                skillLoneWarriorComboCount = 0;
            }

            if(skillLoneWarriorComboCount >= SkillLoneComboSpan)
            {
                LoneWarriorReset = true;
                isLoneWarrior = false;
            }
        }
        else if(skillLoneWarriorTime < skillLoneWarriorDuration)
        {
            LoneWarriorReset = true;
        }
        //else
        //{
        //    isLoneWarrior = false;
        //    HMng.ATK = exAtk;
        //    skillLoneWarriorDuration = 0;
        //    skillLoneWarriorCount = 0;

        //}

        if(LoneWarriorReset == true)
        {
            isLoneWarrior = false;
            HMng.ATK = exAtk;                   // 攻撃力を戻す
            skillLoneWarriorDuration = 0;       // 継続時間をリセット
            skillLoneWarriorComboCount = 0;     // コンボ継続カウントをリセット
            skillLoneWarriorCount = 0;          // クールタイムをリセット

            LoneWarriorReset = false;
        }

    }
    public void SkillGreem()
    {
        SkillSE();

        GameData.SkillCount++;

        if (dir.x == 1)
        {
            Instantiate(greem, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -50, 90));
            GameObject greemObj = GameObject.Find("Greem(Clone)");
            greemObj.transform.localScale = new Vector3(3, 5, 5);

        }
        else if (dir.x == -1)
        {
            Instantiate(greem, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -50, 90));
            GameObject greemObj = GameObject.Find("Greem(Clone)");
            greemObj.transform.localScale = new Vector3(-3, -5, -5);
        }

    }
    public void SkillDeathPrationStrike()
    {
        SkillSE();

        GameData.SkillCount++;

        HMng.HP -= 1;

        if (dir.x == 1)
        {
            Instantiate(dstrike, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject dstrikeObj = GameObject.Find("DStrike(Clone)");
            dstrikeObj.transform.localScale = new Vector3(5, 5, 5);
        }
        else if (dir.x == -1)
        {
            Instantiate(dstrike, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject dstrikeObj = GameObject.Find("DStrikle(Clone)");
            dstrikeObj.transform.localScale = new Vector3(-5, -5, -5);

        }

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
