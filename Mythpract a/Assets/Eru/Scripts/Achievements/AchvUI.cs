using UnityEngine;
using UnityEngine.UI;

public class AchvUI : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private Text gaugeText;

    [SerializeField]
    private Image gaugeImage;

    [SerializeField]
    private Text detail1Text, detail2Text, detail3Text, detail4Text;

    [SerializeField]
    private Image[] progressGauge = new Image[12];

    [SerializeField]
    private Image[] progressComplete = new Image[12];

    private const int allAchv = 12;
    private const int allPassive = 5;
    private const int allActive = 8;
    private const int allBoss = 3;

    void Start()
    {
        UpdateUI();
        ui.SetActive(false);
    }


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) OpenUI();
    }

    public void OpenUI()
    {
        ui.SetActive(true);
        UpdateUI();
    }

    public void ClauseUI()
    {
        ui.SetActive(false);
    }

    private void UpdateUI()
    {
        //左上
        gaugeText.text = ((float)GameData.clearAchv / (float)allAchv * 100.0f).ToString("F0") + "%";
        gaugeImage.fillAmount = ((float)GameData.clearAchv / (float)allAchv);

        //左下
        detail1Text.text = GameData.clearAchv.ToString() + "/" + allAchv.ToString();
        detail2Text.text = "5/" + allPassive.ToString();
        detail3Text.text = "8/" + allActive.ToString();
        detail4Text.text = GameData.clearBoss.ToString() + "/" + allBoss.ToString();

        //右
        progressComplete[0].enabled = GameData.dieXFlg;
        progressComplete[1].enabled = GameData.blinkXFlg;
        progressComplete[2].enabled = GameData.allBossFlg;
        progressComplete[3].enabled = GameData.oneHpFlg;
        progressComplete[4].enabled = GameData.attackComboFlg;
        progressComplete[5].enabled = GameData.sheriffUseFlg;
        progressComplete[6].enabled = GameData.guardCountFlg;
        progressComplete[7].enabled = GameData.noDamage;
        progressComplete[8].enabled = GameData.justGuardFlg;
        progressComplete[9].enabled = GameData.noGuard;
        progressComplete[10].enabled = GameData.activeSkillOnlyFlg;
        progressComplete[11].enabled = GameData.timeAttack;

        progressGauge[0].fillAmount = (float)GameData.dieXCount / (float)AchvMeasurement.instance.dieClearCount;
        progressGauge[1].fillAmount = (float)GameData.blinkXCount / (float)AchvMeasurement.instance.blinkClearCount;
        progressGauge[2].fillAmount = (float)GameData.clearBoss / (float)allBoss;
        progressGauge[3].fillAmount = GameData.oneHpFlg == false ? 0 : 1;
        progressGauge[4].fillAmount = GameData.attackComboFlg == false ? 0 : 1;
        progressGauge[5].fillAmount = (float)GameData.sheriffUseCount / (float)AchvMeasurement.instance.sheriffClearCount;
        progressGauge[6].fillAmount = (float)GameData.guardCount / (float)AchvMeasurement.instance.guardClearCount;
        progressGauge[7].fillAmount = GameData.noDamage == false ? 0 : 1;
        progressGauge[8].fillAmount = (float)GameData.justGuardCount / (float)AchvMeasurement.instance.justGuardClearCount;
        progressGauge[9].fillAmount = GameData.noGuard == false ? 0 : 1;
        progressGauge[10].fillAmount = GameData.activeSkillOnlyFlg == false ? 0 : 1;
        progressGauge[11].fillAmount = GameData.timeAttack == false ? 0 : 1;
    }
}
