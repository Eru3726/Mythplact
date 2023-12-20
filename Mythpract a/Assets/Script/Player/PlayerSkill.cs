using UnityEngine;

partial class Player
{

    //[SerializeField, Tooltip("スラッシュのクールタイム")] float skillSlashCT;
    //[SerializeField, Tooltip("フリートのクールタイム")] float skillFleetCT;
    //[SerializeField, Tooltip("フリートの持続時間")] float skillFleetTime;
    //[SerializeField, Tooltip("ローンウォーリアのクールタイム")] float skillLoneWarriorCT;
    //[SerializeField, Tooltip("ローンウォーリアの持続時間")] float skillLoneWarriorTime;
    //[SerializeField, Tooltip("グリームのクールタイム")] float skillGreemCT;
    //[SerializeField, Tooltip("ディスピレイションストライクのクールタイム")] float skillDStrikeCT;

    //[SerializeField, Tooltip("ローンウォーリアの初期攻撃力")] float skillLoneAtk;
    //[SerializeField, Tooltip("ローンウォーリアの一回の追加攻撃力")] float skillLoneAtkPlus;
    //[SerializeField, Tooltip("ローンウォーリアのコンボの許容時間")] float skillLoneComboSpan;
    [SerializeField, Tooltip("ローンウォーリア1段階目")] Color SkillLWFirstColor;
    [SerializeField, Tooltip("ローンウォーリア2段階目")] Color SkillLWSecondColor;
    [SerializeField, Tooltip("ローンウォーリア3段階目")] Color SkillLWThirdColor;
    [SerializeField, Tooltip("ローンウォーリア4段階目")] Color SkillLWFoursColor;
    [SerializeField, Tooltip("ローンウォーリア5段階目")] Color SkillLWLastColor;


    //[SerializeField, Tooltip("ブリンク距離スキル")] float skillBrinkMove;
    //[SerializeField, Tooltip("ジャストガードスキル")] float skillJustGuard;
    //[SerializeField, Tooltip("スピードアップスキル")] int skillMaxSpeed;
    //[SerializeField, Tooltip("火事場攻撃力アップ")] float skillKajibaAtk;

    [SerializeField] BoxCollider2D FleetCol;

    float skillSlashCount = 100;
    float skillFleetCount = 100;
    float skillLoneWarriorCount = 100;
    float skillGreemCount = 100;
    float skillDStrikeCount = 100;

    float skillFleetDuration = 0;
    float skillFleetDirX = 0;
    float skillLoneWarriorDuration = 0;
    float skillLoneWarriorComboCount = 0;

    float exAtk = 0;




    public GameObject slash;
    public GameObject greem;
    public GameObject dstrike;

    bool settingActive;
    bool settingPassive;
    

    bool isFleet = false;
    bool isLoneWarrior = false;
    bool LoneWarriorReset = false;
    bool ChargeEffectPlayOnce = false;
    bool kajibaAtkPlusOnce = false;
    bool kajibaAtkMinusOnce = false;

    bool isSkill = false;
    bool isCharge = false;

    public float SkillSlashCT { get { return playerData.Player[0].skillSlashCT; } }
    public float SkillSlashCount { get { return skillSlashCount; } }

    public float SkillFleetCT { get { return playerData.Player[0].skillFleetCT; } }
    public float SkillFleetCount { get { return skillFleetCount; } }

    public bool IsFleet { get { return isFleet; } set { isFleet = value; } }

    public float SkillLoneWarrirorCT { get { return playerData.Player[0].skillLoneWarriorCT; } }
    public float SkillLoneWarrirorCount { get { return skillLoneWarriorCount; } }

    public float SkillGreemCT { get { return playerData.Player[0].skillGreemCT; } }
    public float SkillGreemCount { get { return skillGreemCount; } }

    public float SkillDStrikeCT { get { return playerData.Player[0].skillDStrikeCT; } }
    public float SkillDStrikeCount { get { return skillDStrikeCount; } }

