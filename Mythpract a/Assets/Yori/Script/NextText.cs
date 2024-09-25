using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NextText : MonoBehaviour
{
    [SerializeField, Header("出てくる速度")]
    private float popSpd;

    private bool isPop;

    private string poptext;

    private Color color;
    private void Start()
    {
        isPop = false;
        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;

        
    }
    private void Update()
    {
        // コントローラーかキー入力か判別　キーなら0
        if (Gamepad.current == null) {
            poptext = "zで次へ\nESCでチュートリアルスキップ";
        }
        // この辺はコントローラーの様子見ながら
        else poptext = "optionで次へ\nhomeでチュートリアルスキップ";

        if (!isPop)
        {
            color.a += popSpd * Time.deltaTime;
            this.GetComponent<TextMesh>().color = color;
            if (color.a>=1)
            {
                isPop = true;
            }
        }
    }
}
