using UnityEngine;

public class Rightkey : MonoBehaviour
{
    public Keyconfig keycon;
    void Start()
    {
    }

    void Update()
    {

    }

    public void Onclick()
    {
        keycon.right = true;
        Debug.Log("rightclick");
    }
    public void rightkeychange()
    {
        GameData.rightkey = keycon.codechange;
    }
}
