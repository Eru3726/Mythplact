using UnityEngine;
using UnityEngine.InputSystem;
public class NextText : MonoBehaviour
{
    [SerializeField, Header("出てくる速度")]
    private float popSpd;

    private bool isPop;

    private string poptext;

    private Color color;

    private TextMesh nextTextMesh;
    //private int bindingIndex = 0;
    private void Start()
    {
        isPop = false;
        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;

        nextTextMesh = this.GetComponent<TextMesh>();
    }
    private void Update()
    {
        // コントローラーかキー入力か判別　キーなら0
        if (Gamepad.current == null)
        {
            poptext = "zで次へ\nESCでチュートリアルスキップ";
        }
        // この辺はコントローラーの様子見ながら
        else poptext = "optionで次へ\nhomeでチュートリアルスキップ";

        nextTextMesh.text = poptext;
        if (!isPop)
        {
            color.a += popSpd * Time.deltaTime;
            nextTextMesh.color = color;
            if (color.a >= 1)
            {
                isPop = true;
            }
        }
    }
}
