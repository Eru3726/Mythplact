using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    private SkillLog skillLogPhase;

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

    private bool isCoroutine;

    [SerializeField, Header("背景")]
    private GameObject textBackGround, hades;

    [SerializeField, Header("ぼたん")]
    Button button, button2, button3, button4, button5, button6;

    [SerializeField, Header("しゃべてる箱")]
    private GameObject textBox;

    [SerializeField]
    private List<InputActionReference> _actionRef;
    private List<InputAction> _action;

    [SerializeField, Header("スプライトマスク")]
    private GameObject spriteMaskGameObject;

    private Vector3 serializeSpriteMaskScale;

    private float plusScaleX = 0.4f;
    private float plusScaleY = 0.2f;

    public bool selectedSkill = false;

    [SerializeField]
    private GameObject SpriteObj;

    int SkillSelectNum;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = textMesh.GetComponent<TextMesh>();
        setSkill = false;
        isCoroutine = false;
        _actionRef[0].action.Enable();
        serializeSpriteMaskScale = spriteMaskGameObject.transform.localScale;
        selectedSkill = false;
    }

    // Update is called once per frame
    void Update()
    {
        SkillDescription();
    }

    void SkillDescription()
    {
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
                    SetSkillTutorial();
                    button.enabled = true;
                    if (setSkill)
                    {
                        ResetSpriteMask();
                        methodTimer = 0;
                        skillLogPhase++;
                        dialogCoroutine = null;
                        poptext = null;
                    }
                }

                TutorialSkip();
                break;

            case SkillLog.PassiveSkillDescription:
                textBackGround.SetActive(true);
                hades.SetActive(true);

                talks = "ス キ ル を セ ッ ト で き た な \nい ま セ ッ ト し た ア ク テ ィ ブ ス キ ル 以 外 に も \n" +
                    " 常 時 発 動 す る パ ッ シ ブ ス キ ル も あ る";
                if (dialogCoroutine == null)
                {
                    dialogCoroutine = StartCoroutine(Dialogue());
                }
                if (!isCoroutine)
                {
                    methodTimer += Time.deltaTime;
                    if (methodTimer >= 3)
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
            ResetSpriteMask();
        }
    }

    private void SetSkillTutorial()
    {
        Debug.Log(SkillSelectNum);
        switch (SkillSelectNum)
        {
            case 0:
                // 一回目の注目
                SpriteMaskMove(3, 1);
                break;
            case 1:
                // ポジションを上にあげる
                spriteMaskGameObject.transform.position += new Vector3(0, 0.6f, 0);
                SkillSelectNum++;
                break;
            case 2:
                // 二回目の注目
                SpriteMaskMove(3.5f, 1.5f);
                break;
            case 3:
                spriteMaskGameObject.transform.position = new Vector3(-0.7f, 0.5f, 0);
                SkillSelectNum++;
                break;
            case 4:
                SpriteMaskMove(4.5f, 4.7f);
                break;

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

    public void ResetSpriteMask()
    {
        spriteMaskGameObject.transform.localScale = serializeSpriteMaskScale;
        SpriteObj.SetActive(false);
    }

    private void SpriteMaskMove(float xScale, float yScale)
    {
        SpriteObj.SetActive(true);
        if (spriteMaskGameObject.transform.localScale.x > xScale)
        {
            spriteMaskGameObject.transform.localScale -= new Vector3(plusScaleX, 0, 0);
        }
        if (spriteMaskGameObject.transform.localScale.y > yScale)
        {
            spriteMaskGameObject.transform.localScale -= new Vector3(0, plusScaleY, 0);
        }
    }

    public void SelectSkill()
    {
        ResetSpriteMask();
        SkillSelectNum++;
    }
}

