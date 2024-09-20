using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SkillTutorial : MonoBehaviour
{
    private enum SkillLog
    {
        SetSkillDescription,
        DoSetSkill,
        PassiveSkillDescription,
        GameDescription,
        GoodByHades,
        Num
    }
    [SerializeField]
    public FadeManager Fade;

    private string poptext;

    SkillLog skillLogPhase;

    private string talks;

    private string[] words;

    float methodTimer = 0;

    Coroutine dialogCoroutine;

    [HideInInspector]
    public bool setSkill;

    [SerializeField, Header("TextMesh")]
    private TextMesh textMesh;

    [SerializeField, Header("テキストボックスの位置")]
    private GameObject popTextBox1, popTextBox2, popTextBox3;

    [SerializeField]
    private InputActionReference selectRef;

    //private int bindingIndex;

    private bool isCoroutine;

    [SerializeField, Header("背景")]
    private GameObject textBackGround,hades;

    [SerializeField,Header("ぼたん")]
    Button button, button2, button3, button4, button5, button6;


    [SerializeField]
    private List<InputActionReference> _actionRef;
    private List<InputAction> _action;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = textMesh.GetComponent<TextMesh>();
        setSkill = false;
        isCoroutine = false;
        _actionRef[0].action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        SkillDescription();
    }
    [SerializeField, Header("しゃべてる箱")]
    private GameObject textBox;
    void SkillDescription()
    {        
        //if (Gamepad.current == null) bindingIndex = 0;
        //else bindingIndex = 1;
        switch (skillLogPhase)
        {
            case SkillLog.SetSkillDescription:
                button.enabled = false;
                button2.enabled = false;
                button3.enabled = false;
                button4.enabled = false;
                button5.enabled = false;
                button6.enabled = false;
                talks = "こ こ で は 自 身 の ス キ ル を\n セ ッ ト す る こ と が で き る";
                if (dialogCoroutine == null)
                {
                    dialogCoroutine = StartCoroutine(Dialogue());
                }
                methodTimer += Time.deltaTime;
                if (methodTimer >= 5)
                {
                    dialogCoroutine = null;
                    skillLogPhase++;
                    poptext = null;
                }
                TutorialSkip();
                break;
            case SkillLog.DoSetSkill:
                
                talks = "左 側 の ス キ ル ス ロ ッ ト を 「 カ ー ソ ル 」 で   選 択  し 、\n ス キ ル を 選 択 、そ し て  " +
                    "\n 画 面 真 ん 中 の ス ロ ッ ト に ス キ ル を セ ッ ト し て み ろ  ";
                if (dialogCoroutine == null)
                {
                    dialogCoroutine = StartCoroutine(Dialogue());
                }
                if (!isCoroutine)
                {
                    button.enabled = true;
                }
                TutorialSkip();
                break;
            case SkillLog.PassiveSkillDescription:
                TutorialSkip();
                if (setSkill)
                {
                    textBackGround.SetActive(true);
                    hades.SetActive(true);
                    methodTimer += Time.deltaTime;
                    talks = "ス キ ル を セ ッ ト で き た な \nい ま セ ッ ト し た ア ク テ ィ ブ ス キ ル 以 外 に も \n" +
                        " 常 時 発 動 す る パ ッ シ ブ ス キ ル も あ る";
                    if (dialogCoroutine == null)
                    {
                        dialogCoroutine = StartCoroutine(Dialogue());
                    }
                    if (methodTimer >= 7)
                    {
                        poptext = null;
                        dialogCoroutine = null;
                        methodTimer = 0;
                        skillLogPhase++;
                    }
                }
                TutorialSkip();
                break;
            case SkillLog.GameDescription:
                methodTimer += Time.deltaTime;
                talks = "貴 様 に は こ れ か ら 様 々 な 世 界 へ と 行 っ て も ら う \n " +
                    "そ こ で 神 を 倒 し 、 ス キ ル を 手 に 入 れ 、 強 く な っ て 見 せ ろ";
                if (dialogCoroutine == null)
                {
                    dialogCoroutine = StartCoroutine(Dialogue());
                }
                if (methodTimer >= 7)
                {
                    methodTimer = 0;
                    poptext = null;
                    dialogCoroutine = null;
                    skillLogPhase++;
                }
                break;
            case SkillLog.GoodByHades:
                methodTimer += Time.deltaTime;
                talks = "貴 様 に は期 待 し て い る ";
                if (dialogCoroutine == null)
                {
                    dialogCoroutine = StartCoroutine(Dialogue());
                }
                if (methodTimer >= 3)
                {
                    Fade.Fadeout();
                }
                break;
            default:
                Debug.Log("なんかおかしいことになってるぞ");
                break;
        }

        textMesh.text = poptext;
    }
    private void TutorialSkip()
    {
        // エスケープに値するボタンを押したらスキップ
        if (_actionRef[0].action.triggered)
        {
            skillLogPhase = SkillLog.GameDescription;
            talks = " ";
            poptext = " ";
            StopCoroutine(dialogCoroutine);
            dialogCoroutine = null;
            words = null;
            poptext = null;
            methodTimer = 0;
        }
    }
    private IEnumerator Dialogue()
    {
        isCoroutine = true;
        // 半角スペースで文字を分割する。
        words = talks.Split(' ');

        foreach (var word in words)
        {
            // 0.1秒刻みで１文字ずつ表示する。
            poptext = poptext + word;
            yield return new WaitForSeconds(0.1f);

        }
        isCoroutine = false;
    }

    
}

