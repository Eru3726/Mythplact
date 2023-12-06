using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIDirector : MonoBehaviour
{


    [SerializeField] GameObject SkillSlots;
    [SerializeField] GameObject ActiveSkill;
    [SerializeField] GameObject PassiveSkill;
    [SerializeField] Scrollbar ActiveSkillScroll;
    [SerializeField] Scrollbar PassiveSkillScroll;
    [SerializeField] Button slotFirstSelect;
    [SerializeField] Button activeFirstSelect;
    [SerializeField] Button passiveFirstSelect;

    [SerializeField] Button SkillSlot1_Button;
    [SerializeField] Button SkillSlot2_Button;
    [SerializeField] Button SkillSlot3_Button;
    [SerializeField] Button SkillSlot4_Button;

    [SerializeField] Image SkillSlot1_Image;
    [SerializeField] Image SkillSlot2_Image;
    [SerializeField] Image SkillSlot3_Image;
    [SerializeField] Image SkillSlot4_Image;

    [SerializeField] Sprite ACSkill1;
    [SerializeField] Sprite ACSkill2;
    [SerializeField] Sprite ACSkill3;
    [SerializeField] Sprite ACSkill4;
    [SerializeField] Sprite ACSkill5;

    Controllerconnect conconect;
    SkillSetDirector skillSetDirector;

    public static bool setSlot1 = false;
    public static bool setSlot2 = false;
    public static bool setSlot3 = false;
    public static bool setSlot4 = false;

    bool scrollreset = false;
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
                float rsv = Input.GetAxis("R_stick_V");        //右スティック縦

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
                if(ActiveSkill.activeSelf == true)
                {
                    if (rsv > 0)
                    {
                        ActiveSkillScroll.value += 0.1f;
                    }
                    else if (rsv < 0)
                    {
                        ActiveSkillScroll.value -= 0.1f;

                    }

                }
                else if(PassiveSkill.activeSelf == true)
                {
                    if (rsv > 0)
                    {
                        PassiveSkillScroll.value += 0.1f;
                    }
                    else if (rsv < 0)
                    {
                        PassiveSkillScroll.value -= 0.1f;

                    }

                }
            }
            else
            {
                float mousewheel = Input.GetAxis("Mouse ScrollWheel");
                if (Input.GetKeyDown(KeyCode.Escape) && skillSetDirector.useCursorProp == false)
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
                if (ActiveSkill.activeSelf == true)
                {
                    ActiveSkillScroll.value += mousewheel;

                }
                else if (PassiveSkill.activeSelf == true)
                {
                    PassiveSkillScroll.value += mousewheel;

                }


            }

            if (!scrollreset)
            {
                ActiveSkillScroll.value = 1;
                PassiveSkillScroll.value = 1;
                scrollreset = true;
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

            scrollreset = false;
        }



        if(GameData.skillSlot1 == 1)
        {
            SkillSlot1_Image.sprite = ACSkill1;
        }
        else if(GameData.skillSlot1 == 2)
        {
            SkillSlot1_Image.sprite = ACSkill2;

        }
        else if (GameData.skillSlot1 == 3)
        {
            SkillSlot1_Image.sprite = ACSkill3;

        }
        else if (GameData.skillSlot1 == 4)
        {
            SkillSlot1_Image.sprite = ACSkill4;

        }
        else if (GameData.skillSlot1 == 5)
        {
            SkillSlot1_Image.sprite = ACSkill5;

        }
        if(GameData.skillSlot1 == 0)
        {
            SkillSlot1_Image.enabled = false;
        }
        else
        {
            SkillSlot1_Image.enabled = true;

        }

        if (GameData.skillSlot2 == 1)
        {
            SkillSlot2_Image.sprite = ACSkill1;
        }
        else if (GameData.skillSlot2 == 2)
        {
            SkillSlot2_Image.sprite = ACSkill2;

        }
        else if (GameData.skillSlot2 == 3)
        {
            SkillSlot2_Image.sprite = ACSkill3;

        }
        else if (GameData.skillSlot2 == 4)
        {
            SkillSlot2_Image.sprite = ACSkill4;

        }
        else if (GameData.skillSlot2 == 5)
        {
            SkillSlot2_Image.sprite = ACSkill5;

        }
        if (GameData.skillSlot2 == 0)
        {
            SkillSlot2_Image.enabled = false;
        }
        else
        {
            SkillSlot2_Image.enabled = true;

        }

        if (GameData.skillSlot3 == 1)
        {
            SkillSlot3_Image.sprite = ACSkill1;
        }
        else if (GameData.skillSlot3 == 2)
        {
            SkillSlot3_Image.sprite = ACSkill2;

        }
        else if (GameData.skillSlot3 == 3)
        {
            SkillSlot3_Image.sprite = ACSkill3;

        }
        else if (GameData.skillSlot3 == 4)
        {
            SkillSlot3_Image.sprite = ACSkill4;

        }
        else if (GameData.skillSlot3 == 5)
        {
            SkillSlot3_Image.sprite = ACSkill5;

        }
        if (GameData.skillSlot3 == 0)
        {
            SkillSlot3_Image.enabled = false;
        }
        else
        {
            SkillSlot3_Image.enabled = true;

        }

        if (GameData.skillSlot4 == 1)
        {
            SkillSlot4_Image.sprite = ACSkill1;
        }
        else if (GameData.skillSlot4 == 2)
        {
            SkillSlot4_Image.sprite = ACSkill2;

        }
        else if (GameData.skillSlot4 == 3)
        {
            SkillSlot4_Image.sprite = ACSkill3;

        }
        else if (GameData.skillSlot4 == 4)
        {
            SkillSlot4_Image.sprite = ACSkill4;

        }
        else if (GameData.skillSlot4 == 5)
        {
            SkillSlot4_Image.sprite = ACSkill5;

        }
        if (GameData.skillSlot4 == 0)
        {
            SkillSlot4_Image.enabled = false;
        }
        else
        {
            SkillSlot4_Image.enabled = true;

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

    public void Skill1Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill2Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill3Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill4Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill5Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill6Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill7Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill8Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill9Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill10Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill11Select()
    {
        ActiveSkillScroll.value = 1;
    }

    public void Skill12Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill13Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill14Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill15Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill16Select()
    {
        ActiveSkillScroll.value = 1;
    }
    public void Skill17Select()
    {
        ActiveSkillScroll.value = 0;
    }
    public void Skill18Select()
    {
        ActiveSkillScroll.value = 0;
    }
    public void Skill19Select()
    {
        ActiveSkillScroll.value = 0;
    }


}
