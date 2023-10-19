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
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "ç§’";
        HitCountText.text = GameData.HitCount + "å›";
        SkillCountText.text = GameData.SkillCount + "å›";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fade.Fadeout();
        }
        if (GameData.FafnirDead)
        {
            BackText.text = "ƒL[‚ğ‰Ÿ‚µ‚Äƒ^ƒCƒgƒ‹‚É–ß‚é";
        }
        else if (GameData.ShoggothDead)
        {
            BackText.text = "ƒL[‚ğ‰Ÿ‚µ‚Ä‘Ò‹@Š‚É–ß‚é";

        }

    }

    public void scenetrans()
    {
        if (GameData.FafnirDead)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else if (GameData.ShoggothDead)
        {
            SceneManager.LoadScene("RestScene");

        }
    }


}
