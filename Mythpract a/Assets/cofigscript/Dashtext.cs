using UnityEngine;
using UnityEngine.UI;

public class Dashtext : MonoBehaviour
{
    public Text text;
    public Keyconfig keycon;

    void Update()
    {
        text.text = GameData.dashtx;
        if (keycon.dash == true)
        {
            text.color = Color.clear;
        }
        else
        {
            text.color = new Color(217, 217, 217);
        }
    }
    public void dashtextchange()
    {
        GameData.dashtx = keycon.keyStr;
    }
}
