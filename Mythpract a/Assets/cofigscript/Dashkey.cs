using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashkey : MonoBehaviour
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
        keycon.dash = true;
    }
    public void dashkeychange()
    {
        GameData.dashkey = keycon.codechange;
    }
}
