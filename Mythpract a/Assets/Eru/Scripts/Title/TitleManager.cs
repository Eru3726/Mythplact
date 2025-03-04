using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private InputActionReference moveRight;

    [SerializeField]
    private InputActionReference moveLeft;

    [SerializeField]
    private GameObject optionCan, disCan, souCan, keyCan, padCan, quitCan, saveCan;

    [SerializeField]
    private GameObject sceneLight;

    [SerializeField]
    private GameObject globalVol;
    private bool optionOpenFlg = false;

    private int nowOpution = 1;

    private bool rebindFlg = false;

    private const int optionLeftBorder = 1;
    private const int optionRightBorder = 4;

    public static int startTime = 0;

    void Start()
    {
        pause.action.Enable();
        moveRight.action.Enable();
        moveLeft.action.Enable();

        optionOpenFlg = false;
        optionCan.SetActive(optionOpenFlg);

        quitCan.SetActive(false);

        nowOpution = 1;
        PanelUpdata();

        sceneLight.SetActive(true);
    }

    void Update()
    {
        if(pause.action.triggered && optionOpenFlg)
        {
            optionOpenFlg = false;
            optionCan.SetActive(optionOpenFlg);
        }

        if (moveRight.action.triggered && nowOpution < optionRightBorder && optionOpenFlg && !rebindFlg)
        {
            rebindFlg = true;
            nowOpution++;
            PanelUpdata();
        }
        else if (moveLeft.action.triggered && nowOpution > optionLeftBorder && optionOpenFlg && !rebindFlg)
        {
            rebindFlg = true;
            nowOpution--;
            PanelUpdata();
        }

        if (!moveLeft.action.triggered && !moveRight.action.triggered && rebindFlg) rebindFlg = false;
    }
    private void PanelUpdata()
    {
        disCan.SetActive(false);
        souCan.SetActive(false);
        keyCan.SetActive(false);
        padCan.SetActive(false);

        switch (nowOpution)
        {
            case 1:
                disCan.SetActive(true);
                break;
            case 2:
                souCan.SetActive(true);
                break;
            case 3:
                keyCan.SetActive(true);
                break;
            case 4:
                padCan.SetActive(true);
                break;
        }
    }

    public void PanelChangeButton(int value)
    {
        if (nowOpution != value)
        {
            nowOpution = value;
            PanelUpdata();
        }
    }

    public void GameStart()
    {
        startTime = (int)Time.time;
        Debug.Log(Time.time);
    }

    public void FadeStart()
    {
        if (GameData.Firsttime == false)
        {
            SceneManager.LoadScene("RestScene");
        }
        if (GameData.Firsttime == true)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void OptionOpenButton()
    {
        optionOpenFlg = true;
        optionCan.SetActive(optionOpenFlg);
        sceneLight.SetActive(false);
    }

    public void OptionClauseButton()
    {
        optionOpenFlg = false;
        optionCan.SetActive(optionOpenFlg);
        saveCan.SetActive(false);
        sceneLight.SetActive(true);
    }

    public void QuitMenuOpen()
    {
        quitCan.SetActive(true);
        sceneLight.SetActive(false);
    }

    public void QuitMenuClause()
    {
        quitCan.SetActive(false);
        sceneLight.SetActive(true);
    }

    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
#endif
    }
}
