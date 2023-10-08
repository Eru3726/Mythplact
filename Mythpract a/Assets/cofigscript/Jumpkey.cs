using UnityEngine;

public class Jumpkey : MonoBehaviour
{
    public Keyconfig keycon;

    void Update()
    {

    }
    public void Onclick()
    {
        keycon.jump = true;
    }
    public void jumpkeychange()
    {
        GameData.jumpkey = keycon.codechange;
    }
}
