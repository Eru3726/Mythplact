using UnityEngine;

public class Dashkey : MonoBehaviour
{
    public Keyconfig keycon;

    public void Onclick()
    {
        keycon.dash = true;
    }
    public void dashkeychange()
    {
        GameData.dashkey = keycon.codechange;
    }
}
