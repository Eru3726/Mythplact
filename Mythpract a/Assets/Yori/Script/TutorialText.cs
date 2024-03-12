using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialText : MonoBehaviour
{
    // 入力関係
    [SerializeField]
    private List<InputActionReference> _actionRef;
    private List<InputAction> _action;
    public FadeManager Fade;

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
        Guard,
        Blink,
        tutorialBattle,
        num
    }

    private InputActionNum inputActionNum;
    [SerializeField]
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

    private string talks;

    private string[] words;

    Coroutine dialogCoroutine;

    // 文字のフェイド関係ここまで

    // チュートリアルバトル関係

    private bool isBossBatlle = false;

    private int talkNum = 0;

    [SerializeField, Header("hades")]
    HadesController hadesCon;

    private int endTalkNum = 0;

    [SerializeField, Header("フェイド")]
    private SpriteRenderer fadeSprite;

    private int fadeMathodSprite = 0;

    private Color fadeColor;

    [SerializeField, Header("HPゲージ")]
    private GameObject HpGarge;
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

        endTalkNum = 0;

        fadeSprite = fadeSprite.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        TutorialPopText();
        FadeText();
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
                // Tutorialスキップ
                TutorialSkip();
                switch (talkNum)
                {
                    case 0:
                        talks = "目 が 覚 め た か";
                        if (dialogCoroutine == null)
                        {
                            dialogCoroutine = StartCoroutine(Dialogue());
                        }
                        waitSeconds(4);
                        if (isChange)
                        {
                            dialogCoroutine = null;
                            isChange = false;
                            poptext = null;
                            talkNum++;
                        }
                        break;
                    case 1:
                        talks = "お 前 は ど れ だ け 強 く な れ る か 楽 し み だ";
                        if (dialogCoroutine == null)
                        {
                            dialogCoroutine = StartCoroutine(Dialogue());
                        }
                        waitSeconds(4);
                        if (isChange)
                        {
                            dialogCoroutine = null;
                            isChange = false;
                            poptext = null;
                            talkNum++;
                        }
                        break;
                    case 2:
                        talks = "動 作 確 認 を す る";
                        if (dialogCoroutine == null)
                        {
                            dialogCoroutine = StartCoroutine(Dialogue());
                        }
                        waitSeconds(4);
                        if (isChange)
                        {
                            isChange = false;
                            poptext = null;

                            fadeMathod = 0;
                            isChange = false;
                        }
                        break;
                }

                break;

            case PopTextType.Move:
                // Tutorialスキップ
                TutorialSkip();
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
                // Tutorialスキップ
                TutorialSkip();
                poptext = " 「" + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "」攻撃\n" +
                    "　空中で上下入力で攻撃が変化";
                if (_actionRef[(int)InputActionNum.attackInp].action.IsPressed())
                {
                    poptext = " 「<color=red>" + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "</color>」攻撃\n" +
                     "　空中で上下入力で攻撃が変化";
                    Debug.Log("攻撃"+_action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "+" +"ジャンプ"+ _action[(int)InputActionNum.jumpInp].GetBindingDisplayString(bindingIndex));
                }

                waitSeconds(4);

                nextTutorial(InputActionNum.attackInp, 5);
                break;

            case PopTextType.Guard:
                // Tutorialスキップ
                TutorialSkip();
                poptext = "「" + _action[(int)InputActionNum.guardInp].GetBindingDisplayString(bindingIndex) + "」ガード";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.guardInp].action.IsPressed())
                {
                    poptext = "「<color=red>" + _action[(int)InputActionNum.guardInp].GetBindingDisplayString(bindingIndex) + "</color>」ガード";
                }

                nextTutorial(InputActionNum.guardInp, 5);

                break;
            case PopTextType.Blink:
                // Tutorialスキップ
                TutorialSkip();
                poptext = "「" + _action[(int)InputActionNum.blinkInp].GetBindingDisplayString(bindingIndex) + "」ブリンク";

                waitSeconds(4);

                if (_actionRef[(int)InputActionNum.blinkInp].action.IsPressed())
                {
                    poptext = "「<color=red>" + _action[(int)InputActionNum.blinkInp].GetBindingDisplayString(bindingIndex) + "</color>」ブリンク";
                }

                nextTutorial(InputActionNum.blinkInp, 5);
                talkNum = 0;

                break;
            case PopTextType.tutorialBattle:
                // ここにチュートリアルバトルの処理
                switch (endTalkNum)
                {
                    case 0:
                        talks = "問 題 な い よ う だ な";
                        if (dialogCoroutine == null)
                        {
                            poptext = null;
                            Debug.Log(popTexttype);
                            fadeColor = fadeSprite.color;
                            dialogCoroutine = StartCoroutine(Dialogue());
                        }
                        waitSeconds(6);
                        if (isChange)
                        {

                            switch (fadeMathodSprite)
                            {
                                case 0:
                                    if (fadeColor.a <= 1)
                                    {
                                        fadeColor.a += popSpd * Time.deltaTime;
                                        fadeSprite.color = fadeColor;
                                    }
                                    else
                                    {
                                        poptext = null;
                                        fadeMathodSprite++;
                                        HpGarge.SetActive(true);
                                    }
                                    break;
                                case 1:
                                    fadeColor.a -= fadeSpd * Time.deltaTime;
                                    fadeSprite.color = fadeColor;

                                    if (fadeColor.a <= 0)
                                    {
                                        fadeMathodSprite++;
                                        dialogCoroutine = null;
                                        talks = null;
                                        endTalkNum++;
                                        fadeColor = fadeSprite.color;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 1:
                        talks = "行 く ぞ";
                        if (dialogCoroutine == null)
                        {
                            poptext = null;

                            dialogCoroutine = StartCoroutine(Dialogue());
                            isChange = false;
                        }
                        waitSeconds(3);
                        // テキスト送りが終わったら速攻攻撃
                        if (isChange)
                        {
                            hadesCon.actNo = 2;
                            hadesCon.methodNo = 0;
                            isChange = false;
                            endTalkNum++;
                        }
                        break;
                    case 2:
                        waitSeconds(6);
                        if (isChange)
                        {
                            poptext = null;
                            isChange = false;
                        }
                        Debug.Log("死ぬの待機中");
                        if (hadesCon.dieFlg)
                        {
                            endTalkNum++;
                            dialogCoroutine = null;
                            timer = 0;
                        }
                        break;
                    case 3:
                        talks = "よ く や っ た \nス キ ル を 渡 し て や る";
                        if (dialogCoroutine == null)
                        {
                            dialogCoroutine = StartCoroutine(Dialogue());
                        }
                        waitSeconds(4);
                        if (isChange)
                        {
                            //dialogCoroutine = null;
                            //isChange = false;
                            //poptext = null;
                            //endTalkNum++;
                            Fade.Fadeout();// シーン移動
                        }
                        break;
                    //case 4:
                    //    talks = "貴 様 に は こ れ か ら 様 々 な 世 界 へ と 赴 き\n そ の 世 界 で 貴 様 の 実 力 を 示 す の だ";
                    //    if (dialogCoroutine == null)
                    //    {
                    //        dialogCoroutine = StartCoroutine(Dialogue());
                    //    }
                    //    waitSeconds(6);
                    //    if (isChange)
                    //    {
                    //        Fade.Fadeout();// シーン移動
                    //    }
                    //    break;
                }
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
                    if (popTexttype + 1 == PopTextType.tutorialBattle)
                    {
                        isBossBatlle = true;
                        dialogCoroutine = null;
                        poptext = null;
                    }
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

    private IEnumerator Dialogue()
    {
        // 半角スペースで文字を分割する。
        words = talks.Split(' ');

        foreach (var word in words)
        {
            // 0.1秒刻みで１文字ずつ表示する。
            poptext = poptext + word;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void TutorialSkip()
    {
        // Tutorialスキップ
        if (_actionRef[(int)InputActionNum.escInp].action.triggered)
        {
            poptext = " ";
            StopCoroutine(dialogCoroutine);
            dialogCoroutine = null;
            popTexttype = PopTextType.tutorialBattle;
            Debug.Log(popTexttype);
            nextTexntMesh.SetActive(false);

            talks = null;
            Debug.Log(dialogCoroutine);
            talkNum = 3;
        }
    }
}
