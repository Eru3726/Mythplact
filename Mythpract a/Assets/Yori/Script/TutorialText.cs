using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    private enum PopTextType
    {
        Move=0,
        Jump=1,
        WJump=2,
        NAttack=3,
        SAttack=4,
        Skill=5,
        Guard=6,
        Blink=7
    }
    [SerializeField, Header("検知範囲")]
    private PopTextType popText = PopTextType.Move;
    private void Awake()
    {
        
    }
    void Start()
    {
        this.GetComponent<TextMesh>().text = GameData.lefttx + " " + GameData.righttx + "で移動";
    }
    void Update()
    {
        
    }
}
