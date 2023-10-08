using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public Controllerconnect conconnect;

    public GameObject start;

    public GameObject setting;

    public GameObject quit;

    public GameObject keycon;

    public GameObject keyconCmana;

    public GameObject titleCanvas;

    public GameObject titleCmana;

    [SerializeField, Header("FPS")]
    private int fps = 60;

    public DataManager data;
    void Start()
    {
        data.Read();

        keycon.SetActive(false);
        keyconCmana.SetActive(false);
        titleCmana.SetActive(true);

        Application.targetFrameRate = fps;
    }

    void Update()
    {
    }

    public void skillscene()
    {
        
    }
    

    public void GameStart()
    {
        SceneManager.LoadScene("RestScene");
    }

    public void Setting()
    {
        start.SetActive(false);
        setting.SetActive(false);
        quit.SetActive(false);
        keycon.SetActive(true);
        keyconCmana.SetActive(true);
        titleCmana.SetActive(false);
        titleCanvas.SetActive(false);
    }

    public void SettingExit()
    {
        start.SetActive(true);
        setting.SetActive(true);
        quit.SetActive(true);
        keycon.SetActive(false);
        keyconCmana.SetActive(false);
        titleCmana.SetActive(true);
        titleCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
