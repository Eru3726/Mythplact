using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftkey : MonoBehaviour
{
    public Keyconfig keycon;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        keycon.left = true;
    }
    public void leftkeychange()
    {
        GameData.leftkey = keycon.codechange;
    }
}
