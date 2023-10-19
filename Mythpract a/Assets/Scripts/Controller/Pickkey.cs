using UnityEngine;
using UnityEngine.UI;

public class Pickkey : MonoBehaviour
{
    public Controllerconnect controllerconnect;
    public Keyconfig keycon;

    public GameObject rk;             //ライトキー
    public GameObject lk;             //レフトキー
    public GameObject dwk;            //ダウンキー
    public GameObject ak;             //アタックキー
    public GameObject jk;             //ジャンプキー
    public GameObject dk;             //ダッシュキー
    public GameObject hk;             //ヒールキー
    public GameObject ik;             //インタラクトキー
    public GameObject rkr;            //r付きはそのキーのリセットキー
    public GameObject lkr;            //
    public GameObject dwkr;           //
    public GameObject akr;            //
    public GameObject jkr;            //
    public GameObject dkr;            //
    public GameObject hkr;            //
    public GameObject ikr;            // 
    public GameObject save;           //セーブキー
    public GameObject escape;           //エスケープキー
    public GameObject skill;           //スキルキー
    //public GameObject load;           //ロードキー
    //public GameObject allr;           //オールリセットキー

    private float buttonnumv = 1;     //ボタンの縦に動くためのやつ
    private float buttonnumh = 1;     //ボタンの横に動くためのやつ

    private GameObject Button;        //何のボタンにいるか判別するためのやつ

    //左スティックをどこに倒しているかを判別するやつ
    private bool lsvup = true;        //上
    private bool lsvdown = true;　　　//下
    private bool lshup = true;        //右
    private bool lshdown = true;      //左
    //十字キーをどこに倒しているかを判別するやつ
    private bool dpvup = true;        //上
    private bool dpvdown = true;      //下
    private bool dphup = true;        //左
    private bool dphdown = true;      //右

    private bool connect = false;      //コントローラー接続したときのメソッドが何度も実行されないようにするもの

    private float deadzone = 0.5f;     //スティックをどれだけ倒したら反応するかの値

    private bool Cnotcon = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //コントローラー接続
        if (controllerconnect.ConConnect && !connect) 
        {
            buttonnumh = 2;
            buttonnumv = 1;
            Button = rk;
            Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            //Buttonselect();    //縦と横のボタンの変数の値によってボタンの位置を動かす 
            connect = true;
            Debug.Log("コントローラー接続");
        }
        //コントローラー非接続
        else if (!controllerconnect.ConConnect&&connect)
        {
            Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.disabledSprite;
            connect = false;
            Debug.Log("コントローラー切断");
        }
        //////////////////////////////////
        /////////////////////////////////
        ////////////////////////////////
        ///////////////////////////////
        
