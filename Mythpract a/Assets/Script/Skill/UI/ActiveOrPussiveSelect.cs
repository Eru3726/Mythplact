using UnityEngine;
using UnityEngine.UI;

public class ActiveOrPussiveSelect : MonoBehaviour
{
    public GameObject ActiveSkillButtonEnable;
    public GameObject ActiveSkillButtonDisable;
    public GameObject PassiveSkillButtonEnable;
    public GameObject PassiveSkillButtonDisable;


    public GameObject ActiveSkill;
    public GameObject PassiveSkill;

    void Start()
    {
        ActiveSkill.SetActive(true);
        ActiveSkillButtonEnable.SetActive(true);
        ActiveSkillButtonDisable.SetActive(false);
        PassiveSkill.SetActive(false);
        PassiveSkillButtonEnable.SetActive(false);
        PassiveSkillButtonDisable.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectActiveSkill()
    {
        ActiveSkill.SetActive(true);
        ActiveSkillButtonEnable.SetActive(true);
        ActiveSkillButtonDisable.SetActive(false);
        PassiveSkill.SetActive(false);
        PassiveSkillButtonEnable.SetActive(false);
        PassiveSkillButtonDisable.SetActive(true);

        Button activeButton = ActiveSkillButtonEnable.GetComponent<Button>();
        activeButton.Select();

    }
    public void SelectPassiveSkill()
    {
        ActiveSkill.SetActive(false);
        ActiveSkillButtonEnable.SetActive(false);
        ActiveSkillButtonDisable.SetActive(true);
        PassiveSkill.SetActive(true);
        PassiveSkillButtonEnable.SetActive(true);
        PassiveSkillButtonDisable.SetActive(false);

        Button passiveButton = PassiveSkillButtonEnable.GetComponent<Button>();
        passiveButton.Select();

    }

}
