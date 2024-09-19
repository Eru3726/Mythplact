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

    [SerializeField]
    private int waitTime = 3;

    private float time = 0;

    void Start()
    {
        dataManager.Read();
        time = 0;
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "秒";
        if (GameData.QilinDead)
        {
            if(GameData.bestTimeQilin > GameData.ClearTime || GameData.bestTimeQilin == 0) GameData.bestTimeQilin = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeQilin.ToString("F1") + "秒";
        }
        else if (GameData.FafnirDead)
        {
            if (GameData.bestTimeFafnir > GameData.ClearTime || GameData.bestTimeFafnir == 0) GameData.bestTimeFafnir = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeFafnir.ToString("F1") + "秒";
        }
        else
        {
            if (GameData.bestTimeShoggoth > GameData.ClearTime || GameData.bestTimeShoggoth == 0) GameData.bestTimeShoggoth = GameData.ClearTime;
            bestTimeText.text = GameData.bestTimeShoggoth.ToString("F1") + "秒";
        }
        justGuardText.text = GameData.justGuardCount + "回";

        HitCountText.text = GameData.HitCount + "回";

        score = (int)(150 - GameData.ClearTime) + (GameData.justGuardCount * 3) - (GameData.HitCount * 2);

        if (score >= sScore) rankImage.sprite = s;
        else if (score >= aScore) rankImage.sprite = a;
        else if (score >= bScore) rankImage.sprite = b;
        else rankImage.sprite = c;

        dataManager.Save();

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.anyKeyDown)
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
        if (time < waitTime) return;
        if (GameData.QilinDead)
        {
            GameData.QilinDead = false;
            GameData.FafnirDead = false;
            GameData.ShoggothDead = false;
            dataManager.Save();
            SceneManager.LoadScene("TitleScene");
        }
        else if (GameData.ShoggothDead || GameData.FafnirDead)
        {
            SceneManager.LoadScene("RestScene");

        }
    }


}
