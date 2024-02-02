using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextFade : MonoBehaviour
{
    [SerializeField, Header("TitleTextのイメージ")]
    private Image textImage;
    [SerializeField, Header("TitleTextのイメージ")]
    private Image textImage;
    [SerializeField, Header("TitleTextのイメージ")]
    private Image textImage;
    [SerializeField, Header("TitleTextのイメージ")]
    private Image textImage;

    private Color colorText;

    [SerializeField,Header("出てくる速さ")]
    private float alphaColor;
    void Start()
    {
        colorText = textImage.color;
        colorText.a = 0;
        textImage.color = colorText;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorText.a <= 1)
        {
            colorText.a += alphaColor;
            textImage.color = colorText;
        }        
    }
}
