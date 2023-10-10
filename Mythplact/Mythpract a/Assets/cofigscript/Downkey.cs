using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downkey : MonoBehaviour
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
        keycon.down = true;
    }
    public void downkeychange()
    {
        GameData.downkey = keycon.codechange;
    }
}
