using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField] Text ClearTimeText;
    [SerializeField] Text bestTimeText;
    [SerializeField] Text HitCountText;
    [SerializeField] Text justGuardText;
    [SerializeField] Text BackText;

    [SerializeField]
    private Image rankImage;

    [SerializeField]
    private Sprite s, a, b, c;

    private int score;

    [SerializeField]
    private int sScore, aScore, bScore;

    public FadeManager Fade;

    void Start()
    {
        dataManager.Read();
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "秒";
        if (GameData.QilinDead && GameData.bestTimeQilin < GameData.ClearTime)
        {
            GameData.bestTimeQilin = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeQilin.ToString("F1") + "秒";
        }
        else if (GameData.FafnirDead && GameData.bestTimeFafnir < GameData.ClearTime)
        {
            GameData.bestTimeFafnir = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeFafnir.ToString("F1") + "秒";
        }
        else
        {
            GameData.bestTimeShoggoth = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeShoggoth.ToString("F1") + "秒";
        }
        justGuardText.text = GameData.justGuardCount + "回";

        HitCountText.text = GameData.HitCount + "回";

        score = (int)(100 - GameData.ClearTime) + (GameData.justGuardCount * 3) - GameData.HitCount;

        if (score >= sScore) rankImage.sprite = s;
        else if (score >= aScore) rankImage.sprite = a;
        else if (score >= bScore) rankImage.sprite = b;
        else rankImage.sprite = c;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fade.Fadeout();
        }
        if (GameData.QilinDead)
        {
            BackText.text = "キーを押してタイトルに戻る";
        }
        else if (GameData.ShoggothDead || GameData.FafnirDead)
        {
            BackText.text = "キーを押して待機所に戻る";

        }

    }

    public void scenetrans()
    {
        if (GameData.QilinDead)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else if (GameData.ShoggothDead || GameData.FafnirDead)
        {
            SceneManager.LoadScene("RestScene");

        }
    }


}
