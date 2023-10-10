using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public FadeManager fade;

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
            fade.Fadeout();
        }
    }

    public void scenetrans()
    {
        if (GameData.ShoggothDead)
        {
            SceneManager.LoadScene("FafnirScene");

        }
        else
        {
            SceneManager.LoadScene("ShoggothScene");

        }
    }
}
