using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector2 : MonoBehaviour
{
    public static bool Bossdead2;
    public DataManager dataManager;
    public FadeManager Fade;
    Player player;
    void Start()
    {
        dataManager.Read();

        player = GameObject.Find("Player").GetComponent<Player>();
        Bossdead2 = false;
    }
    private void Update()
    {
        if (player.GameOver == true)
        {
            Fade.Fadeout();
        }
        else if (Bossdead2 == true)
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
        else if (Bossdead2 == true)
        {
            SceneManager.LoadScene("ResultScene2");
        }
    }
}
