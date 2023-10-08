using UnityEngine;

public class Healkey : MonoBehaviour
{
    public Keyconfig keycon;

    public void Onclick()
    {
        keycon.heal = true;
    }
    public void menukeychange()
    {
        GameData.healkey = keycon.codechange;
    }
}
