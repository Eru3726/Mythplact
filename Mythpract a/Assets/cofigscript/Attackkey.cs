using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackkey : MonoBehaviour
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
        keycon.attack = true;
    }
    public void attackkeychange()
    {
        GameData.attackkey = keycon.codechange;
    }
}
