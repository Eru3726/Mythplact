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
    private const int allPassive = 12;
    private const int allActive = 12;
    private const int allBoss = 3;

    void Start()
    {
        UpdateUI();
        ui.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) OpenUI();
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
        gaugeText.text = ((float)AchvManager.instance.clearAchv / (float)allAchv * 100.0f).ToString("F0") + "%";
        gaugeImage.fillAmount = ((float)AchvManager.instance.clearAchv / (float)allAchv);

        //左下
        detail1Text.text = AchvManager.instance.clearAchv.ToString() + "/" + allAchv.ToString();
        detail2Text.text = "/" + allPassive.ToString();
        detail3Text.text = "/" + allActive.ToString();
        detail4Text.text = AchvManager.instance.clearBoss.ToString() + "/" + allBoss.ToString();

        //右
        progressComplete[0].enabled = AchvManager.instance.dieXFlg;
        progressComplete[1].enabled = AchvManager.instance.blinkXFlg;
        progressComplete[2].enabled = AchvManager.instance.allBossFlg;
        progressComplete[3].enabled = AchvManager.instance.oneHpFlg;
        progressComplete[4].enabled = AchvManager.instance.attackComboFlg;
        progressComplete[5].enabled = AchvManager.instance.sheriffUseFlg;
        progressComplete[6].enabled = AchvManager.instance.guardCountFlg;
        progressComplete[7].enabled = AchvManager.instance.noDamage;
        progressComplete[8].enabled = AchvManager.instance.justGuardFlg;
        progressComplete[9].enabled = AchvManager.instance.noGuard;
        progressComplete[10].enabled = AchvManager.instance.activeSkillOnlyFlg;
        progressComplete[11].enabled = AchvManager.instance.timeAttack;

        progressGauge[0].fillAmount = (float)AchvManager.instance.dieXCount / (float)AchvManager.instance.dieClearCount;
        progressGauge[1].fillAmount = (float)AchvManager.instance.blinkXCount / (float)AchvManager.instance.blinkClearCount;
        progressGauge[2].fillAmount = (float)AchvManager.instance.clearBoss / (float)allBoss;
        progressGauge[3].fillAmount = AchvManager.instance.oneHpFlg == false ? 0 : 1;
        progressGauge[4].fillAmount = AchvManager.instance.attackComboFlg == false ? 0 : 1;
        progressGauge[5].fillAmount = (float)AchvManager.instance.sheriffUseCount / (float)AchvManager.instance.sheriffClearCount;
        progressGauge[6].fillAmount = (float)AchvManager.instance.guardCount / (float)AchvManager.instance.guardClearCount;
        progressGauge[7].fillAmount = AchvManager.instance.noDamage == false ? 0 : 1;
        progressGauge[8].fillAmount = (float)AchvManager.instance.justGuardCount / (float)AchvManager.instance.justGuardClearCount;
        progressGauge[9].fillAmount = AchvManager.instance.noGuard == false ? 0 : 1;
        progressGauge[10].fillAmount = AchvManager.instance.activeSkillOnlyFlg == false ? 0 : 1;
        progressGauge[11].fillAmount = AchvManager.instance.timeAttack == false ? 0 : 1;
    }
}
