using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpkey : MonoBehaviour
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
        keycon.jump = true;
    }
    public void jumpkeychange()
    {
        GameData.jumpkey = keycon.codechange;
    }
}
