using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public DataManager data;
    void Start()
    {
        data.Read();

        keycon.SetActive(false);
        keyconCmana.SetActive(false);
        titleCmana.SetActive(true);
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
