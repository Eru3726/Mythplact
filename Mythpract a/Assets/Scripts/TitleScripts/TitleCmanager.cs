using UnityEngine;
using UnityEngine.UI;

public class TitleCmanager : MonoBehaviour
{
    public Controllerconnect conconnect;

    public Button start;

    public Button setting;

    public Button quit;

    public Button cbutton;
    
    public GameObject keycon;

    private GameObject Button;

    private float PickButton = 3;

    private bool connect = true;

    //左スティックをどこに倒しているかを判別するやつ
    private bool lsvup = true;        //上
    private bool lsvdown = true;　　　//下
    //十字キーをどこに倒しているかを判別するやつ
    private bool dpvup = true;        //上
    private bool dpvdown = true;      //下

    private float deadzone = 0.5f;     //スティックをどれだけ倒したら反応するかの値
    void Start()
    {

    }

    void Update()
    {
        if (conconnect.ConConnect)
        {
            if (connect == true)
            {
                start.Select();
                //ButtonSelect();
                connect = false;
                Debug.Log("コントローラー接続");
            }
            //Debug.Log(Button);
            //カーソルを見えなくする
            Cursor.visible = false;
            //カーソルを画面中央にロック
            Cursor.lockState = CursorLockMode.Locked;
            //InputManagerで新たに設定したAxisの変数を取得
            //float lsv = Input.GetAxis("L_stick_V");        //左スティック縦

            //if (lsv >= deadzone)     //左スティックの倒しこみがデッドゾーンを超えたら
            //{
            //    if (lsvup == true)　 //スティックを一回倒したら一個しか動かないようにするためのもの
            //    {
            //        if (PickButton < 3)
            //        {
            //            PickButton += 1;
            //            Debug.Log("上");
            //        }
            //        else
            //        {
            //            PickButton = 1;
            //            Debug.Log("上1");
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        lsvup = false;
            //    }
            //}
            //else if (lsv <= -deadzone)
            //{
            //    if (lsvdown == true)
            //    {
            //        if (PickButton > 1)
            //        {
            //            PickButton -= 1;
            //            Debug.Log("下");
            //        }
            //        else
            //        {
            //            PickButton = 3;
            //            Debug.Log("下3");
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        lsvdown = false;
            //    }
            //}
            ////一回倒したスティックを戻すともう一回倒して移動させれるようにする
            //if (lsv <= deadzone)
            //{
            //    lsvup = true;
            //}
            //if (lsv >= -deadzone)
            //{
            //    lsvdown = true;
            //}

            //float dpv = Input.GetAxis("D_pad_V");        //十字キーの縦を取得
            //if (dpv >= deadzone)
            //{
            //    if (dpvup == true)
            //    {
            //        if (PickButton < 3)
            //        {
            //            PickButton += 1;
            //        }
            //        else
            //        {
            //            PickButton = 1;
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        dpvup = false;
            //    }
            //}
            //else if (dpv <= -deadzone)
            //{
            //    if (dpvdown == true)
            //    {

            //        if (PickButton > 1)
            //        {
            //            PickButton -= 1;
            //        }
            //        else
            //        {
            //            PickButton = 3;
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        dpvdown = false;
            //    }
            //}
            ////上のスティックと同じ
            //if (dpv <= deadzone)
            //{
            //    dpvup = true;
            //}
            //if (dpv >= -deadzone)
            //{
            //    dpvdown = true;
            //}


            //if (Input.GetKeyDown(KeyCode.JoystickButton0))
            //{
            //    Debug.Log("決定");
            //    Button.GetComponent<Button>().onClick.Invoke();
            //    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.pressedSprite;
            //}
            //else if (Input.GetKeyUp(KeyCode.JoystickButton0))
            //{
            //    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            //}
        }
        else      //コントローラー非接続
        {
            if (connect == false)
            {
                //カーソルを表示
                Cursor.visible = true;
                //カーソルのロックを解除
                Cursor.lockState = CursorLockMode.None;
                //Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
                connect = true;
                Button = null;
                cbutton.Select();
                Debug.Log("コントローラー非接続");
            }
        }
    }

    public void ButtonSelect()
    {
        //if (PickButton == 1)
        //{
        //    Button = quit;
        //}
        //else if (PickButton == 2)
        //{
        //    Button = setting;
        //}
        //else
        //{
        //    Button = start;
        //}
        //Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
    }
}
