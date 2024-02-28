using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    // 入力関係

    [SerializeField]
    private List<InputActionReference> _actionRef;
    private List<InputAction> _action;

    private enum InputActionNum
    {
        attackInp,
        guardInp,
        rightInp,
        leftInp,
        skill1Inp,
        jumpInp,
        blinkInp,
        escInp
    }

    private enum PopTextType
    {
        Talk,
        Move,
        Attack,
        Skill,
        Guard,
        Blink,
        tutorialBattle,
    }

    private InputActionNum inputActionNum;
    private PopTextType popTexttype;

    private string poptext;

    private int bindingIndex = 0;

    private float timer = 0;

    private bool isChange = false;

    private int pushCount = 0;

    private int pushBottum = 0;

    // 入力関係ここまで

    // 文字のフェイド関係

    private Color color;

    [SerializeField, Header("文字の出てくる速度")]
    private float popSpd;

    [SerializeField, Header("文字の消える速度")]
    private float fadeSpd;

    private int fadeMathod = 1;

    [SerializeField, Header("スキップって書いてあるテキストメッシュ")]
    private GameObject nextTexntMesh;

    // 文字のフェイド関係ここまで

    // チュートリアルバトル関係

    private bool isBossBatlle = false;

    private int talkNum = 0;

    void Start()
    {
        // listにアタッチした奴を格納
        // InputActionNumの順番通りにアタッチしないと出てくるテキストが違うものになる。何とかしたい
        _action = new List<InputAction>();
        for (inputActionNum = 0; (int)inputActionNum < _actionRef.Count; inputActionNum++)
        {
            _action.Add(_actionRef[(int)inputActionNum]);
        }


        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;

        isBossBatlle = false;

        pushBottum = 10;
        pushCount = 0;

        _actionRef[(int)InputActionNum.escInp].action.Enable();
    }
    private void Update()
    {

        TutorialPopText();
        FadeText();

        // Tutorialスキップ
        if (_actionRef[(int)InputActionNum.escInp].action.triggered)
        {
            popTexttype = PopTextType.tutorialBattle;
        }
    }

    void TutorialPopText()
    {
        // コントローラーかキー入力か判別　キーなら0
        if (Gamepad.current == null) bindingIndex = 0;
        else bindingIndex = 1;

        // popTexttypeに応じてテキスト表示
        switch (popTexttype)
        {
            case PopTextType.Talk:

                switch (talkNum)
                {
                    case 0:
                        poptext = "目が覚めたか\nPress " + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex);
                        waitSeconds(3);
                        if (isChange&& _actionRef[(int)InputActionNum.attackInp].action.triggered)
                        {
                            isChange = false;
                            talkNum++;
                        }
                        break;
                    case 1:
                        poptext = "お前はどれだけ強くなれるか楽しみだ";
                        waitSeconds(3);
                        break;
                    case 2:
                        poptext = "動作確認をする";
                        waitSeconds(3);
                        break;
                }
                
            break;

            case PopTextType.Move:
                poptext = " 「" + _action[(int)InputActionNum.leftInp].GetBindingDisplayString(bindingIndex) + ","
                    + _action[(int)InputActionNum.rightInp].GetBindingDisplayString(bindingIndex) + "」移動";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.rightInp].action.IsPressed() && _actionRef[(int)InputActionNum.leftInp].action.IsPressed())
                {
                    poptext = " 「<color=red>" + _action[(int)InputActionNum.leftInp].GetBindingDisplayString(bindingIndex) + "</color>,<color=red>" +
                        _action[(int)InputActionNum.rightInp].GetBindingDisplayString(bindingIndex) + "</color>」移動";
                }
                else if (_actionRef[(int)InputActionNum.leftInp].action.IsPressed())
                {
                    poptext = " 「<color=red>" + _action[(int)InputActionNum.leftInp].GetBindingDisplayString(bindingIndex) + "</color>,"
                   + _action[(int)InputActionNum.rightInp].GetBindingDisplayString(bindingIndex) + "」移動";
                }
                else if (_actionRef[(int)InputActionNum.rightInp].action.IsPressed())
                {
                    poptext = " 「" + _action[(int)InputActionNum.leftInp].GetBindingDisplayString(bindingIndex) + ",<color=red>"
                   + _action[(int)InputActionNum.rightInp].GetBindingDisplayString(bindingIndex) + "</color>」移動";
                }

                if (isChange && _actionRef[(int)InputActionNum.leftInp].action.triggered ||
                    _actionRef[(int)InputActionNum.rightInp].action.triggered)
                {
                    pushCount++;
                    if (pushBottum <= pushCount)
                    {
                        pushCount = 0;
                        pushBottum = 5;
                        fadeMathod = 0;
                        isChange = false;
                    }
                }

                break;

            case PopTextType.Attack:
                poptext = " 「" + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "」攻撃\n" +
                    "　空中で上下入力で攻撃が変化";
                if (_actionRef[(int)InputActionNum.attackInp].action.IsPressed())
                {
                    poptext = " 「<color=red>" + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "</color>」攻撃\n" +
                     "　空中で上下入力で攻撃が変化";
                }

                waitSeconds(4);

                nextTutorial(InputActionNum.attackInp, 5);
                break;

            case PopTextType.Skill:
                poptext = "「" + _action[(int)InputActionNum.skill1Inp].GetBindingDisplayString(bindingIndex) + "」スキル攻撃";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.skill1Inp].action.IsPressed())
                {
                    poptext = "「<color=red>" + _action[(int)InputActionNum.skill1Inp].GetBindingDisplayString(bindingIndex) + "</color>」スキル攻撃";
                }

                nextTutorial(InputActionNum.skill1Inp, 5);

                break;

            case PopTextType.Guard:
                poptext = "「" + _action[(int)InputActionNum.guardInp].GetBindingDisplayString(bindingIndex) + "」ガード";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.guardInp].action.IsPressed())
                {
                    poptext = "「<color=red>" + _action[(int)InputActionNum.guardInp].GetBindingDisplayString(bindingIndex) + "</color>」ガード";
                }

                nextTutorial(InputActionNum.guardInp, 5);

                break;
            case PopTextType.Blink:

                poptext = "「" + _action[(int)InputActionNum.blinkInp].GetBindingDisplayString(bindingIndex) + "」ブリンク";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.blinkInp].action.IsPressed())
                {
                    poptext = "「<color=red>" + _action[(int)InputActionNum.blinkInp].GetBindingDisplayString(bindingIndex) + "</color>」ブリンク";
                }

                nextTutorial(InputActionNum.blinkInp, 5);

                break;
            case PopTextType.tutorialBattle:
                // ここにチュートリアルバトルの処理
                poptext = "ボスを倒そう";
                break;
        }


        this.GetComponent<TextMesh>().text = poptext;
    }
    void FadeText()
    {
        switch (fadeMathod)
        {
            case 0:
                // テキストが消えていき完全に消えたら次のテキスト表示
                color.a -= fadeSpd * Time.deltaTime;
                this.GetComponent<TextMesh>().color = color;

                // 次表示させるテキストがチュートリアルの敵ならnextTextMeshも消す
                if (popTexttype + 1 == PopTextType.tutorialBattle)
                {
                    nextTexntMesh.GetComponent<TextMesh>().color = color;
                }

                if (color.a <= 0)
                {
                    fadeMathod++;
                    popTexttype++;
                }
                break;
            case 1:
                // 文字が浮かび上がり完全に浮かび上がったら次のテキストへ行ける
                if (color.a <= 1)
                {
                    color.a += popSpd * Time.deltaTime;
                    this.GetComponent<TextMesh>().color = color;
                }
                else if (popTexttype != PopTextType.tutorialBattle)
                {
                    isBossBatlle = true;
                }
                break;
        }
    }

    void waitSeconds(int sec)
    {
        timer += Time.deltaTime;
        if (sec <= timer)
        {
            timer = 0;
            isChange = true;
        }
    }

    void nextTutorial(InputActionNum inputNum, int _pushBottum)
    {
        if (isChange && _actionRef[(int)inputNum].action.triggered)
        {
            pushCount++;
            if (pushBottum <= pushCount)
            {
                pushCount = 0;
                pushBottum = _pushBottum;
                fadeMathod = 0;
                isChange = false;
            }
        }
    }
}
