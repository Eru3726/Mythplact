using UnityEngine;
using UnityEngine.UI;

public class SkillPieceData : MonoBehaviour
{
    //private readonly AchvManager achv = new AchvManager();

    [SerializeField] GameObject Skill1;
    [SerializeField] GameObject Skill2;
    [SerializeField] GameObject Skill3;
    [SerializeField] GameObject Skill4;
    [SerializeField] GameObject Skill5;
    [SerializeField] GameObject Skill6;
    [SerializeField] GameObject Skill7;
    [SerializeField] GameObject Skill8;
    [SerializeField] GameObject Skill9;
    [SerializeField] GameObject Skill10;
    [SerializeField] GameObject Skill11;
    [SerializeField] GameObject Skill12;
    [SerializeField] GameObject Skill13;
    [SerializeField] GameObject Skill14;
    [SerializeField] GameObject Skill15;
    [SerializeField] GameObject Skill16;
    [SerializeField] GameObject Skill17;
    [SerializeField] GameObject Skill18;
    [SerializeField] GameObject Skill19;



    [SerializeField] Button Skill1_Button;
    [SerializeField] Button Skill2_Button;
    [SerializeField] Button Skill3_Button;
    [SerializeField] Button Skill4_Button;
    [SerializeField] Button Skill5_Button;
    [SerializeField] Button Skill6_Button;
    [SerializeField] Button Skill7_Button;
    [SerializeField] Button Skill8_Button;
    [SerializeField] Button Skill9_Button;
    [SerializeField] Button Skill10_Button;
    [SerializeField] Button Skill11_Button;
    [SerializeField] Button Skill12_Button;
    [SerializeField] Button Skill13_Button;
    [SerializeField] Button Skill14_Button;
    [SerializeField] Button Skill15_Button;
    [SerializeField] Button Skill16_Button;
    [SerializeField] Button Skill17_Button;
    [SerializeField] Button Skill18_Button;
    [SerializeField] Button Skill19_Button;




    public static GameObject skillPiece1; // アクティブスキルスラッシュ
    public static GameObject skillPiece2;
    public static GameObject skillPiece3;
    public static GameObject skillPiece4;
    public static GameObject skillPiece5;
    public static GameObject skillPiece6;
    public static GameObject skillPiece7;
    public static GameObject skillPiece8;
    public static GameObject skillPiece9;
    public static GameObject skillPiece10;
    public static GameObject skillPiece11;
    public static GameObject skillPiece12;
    public static GameObject skillPiece13;
    public static GameObject skillPiece14;
    public static GameObject skillPiece15;
    public static GameObject skillPiece16;
    public static GameObject skillPiece17;
    public static GameObject skillPiece18;
    public static GameObject skillPiece19;


    private void Start()
    {
        /*
        AllButtonClear();

        FirstSelectableSkill();

        AchvSkill();
        */
    }

