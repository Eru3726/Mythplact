using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    [SerializeField]
    
    void Start()
    {
        this.GetComponent<TextMesh>().text = GameData.lefttx + " " + GameData.righttx + "で移動";
    }
    void Update()
    {
        
    }
}
