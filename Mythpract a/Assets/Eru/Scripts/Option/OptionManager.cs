using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference pause;

    [SerializeField]
    private InputActionReference moveRight;

    [SerializeField]
    private InputActionReference moveLeft;

    [SerializeField]
    private GameObject settingCan,optionCan, disCan, souCan, keyCan, padCan, quitMenu;

    private bool settingOpenFlg = false;
    private bool optionOpenFlg = false;
    private bool achvOpenFlg = false;

    private int nowOpution = 1;

    private bool rebindFlg = false;

    private const int optionLeftBorder = 1;
    private const int optionRightBorder = 4;

    private AchvUI achvUI;

    //public static OptionManager instance;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else Destroy(this.gameObject);

        //キーの有効化
        pause.action.Enable();
        moveRight.action.Enable();
        moveLeft.action.Enable();

        PanelUpdata();

        settingOpenFlg = false;
        optionOpenFlg = false;
        achvOpenFlg = false;
        settingCan.SetActive(settingOpenFlg);
        optionCan.SetActive(optionOpenFlg);

        quitMenu.SetActive(false);

        achvUI = GetComponent<AchvUI>();
    }

    void Update()
    {
        //pauseキーが押されたら
        if (pause.action.triggered)
        {
            if (!optionOpenFlg && !achvOpenFlg)
            {
                settingOpenFlg = !settingOpenFlg;
                settingCan.SetActive(settingOpenFlg);
            }
            else if(optionOpenFlg && !achvOpenFlg)
            {
                optionOpenFlg = false;
                optionCan.SetActive(optionOpenFlg);
            }
            else
            {
                Debug.Log("a");
                if (achvOpenFlg) AchvUIClause();
                else AchvUIClause();
            }
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

    public void GameBackButton()
    {
        settingOpenFlg = false;
        settingCan.SetActive(settingOpenFlg);
    }

    public void OptionOpenButton()
    {
        optionOpenFlg = true;
        optionCan.SetActive(optionOpenFlg);
    }

    public void OptionClauseButton()
    {
        optionOpenFlg = false;
        optionCan.SetActive(optionOpenFlg);
    }

    public void TitleBackButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void AchvUIOpen()
    {
        achvOpenFlg = true;
        achvUI.OpenUI();
    }

    public void AchvUIClause()
    {
        achvOpenFlg = false;
        achvUI.ClauseUI();
    }

    public void QuitMenuOpenButton()
    {
        quitMenu.SetActive(true);
    }

    public void QuitMenuClauseButton()
    {
        quitMenu.SetActive(false);
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
