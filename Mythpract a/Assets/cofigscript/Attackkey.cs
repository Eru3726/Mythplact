using UnityEngine;

public class Attackkey : MonoBehaviour
{
    public Keyconfig keycon;

    public void Onclick()
    {
        keycon.attack = true;
    }
    public void attackkeychange()
    {
        GameData.attackkey = keycon.codechange;
    }
}