    void AllButtonClear()
    {
        Skill1_Button.gameObject.SetActive(false);
        Skill2_Button.gameObject.SetActive(false);
        Skill3_Button.gameObject.SetActive(false);
        Skill4_Button.gameObject.SetActive(false);
        Skill5_Button.gameObject.SetActive(false);
        Skill10_Button.gameObject.SetActive(false);
        Skill11_Button.gameObject.SetActive(false);
        Skill12_Button.gameObject.SetActive(false);
        Skill13_Button.gameObject.SetActive(false);
        Skill14_Button.gameObject.SetActive(false);
        Skill15_Button.gameObject.SetActive(false);
        Skill16_Button.gameObject.SetActive(false);
        Skill17_Button.gameObject.SetActive(false);
        Skill18_Button.gameObject.SetActive(false);
        Skill19_Button.gameObject.SetActive(false);


    }
    void FirstSelectableSkill()
    {
        Skill1_Button.gameObject.SetActive(true);
        Skill13_Button.gameObject.SetActive(true);
        Skill17_Button.gameObject.SetActive(true);
        Skill19_Button.gameObject.SetActive(true);

    }
    void AchvSkill()
    {
        if (AchvManager.instance.timeAttack) Skill2_Button.gameObject.SetActive(true);
        if (AchvManager.instance.attackComboFlg) Skill3_Button.gameObject.SetActive(true);
        if (AchvManager.instance.sheriffUseFlg) Skill4_Button.gameObject.SetActive(true);
        if (AchvManager.instance.activeSkillOnlyFlg) Skill5_Button.gameObject.SetActive(true);
        if (AchvManager.instance.dieXFlg) Skill10_Button.gameObject.SetActive(true);
        if (AchvManager.instance.blinkXFlg) Skill11_Button.gameObject.SetActive(true);
        if (AchvManager.instance.guardCountFlg) Skill12_Button.gameObject.SetActive(true);
        if (AchvManager.instance.oneHpFlg) Skill14_Button.gameObject.SetActive(true);
        if (AchvManager.instance.noGuard) Skill15_Button.gameObject.SetActive(true);
        if (AchvManager.instance.justGuardFlg) Skill16_Button.gameObject.SetActive(true);
        if (AchvManager.instance.allBossFlg) Skill18_Button.gameObject.SetActive(true);
    }
    public void SaveSkillPiece()
    {
        if(skillPiece1 != null)
        {
            Debug.Log("skill1True");
            GameData.skillPiece1Pos = skillPiece1.transform.position;
            GameData.skillPiece1Deg = skillPiece1.transform.rotation;
            GameData.saveSkill1 = true;

            //Debug.Log("スキルピース1のPos" + GameData.skillPiece1Pos);
            //Debug.Log("スキルピース1のDeg" + GameData.skillPiece1Deg);

        }
        else
        {
            GameData.saveSkill1 = false;
        }
        if (skillPiece2 != null)
        {
            GameData.skillPiece2Pos = skillPiece2.transform.position;
            GameData.skillPiece2Deg = skillPiece2.transform.rotation;
            GameData.saveSkill2 = true;

            //Debug.Log("スキルピース2のPos" + GameData.skillPiece2Pos);
            //Debug.Log("スキルピース2のDeg" + GameData.skillPiece2Deg);


        }
        else
        {
            GameData.saveSkill2 = false;
        }
        if (skillPiece3 != null)
        {
            GameData.skillPiece3Pos = skillPiece3.transform.position;
            GameData.skillPiece3Deg = skillPiece3.transform.rotation;
            GameData.saveSkill3 = true;

            //Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
            //Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);


        }
        else
        {
            GameData.saveSkill3 = false;
        }
        if (skillPiece4 != null)
        {
            GameData.skillPiece4Pos = skillPiece4.transform.position;
            GameData.skillPiece4Deg = skillPiece4.transform.rotation;
            GameData.saveSkill4 = true;


        }
        else
        {
            GameData.saveSkill4 = false;
        }
        if (skillPiece5 != null)
        {
            GameData.skillPiece5Pos = skillPiece5.transform.position;
            GameData.skillPiece5Deg = skillPiece5.transform.rotation;
            GameData.saveSkill5 = true;


        }
        else
        {
            GameData.saveSkill5 = false;
        }

        if (skillPiece10 != null)
        {
            GameData.skillPiece10Pos = skillPiece10.transform.position;
            GameData.skillPiece10Deg = skillPiece10.transform.rotation;
            GameData.saveSkill10 = true;


        }
        else
        {
            GameData.saveSkill10 = false;
        }
        if (skillPiece11 != null)
        {
            GameData.skillPiece11Pos = skillPiece11.transform.position;
            GameData.skillPiece11Deg = skillPiece11.transform.rotation;
            GameData.saveSkill11 = true;


        }
        else
        {
            GameData.saveSkill11 = false;
        }
        if (skillPiece12 != null)
        {
            GameData.skillPiece12Pos = skillPiece12.transform.position;
            GameData.skillPiece12Deg = skillPiece12.transform.rotation;
            GameData.saveSkill12 = true;


        }
        else
        {
            GameData.saveSkill12 = false;
        }
        if (skillPiece13 != null)
        {
            GameData.skillPiece13Pos = skillPiece13.transform.position;
            GameData.skillPiece13Deg = skillPiece13.transform.rotation;
            GameData.saveSkill13 = true;


        }
        else
        {
            GameData.saveSkill13 = false;
        }
        if (skillPiece14 != null)
        {
            GameData.skillPiece14Pos = skillPiece14.transform.position;
            GameData.skillPiece14Deg = skillPiece14.transform.rotation;
            GameData.saveSkill14 = true;


        }
        else
        {
            GameData.saveSkill14 = false;
        }
        if (skillPiece15 != null)
        {
            GameData.skillPiece15Pos = skillPiece15.transform.position;
            GameData.skillPiece15Deg = skillPiece15.transform.rotation;
            GameData.saveSkill15 = true;


        }
        else
        {
            GameData.saveSkill15 = false;
        }
        if (skillPiece16 != null)
        {
            GameData.skillPiece16Pos = skillPiece16.transform.position;
            GameData.skillPiece16Deg = skillPiece16.transform.rotation;
            GameData.saveSkill16 = true;


        }
        else
        {
            GameData.saveSkill16 = false;
        }
        if (skillPiece17 != null)
        {
            GameData.skillPiece17Pos = skillPiece17.transform.position;
            GameData.skillPiece17Deg = skillPiece17.transform.rotation;
            GameData.saveSkill17 = true;


        }
        else
        {
            GameData.saveSkill17 = false;
        }
        if (skillPiece18 != null)
        {
            GameData.skillPiece18Pos = skillPiece18.transform.position;
            GameData.skillPiece18Deg = skillPiece18.transform.rotation;
            GameData.saveSkill18 = true;


        }
        else
        {
            GameData.saveSkill18 = false;
        }
        if (skillPiece19 != null)
        {
            GameData.skillPiece19Pos = skillPiece19.transform.position;
            GameData.skillPiece19Deg = skillPiece19.transform.rotation;
            GameData.saveSkill19 = true;


        }
        else
        {
            GameData.saveSkill19 = false;
        }






    }

