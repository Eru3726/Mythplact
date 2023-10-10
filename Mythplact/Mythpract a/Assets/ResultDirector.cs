using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField] Text InputAnyKey;
    [SerializeField] Text ClearTimeText;
    [SerializeField] Text HitCountText;
    [SerializeField] Text SkillCountText;
    public FadeManager Fade;
    void Start()
    {
        dataManager.Read();
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "�b";
        HitCountText.text = GameData.HitCount + "��";
        SkillCountText.text = GameData.SkillCount + "��";
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
            InputAnyKey.text = "�L�[�������ă^�C�g���ɖ߂�";
        }
        else if (GameData.ShoggothDead)
        {
            InputAnyKey.text = "�L�[�������đҋ@���ɖ߂�";


        }


    }

    public void scenetrans()
    {
        if (GameData.FafnirDead)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else if(GameData.ShoggothDead)
        {
            SceneManager.LoadScene("RestScene");

        }
    }


}
