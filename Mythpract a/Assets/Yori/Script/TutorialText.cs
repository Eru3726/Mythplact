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
    }

    private enum PopTextType
    {
        Move,
        Jump,
        Attack,
        Skill,
        Guard,
        Blink,
        tutorialBattle
    }

    private InputActionNum inputActionNum;
    private PopTextType popTexttype;

    private string poptext;

    private int bindingIndex = 0;

    // 入力関係ここまで

    // 文字のフェイド関係

    private Color color;

    [SerializeField, Header("文字の出てくる速度")]
    private float popSpd;

    [SerializeField, Header("文字の消える速度")]
    private float fadeSpd;

    private int fadeMathod = 1;

    [SerializeField, Header("「次へ」って書いてあるテキストメッシュ")]
    private GameObject nextTexntMesh;

    // 文字のフェイド関係ここまで

    // チュートリアルバトル関係

    [SerializeField, Header("チュートリアルの敵")]
    private TextMesh tutorialEnemy;

    private bool canChange = false;

    void Start()
    {
        // listにアタッチした奴を格納
        // InputActionNumの順番通りにアタッチしないと出てくるテキストが違うものになる。何とかしたかった
        _action = new List<InputAction>();
        for (inputActionNum = 0; (int)inputActionNum < _actionRef.Count; inputActionNum++)
        {
            _action.Add(_actionRef[(int)inputActionNum]);
        }


        color = this.GetComponent<TextMesh>().color;
        color.a = 0;
        this.GetComponent<TextMesh>().color = color;

        canChange = false;
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
            case PopTextType.Move:
                poptext = " 「" + _action[(int)InputActionNum.leftInp].GetBindingDisplayString(bindingIndex) + ","
                    + _action[(int)InputActionNum.rightInp].GetBindingDisplayString(bindingIndex) + "」移動";
                if (canChange&& _actionRef[0].action.triggered)
                {

                }
                break;
            case PopTextType.Jump:
                poptext = " 「" + _action[(int)InputActionNum.jumpInp].GetBindingDisplayString(bindingIndex) + "」 ジャンプ"
                    + "\nジャンプ中にもう一度\n「" + _action[(int)InputActionNum.jumpInp].GetBindingDisplayString(bindingIndex) + "」二段ジャンプ";
                break;
            case PopTextType.Attack:
                poptext = " 「" + _action[(int)InputActionNum.attackInp].GetBindingDisplayString(bindingIndex) + "」攻撃\n" +
                    "　空中で上下入力で攻撃が変化";
                break;
            case PopTextType.Skill:
                poptext = "「" + _action[(int)InputActionNum.skill1Inp].GetBindingDisplayString(bindingIndex) + "」スキル攻撃";
                break;
            case PopTextType.Guard:
                poptext = "「" + _action[(int)InputActionNum.guardInp].GetBindingDisplayString(bindingIndex) + "」ガード";
                break;
            case PopTextType.Blink:
                poptext = "「" + _action[(int)InputActionNum.blinkInp].GetBindingDisplayString(bindingIndex) + "」ブリンク";
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
                    canChange = true;
                }
                break;
        }
    }
}
