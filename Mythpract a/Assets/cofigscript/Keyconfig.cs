using UnityEngine;
using UnityEngine.UI;
using System;

public class Keyconfig : MonoBehaviour
{
    public Controllerconnect conconnect;               
    public Pickkey pickkey;

    public string keyStr;                        //キーコンをストリングに入れるためのやつ
    public KeyCode codechange;

    public GameObject rightbutton;              //全部ボタンぶち込む
    public GameObject leftbutton;
    public GameObject downbutton;
    public GameObject jumpbutton;
    public GameObject dashbutton;
    public GameObject attackbutton;
    public GameObject healbutton;
    public GameObject interactbutton;

    

    public Righttext rtx;              //全部のボタンに応じたテキストぶち込む
    public Rightkey rk;
    public Lefttext ltx;
    public Leftkey lk;
    public Downkey dwk;
    public Downtext dwtx;
    public Jumptext jtx;
    public Jumpkey jk;
    public Dashtext dtx;
    public Dashkey dk;
    public Attacktext atx;
    public Attackkey ak;
    public Healtext htx;
    public Healkey hk;
    public Interactkey ik;
    public Interacttext itx;

    //キーを変えるとき他のコンフィグも変わらないようにするためのやつ
    public bool right;
    public bool left;
    public bool down;
    public bool jump;
    public bool attack;
    public bool dash;
    public bool heal;
    public bool interact;

    public bool condec = false;                //コントローラーの決定ボタンもキーコンで設定できるようにするためのもの
    void Start()
    {
        right = false;
        left = false;
        down = false;
        jump = false;
        attack = false;
        dash = false;
        heal = false;
        interact = false;
    }