    public void ReadSkillPiece()
    {
        if (skillPiece1 != null)
        {
            Debug.Log("active"+GameData.saveSkill1);
            if (GameData.saveSkill1)
            {
                skillPiece1.transform.position = GameData.skillPiece1Pos;
                skillPiece1.transform.rotation = GameData.skillPiece1Deg;
                Debug.Log("スキルピース1のPos" + GameData.skillPiece1Pos);
                Debug.Log("スキルピース1のDeg" + GameData.skillPiece1Deg);
            }
            else
            {
                Destroy(skillPiece1);
                GameData.setSkill1 = false;
                Skill1_Button.interactable = true;
                Debug.Log("Destroy1");
            }
        }
        else
        {
            Debug.Log("null"+GameData.saveSkill1);
            if (GameData.saveSkill1)
            {
                Instantiate(Skill1);
                skillPiece1 = GameObject.Find("SkillPiece1(Clone)");
                skillPiece1.transform.position = GameData.skillPiece1Pos;
                skillPiece1.transform.rotation = GameData.skillPiece1Deg;

                GameData.setSkill1 = true;
                Skill1_Button.interactable = false;

                Debug.Log("スキルピース1のPos" + GameData.skillPiece1Pos);
                Debug.Log("スキルピース1のDeg" + GameData.skillPiece1Deg);

                GameData.saveSkill1 = false;

            }
            else
            {
                Destroy(skillPiece1);
                GameData.setSkill1 = false;
                Skill1_Button.interactable = true;
                Debug.Log("Destroy1nullnotoki");

            }

        }

        if (skillPiece2 != null)
        {
            if (GameData.saveSkill2)
            {
                skillPiece2.transform.position = GameData.skillPiece2Pos;
                skillPiece2.transform.rotation = GameData.skillPiece2Deg;
                Debug.Log("スキルピース2のPos" + GameData.skillPiece2Pos);
                Debug.Log("スキルピース2のDeg" + GameData.skillPiece2Deg);


            }
            else
            {
                Destroy(skillPiece2);
                GameData.setSkill2 = false;
                Skill2_Button.interactable = true;

            }
        }
        else if(GameData.saveSkill2)
        {
            if (GameData.saveSkill2)
            {
                Instantiate(Skill2);
                skillPiece2 = GameObject.Find("SkillPiece2(Clone)");

                skillPiece2.transform.position = GameData.skillPiece2Pos;
                skillPiece2.transform.rotation = GameData.skillPiece2Deg;

                GameData.setSkill2 = true;
                Skill2_Button.interactable = false;


                Debug.Log("スキルピース2のPos" + GameData.skillPiece2Pos);
                Debug.Log("スキルピース2のDeg" + GameData.skillPiece2Deg);

                GameData.saveSkill2 = false;

            }
            else
            {
                Destroy(skillPiece2);
                GameData.setSkill2 = false;
                Skill2_Button.interactable = true;

            }

        }


        if (skillPiece3 != null)
        {
            if (GameData.saveSkill3)
            {
                skillPiece3.transform.position = GameData.skillPiece3Pos;
                skillPiece3.transform.rotation = GameData.skillPiece3Deg;
                Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
                Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);

            }
            else
            {
                Destroy(skillPiece3);
                GameData.setSkill3 = false;
                Skill3_Button.interactable = true;

            }

        }
        else if (GameData.saveSkill3)
        {
            if (GameData.saveSkill3)
            {
                Instantiate(Skill3);
                skillPiece3 = GameObject.Find("SkillPiece3(Clone)");

                skillPiece3.transform.position = GameData.skillPiece3Pos;
                skillPiece3.transform.rotation = GameData.skillPiece3Deg;

                GameData.setSkill3 = true;
                Skill3_Button.interactable = false;

                Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
                Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);

                GameData.saveSkill3 = false;

            }
            else
            {
                Destroy(skillPiece3);
                GameData.setSkill3 = false;
                Skill3_Button.interactable = true;

            }
        }

        if (skillPiece4 != null)
        {
            if (GameData.saveSkill4)
            {
                skillPiece4.transform.position = GameData.skillPiece4Pos;
                skillPiece4.transform.rotation = GameData.skillPiece4Deg;

            }
            else
            {
                Destroy(skillPiece4);
                GameData.setSkill4 = false;
                Skill4_Button.interactable = true;

            }
        }
        else 
        {
            if (GameData.saveSkill4)
            {
                Instantiate(Skill4);
                skillPiece4 = GameObject.Find("SkillPiece4(Clone)");
                skillPiece4.transform.position = GameData.skillPiece4Pos;
                skillPiece4.transform.rotation = GameData.skillPiece4Deg;

                GameData.setSkill4 = true;
                Skill4_Button.interactable = false;


                GameData.saveSkill4 = false;

            }
            else
            {
                Destroy(skillPiece4);
                GameData.setSkill4 = false;
                Skill4_Button.interactable = true;

            }
        }
        if (skillPiece5 != null)
        {
            if (GameData.saveSkill5)
            {
                skillPiece5.transform.position = GameData.skillPiece5Pos;
                skillPiece5.transform.rotation = GameData.skillPiece5Deg;

            }
            else
            {
                Destroy(skillPiece5);
                GameData.setSkill5 = false;
                Skill5_Button.interactable = true;

            }
        }

        else if (GameData.saveSkill5)
        {
            if (GameData.saveSkill5)
            {
                Instantiate(Skill5);
                skillPiece5 = GameObject.Find("SkillPiece5(Clone)");
                skillPiece5.transform.position = GameData.skillPiece5Pos;
                skillPiece5.transform.rotation = GameData.skillPiece5Deg;

                GameData.setSkill5 = true;
                Skill5_Button.interactable = false;


                GameData.saveSkill5 = false;

            }
            else
            {
                Destroy(skillPiece5);
                GameData.setSkill5 = false;
                Skill5_Button.interactable = true;

            }
        }


        if (skillPiece10 != null)
        {
            if (GameData.saveSkill10)
            {
                skillPiece10.transform.position = GameData.skillPiece10Pos;
                skillPiece10.transform.rotation = GameData.skillPiece10Deg;

            }
            else
            {
                Destroy(skillPiece10);
                GameData.setSkill10 = false;
                Skill10_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill10)
            {
                Instantiate(Skill10);
                skillPiece10 = GameObject.Find("SkillPiece10(Clone)");
                skillPiece10.transform.position = GameData.skillPiece10Pos;
                skillPiece10.transform.rotation = GameData.skillPiece10Deg;

                GameData.setSkill10 = true;
                Skill10_Button.interactable = false;


                GameData.saveSkill10 = false;

            }
            else
            {
                Destroy(skillPiece10);
                GameData.setSkill10 = false;
                Skill10_Button.interactable = true;


            }
        }

        if (skillPiece11 != null)
        {
            if (GameData.saveSkill11)
            {
                skillPiece11.transform.position = GameData.skillPiece11Pos;
                skillPiece11.transform.rotation = GameData.skillPiece11Deg;

            }
            else
            {
                Destroy(skillPiece11);
                GameData.setSkill11 = false;
                Skill11_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill11)
            {
                Instantiate(Skill11);
                skillPiece11 = GameObject.Find("SkillPiece11(Clone)");
                skillPiece11.transform.position = GameData.skillPiece11Pos;
                skillPiece11.transform.rotation = GameData.skillPiece11Deg;

                GameData.setSkill11 = true;
                Skill11_Button.interactable = false;


                GameData.saveSkill11 = false;

            }
            else
            {
                Destroy(skillPiece11);
                GameData.setSkill11 = false;
                Skill11_Button.interactable = true;


            }
        }

        if (skillPiece12 != null)
        {
            if (GameData.saveSkill12)
            {
                skillPiece12.transform.position = GameData.skillPiece12Pos;
                skillPiece12.transform.rotation = GameData.skillPiece12Deg;

            }
            else
            {
                Destroy(skillPiece12);
                GameData.setSkill12 = false;
                Skill12_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill12)
            {
                Instantiate(Skill12);
                skillPiece12 = GameObject.Find("SkillPiece12(Clone)");
                skillPiece12.transform.position = GameData.skillPiece12Pos;
                skillPiece12.transform.rotation = GameData.skillPiece12Deg;

                GameData.setSkill12 = true;
                Skill12_Button.interactable = false;


                GameData.saveSkill12 = false;

            }
            else
            {
                Destroy(skillPiece12);
                GameData.setSkill12 = false;
                Skill12_Button.interactable = true;


            }
        }

        if (skillPiece13 != null)
        {
            if (GameData.saveSkill13)
            {
                skillPiece13.transform.position = GameData.skillPiece13Pos;
                skillPiece13.transform.rotation = GameData.skillPiece13Deg;

            }
            else
            {
                Destroy(skillPiece13);
                GameData.setSkill13 = false;
                Skill13_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill13)
            {
                Instantiate(Skill13);
                skillPiece13 = GameObject.Find("SkillPiece13(Clone)");
                skillPiece13.transform.position = GameData.skillPiece13Pos;
                skillPiece13.transform.rotation = GameData.skillPiece13Deg;

                GameData.setSkill13 = true;
                Skill13_Button.interactable = false;


                GameData.saveSkill13 = false;

            }
            else
            {
                Destroy(skillPiece13);
                GameData.setSkill13 = false;
                Skill13_Button.interactable = true;

            }
        }

        if (skillPiece14 != null)
        {
            if (GameData.saveSkill14)
            {
                skillPiece14.transform.position = GameData.skillPiece14Pos;
                skillPiece14.transform.rotation = GameData.skillPiece14Deg;

            }
            else
            {
                Destroy(skillPiece14);
                GameData.setSkill14 = false;
                Skill14_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill14)
            {
                Instantiate(Skill14);
                skillPiece14 = GameObject.Find("SkillPiece14(Clone)");
                skillPiece14.transform.position = GameData.skillPiece14Pos;
                skillPiece14.transform.rotation = GameData.skillPiece14Deg;

                GameData.setSkill14 = true;
                Skill14_Button.interactable = false;


                GameData.saveSkill14 = false;

            }
            else
            {
                Destroy(skillPiece14);
                GameData.setSkill14 = false;
                Skill14_Button.interactable = true;


            }
        }
        if (skillPiece15 != null)
        {
            if (GameData.saveSkill15)
            {
                skillPiece15.transform.position = GameData.skillPiece15Pos;
                skillPiece15.transform.rotation = GameData.skillPiece15Deg;

            }
            else
            {
                Destroy(skillPiece15);
                GameData.setSkill15 = false;
                Skill15_Button.interactable = true;

            }
        }

        else
        {
            if (GameData.saveSkill15)
            {
                Instantiate(Skill15);
                skillPiece15 = GameObject.Find("SkillPiece15(Clone)");
                skillPiece15.transform.position = GameData.skillPiece15Pos;
                skillPiece15.transform.rotation = GameData.skillPiece15Deg;

                GameData.setSkill15 = true;
                Skill15_Button.interactable = false;


                GameData.saveSkill15 = false;

            }
            else
            {
                Destroy(skillPiece15);
                GameData.setSkill15 = false;
                Skill15_Button.interactable = true;

            }
        }

        if (skillPiece16 != null)
        {
            if (GameData.saveSkill16)
            {
                skillPiece16.transform.position = GameData.skillPiece16Pos;
                skillPiece16.transform.rotation = GameData.skillPiece16Deg;

            }
            else
            {
                Destroy(skillPiece16);
                GameData.setSkill16 = false;
                Skill16_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill16)
            {
                Instantiate(Skill16);
                skillPiece16 = GameObject.Find("SkillPiece16(Clone)");
                skillPiece16.transform.position = GameData.skillPiece16Pos;
                skillPiece16.transform.rotation = GameData.skillPiece16Deg;

                GameData.setSkill16 = true;
                Skill16_Button.interactable = false;


                GameData.saveSkill16 = false;

            }
            else
            {
                Destroy(skillPiece16);
                GameData.setSkill16 = false;
                Skill16_Button.interactable = true;


            }
        }
        if (skillPiece17 != null)
        {
            if (GameData.saveSkill17)
            {
                skillPiece17.transform.position = GameData.skillPiece17Pos;
                skillPiece17.transform.rotation = GameData.skillPiece17Deg;

            }
            else
            {
                Destroy(skillPiece17);
                GameData.setSkill17 = false;
                Skill17_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill17)
            {
                Instantiate(Skill17);
                skillPiece17 = GameObject.Find("SkillPiece17(Clone)");
                skillPiece17.transform.position = GameData.skillPiece17Pos;
                skillPiece17.transform.rotation = GameData.skillPiece17Deg;

                GameData.setSkill17 = true;
                Skill17_Button.interactable = false;


                GameData.saveSkill17 = false;

            }
            else
            {
                Destroy(skillPiece17);
                GameData.setSkill17 = false;
                Skill17_Button.interactable = true;

            }
        }

        if (skillPiece18 != null)
        {
            if (GameData.saveSkill18)
            {
                skillPiece18.transform.position = GameData.skillPiece18Pos;
                skillPiece18.transform.rotation = GameData.skillPiece18Deg;

            }
            else
            {
                Destroy(skillPiece18);
                GameData.setSkill18 = false;
                Skill18_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill18)
            {
                Instantiate(Skill18);
                skillPiece18 = GameObject.Find("SkillPiece18(Clone)");
                skillPiece18.transform.position = GameData.skillPiece18Pos;
                skillPiece18.transform.rotation = GameData.skillPiece18Deg;

                GameData.setSkill18 = true;
                Skill18_Button.interactable = false;


                GameData.saveSkill18 = false;

            }
            else
            {
                Destroy(skillPiece18);
                GameData.setSkill18 = false;
                Skill18_Button.interactable = true;

            }
        }

        if (skillPiece19 != null)
        {
            if (GameData.saveSkill19)
            {
                skillPiece19.transform.position = GameData.skillPiece19Pos;
                skillPiece19.transform.rotation = GameData.skillPiece19Deg;

            }
            else
            {
                Destroy(skillPiece19);
                GameData.setSkill19 = false;
                Skill19_Button.interactable = true;

            }
        }
        else
        {
            if (GameData.saveSkill19)
            {
                Instantiate(Skill19);
                skillPiece19 = GameObject.Find("SkillPiece19(Clone)");
                skillPiece19.transform.position = GameData.skillPiece19Pos;
                skillPiece19.transform.rotation = GameData.skillPiece19Deg;

                GameData.setSkill19 = true;
                Skill19_Button.interactable = false;


                GameData.saveSkill19 = false;

            }
            else
            {
                Destroy(skillPiece19);
                GameData.setSkill19 = false;
                Skill19_Button.interactable = true;

            }
        }

    }


}
