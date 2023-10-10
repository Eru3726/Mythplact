using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillDirector : MonoBehaviour
{
    public DataManager dataManager;
    public void Start()
    {
        dataManager.Read();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Back()
    {
        SceneManager.LoadScene("RestScene");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
