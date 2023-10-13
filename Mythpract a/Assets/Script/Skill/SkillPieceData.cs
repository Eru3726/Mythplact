using UnityEngine;
using UnityEngine.UI;

public class SkillPieceData : MonoBehaviour
{
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



    private void Update()
    {


    }
    public void SaveSkillPiece()
    {
        if(skillPiece1 != null)
        {
            GameData.skillPiece1Pos = skillPiece1.transform.position;
            GameData.skillPiece1Deg = skillPiece1.transform.rotation;
            GameData.saveSkill1 = true;


            //Debug.Log("スキルピース1のPos" + GameData.skillPiece1Pos);
            //Debug.Log("スキルピース1のDeg" + GameData.skillPiece1Deg);

        }
        if (skillPiece2 != null)
        {
            GameData.skillPiece2Pos = skillPiece2.transform.position;
            GameData.skillPiece2Deg = skillPiece2.transform.rotation;
            GameData.saveSkill2 = true;

            //Debug.Log("スキルピース2のPos" + GameData.skillPiece2Pos);
            //Debug.Log("スキルピース2のDeg" + GameData.skillPiece2Deg);


        }
        if (skillPiece3 != null)
        {
            GameData.skillPiece3Pos = skillPiece3.transform.position;
            GameData.skillPiece3Deg = skillPiece3.transform.rotation;
            GameData.saveSkill3 = true;

            //Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
            //Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);


        }

        if (skillPiece10 != null)
        {
            GameData.skillPiece10Pos = skillPiece10.transform.position;
            GameData.skillPiece10Deg = skillPiece10.transform.rotation;
            GameData.saveSkill10 = true;


        }



    }

    public void ReadSkillPiece()
    {
        if (skillPiece1 != null)
        {
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

            }
        }
        else if(GameData.saveSkill1)
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
        else if (GameData.saveSkill10)
        {
            Instantiate(Skill10);
            skillPiece10 = GameObject.Find("SkillPiece10(Clone)");
            skillPiece10.transform.position = GameData.skillPiece10Pos;
            skillPiece10.transform.rotation = GameData.skillPiece10Deg;

            GameData.setSkill10 = true;
            Skill10_Button.interactable = false;


            GameData.saveSkill10 = false;

        }



    }


}
