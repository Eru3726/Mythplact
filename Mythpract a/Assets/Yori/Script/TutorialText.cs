using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    private Color color;
    //[SerializeField]
    //private List<InputActionReference>  _actionRef;
    //private List<InputAction>  _action;
    private enum PopTextType
    {
        Move,
        Jump,
        WJump,
        Attack,
        Skill,
        Guard,
        Blink
    }
    [SerializeField, Header("表示テキスト")]
    private PopTextType popTexttype=PopTextType.Move;

    private string poptext;

    private void Awake()
    {
        //var _action = new List<InputAction>();
        //for (int i = 0; i < _actionRef.Count; i++)
        //{
        //    _action.Add(_actionRef[i]);
        //    Debug.Log(_actionRef[i]);
        //}
    }
    void Start()
    {
        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;
        switch (popTexttype)
        {
            case PopTextType.Move:
                poptext = "「A,D」 移動";
                break;
            case PopTextType.Jump:
                poptext = " 「SPACE」 ジャンプ";
                break;
            case PopTextType.WJump:
                poptext =  "ジャンプ中にもう一度「SPACE」二段ジャンプ";
                break;
            case PopTextType.Attack:
                poptext = " 「左クリック」攻撃" +
                    "　空中で移動キー入力で攻撃が変化";
                break;
            case PopTextType.Skill:
                poptext = "「スキルボタン」スキル攻撃";
                break;
            case PopTextType.Guard:
                poptext = "「右クリック」ガード";
                break;
            case PopTextType.Blink:
                poptext = "「SHIFT」ブリンク";
                break;
        }
        this.GetComponent<TextMesh>().text = poptext;
    }
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            color.a = 255;
            this.GetComponent<TextMesh>().color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;
    }
}
