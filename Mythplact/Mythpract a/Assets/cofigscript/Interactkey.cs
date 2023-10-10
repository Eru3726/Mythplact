using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactkey : MonoBehaviour
{
    public Keyconfig keycon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        keycon.interact = true;
    }
    public void interactkeychange()
    {
        GameData.interactkey = keycon.codechange;
    }
}
