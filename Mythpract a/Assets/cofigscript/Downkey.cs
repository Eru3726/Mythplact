using UnityEngine;

public class Downkey : MonoBehaviour
{
    public Keyconfig keycon;

    void Update()
    {
        
    }
    public void Onclick()
    {
        keycon.down = true;
    }
    public void downkeychange()
    {
        GameData.downkey = keycon.codechange;
    }
}
