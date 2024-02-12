using UnityEngine;
using UnityEngine.UI;

public class TitleTextFade : MonoBehaviour
{
    [SerializeField, Header("buttom")]
    private Text text;

    private Color colorText;

    [SerializeField, Header("出てくる速さ")]
    private float alphaColor;
    void Start()
    {
        colorText = text.color;
        colorText.a = 0;
        text.color = colorText;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorText.a >= 1)
        {
            colorText.a += alphaColor;
            text.color = colorText;
        }
    }
}
