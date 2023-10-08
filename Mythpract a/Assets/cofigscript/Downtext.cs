using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Downtext : MonoBehaviour
{
    public Keyconfig keycon;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameData.downtx;
        if (keycon.down == true)
        {
            text.color = Color.clear;
        }
        else
        {
            text.color = new Color(217, 217, 217);
        }
    }
    public void downtextchange()
    {
        GameData.downtx = keycon.keyStr;
    }
}
