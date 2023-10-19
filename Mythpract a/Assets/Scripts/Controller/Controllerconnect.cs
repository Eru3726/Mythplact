using UnityEngine;

public class Controllerconnect : MonoBehaviour
{
    bool conconnect = false;    //コントローラーを接続しているかどうか
    string[] connect;           //コントローラーの種類を判別するためのやつ
    public Keyconfig keycon;    //キーコンをコントローラー接続時に変えるためにぶち込む

    //コントローラー接続のプロパティを設定
    public bool ConConnect       
    {
        get { return conconnect; }
        
        set { conconnect = value; }
    }

    void Start()
    {
        keyread();
    }

    void Update()
    {
        if (Input.GetJoystickNames().Length > 0)  //コントローラー接続してるかどうか
        {
            connect = Input.GetJoystickNames();  //接続しているコントローラーの名前を取得
            if (connect[0] == ("Controller (JC-U3613M - Xinput Mode)") && conconnect == false)　　//コントローラー接続
            {
                conread();  //キーコンをコントローラー用に変更
                //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.attack == false && keycon.dash == false && keycon.heal == false && keycon.interact == false)
                {
                    conconnect = true;　　　　//こいつはプロパティ
                }
                Debug.Log("コントローラー接続" + conconnect);
            }
        }

        if (connect[0] == "" && conconnect == true)     //コントローラー非接続
        {
            keyread();       //キーコンをキーボード用に変更
            //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.attack == false && keycon.dash == false && keycon.heal == false && keycon.interact == false)
            {
                conconnect = false;　　　　//こいつはプロパティ
            }
            Debug.Log("コントローラー接続" + conconnect);
        }
    }

    //キーコンをコントローラー用に変更するメソッド
    public void conread()
    {
        //GameData.keyrightkey = GameData.rightkey;
        //GameData.keyleftkey = GameData.leftkey;
        //GameData.keyjumpkey = GameData.jumpkey;
        //GameData.keyattackkey = GameData.attackkey;
        //GameData.keydashkey = GameData.dashkey;
        //GameData.keyhealkey = GameData.healkey;
        //GameData.keyinteractkey = GameData.interactkey;
        //GameData.keydownkey = GameData.downkey;
        //Debug.Log(GameData.keyrightkey);
        //Debug.Log(GameData.keyleftkey);
        //Debug.Log(GameData.keydownkey);
        //Debug.Log(GameData.keyjumpkey);
        //Debug.Log(GameData.keyattackkey);
        //Debug.Log(GameData.keydashkey);
        //Debug.Log(GameData.keyhealkey);
        //Debug.Log(GameData.keyinteractkey);
        GameData.rightkey = KeyCode.None;　　　　　　　　//GameDataのキーを変える
        keycon.keyStr = GameData.rightkey.ToString();　　//変えたキーをストリング型で取得
        Debug.Log(keycon.keyStr);
        keycon.right = true;                             //どのキーを変えるかを判別するbool文をtrueに
        keycon.codechange = GameData.rightkey;           //変更するキーコードをぶち込んでおく
        keycon.KeyChange();                              //キーを変更するメソッドを使用     //以下同じ
        Debug.Log("right" + GameData.rightkey);
        GameData.leftkey = KeyCode.None;
        keycon.keyStr = GameData.leftkey.ToString();
        Debug.Log(keycon.keyStr);
        keycon.left = true;
        keycon.codechange = GameData.leftkey;
        keycon.KeyChange();
        Debug.Log("left" + GameData.leftkey);
        GameData.downkey = GameData.condownkey;
        keycon.keyStr = GameData.downkey.ToString();
        Debug.Log(keycon.keyStr);
        keycon.down = true;
        keycon.codechange = GameData.downkey;
        keycon.KeyChange();
        //Debug.Log("down" + GameData.downkey);
        GameData.jumpkey = GameData.conjumpkey;
        keycon.keyStr = GameData.jumpkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.jump = true;
        keycon.codechange = GameData.jumpkey;
        keycon.KeyChange();
        //Debug.Log("jump" + GameData.jumpkey);
        GameData.attackkey = GameData.conattackkey;
        keycon.keyStr = GameData.attackkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.attack = true;
        keycon.codechange = GameData.attackkey;
        keycon.KeyChange();
        //Debug.Log("attack" + GameData.attackkey);
        GameData.dashkey = GameData.condashkey;
        keycon.keyStr = GameData.dashkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.dash = true;
        keycon.codechange = GameData.dashkey;
        keycon.KeyChange();
        //Debug.Log("dash" + GameData.dashkey);
        GameData.healkey = GameData.conhealkey;
        keycon.keyStr = GameData.healkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.heal = true;
        keycon.codechange = GameData.healkey;
        keycon.KeyChange();
        //Debug.Log("heal" + GameData.healkey);
        GameData.interactkey = GameData.coninteractkey;
        keycon.keyStr = GameData.interactkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.interact = true;
        keycon.codechange = GameData.interactkey;
        keycon.KeyChange();
        //Debug.Log("interact" + GameData.interactkey);
    }

