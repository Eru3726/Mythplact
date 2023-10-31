using UnityEngine;
using UnityEngine.SceneManagement;

public class RestManager : MonoBehaviour
{
    public GameObject keycon;

    public GameObject Cmana;

    public static bool heal;

    public Read readclass;
    // Start is called before the first frame update
    void Start()
    {
        //keycon.SetActive(false);
        Cmana.SetActive(false);

        heal = true;

        readclass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (keycon.activeSelf == false)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        //    {
        //        keycon.SetActive(true);
        //        Cmana.SetActive(true);
        //        Time.timeScale = 0;
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        //    {
        //        keycon.SetActive(false);
        //        Cmana.SetActive(false);
        //        Time.timeScale = 1;
        //    }
        //}
    }

    public void Boss1Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("");
    }

    public void Boss2Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("");
    }
    public void Skill()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SkillPiece");
    }
    public void Escape()
    {
        Time.timeScale = 1;
        keycon.SetActive(false);
        Cmana.SetActive(false);
    }
}
