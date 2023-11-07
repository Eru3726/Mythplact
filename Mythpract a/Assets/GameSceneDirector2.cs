using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector2 : MonoBehaviour
{
    public DataManager dataManager;
    public FadeManager Fade;
    Player player;
    void Start()
    {
        dataManager.Read();
        GameData.HitCount = 0;
        GameData.justGuardCount = 0;
        GameData.SkillCount = 0;

        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if (player.GameOver == true)
        {
            Fade.Fadeout();
        }
        else if (GameData.FafnirDead == true)
        {
            Fade.Fadeout();
        }
    }

    public void Scenetrans()
    {
        dataManager.Save();
        if (player.GameOver == true)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else if (GameData.FafnirDead == true)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