    void Update()
    {
        //if (button == true)
        //{
        //    pickkey.ConClick();
        //}

        //設定するボタン以外をフォルスに
        if (right == true)
        {
            rightbutton.GetComponent<Button>().enabled = false;
            left = false;
            down = false;
            jump = false;
            attack = false;
            dash = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (left == true)
        {
            leftbutton.GetComponent<Button>().enabled = false;
            right = false;
            down = false;
            jump = false;
            attack = false;
            dash = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (down == true)
        {
            downbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            jump = false;
            attack = false;
            dash = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (jump == true)
        {
            jumpbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            down = false;
            attack = false;
            dash = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (attack == true)
        {
            attackbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            down = false;
            jump = false;
            dash = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (dash == true)
        {
            dashbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            down = false;
            jump = false;
            attack = false;
            heal = false;
            interact = false;
            keycheck();
        }
        else if (heal == true)
        {
            healbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            down = false;
            jump = false;
            attack = false;
            dash = false;
            interact = false;
            keycheck();
        }
        else if (interact == true)
        {
            interactbutton.GetComponent<Button>().enabled = false;
            right = false;
            left = false;
            down = false;
            jump = false;
            attack = false;
            dash = false;
            heal = false;
            keycheck();
        }
    }

    public void keycheck()
    {
        if (Input.GetAxisRaw("RT") != 0)               //オリジナルに作ったキーコードを設定する
        {
            codechange = (KeyCode)CustomKeycode.RT; 
            //Debug.Log("codechange" + codechange);
            keyStr = codechange.ToString();
            KeyChange();
        }
        else if (Input.GetAxisRaw("LT") != 0)
        {
            codechange = (KeyCode)CustomKeycode.LT;
            //Debug.Log("codechange" + codechange);
            keyStr = codechange.ToString();
            KeyChange();
        }
        if (Input.anyKeyDown && !(Input.GetKeyDown(KeyCode.Escape)) && !(Input.GetKeyDown(KeyCode.JoystickButton7)))
        {
            //keyStr = Input.inputString;
            //キーボードの押されたキーを取得
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (code == KeyCode.JoystickButton0)
                {
                    condec = true;
                }
                //取得したキーをcodechangeにぶちこむ
                if (Input.GetKeyDown(code))
                {
                    codechange = code;
                    if (codechange != KeyCode.None)
                    {
                        Debug.Log("codechange" + codechange);
                        keyStr = codechange.ToString();      //キーコードをストリング型に
                    }
                    KeyChange();              //下へ続く
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            right = false;
            left = false;
            down = false;
            jump = false;
            attack = false;
            dash = false;
            heal = false;
            interact = false;
            rightbutton.GetComponent<Button>().enabled = true;
            leftbutton.GetComponent<Button>().enabled = true;
            downbutton.GetComponent<Button>().enabled = true;
            attackbutton.GetComponent<Button>().enabled = true;
            dashbutton.GetComponent<Button>().enabled = true;
            jumpbutton.GetComponent<Button>().enabled = true;
            healbutton.GetComponent<Button>().enabled = true;
            interactbutton.GetComponent<Button>().enabled = true;
            Debug.Log("ボタン復活");
        }
        //Debug.Log("keycheck");
    }
    public void KeyChange()
    {
        //if (keyStr != "Escape" || keyStr != "Q"||conconnect.ConConnect&&keyStr == "None")

        {
            for (int i = 0; i < 10; i++)   //ジョイスティック10個分確かめる
            {
                if (keyStr == "JoystickButton" + i)
                {
                    if (i == 0)
                    {
                        keyStr = "a";
                    }
                    if (i == 1)
                    {
                        keyStr = "b";
                    }
                    if (i == 2)
                    {
                        keyStr = "x";
                    }
                    if (i == 3)
                    {
                        keyStr = "y";
                    }
                    if (i == 4)
                    {
                        keyStr = "L1";
                    }
                    if (i == 5)
                    {
                        keyStr = "R1";
                    }
                    if (i == 6)
                    {
                        keyStr = "back";
                    }
                    if (i == 7)
                    {
                        keyStr = "start";
                    }
                    if (i == 8)
                    {
                        keyStr = "L3";
                    }
                    if (i == 9)
                    {
                        keyStr = "R3";
                    }
                    //Debug.Log("KeyStr " + keyStr);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (keyStr == "Joystick1Button" + i)
                {
                    if (i == 0)
                    {
                        keyStr = "a";
                    }
                    if (i == 1)
                    {
                        keyStr = "b";
                    }
                    if (i == 2)
                    {
                        keyStr = "x";
                    }
                    if (i == 3)
                    {
                        keyStr = "y";
                    }
                    if (i == 4)
                    {
                        keyStr = "L1";
                    }
                    if (i == 5)
                    {
                        keyStr = "R1";
                    }
                    if (i == 6)
                    {
                        keyStr = "back";
                    }
                    if (i == 7)
                    {
                        keyStr = "start";
                    }
                    if (i == 8)
                    {
                        keyStr = "L3";
                    }
                    if (i == 9)
                    {
                        keyStr = "R3";
                    }
                    //Debug.Log("KeyStr " + keyStr);
                }
            }

            //色んなキーコード名を分かりやすく変更する
            if (keyStr == "JoystickButton18")
            {
                keyStr = "L2";
            }
            else if (keyStr == "JoystickButton19")
            {
                keyStr = "R2";
            }
            else if (keyStr == "LeftShift")
            {
                keyStr = "LShift";
            }
            else if (keyStr == "RightShift")
            {
                keyStr = "RShift";
            }
            else if (keyStr == "LeftControl")
            {
                keyStr = "LControl";
            }
            else if (keyStr == "RightControl")
            {
                keyStr = "RControl";
            }
            else if (keyStr == "Backspace")
            {
                keyStr = "back";
            }
            else if (keyStr == "RightArrow")
            {
                keyStr = "→";
            }
            else if (keyStr == "LeftArrow")
            {
                keyStr = "←";
            }
            else if (keyStr == "UpArrow")
            {
                keyStr = "↑";
            }
            else if (keyStr == "DownArrow")
            {
                keyStr = "↓";
            }
            //Debug.Log(keyStr);
            if (right == true)
            {
                //キーがかぶらないようにするやつ
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx)||
                    keyStr == "None")
                {
                    rtx.righttextchange();     //テキストを変更する
                    rk.rightkeychange();       //キーを変更する
                    right = false;             //変更終わり
                    Debug.Log("right");
                }
                //else if (keyStr == "None")
                //{
                //    rtx.righttextchange();
                //    rk.rightkeychange();
                //    right = false;
                //    //Debug.Log("right");
                //}
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.rightkey;
                    GameData.rightkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.righttx;
                    GameData.righttx = keyStr;
                    Debug.Log("同じキーがあります");
                    right = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    right = false;
                }
            }
            else if (left == true)
            {
                //キーがかぶらないようにするやつ
                if (!(keyStr == GameData.righttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx)||
                    keyStr == "None")
                {
                    ltx.lefttextchange();     //テキストを変更する
                    lk.leftkeychange();       //キーを変更する
                    left = false;             //変更終わり
                    //Debug.Log("right");
                }
                //else if (keyStr == "None")
                //{
                //    rtx.righttextchange();
                //    rk.rightkeychange();
                //    right = false;
                //    //Debug.Log("right");
                //}
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.leftkey;
                    GameData.leftkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.lefttx;
                    GameData.lefttx = keyStr;
                    Debug.Log("同じキーがあります");
                    left = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    left = false;
                }
            }
            else if (down == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.righttx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx)||
                    keyStr == "None")
                {
                    dwtx.downtextchange();
                    dwk.downkeychange();
                    down = false;
                    //Debug.Log("down");
                }
                //else if (keyStr == "None")
                //{
                //    dwtx.downtextchange();
                //    dwk.downkeychange();
                //    down = false;
                //    //Debug.Log("down");
                //}

                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.downkey;
                    GameData.downkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.downtx;
                    GameData.downtx = keyStr;
                    Debug.Log("同じキーがあります");
                    down = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    down = false;
                }
            }
            else if (jump == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.righttx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx))
                {
                    jtx.jumptextchange();
                    jk.jumpkeychange();
                    jump = false;
                    //Debug.Log("jump");
                }
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.jumpkey;
                    GameData.jumpkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.jumptx;
                    GameData.jumptx = keyStr;
                    Debug.Log("同じキーがあります");
                    jump = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    jump = false;
                }
            }
            else if (attack == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.righttx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx))
                {
                    atx.attacktextchange();
                    ak.attackkeychange();
                    attack = false;
                    //Debug.Log("atack");
                }
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.attackkey;
                    GameData.attackkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.attacktx;
                    GameData.attacktx = keyStr;
                    Debug.Log("同じキーがあります");
                    attack = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    attack = false;
                }
            }
            else if (dash == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.righttx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.interacttx))
                {
                    dtx.dashtextchange();
                    dk.dashkeychange();
                    dash = false;
                    //Debug.Log("dash");
                }
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.dashkey;
                    GameData.dashkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.dashtx;
                    GameData.dashtx = keyStr;
                    Debug.Log("同じキーがあります");
                    dash = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    dash = false;
                }
            }
            else if (heal == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.righttx ||
                    keyStr == GameData.interacttx))
                {
                    htx.menutextchange();
                    hk.menukeychange();
                    heal = false;
                    //Debug.Log("heal");
                }
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else if (keyStr == GameData.interacttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.healkey;
                    GameData.healkey = GameData.interactkey;
                    GameData.interactkey = holdkey;
                    GameData.interacttx = GameData.healtx;
                    GameData.healtx = keyStr;
                    Debug.Log("同じキーがあります");
                    heal = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    heal = false;
                }
            }
            else if (interact == true)
            {
                if (!(keyStr == GameData.lefttx ||
                    keyStr == GameData.downtx ||
                    keyStr == GameData.dashtx ||
                    keyStr == GameData.jumptx ||
                    keyStr == GameData.attacktx ||
                    keyStr == GameData.healtx ||
                    keyStr == GameData.righttx))
                {
                    itx.interacttextchange();
                    ik.interactkeychange();
                    interact = false;
                    //Debug.Log("interact");
                }
                else if (keyStr == GameData.righttx)
                {
                    KeyCode holdkey;      //キーの一時保存
                    //キーの入れ替え
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.rightkey;
                    GameData.rightkey = holdkey;
                    GameData.righttx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.downtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.downkey;
                    GameData.downkey = holdkey;
                    GameData.downtx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.attacktx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.attackkey;
                    GameData.attackkey = holdkey;
                    GameData.attacktx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.lefttx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.leftkey;
                    GameData.leftkey = holdkey;
                    GameData.lefttx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.jumptx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.jumpkey;
                    GameData.jumpkey = holdkey;
                    GameData.jumptx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.dashtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.dashkey;
                    GameData.dashkey = holdkey;
                    GameData.dashtx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else if (keyStr == GameData.healtx)
                {
                    KeyCode holdkey;
                    holdkey = GameData.interactkey;
                    GameData.interactkey = GameData.healkey;
                    GameData.healkey = holdkey;
                    GameData.healtx = GameData.interacttx;
                    GameData.interacttx = keyStr;
                    Debug.Log("同じキーがあります");
                    interact = false;
                }
                else
                {
                    Debug.Log("なんかダメ");
                    interact = false;
                }
            }
            else
            {
                Debug.Log("そのキーはだめ");
                right = false;
                left = false;
                down = false;
                jump = false;
                attack = false;
                dash = false;
                heal = false;
                interact = false;
            }
        }
        //else
        //{
        //Debug.Log("なんかダメ");
        //}
        
        rightbutton.GetComponent<Button>().enabled = true;
        leftbutton.GetComponent<Button>().enabled = true;
        downbutton.GetComponent<Button>().enabled = true;
        attackbutton.GetComponent<Button>().enabled = true;
        dashbutton.GetComponent<Button>().enabled = true;
        jumpbutton.GetComponent<Button>().enabled = true;
        healbutton.GetComponent<Button>().enabled = true;
        interactbutton.GetComponent<Button>().enabled = true;
        Debug.Log("ボタン復活");
    }
}

