using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SaveSlotPanel;

    [SerializeField]
    private Image[] backGround;

    [SerializeField]
    private Button[] saveDataButton;

    [SerializeField]
    private Sprite saveBar, saveBarOFF, saveBarON, newSaveBar, newSaveBarOFF, newSaveBarON, noSaveBar, noSaveBarOFF, noSaveBarON;

    [SerializeField]
    private GameObject[] dataObj;

    [SerializeField]
    private Text[] playTimeText;

    [SerializeField]
    private Text[] lastTimeText;

    [SerializeField]
    private Text[] percentText;

    [SerializeField]
    private Image[] gaugeImage;

    [SerializeField]
    private DataManager dm;

    private bool nowOpenFlg = false;

    private bool newGameFlg = false;

    private TitleManager tm;

    private const int allAchv = 12;

    private void Start()
    {
        tm = GetComponent<TitleManager>();
        newGameFlg = false;
        nowOpenFlg = false;
        SaveSlotPanel.SetActive(nowOpenFlg);
    }

    public void NewGameButton()
    {
        newGameFlg = true;
        for (int i = 0; i < 3; i++)
        {
#if UNITY_EDITOR
            //UnityEditor上なら
            //Assetファイルの中のSaveファイルのパスを入れる
            string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

            //セーブファイルのパスを設定
            string SaveFilePath = path + "/save" + (i + 1) + ".bytes";

            //セーブファイルがあるか
            if (File.Exists(SaveFilePath))
            {
                backGround[i].sprite = saveBar;
                dataObj[i].SetActive(true);

                SpriteState xState = new();

                xState.highlightedSprite = saveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.pressedSprite = saveBarON;
                saveDataButton[i].spriteState = xState;

                xState.selectedSprite = saveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.disabledSprite = saveBar;
                saveDataButton[i].spriteState = xState;

                //データの反映
                DataManager.saveFile = i + 1;
                dm.Read();
                AchvManager.instance.Load();

                gaugeImage[i].fillAmount = ((float)AchvManager.instance.clearAchv / (float)allAchv);
                percentText[i].text = ((float)AchvManager.instance.clearAchv / (float)allAchv * 100.0f).ToString("F0") + "%";

                playTimeText[i].text = (GameData.playTime / 3600).ToString("D2") + "：" + ((GameData.playTime % 3600) / 60).ToString("D2");
                lastTimeText[i].text = GameData.lastYear.ToString("D4") + "/" + GameData.lastMonth.ToString("D2") + "/" + GameData.lastDay.ToString("D2")
                                       + "　" + GameData.lastHour.ToString("D2") + "：" + GameData.lastMinute.ToString("D2");
            }
            else
            {
                backGround[i].sprite = newSaveBar;
                dataObj[i].SetActive(false);

                SpriteState xState = new();

                xState.highlightedSprite = newSaveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.pressedSprite = newSaveBarON;
                saveDataButton[i].spriteState = xState;

                xState.selectedSprite = newSaveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.disabledSprite = newSaveBar;
                saveDataButton[i].spriteState = xState;

            }

            saveDataButton[i].enabled = true;
        }

        nowOpenFlg = true;
        SaveSlotPanel.SetActive(nowOpenFlg);
    }

    public void ContinueButton()
    {
        newGameFlg = false;
        for (int i = 0; i < 3; i++)
        {
#if UNITY_EDITOR
            //UnityEditor上なら
            //Assetファイルの中のSaveファイルのパスを入れる
            string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

            //セーブファイルのパスを設定
            string SaveFilePath = path + "/save" + (i + 1) + ".bytes";

            //セーブファイルがあるか
            if (File.Exists(SaveFilePath))
            {
                backGround[i].sprite = saveBar;
                saveDataButton[i].enabled = true;
                dataObj[i].SetActive(true);

                SpriteState xState = new();

                xState.highlightedSprite = saveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.pressedSprite = saveBarON;
                saveDataButton[i].spriteState = xState;

                xState.selectedSprite = saveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.disabledSprite = saveBar;
                saveDataButton[i].spriteState = xState;

                //データの反映
                DataManager.saveFile = i + 1;
                dm.Read();
                AchvManager.instance.Load();

                gaugeImage[i].fillAmount = ((float)AchvManager.instance.clearAchv / (float)allAchv);
                percentText[i].text = ((float)AchvManager.instance.clearAchv / (float)allAchv * 100.0f).ToString("F0") + "%";

                playTimeText[i].text = (GameData.playTime / 3600).ToString("D2") + "：" + ((GameData.playTime % 3600) / 60).ToString("D2");
                lastTimeText[i].text = GameData.lastYear.ToString("D4") + "/" + GameData.lastMonth.ToString("D2") + "/" + GameData.lastDay.ToString("D2")
                                       + "　" + GameData.lastHour.ToString("D2") + "：" + GameData.lastMinute.ToString("D2");
            }
            else
            {
                backGround[i].sprite = noSaveBar;
                saveDataButton[i].enabled = false;
                dataObj[i].SetActive(false);

                SpriteState xState = new();

                xState.highlightedSprite = noSaveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.pressedSprite = noSaveBarON;
                saveDataButton[i].spriteState = xState;

                xState.selectedSprite = noSaveBarOFF;
                saveDataButton[i].spriteState = xState;

                xState.disabledSprite = noSaveBar;
                saveDataButton[i].spriteState = xState;
            }
        }

        nowOpenFlg = true;
        SaveSlotPanel.SetActive(nowOpenFlg);
    }

    public void GameStartButton(int value)
    {
        if (value < 1 && value > 3) return;
        DataManager.saveFile = value;
        if (newGameFlg) dm.Delete();
        dm.Read();
        tm.GameStart();
    }

    public void BackButton()
    {
        nowOpenFlg = false;
        SaveSlotPanel.SetActive(nowOpenFlg);
    }
}
