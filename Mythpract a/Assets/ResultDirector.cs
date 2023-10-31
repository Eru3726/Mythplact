using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField] Text ClearTimeText;
    [SerializeField] Text HitCountText;
    [SerializeField] Text SkillCountText;
    [SerializeField] Text BackText;
    public FadeManager Fade;
    void Start()
    {
        dataManager.Read();
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "秒";
        HitCountText.text = GameData.HitCount + "回";
        SkillCountText.text = GameData.SkillCount + "回";

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
