using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyPanel,padPanel;

    [SerializeField] 
    private RebindSaveManager rsm;

    [SerializeField]
    private AchvUI achv;

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private RectTransform cursorRect;

    [SerializeField]
    private InputActionReference pause;

    private bool openFlg = false;

    private void Awake()
    {
        //キーコン読み込み
        rsm.Load();
        pause.action.Enable();
        ClosePanel();
    }

    void Update()
    {
        //pauseキーが押されたら
        if (pause.action.triggered)
        {
            if (openFlg == false) KeyBoardPanel();
            else ClosePanel();
        }
        if(cursor != null) cursor.SetActive(openFlg);
    }

    public void KeyBoardPanel()
    {
        keyPanel.SetActive(true);
        padPanel.SetActive(false);
        openFlg = true;
        Time.timeScale = 0;
    }

    public void GamePadPanel()
    {
        padPanel.SetActive(true);
        keyPanel.SetActive(false);
        openFlg = true;
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        padPanel.SetActive(false);
        keyPanel.SetActive(false);
        openFlg = false;
        if(cursorRect != null) cursorRect.transform.position = new Vector2(960, 540);
        Time.timeScale = 1;
    }

    public void AchvOpen()
    {
        achv.OpenUI();
    }

    public void SkillOpen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SkillPiece");
    }
}
