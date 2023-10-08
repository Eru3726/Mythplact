using UnityEngine;
using UnityEngine.UI;

public class Interacttext : MonoBehaviour
{
    public Keyconfig keycon;
    public Text text;

    void Update()
    {
        text.text = GameData.interacttx;
        if (keycon.interact == true)
        {
            text.color = Color.clear;
        }
        else
        {
            text.color = new Color(217, 217, 217);
        }
    }
    public void interacttextchange()
    {
        GameData.interacttx = keycon.keyStr;
    }
}
