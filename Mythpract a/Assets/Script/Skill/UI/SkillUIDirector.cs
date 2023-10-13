using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIDirector : MonoBehaviour
{
    [SerializeField] GameObject SkillSlots;
    [SerializeField] GameObject ActiveSkill;
    [SerializeField] GameObject PassiveSkill;
    [SerializeField] Button slotFirstSelect;
    [SerializeField] Button activeFirstSelect;
    [SerializeField] Button passiveFirstSelect;

    [SerializeField] Button SkillSlot1_Button;
    [SerializeField] Button SkillSlot2_Button;
    [SerializeField] Button SkillSlot3_Button;
    [SerializeField] Button SkillSlot4_Button;
    Controllerconnect conconect;
    SkillSetDirector skillSetDirector;

    public static bool setSlot1 = false;
    public static bool setSlot2 = false;
    public static bool setSlot3 = false;
    public static bool setSlot4 = false;
    void Start()
    {
        SkillSlots.SetActive(true);
        ActiveSkill.SetActive(false);
        PassiveSkill.SetActive(false);

        slotFirstSelect.Select();

        conconect = GameObject.Find("keycon").GetComponent<Controllerconnect>();
        skillSetDirector = GameObject.Find("SkillSetDirector").GetComponent<SkillSetDirector>();




    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveSkill.activeSelf == true || PassiveSkill.activeSelf == true)
        {
            if(conconect.ConConnect == true)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    SkillSlots.SetActive(true);
                    ActiveSkill.SetActive(false);
                    PassiveSkill.SetActive(false);

                    slotFirstSelect.Select();

                    setSlot1 = false;
                    setSlot2 = false;
                    setSlot3 = false;
                    setSlot4 = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SkillSlots.SetActive(true);
                    ActiveSkill.SetActive(false);
                    PassiveSkill.SetActive(false);

                    slotFirstSelect.Select();


                    setSlot1 = false;
                    setSlot2 = false;
                    setSlot3 = false;
                    setSlot4 = false;

                }

            }
        }
        else
        {
            if (GameData.skillSlot1 != 0) SkillSlot1_Button.interactable = false;
            else SkillSlot1_Button.interactable = true;
            if (GameData.skillSlot2 != 0) SkillSlot2_Button.interactable = false;
            else SkillSlot2_Button.interactable = true;
            if (GameData.skillSlot3 != 0) SkillSlot3_Button.interactable = false;
            else SkillSlot3_Button.interactable = true;
            if (GameData.skillSlot4 != 0) SkillSlot4_Button.interactable = false;
            else SkillSlot4_Button.interactable = true;

        }


    }

    public void SetSlot1()
    {
        SkillSlots.SetActive(false);
        ActiveSkill.SetActive(true);
        PassiveSkill.SetActive(false);

        activeFirstSelect.Select();

        setSlot1 = true;

    }
    public void SetSlot2()
    {
        SkillSlots.SetActive(false);
        ActiveSkill.SetActive(true);
        PassiveSkill.SetActive(false);

        activeFirstSelect.Select();

        setSlot2 = true;

    }
    public void SetSlot3()
    {
        SkillSlots.SetActive(false);
        ActiveSkill.SetActive(true);
        PassiveSkill.SetActive(false);

        activeFirstSelect.Select();

        setSlot3 = true;

    }
    public void SetSlot4()
    {
        SkillSlots.SetActive(false);
        ActiveSkill.SetActive(true);
        PassiveSkill.SetActive(false);

        activeFirstSelect.Select();

        setSlot4 = true;

    }
    public void SetPassive()
    {
        SkillSlots.SetActive(false);
        ActiveSkill.SetActive(false);
        PassiveSkill.SetActive(true);

        passiveFirstSelect.Select();
    }



}
