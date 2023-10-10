using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector2 : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField] Text ClearTimeText;
    [SerializeField] Text HitCountText;
    [SerializeField] Text SkillCountText;
    public FadeManager Fade;
    void Start()
    {
        dataManager.Read();
        ClearTimeText.text = GameData.ClearTime.ToString("F1") + "•b";
        HitCountText.text = GameData.HitCount + "‰ñ";
        SkillCountText.text = GameData.SkillCount + "‰ñ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fade.Fadeout();
        }
    }

    public void scenetrans()
    {
        SceneManager.LoadScene("TitleScene");
    }


}
