using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconView : MonoBehaviour
{
    [SerializeField, Tooltip("スラッシュ")] Sprite ActiveIcon1;
    [SerializeField, Tooltip("フリート")] Sprite ActiveIcon2;
    [SerializeField, Tooltip("ローンウォーリアー")] Sprite ActiveIcon3;
    [SerializeField, Tooltip("グリーム")] Sprite ActiveIcon4;
    [SerializeField, Tooltip("ディスピレーションストライク")] Sprite ActiveIcon5;

    GameObject Slot1;
    GameObject Slot2;
    GameObject Slot3;
    GameObject Slot4;

    Image SlotGauge1;
    Image SlotGauge2;
    Image SlotGauge3;
    Image SlotGauge4;

    Image SlotBack1;
    Image SlotBack2;
    Image SlotBack3;
    Image SlotBack4;

    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        Slot1 = GameObject.Find("UI/SkillIcon/Slot1");
        Slot2 = GameObject.Find("UI/SkillIcon/Slot2");
        Slot3 = GameObject.Find("UI/SkillIcon/Slot3");
        Slot4 = GameObject.Find("UI/SkillIcon/Slot4");

        SlotGauge1 = GameObject.Find("UI/SkillIcon/Slot1/Slot1Gauge").GetComponent<Image>();
        SlotGauge2 = GameObject.Find("UI/SkillIcon/Slot2/Slot2Gauge").GetComponent<Image>();
        SlotGauge3 = GameObject.Find("UI/SkillIcon/Slot3/Slot3Gauge").GetComponent<Image>();
        SlotGauge4 = GameObject.Find("UI/SkillIcon/Slot4/Slot4Gauge").GetComponent<Image>();

        SlotBack1 = GameObject.Find("UI/SkillIcon/Slot1/Slot1Back").GetComponent<Image>();
        SlotBack2 = GameObject.Find("UI/SkillIcon/Slot2/Slot2Back").GetComponent<Image>();
        SlotBack3 = GameObject.Find("UI/SkillIcon/Slot3/Slot3Back").GetComponent<Image>();
        SlotBack4 = GameObject.Find("UI/SkillIcon/Slot4/Slot4Back").GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.skillSlot1 != 0)
        {
            Slot1.SetActive(true);

            if (GameData.skillSlot1 == 1) { SlotGauge1.overrideSprite = ActiveIcon1; SlotGauge1.fillAmount = player.SkillSlashCount / player.SkillSlashCT; }
            else if (GameData.skillSlot1 == 2) { SlotGauge1.overrideSprite = ActiveIcon2; SlotGauge1.fillAmount = player.SkillFleetCount / player.SkillFleetCT; }
            else if (GameData.skillSlot1 == 3) { SlotGauge1.overrideSprite = ActiveIcon3; SlotGauge1.fillAmount = player.SkillLoneWarrirorCount / player.SkillLoneWarrirorCT; }
            else if (GameData.skillSlot1 == 4) { SlotGauge1.overrideSprite = ActiveIcon4; SlotGauge1.fillAmount = player.SkillGreemCount / player.SkillGreemCT; }
            else if (GameData.skillSlot1 == 5) { SlotGauge1.overrideSprite = ActiveIcon5; SlotGauge1.fillAmount = player.SkillDStrikeCount / player.SkillDStrikeCT; }

            SlotBack1.overrideSprite = SlotGauge1.overrideSprite;
        }
        else 
        { 
            Slot1.SetActive(false); 
        }

        if (GameData.skillSlot2 != 0)
        {
            Slot2.SetActive(true);

            if (GameData.skillSlot2 == 1) { SlotGauge2.overrideSprite = ActiveIcon1; SlotGauge2.fillAmount = player.SkillSlashCount / player.SkillSlashCT; }
            else if (GameData.skillSlot2 == 2) { SlotGauge2.overrideSprite = ActiveIcon2; SlotGauge2.fillAmount = player.SkillFleetCount / player.SkillFleetCT; }
            else if (GameData.skillSlot2 == 3) { SlotGauge2.overrideSprite = ActiveIcon3; SlotGauge2.fillAmount = player.SkillLoneWarrirorCount / player.SkillLoneWarrirorCT; }
            else if (GameData.skillSlot2 == 4) { SlotGauge2.overrideSprite = ActiveIcon4; SlotGauge2.fillAmount = player.SkillGreemCount / player.SkillGreemCT; }
            else if (GameData.skillSlot2 == 5) { SlotGauge2.overrideSprite = ActiveIcon5; SlotGauge2.fillAmount = player.SkillDStrikeCount / player.SkillDStrikeCT; }
            else SlotGauge2.overrideSprite = null;

            SlotBack2.overrideSprite = SlotGauge2.overrideSprite;
        }
        else
        {
            Slot2.SetActive(false);
        }
        if (GameData.skillSlot3 != 0)
        {
            Slot3.SetActive(true);

            if (GameData.skillSlot3 == 1) { SlotGauge3.overrideSprite = ActiveIcon1; SlotGauge3.fillAmount = player.SkillSlashCount / player.SkillSlashCT; }
            else if (GameData.skillSlot3 == 2) { SlotGauge3.overrideSprite = ActiveIcon2; SlotGauge3.fillAmount = player.SkillFleetCount / player.SkillFleetCT; }
            else if (GameData.skillSlot3 == 3) { SlotGauge3.overrideSprite = ActiveIcon3; SlotGauge3.fillAmount = player.SkillLoneWarrirorCount / player.SkillLoneWarrirorCT; }
            else if (GameData.skillSlot3 == 4) { SlotGauge3.overrideSprite = ActiveIcon4; SlotGauge3.fillAmount = player.SkillGreemCount / player.SkillGreemCT; }
            else if (GameData.skillSlot3 == 5) { SlotGauge3.overrideSprite = ActiveIcon5; SlotGauge3.fillAmount = player.SkillDStrikeCount / player.SkillDStrikeCT; }
            else SlotGauge3.overrideSprite = null;

            SlotBack3.overrideSprite = SlotGauge3.overrideSprite;
        }
        else
        {
            Slot3.SetActive(false);
        }

        if (GameData.skillSlot4 != 0)
        {
            Slot4.SetActive(true);

            if (GameData.skillSlot4 == 1) { SlotGauge4.overrideSprite = ActiveIcon1; SlotGauge4.fillAmount = player.SkillSlashCount / player.SkillSlashCT; }
            else if (GameData.skillSlot4 == 2) { SlotGauge4.overrideSprite = ActiveIcon2; SlotGauge4.fillAmount = player.SkillFleetCount / player.SkillFleetCT; }
            else if (GameData.skillSlot4 == 3) { SlotGauge4.overrideSprite = ActiveIcon3; SlotGauge4.fillAmount = player.SkillLoneWarrirorCount / player.SkillLoneWarrirorCT; }
            else if (GameData.skillSlot4 == 4) { SlotGauge4.overrideSprite = ActiveIcon4; SlotGauge4.fillAmount = player.SkillGreemCount / player.SkillGreemCT; }
            else if (GameData.skillSlot4 == 5) { SlotGauge4.overrideSprite = ActiveIcon5; SlotGauge4.fillAmount = player.SkillDStrikeCount / player.SkillDStrikeCT; }
            else SlotGauge4.overrideSprite = null;

            SlotBack4.overrideSprite = SlotGauge4.overrideSprite;
        }
        else
        {
            Slot4.SetActive(false);
        }



    }
}
