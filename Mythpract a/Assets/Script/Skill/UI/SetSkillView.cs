using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSkillView : MonoBehaviour
{

    public Text[] nameText;

    bool[] skill;
    


    public enum PassiveSkillText
    {
        Solutary,
        Stride,
        Dex,
        Flawless,
        Adrenaline,
        Strength,
        Wise,
        Elect,
        Carse,
        Heep,
        Num,    // スキルの数
    }
    void Start()
    {
        for (int i = 0; i < nameText.Length; i++)
        {
            nameText[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
#if false
        for(int i = 0; i < nameText.Length; i++)
        {
            if (GameData.setSkill10)
            {
                for(int j = 0; j < nameText.Length; j++)
                {
                    if(nameText[j].text == "サルタリー") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "サルタリー";

                    }
                }
            }
            if (GameData.setSkill11)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "ストライド") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "ストライド";

                    }
                }
            }
            if (GameData.setSkill12)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "デックス") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "デックス";

                    }
                }
            }
            if (GameData.setSkill13)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "フローレス") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "フローレス";

                    }
                }
            }
            if (GameData.setSkill14)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "アドレナリン") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "アドレナリン";

                    }
                }
            }
            if (GameData.setSkill15)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "ストレングス") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "ストレングス";

                    }
                }
            }
            if (GameData.setSkill16)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "ワイズ") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "ワイズ";

                    }
                }
            }
            if (GameData.setSkill17)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "エレクト") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "エレクト";

                    }
                }
            }
            if (GameData.setSkill18)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "カース") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "カース";

                    }
                }
            }
            if (GameData.setSkill19)
            {
                for (int j = 0; j < nameText.Length; j++)
                {
                    if (nameText[j].text == "ヒープ") break;
                    else
                    {
                        nameText[i].gameObject.SetActive(true);
                        nameText[i].text = "ヒープ";

                    }
                }
            }

        }
#endif

        if (GameData.setSkill10)
        {
            nameText[0].gameObject.SetActive(true);
            nameText[0].text = "サルタリー";
        }
        else nameText[0].gameObject.SetActive(false);

        if (GameData.setSkill11)
        {
            nameText[1].gameObject.SetActive(true);
            nameText[1].text = "ストライド";
        }
        else nameText[1].gameObject.SetActive(false);

        if (GameData.setSkill12)
        {
            nameText[2].gameObject.SetActive(true);
            nameText[2].text = "デックス";
        }
        else nameText[2].gameObject.SetActive(false);

        if (GameData.setSkill13)
        {
            nameText[3].gameObject.SetActive(true);
            nameText[3].text = "フローレス";
        }
        else nameText[3].gameObject.SetActive(false);

        if (GameData.setSkill14)
        {
            nameText[4].gameObject.SetActive(true);
            nameText[4].text = "アドレナリン";
        }
        else nameText[4].gameObject.SetActive(false);

        if (GameData.setSkill15)
        {
            nameText[5].gameObject.SetActive(true);
            nameText[5].text = "ストレングス";
        }
        else nameText[5].gameObject.SetActive(false);

        if (GameData.setSkill16)
        {
            nameText[6].gameObject.SetActive(true);
            nameText[6].text = "ワイズ";
        }
        else nameText[6].gameObject.SetActive(false);

        if (GameData.setSkill17)
        {
            nameText[7].gameObject.SetActive(true);
            nameText[7].text = "エレクト";
        }
        else nameText[7].gameObject.SetActive(false);

        if (GameData.setSkill18)
        {
            nameText[8].gameObject.SetActive(true);
            nameText[8].text = "カース";
        }
        else nameText[8].gameObject.SetActive(false);

        if (GameData.setSkill19)
        {
            nameText[9].gameObject.SetActive(true);
            nameText[9].text = "ヒープ";
        }
        else nameText[9].gameObject.SetActive(false);





    }
}
