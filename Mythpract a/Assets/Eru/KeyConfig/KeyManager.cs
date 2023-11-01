using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyPanel,padPanel;

    [SerializeField] 
    private RebindSaveManager rsm;

    [SerializeField]
    private AchvUI achv;

    private bool openFlg = false;

    private void Awake()
    {
        //キーコン読み込み
        rsm.Load();

        ClosePanel();
    }

    void Update()
    {
        //pauseキーが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openFlg == false) KeyBoardPanel();
            else ClosePanel();
        }
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
