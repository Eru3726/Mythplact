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




    public static GameObject skillPiece1; // �A�N�e�B�u�X�L���X���b�V��
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


            //Debug.Log("�X�L���s�[�X1��Pos" + GameData.skillPiece1Pos);
            //Debug.Log("�X�L���s�[�X1��Deg" + GameData.skillPiece1Deg);

        }
        if (skillPiece2 != null)
        {
            GameData.skillPiece2Pos = skillPiece2.transform.position;
            GameData.skillPiece2Deg = skillPiece2.transform.rotation;
            GameData.saveSkill2 = true;

            //Debug.Log("�X�L���s�[�X2��Pos" + GameData.skillPiece2Pos);
            //Debug.Log("�X�L���s�[�X2��Deg" + GameData.skillPiece2Deg);


        }
        if (skillPiece3 != null)
        {
            GameData.skillPiece3Pos = skillPiece3.transform.position;
            GameData.skillPiece3Deg = skillPiece3.transform.rotation;
            GameData.saveSkill3 = true;

            //Debug.Log("�X�L���s�[�X3��Pos" + GameData.skillPiece3Pos);
            //Debug.Log("�X�L���s�[�X3��Deg" + GameData.skillPiece3Deg);


        }

        if (skillPiece10 != null)
        {
            GameData.skillPiece10Pos = skillPiece10.transform.position;
            GameData.skillPiece10Deg = skillPiece10.transform.rotation;
            GameData.saveSkill10 = true;


        }
        if (skillPiece11 != null)
        {
            GameData.skillPiece11Pos = skillPiece11.transform.position;
            GameData.skillPiece11Deg = skillPiece11.transform.rotation;
            GameData.saveSkill11 = true;


        }
        if (skillPiece12 != null)
        {
            GameData.skillPiece12Pos = skillPiece12.transform.position;
            GameData.skillPiece12Deg = skillPiece12.transform.rotation;
            GameData.saveSkill12 = true;


        }
        if (skillPiece13 != null)
        {
            GameData.skillPiece13Pos = skillPiece13.transform.position;
            GameData.skillPiece13Deg = skillPiece13.transform.rotation;
            GameData.saveSkill13 = true;


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
                Debug.Log("�X�L���s�[�X1��Pos" + GameData.skillPiece1Pos);
                Debug.Log("�X�L���s�[�X1��Deg" + GameData.skillPiece1Deg);

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

            Debug.Log("�X�L���s�[�X1��Pos" + GameData.skillPiece1Pos);
            Debug.Log("�X�L���s�[�X1��Deg" + GameData.skillPiece1Deg);

            GameData.saveSkill1 = false;

        }

        if (skillPiece2 != null)
        {
            if (GameData.saveSkill2)
            {
                skillPiece2.transform.position = GameData.skillPiece2Pos;
                skillPiece2.transform.rotation = GameData.skillPiece2Deg;
                Debug.Log("�X�L���s�[�X2��Pos" + GameData.skillPiece2Pos);
                Debug.Log("�X�L���s�[�X2��Deg" + GameData.skillPiece2Deg);


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


            Debug.Log("�X�L���s�[�X2��Pos" + GameData.skillPiece2Pos);
            Debug.Log("�X�L���s�[�X2��Deg" + GameData.skillPiece2Deg);

            GameData.saveSkill2 = false;

        }


        if (skillPiece3 != null)
        {
            if (GameData.saveSkill3)
            {
                skillPiece3.transform.position = GameData.skillPiece3Pos;
                skillPiece3.transform.rotation = GameData.skillPiece3Deg;
                Debug.Log("�X�L���s�[�X3��Pos" + GameData.skillPiece3Pos);
                Debug.Log("�X�L���s�[�X3��Deg" + GameData.skillPiece3Deg);

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

            Debug.Log("�X�L���s�[�X3��Pos" + GameData.skillPiece3Pos);
            Debug.Log("�X�L���s�[�X3��Deg" + GameData.skillPiece3Deg);

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
        else if (GameData.saveSkill11)
        {
            Instantiate(Skill11);
            skillPiece11 = GameObject.Find("SkillPiece11(Clone)");
            skillPiece11.transform.position = GameData.skillPiece11Pos;
            skillPiece11.transform.rotation = GameData.skillPiece11Deg;

            GameData.setSkill11 = true;
            Skill11_Button.interactable = false;


            GameData.saveSkill11 = false;

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
        else if (GameData.saveSkill12)
        {
            Instantiate(Skill12);
            skillPiece12 = GameObject.Find("SkillPiece12(Clone)");
            skillPiece12.transform.position = GameData.skillPiece12Pos;
            skillPiece12.transform.rotation = GameData.skillPiece12Deg;

            GameData.setSkill12 = true;
            Skill12_Button.interactable = false;


            GameData.saveSkill12 = false;

        }

        if (skillPiece13 != null)
        {
            if (GameData.saveSkill12)
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
        else if (GameData.saveSkill13)
        {
            Instantiate(Skill13);
            skillPiece13 = GameObject.Find("SkillPiece13(Clone)");
            skillPiece13.transform.position = GameData.skillPiece13Pos;
            skillPiece13.transform.rotation = GameData.skillPiece13Deg;

            GameData.setSkill13 = true;
            Skill13_Button.interactable = false;


            GameData.saveSkill13 = false;

        }

    }


}
