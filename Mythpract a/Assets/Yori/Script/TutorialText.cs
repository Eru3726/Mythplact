using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    private Color color;
    [SerializeField]
    private List<InputActionReference> _actionRef;
    private List<InputAction> _action;
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

    private int bindingIndex = 0;
    private void Awake()
    {
       
    }
    void Start()
    {
        _action = new List<InputAction>();
        for (int i = 0; i < _actionRef.Count; i++)
        {
            _action.Add(_actionRef[i]);
            Debug.Log(_action[i]);
        }
        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;
        
    }
    private void Update()
    {
        if (Gamepad.current == null) bindingIndex = 0;
        else bindingIndex = 1;

        switch (popTexttype)
        {
            case PopTextType.Move:
                poptext = " 「" + _action[0].GetBindingDisplayString(bindingIndex) + "," + _action[1].GetBindingDisplayString(bindingIndex) + "」移動";
                break;
            case PopTextType.Jump:
                poptext = " 「" + _action[0].GetBindingDisplayString(bindingIndex) + "」 ジャンプ";
                break;
            case PopTextType.WJump:
                poptext = "ジャンプ中にもう一度\n「" + _action[0].GetBindingDisplayString(bindingIndex) + "」二段ジャンプ";
                break;
            case PopTextType.Attack:
                poptext = " 「" + _action[0].GetBindingDisplayString(bindingIndex) + "」攻撃\n" +
                    "　空中で上下キー入力で攻撃が変化";
                break;
            case PopTextType.Skill:
                poptext = "「" + _action[0].GetBindingDisplayString(bindingIndex) + "」スキル攻撃";
                break;
            case PopTextType.Guard:
                poptext = "「" + _action[0].GetBindingDisplayString(bindingIndex) + "」ガード";
                break;
            case PopTextType.Blink:
                poptext = "「" + _action[0].GetBindingDisplayString(bindingIndex) + "」ブリンク";
                break;
        }
        this.GetComponent<TextMesh>().text = poptext;
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
