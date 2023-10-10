using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
