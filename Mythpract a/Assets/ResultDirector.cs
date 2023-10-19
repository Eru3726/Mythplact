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
            BackText.text = "�L�[�������ă^�C�g���ɖ߂�";
        }
        else if (GameData.ShoggothDead)
        {
            BackText.text = "�L�[�������đҋ@���ɖ߂�";

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