    void ActiveSkillController()
    {
        skillSlashCount += Time.deltaTime;
        skillFleetCount += Time.deltaTime;
        skillLoneWarriorCount += Time.deltaTime;
        skillGreemCount += Time.deltaTime;
        skillDStrikeCount += Time.deltaTime;

        if (GameData.setSkill1 && playerData.Player[0].skillSlashCT < skillSlashCount)
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
        if (GameData.setSkill2 && playerData.Player[0].skillFleetCT < skillFleetCount && !hitAnim)
        {
            if (GameData.skillSlot1 == 2)
            {
                if (skill1)
                {
                    GameData.SkillCount += 1;
                    skillFleetDirX = dir.x;
                    PlayerRb.velocity = new Vector2(0, 0);
                    skillFleetDuration = 0;
                    audioSource.PlayOneShot(skillFleetSE);


                    isFleet = true;

                    skillFleetCount = 0;

                }
            }
            else if (GameData.skillSlot2 == 2)
            {
                if (skill2)
                {
                    GameData.SkillCount += 1;
                    skillFleetDirX = dir.x;
                    PlayerRb.velocity = new Vector2(0, 0);
                    skillFleetDuration = 0;
                    audioSource.PlayOneShot(skillFleetSE);

                    isFleet = true;

                    skillFleetCount = 0;

                }
            }
            else if (GameData.skillSlot3 == 2)
            {
                if (skill3)
                {
                    GameData.SkillCount += 1;
                    skillFleetDirX = dir.x;
                    PlayerRb.velocity = new Vector2(0, 0);
                    skillFleetDuration = 0;
                    audioSource.PlayOneShot(skillFleetSE);

                    isFleet = true;

                    skillFleetCount = 0;

                }

            }
            else if (GameData.skillSlot4 == 2)
            {
                if (skill4)
                {
                    GameData.SkillCount += 1;
                    skillFleetDirX = dir.x;
                    PlayerRb.velocity = new Vector2(0, 0);
                    skillFleetDuration = 0;
                    audioSource.PlayOneShot(skillFleetSE);

                    isFleet = true;

                    skillFleetCount = 0;

                }

            }

        }
        if (GameData.setSkill3 && playerData.Player[0].skillLoneWarriorCT < skillLoneWarriorCount )
        {

            if (GameData.skillSlot1 == 3)
            {
                if (skill1)
                {

                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = playerData.Player[0].skillLoneAtk;                        // 攻撃力を上昇
                    GameData.SkillCount += 1;

                    audioSource.PlayOneShot(skillLoneWarriorSE);

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化


                }
            }
            else if (GameData.skillSlot2 == 3)
            {
                if (skill2)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = playerData.Player[0].skillLoneAtk;                        // 攻撃力を上昇
                    GameData.SkillCount += 1;
                    audioSource.PlayOneShot(skillLoneWarriorSE);

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化


                }
            }
            else if (GameData.skillSlot3 == 3)
            {
                if (skill3)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = playerData.Player[0].skillLoneAtk;                        // 攻撃力を上昇
                    GameData.SkillCount += 1;
                    audioSource.PlayOneShot(skillLoneWarriorSE);

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化

                }

            }
            else if (GameData.skillSlot4 == 3)
            {
                if (skill4)
                {
                    exAtk = HMng.ATK;     // 元の攻撃力を保存
                    HMng.ATK = playerData.Player[0].skillLoneAtk;                        // 攻撃力を上昇
                    GameData.SkillCount += 1;
                    audioSource.PlayOneShot(skillLoneWarriorSE);

                    isLoneWarrior = true;       // スキルローンウォーリアを有効化



                }

            }

        }
        if (GameData.setSkill4 && playerData.Player[0].skillGreemCT < skillGreemCount)
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
        if (GameData.setSkill5 && playerData.Player[0].skillDStrikeCT < skillDStrikeCount)
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
        SkillFleet();
        // ローンウォーリア
        SkillLoneWarrior();

    }
    public void PassiveSkillStart()
    {
        settingPassive = false;
        if (GameData.setSkill10 == true)
        {
            SkillHPPlus();
            settingPassive = true;
        }
        if(GameData.setSkill11 == true)
        {
            SkillBrinkMovePlus();
            settingPassive = true;

        }
        if (GameData.setSkill12 == true)
        {
            SkillJustGuardPlus();
            settingPassive = true;

        }
        if (GameData.setSkill15 == true)
        {
            SkillStrength();
            settingPassive = true;

        }
        if (GameData.setSkill17)
        {
            SkillElect();
            settingPassive = true;

        }
        if (GameData.setSkill18 == true)
        {
            SkillCarse();
            settingPassive = true;

        }


    }
    public void PassiveSkillUpdate()
    {
        if(GameData.saveSkill13 == true)
        {
            SkillSpeedUpHpMax();
            settingPassive = true;

        }
        if (GameData.saveSkill14 == true)
        {
            SkillKajiba();
            settingPassive = true;

        }
        if (GameData.saveSkill19 == true)
        {
            SkillHeep();
            settingPassive = true;

        }
    }

    /* アクティブスキル */
    public void SkillSlash()
    {

        audioSource.PlayOneShot(skillSheriffSE);

        GameData.SkillCount++;
        achv.UseSheriff();
        
        if(dir.x == 1)
        {
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject sheriffObj = GameObject.Find("Sheriff(Clone)");
            sheriffObj.transform.localScale = new Vector3(5, 5, 5);
        }
        else
        {
            Instantiate(slash, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(90, 0, 140));
            GameObject sheriffObj = GameObject.Find("Sheriff(Clone)");
            sheriffObj.transform.localScale = new Vector3(-5, -5, -5);

        }

    }
    public void SkillFleet()
    {
        if(isFleet == true)
        {
            isSkill = true;
            HMng.DEFActive = false;
            skillFleetDuration += Time.deltaTime;

            FleetCol.size = new Vector2(6f, 2f);
            FleetCol.offset = new Vector2(0, -0.355f);
            EffectSkillFleet.Play();

            if (skillFleetDirX > 0)
            {
                PlayerRb.gravityScale = 0f;
                gameObject.transform.position += new Vector3(Time.deltaTime * 40, 0, 0);
                //    if (CheckRightHit())
                //    {
                //        PlayerRb.velocity = new Vector2(0, 0);
                //        PlayerRb.gravityScale = 7f;
                //        skillFleetDuration = 0;

                //        isFleet = false;

                //    }
                //}
            }
            else
            {
                PlayerRb.gravityScale = 0f;
                gameObject.transform.position += new Vector3(Time.deltaTime * -40, 0, 0);

                //    if (CheckLeftHit())
                //    {
                //        PlayerRb.velocity = new Vector2(0, 0);
                //        PlayerRb.gravityScale = 7f;
                //        skillFleetDuration = 0;

                //        isFleet = false;

                //    }

            }
            //if (HMng.CheckDamage())
            //{
            //    PlayerRb.gravityScale = 7f;
            //    isFleet = false;

            //}

            if (skillFleetDuration >= playerData.Player[0].skillFleetTime)
            {
                PlayerRb.gravityScale = 7f;
                isFleet = false;

            }

        }
        else
        {
            HMng.DEFActive = true;
            EffectSkillFleet.Stop();

            isSkill = false;
            FleetCol.size = new Vector2(0, 0);
        }
    }
    public void SkillLoneWarrior()
    {
        var main = EffectSkillLoneWarrior.main;
        if (isLoneWarrior == true && playerData.Player[0].skillLoneWarriorTime >= skillLoneWarriorDuration)   
        {
            Debug.Log("ローンウォーリア発動中");
            Debug.Log(skillLoneWarriorComboCount.ToString("F3") + "秒");
            skillLoneWarriorComboCount += Time.deltaTime;   // コンボ継続のカウント
            skillLoneWarriorDuration += Time.deltaTime;     // ローンウォーリアの継続時間
            EffectSkillLoneWarrior.Play();
            if (HMng.CheckAttack() == true)
            {
                Debug.Log("攻撃ヒット");

                HMng.ATK += playerData.Player[0].skillLoneAtkPlus;
                skillLoneWarriorComboCount = 0;
            }

            if(skillLoneWarriorComboCount >= playerData.Player[0].skillLoneComboSpan || HMng.CheckDamage())
            {
                LoneWarriorReset = true;
                isLoneWarrior = false;
            }

            if(HMng.ATK > 2.4f)
            {
                main.startColor = new ParticleSystem.MinMaxGradient(SkillLWLastColor);
                EffectSkillLoneWarrior.Play();


            }
            else if (HMng.ATK > 2.1f)
            {
                main.startColor = new ParticleSystem.MinMaxGradient(SkillLWFoursColor);
                EffectSkillLoneWarrior.Play();


            }
            else if (HMng.ATK > 1.8f)
            {
                main.startColor = new ParticleSystem.MinMaxGradient(SkillLWThirdColor);
                EffectSkillLoneWarrior.Play();


            }
            else if (HMng.ATK > 1.5f)
            {
                main.startColor = new ParticleSystem.MinMaxGradient(SkillLWSecondColor);
                EffectSkillLoneWarrior.Play();

            }
            else
            {
                main.startColor = new ParticleSystem.MinMaxGradient(SkillLWFirstColor);
                EffectSkillLoneWarrior.Play();

            }


        }
        else if(playerData.Player[0].skillLoneWarriorTime < skillLoneWarriorDuration)
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
            Color DeffColer = new Color(1, 1, 1, 0.5f);
            isLoneWarrior = false;
            HMng.ATK = exAtk;                   // 攻撃力を戻す
            EffectSkillLoneWarrior.Stop();
            skillLoneWarriorDuration = 0;       // 継続時間をリセット
            skillLoneWarriorComboCount = 0;     // コンボ継続カウントをリセット
            skillLoneWarriorCount = 0;          // クールタイムをリセット
            main.startColor = new ParticleSystem.MinMaxGradient(DeffColer);

            LoneWarriorReset = false;
        }

    }
    public void SkillGreem()
    {
        audioSource.PlayOneShot(skillGreemSE);

        GameData.SkillCount++;

        if (dir.x == 1)
        {
            Instantiate(greem, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -50, 90));
            GameObject greemObj = GameObject.Find("Greem(Clone)");
            greemObj.transform.localScale = new Vector3(3, 5, 5);

        }
        else
        {
            Instantiate(greem, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -50, 90));
            GameObject greemObj = GameObject.Find("Greem(Clone)");
            greemObj.transform.localScale = new Vector3(-3, -5, -5);
        }

    }
    public void SkillDeathPrationStrike()
    {
        audioSource.PlayOneShot(skillDStrikeSE);

        GameData.SkillCount++;

        HMng.HP -= 1;

        if (dir.x == 1)
        {
            Instantiate(dstrike, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -30, 90));
            GameObject dstrikeObj = GameObject.Find("DStrike(Clone)");
            dstrikeObj.transform.localScale = new Vector3(0.5f, 8, 5);
        }
        else
        {
            Instantiate(dstrike, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, -30, 90));
            GameObject dstrikeObj = GameObject.Find("DStrike(Clone)");
            dstrikeObj.transform.localScale = new Vector3(-0.5f, -8, -5);

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
        playerData.Player[0].brinkMove = playerData.Player[0].skillBrinkMove;
    }
    public void SkillJustGuardPlus()    // スキル12
    {
        playerData.Player[0].justGuardTime = playerData.Player[0].skillJustGuard;
    }
    public void SkillSpeedUpHpMax()     // スキル13
    {
        if(HMng.HP == HMng.MaxHP)
        {
            playerData.Player[0].maxSpeed = playerData.Player[0].skillMaxSpeed;
        }
        else
        {
            playerData.Player[0].maxSpeed = 12;  // めんどいので初期数値手入力
        }
    }
    public void SkillKajiba()
    {
        playerData.Player[0].skillKajibaAtk = HMng.ATK * 2;
        if(HMng.HP == 1)
        {
            kajibaAtkMinusOnce = false;

            if (kajibaAtkPlusOnce == false)
            {
                HMng.ATK = playerData.Player[0].skillKajibaAtk;
                kajibaAtkPlusOnce = true;
            }
        }
        else
        {
            kajibaAtkPlusOnce = false;
            if (kajibaAtkMinusOnce == false)
            {
                HMng.ATK = 1;
                kajibaAtkMinusOnce = true;
            }
        }
    }
    public void SkillStrength() // スキル15
    {
        playerData.Player[0].maxStamina *= 2;
    }
    public void SkillWise()     // スキル16
    {
        if (GameData.setSkill16 == true)
        {
            HMng.HP += 1;
            EffectHeal.Play();

        }

    }
    public void SkillElect()    // スキル17
    {
        playerData.Player[0].healStamina *= 1.5f;
    }
    public void SkillCarse()    // スキル18
    {
        HMng.MaxHP = 1;
        HMng.HP = HMng.MaxHP;

    }
    public void SkillHeep()     // スキル19
    {
        if (attackInp.action.WasPressedThisFrame())
        {

            if (isGround)
            {
                PlayerRb.velocity = new Vector2(0, 0);

            }

        }
        // ため攻撃の判定
        if (attack && isGround)
        {
            if(ChargeEffectPlayOnce == false)
            {
                EffectCharge.Play();
                audioSource.PlayOneShot(chargeSE);

                ChargeEffectPlayOnce = true;
            }

            attackCount += Time.deltaTime;
            isCharge = true;


        }
        if (attackEnd)
        {
            ChargeEffectPlayOnce = false;
            isCharge = false;
            EffectCharge.Stop();
            EffectCharge.Clear();

            if (attackCount >= playerData.Player[0].chargeAttackTime)
            {
                EffectChargeAttack.Play();

                chargeAttack = true;
                attackCount = 0;

            }
            else
            {
                normalAttack = true;
                attackCount = 0;

            }
        }
        else
        {
            normalAttack = false;
            chargeAttack = false;
            EffectChargeAttack.Stop();
        }

    }
}
