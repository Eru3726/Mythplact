using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public FadeManager fade;

    float time=0;
    //public bool portal;
    //private void Start()
    //{
    //    portal = false;
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    portal = true;   
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        //time += Time.deltaTime;
        //if (time >= 1.2f)
        //{
        //    SceneManager.LoadScene("GameScene");
        //}

        if(collision.transform.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            fade.Fadeout();
        }
    }

    public void scenetrans()
    {
        if (GameData.FafnirDead)
        {
            SceneManager.LoadScene("QilinScene");

        }
        else if (GameData.ShoggothDead)
        {
            SceneManager.LoadScene("FafnirScene");

        }
        else
        {
            SceneManager.LoadScene("ShoggothScene");

        }
    }

    public void scenetrans2()
    {
    }
}
