using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healkey : MonoBehaviour
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
        keycon.heal = true;
    }
    public void menukeychange()
    {
        GameData.healkey = keycon.codechange;
    }
}