        //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.dash == false && keycon.attack == false && keycon.heal == false && keycon.interact == false)
        
        
        if (keycon.condec == false)         //コントローラーの決定ボタンもキーコンで設定できるようにするためのもの
        {
            ConClick();                   //コントローラーでボタンをクリックさせるためのもの
        }
        else
        {
            keycon.condec = false;
        }
        //if (Button != rk && Button != lk && Button != dwk && keycon.button == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.JoystickButton0))
        //    {
        //        {
        //            Button.GetComponent<Button>().onClick.Invoke();
        //            Debug.Log("conclick");
        //        }
        //    }
        //}
        //コントローラー接続時のスティック入力を判別
        if (controllerconnect.ConConnect)
        {
            //カーソルを見えなくする
            Cursor.visible = false;
            //カーソルを画面中央にロック
            Cursor.lockState = CursorLockMode.Locked;
            //InputManagerで新たに設定したAxisの変数を取得
            float lsh = Input.GetAxis("L_stick_H");　　　　//左スティック横
            float lsv = Input.GetAxis("L_stick_V");        //左スティック縦
            //if (Button != beforeb)
            //{
            //    if (Input.GetKeyDown(KeyCode.JoystickButton1))
            //    {
            //        Button.GetComponent<Button>().onClick.Invoke();
            //        beforeb = Button;
            //    }
            //}
            if (lsv >= deadzone)     //左スティックの倒しこみがデッドゾーンを超えたら
            {
                if (lsvup == true)　 //スティックを一回倒したら一個しか動かないようにするためのもの
                {
                    Debug.Log("上");
                    //ボタンの位置によって次どのボタンに移動するかを決めるためのif文
                    if (buttonnumh == 2 && buttonnumv == 1 || buttonnumh == 3 && buttonnumv == 1)
                    {
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else
                    {
                        buttonnumv -= 1;
                    }
                    Buttonselect();    
                    lsvup = false;
                }
            }
            else if (lsv <= -deadzone)
            {
                if (lsvdown == true)
                {
                    Debug.Log("下");
                    if (buttonnumh == 2 && buttonnumv == 8 || buttonnumh == 3 && buttonnumv == 8)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumv += 1;
                    }
                    Buttonselect();
                    lsvdown = false;
                }
            }
            if (lsh <= -deadzone)
            {
                if (lshdown == true)
                {
                    Debug.Log("左");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 2 && buttonnumv >= 5)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 2 && buttonnumv <= 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 1;
                        }
                    }
                    else
                    {
                        buttonnumh -= 1;
                    }
                    Buttonselect();
                    lshdown = false;
                }
            }
            else if (lsh >= deadzone)
            {
                if (lshup == true)
                {
                    Debug.Log("右");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumh += 1;
                    }
                    Buttonselect();
                    lshup = false;
                }
            }

            //一回倒したスティックを戻すともう一回倒して移動させれるようにする
            if (lsv <= deadzone)
            {
                lsvup = true;
            }
            if (lsv >= -deadzone)
            {
                lsvdown = true;
            }
            if (lsh <= deadzone)
            {
                lshup = true;
            }
            if (lsh >= -deadzone)
            {
                lshdown = true;
            }

            float dph = Input.GetAxis("D_pad_H");        //十字キーの横を取得
            float dpv = Input.GetAxis("D_pad_V");        //十字キーの縦を取得
            if (dpv >= deadzone)
            {
                if (dpvup == true)
                {
                    Debug.Log("上");
                    if (buttonnumh == 2 && buttonnumv == 1 || buttonnumh == 3 && buttonnumv == 1)
                    {
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else
                    {
                        buttonnumv -= 1;
                    }
                    Buttonselect();
                    dpvup = false;
                }
            }
            else if (dpv <= -deadzone)
            {
                if (dpvdown == true)
                {
                    Debug.Log("下");
                    if (buttonnumh == 2 && buttonnumv == 8 || buttonnumh == 3 && buttonnumv == 8)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumv += 1;
                    }
                    Buttonselect();
                    dpvdown = false;
                }
            }
            if (dph <= -deadzone)
            {
                if (dphdown == true)
                {
                    Debug.Log("左");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 2 && buttonnumv >= 5)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 2 && buttonnumv <= 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 1;
                        }
                    }
                    else
                    {
                        buttonnumh -= 1;
                    }
                    Buttonselect();
                    dphdown = false;
                }
            }
            else if (dph >= deadzone)
            {
                if (dphup == true)
                {
                    Debug.Log("右");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumh += 1;
                    }
                    Buttonselect();
                    dphup = false;
                }
            }

            //上のスティックと同じ
            if (dpv <= deadzone)
            {
                dpvup = true;
            }
            if (dpv >= -deadzone)
            {
                dpvdown = true;
            }
            if (dph <= deadzone)
            {
                dphup = true;
            }
            if (dph >= -deadzone)
            {
                dphdown = true;
            }
        }
        else//コントローラー非接続
        {
            //カーソルを表示
            Cursor.visible = true;
            //カーソルのロックを解除
            Cursor.lockState = CursorLockMode.None;
        }

        ////R Stick
        //float rsh = Input.GetAxis("R_stick_H");
        //float rsv = Input.GetAxis("R_stick_V");
        //if ((rsh != 0) || (rsv != 0))
        //{
        //    Debug.Log("R stick:" + rsh + "," + rsv);
        //}
        ////D-Pad
        //float dph = Input.GetAxis("D_pad_H");
        //float dpv = Input.GetAxis("D_pad_V");
        //if ((dph != 0) || (dpv != 0))
        //{
        //    Debug.Log("D Pad:" + dph + "," + dpv);
        //}
        ////Trigger
        ////float tri = Input.GetAxis("L_R_trigger");
        ////if (tri > 0)
        ////{
        ////    Debug.Log("L trigger:" + tri);
        ////}
        ////else if (tri < 0)
        ////{
        ////    Debug.Log("R trigger:" + tri);
        ////}
        ////else
        ////{
        ////    //Debug.Log("  trigger:none");
        ////}
        //LRTbutton();
    }

    //参照しているボタンを変更するためのメソッド
    public void Buttonselect()
    {
        //参照していない状態にする　とりま色で代用
        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.disabledSprite;
        //Debug.Log("横 " + buttonnumh + "  縦 " + buttonnumv);

        //縦横の変数によって対応したボタンを参照する
        if (buttonnumh == 1 && buttonnumv == 1)
        {
            Button = escape;
        }
        else if (buttonnumh == 1 && buttonnumv == 2 && skill)
        {
            Button = skill;
        }
        else if (buttonnumh == 2 && buttonnumv == 1)
        {
            Button = rk;
        }
        else if (buttonnumh == 2 && buttonnumv == 2)
        {
            Button = lk;
        }
        else if (buttonnumh == 2 && buttonnumv == 3)
        {
            Button = dwk;
        }
        else if (buttonnumh == 2 && buttonnumv == 4)
        {
            Button = jk;
        }
        else if (buttonnumh == 2 && buttonnumv == 5)
        {
            Button = ak;
        }
        else if (buttonnumh == 2 && buttonnumv == 6)
        {
            Button = dk;
        }
        else if (buttonnumh == 2 && buttonnumv == 7)
        {
            Button = hk;
        }
        else if (buttonnumh == 2 && buttonnumv == 8)
        {
            Button = ik;
        }
        else if (buttonnumh == 3 && buttonnumv == 1)
        {
            Button = rkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 2)
        {
            Button = lkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 3)
        {
            Button = dwkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 4)
        {
            Button = jkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 5)
        {
            Button = akr;
        }
        else if (buttonnumh == 3 && buttonnumv == 6)
        {
            Button = dkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 7)
        {
            Button = hkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 8)
        {
            Button = ikr;
        }
        else if (buttonnumh == 4)
        {
            Button = save;
        }
        else if (buttonnumh == 1 && !skill)
        {
            Button = escape;
        }
        Debug.Log("Button " + Button);
        //参照確認
        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
    }
    public void LRTbutton()
    {
        //    float LT = Input.GetAxis("LT");
        //    if (Lt == true)
        //    {
        //        if (LT >= 0.00000000001f)
        //        {
        //            Lt = false;
        //            Debug.Log("LT");
        //        }
        //    }
        //    else
        //    {
        //        if (LT == 0)
        //        {
        //            Lt = true;
        //        }
        //    }
        //    float RT = Input.GetAxis("RT");
        //    if (Rt == true)
        //    {
        //        if (RT >= 0.00000000001f)
        //        {
        //            Rt = false;
        //            Debug.Log("RT");
        //        }
        //    }
        //    else
        //    {
        //        if (RT == 0)
        //        {
        //            Rt = true;
        //        }
        //    }
    }

    //コントローラーでボタンのonClick()メソッドを使用するためのメソッド
    public void ConClick()
    {
        if (Button != rk && Button != lk)        //コントローラーの場合移動キーはいらないので省く
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                {
                    Button.GetComponent<Button>().onClick.Invoke();    //Invoke()メソッドでonClick()メソッドを使用
                    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.pressedSprite;
                    Debug.Log("conclick");
                }
            }
            else if (Input.GetKeyUp(KeyCode.JoystickButton0))
            {
                Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            }
        }
    }

}