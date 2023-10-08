using UnityEngine;
using UnityEngine.UI;

public class SkillPieceData : MonoBehaviour
{
    [SerializeField] GameObject skill1;
    [SerializeField] GameObject skill2;
    [SerializeField] GameObject skill3;

    [SerializeField] Button Skill1_Button;
    [SerializeField] Button Skill2_Button;
    [SerializeField] Button Skill3_Button;



    public static GameObject skillPiece1;
    public static GameObject skillPiece2;
    public static GameObject skillPiece3;


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
            Debug.Log("スキルピース1のPos" + GameData.skillPiece1Pos);
            Debug.Log("スキルピース1のDeg" + GameData.skillPiece1Deg);

        }
        if (skillPiece2 != null)
        {
            GameData.skillPiece2Pos = skillPiece2.transform.position;
            GameData.skillPiece2Deg = skillPiece2.transform.rotation;
            GameData.saveSkill2 = true;

            Debug.Log("スキルピース2のPos" + GameData.skillPiece2Pos);
            Debug.Log("スキルピース2のDeg" + GameData.skillPiece2Deg);


        }
        if (skillPiece3 != null)
        {
            GameData.skillPiece3Pos = skillPiece3.transform.position;
            GameData.skillPiece3Deg = skillPiece3.transform.rotation;
            GameData.saveSkill3 = true;

            Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
            Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);


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
                SkillSetDirector.setSkill1 = false;
                Skill1_Button.interactable = true;

            }
        }
        else if(GameData.saveSkill1)
        {
            Instantiate(skill1);
            skillPiece1 = GameObject.Find("SkillPiece1(Clone)");
            skillPiece1.transform.position = GameData.skillPiece1Pos;
            skillPiece1.transform.rotation = GameData.skillPiece1Deg;

            SkillSetDirector.setSkill1 = true;
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
                SkillSetDirector.setSkill2 = false;
                Skill2_Button.interactable = true;

            }
        }
        else if(GameData.saveSkill2)
        {
            Instantiate(skill2);
            skillPiece2 = GameObject.Find("SkillPiece2(Clone)");

            skillPiece2.transform.position = GameData.skillPiece2Pos;
            skillPiece2.transform.rotation = GameData.skillPiece2Deg;

            SkillSetDirector.setSkill2 = true;
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
                SkillSetDirector.setSkill3 = false;
                Skill3_Button.interactable = true;

            }

        }
        else if (GameData.saveSkill3)
        {
            Instantiate(skill3);
            skillPiece3 = GameObject.Find("SkillPiece3(Clone)");

            skillPiece3.transform.position = GameData.skillPiece3Pos;
            skillPiece3.transform.rotation = GameData.skillPiece3Deg;

            SkillSetDirector.setSkill3 = true;
            Skill3_Button.interactable = false;

            Debug.Log("スキルピース3のPos" + GameData.skillPiece3Pos);
            Debug.Log("スキルピース3のDeg" + GameData.skillPiece3Deg);

            GameData.saveSkill3 = false;
        }






    }


}
