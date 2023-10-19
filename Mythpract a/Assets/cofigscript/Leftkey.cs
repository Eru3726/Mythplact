using UnityEngine;

public class Leftkey : MonoBehaviour
{
    public Keyconfig keycon;

    public void Onclick()
    {
        keycon.left = true;
    }
    public void leftkeychange()
    {
        GameData.leftkey = keycon.codechange;
    }
}
