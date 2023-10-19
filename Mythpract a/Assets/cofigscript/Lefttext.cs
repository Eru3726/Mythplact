using UnityEngine;
using UnityEngine.UI;

public class Lefttext : MonoBehaviour
{
    public Text text;
    public Keyconfig keycon;

    void Update()
    {
        text.text = GameData.lefttx;
        if (keycon.left == true)
        {
            text.color = Color.clear;
        }
        else
        {
            text.color = new Color(217,217,217);
        }
    }
    public void lefttextchange()
    {
        GameData.lefttx = keycon.keyStr;
    }
}
