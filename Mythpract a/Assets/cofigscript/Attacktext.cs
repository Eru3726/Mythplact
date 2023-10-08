using UnityEngine;
using UnityEngine.UI;

public class Attacktext : MonoBehaviour
{
    public Keyconfig keycon;
    public Text text;

    void Update()
    {
        text.text = GameData.attacktx;
        if (keycon.attack == true)
        {
            text.color = Color.clear;
        }
        else
        {
            text.color = new Color(217, 217, 217);
        }
    }

    public void attacktextchange()
    {
        GameData.attacktx = keycon.keyStr;
    }
}
