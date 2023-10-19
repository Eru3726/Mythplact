
using UnityEngine;

public class Interactkey : MonoBehaviour
{
    public Keyconfig keycon;

    public void Onclick()
    {
        keycon.interact = true;
    }
    public void interactkeychange()
    {
        GameData.interactkey = keycon.codechange;
    }
}