    //キーコンをキーボード用に変更するメソッド
    public void keyread()
    {
        //GameData.conjumpkey = GameData.jumpkey;
        //GameData.conattackkey = GameData.attackkey;
        //GameData.condashkey = GameData.dashkey;
        //GameData.conhealkey = GameData.healkey;
        //GameData.coninteractkey = GameData.interactkey;
        //Debug.Log(GameData.conjumpkey);
        //Debug.Log(GameData.conattackkey);
        //Debug.Log(GameData.condashkey);
        //Debug.Log(GameData.conhealkey);
        //Debug.Log(GameData.coninteractkey);
        GameData.rightkey = GameData.keyrightkey;
        keycon.keyStr = GameData.rightkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.right = true;
        Debug.Log("keyright" + GameData.keyrightkey);
        keycon.codechange = GameData.rightkey;
        keycon.KeyChange();
        //Debug.Log("right" + GameData.rightkey);
        GameData.leftkey = GameData.keyleftkey;
        keycon.keyStr = GameData.leftkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.left = true;
        //Debug.Log("keyleft" + GameData.keyleftkey);
        keycon.codechange = GameData.leftkey;
        keycon.KeyChange();
        //Debug.Log("left" + GameData.leftkey);
        GameData.jumpkey = GameData.keyjumpkey;
        keycon.keyStr = GameData.jumpkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.jump = true;
        //Debug.Log("keyjump" + GameData.keyjumpkey);
        keycon.codechange = GameData.jumpkey;
        keycon.KeyChange();
        //Debug.Log("jump" + GameData.jumpkey);
        GameData.attackkey = GameData.keyattackkey;
        keycon.keyStr = GameData.attackkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.attack = true;
        //Debug.Log("keyattack" + GameData.keyattackkey);
        keycon.codechange = GameData.attackkey;
        keycon.KeyChange();
        //Debug.Log("attack" + GameData.attackkey);
        GameData.dashkey = GameData.keydashkey;
        keycon.keyStr = GameData.dashkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.dash = true;
        //Debug.Log("keydash" + GameData.keydashkey);
        keycon.codechange = GameData.dashkey;
        keycon.KeyChange();
        //Debug.Log("dash" + GameData.dashkey);
        GameData.healkey = GameData.keyhealkey;
        keycon.keyStr = GameData.healkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.heal = true;
        //Debug.Log("keyheal" + GameData.keyhealkey);
        keycon.codechange = GameData.healkey;
        keycon.KeyChange();
        //Debug.Log("heal" + GameData.healkey);
        GameData.downkey = GameData.keydownkey;
        keycon.keyStr = GameData.downkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.down = true;
        //Debug.Log("keydown" + GameData.keydownkey);
        keycon.codechange = GameData.downkey;
        keycon.KeyChange();
        //Debug.Log("down" + GameData.downkey);
        GameData.interactkey = GameData.keyinteractkey;
        keycon.keyStr = GameData.interactkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.interact = true;
        //Debug.Log("keyinteract" + GameData.keyinteractkey);
        keycon.codechange = GameData.interactkey;
        keycon.KeyChange();
        //Debug.Log("interact" + GameData.interactkey);
    }

    //キーボード用のキーコンを保存
    public void keysave()
    {
        GameData.keyrightkey = GameData.rightkey;
        GameData.keyleftkey = GameData.leftkey;
        GameData.keydownkey = GameData.downkey;
        GameData.keyjumpkey = GameData.jumpkey;
        GameData.keyattackkey = GameData.attackkey;
        GameData.keydashkey = GameData.dashkey;
        GameData.keyhealkey = GameData.healkey;
        GameData.keyinteractkey = GameData.interactkey;
    }
    
    //コントローラー用のキーコンを保存
    public void consave()
    {
        GameData.condownkey = GameData.downkey;
        GameData.conjumpkey = GameData.jumpkey;
        GameData.conattackkey = GameData.attackkey;
        GameData.condashkey = GameData.dashkey;
        GameData.conhealkey = GameData.healkey;
        GameData.coninteractkey = GameData.interactkey;
    }
}
