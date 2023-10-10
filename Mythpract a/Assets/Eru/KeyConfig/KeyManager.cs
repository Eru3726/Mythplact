using UnityEngine;
using UnityEngine.InputSystem;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyPanel,padPanel;

    [SerializeField] 
    private RebindSaveManager rsm;

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
    }

    public void GamePadPanel()
    {
        padPanel.SetActive(true);
        keyPanel.SetActive(false);
        openFlg = true;
    }

    public void ClosePanel()
    {
        padPanel.SetActive(false);
        keyPanel.SetActive(false);
        openFlg = false;
    }
}
