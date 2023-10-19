using UnityEngine;

public class resetkey : MonoBehaviour
{
    public Controllerconnect conconnect;

    public void rightreset()
    {
        if (!conconnect.ConConnect)      //コントローラー非接続時
        {
            //if (GameData.leftkey != KeyCode.D && 
            //    GameData.downkey != KeyCode.D && 
            //    GameData.jumpkey != KeyCode.D && 
            //    GameData.attackkey != KeyCode.D && 
            //    GameData.dashkey != KeyCode.D && 
            //    GameData.healkey != KeyCode.D && 
            //    GameData.interactkey != KeyCode.D)
            //{
                //GameData.rightkey = KeyCode.D;
                //GameData.righttx = "D";
            //}

            //リセットするキーと同じものがあれば入れ替える
            if (GameData.leftkey == KeyCode.D )
            {
                GameData.leftkey = GameData.rightkey;
                GameData.lefttx = GameData.righttx;
            }
            else if( GameData.downkey == KeyCode.D )
            {
                GameData.downkey = GameData.rightkey;
                GameData.downtx = GameData.righttx;
            }
            else if (GameData.jumpkey == KeyCode.D )
            {
                GameData.jumpkey = GameData.rightkey;
                GameData.jumptx = GameData.righttx;
            }
             else if ( GameData.attackkey == KeyCode.D)
            {
                GameData.attackkey = GameData.rightkey;
                GameData.attacktx = GameData.righttx;
            }
             else if ( GameData.dashkey == KeyCode.D )
            {
                GameData.dashkey = GameData.rightkey;
                GameData.dashtx = GameData.righttx;
            }
             else if ( GameData.healkey == KeyCode.D )
            {
                GameData.healkey = GameData.rightkey;
                GameData.healtx = GameData.righttx;
            }
             else if (  GameData.interactkey == KeyCode.D)
            {
                GameData.interactkey = GameData.rightkey;
                GameData.interacttx = GameData.righttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.rightkey = KeyCode.D;
            GameData.righttx = "D";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.None && 
            //    GameData.downkey != KeyCode.None && 
            //    GameData.jumpkey != KeyCode.None && 
            //    GameData.attackkey != KeyCode.None && 
            //    GameData.dashkey != KeyCode.None && 
            //    GameData.healkey != KeyCode.None && 
            //    GameData.interactkey != KeyCode.None)
            //{
                //GameData.rightkey = KeyCode.None;
                //GameData.righttx = "None";
            //}
            if (GameData.leftkey == KeyCode.None)
            {
                GameData.leftkey = GameData.rightkey;
                GameData.lefttx = GameData.righttx;
            }
            else if (GameData.downkey == KeyCode.None)
            {
                GameData.downkey = GameData.rightkey;
                GameData.downtx = GameData.righttx;
            }
            else if (GameData.jumpkey == KeyCode.None)
            {
                GameData.jumpkey = GameData.rightkey;
                GameData.jumptx = GameData.righttx;
            }
            else if (GameData.attackkey == KeyCode.None)
            {
                GameData.attackkey = GameData.rightkey;
                GameData.attacktx = GameData.righttx;
            }
            else if (GameData.dashkey == KeyCode.None)
            {
                GameData.dashkey = GameData.rightkey;
                GameData.dashtx = GameData.righttx;
            }
            else if (GameData.healkey == KeyCode.None)
            {
                GameData.healkey = GameData.rightkey;
                GameData.healtx = GameData.righttx;
            }
            else if (GameData.interactkey == KeyCode.None)
            {
                GameData.interactkey = GameData.rightkey;
                GameData.interacttx = GameData.righttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.rightkey = KeyCode.None;
            GameData.righttx = "None";
        }
    }
    public void leftreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.rightkey != KeyCode.A && 
            //    GameData.downkey != KeyCode.A && 
            //    GameData.jumpkey != KeyCode.A && 
            //    GameData.attackkey != KeyCode.A && 
            //    GameData.dashkey != KeyCode.A && 
            //    GameData.healkey != KeyCode.A && 
            //    GameData.interactkey != KeyCode.A)
            //{
                //GameData.leftkey = KeyCode.A;
                //GameData.lefttx = "A";
            //}
            if (GameData.rightkey == KeyCode.A)
            {
                GameData.rightkey = GameData.leftkey;
                GameData.righttx = GameData.lefttx;
            }
            else if (GameData.downkey == KeyCode.A)
            {
                GameData.downkey = GameData.leftkey;
                GameData.downtx = GameData.lefttx;
            }
            else if (GameData.jumpkey == KeyCode.A)
            {
                GameData.jumpkey = GameData.leftkey;
                GameData.jumptx = GameData.lefttx;
            }
            else if (GameData.attackkey == KeyCode.A)
            {
                GameData.attackkey = GameData.leftkey;
                GameData.attacktx = GameData.lefttx;
            }
            else if (GameData.dashkey == KeyCode.A)
            {
                GameData.dashkey = GameData.leftkey;
                GameData.dashtx = GameData.lefttx;
            }
            else if (GameData.healkey == KeyCode.A)
            {
                GameData.healkey = GameData.leftkey;
                GameData.healtx = GameData.lefttx;
            }
            else if (GameData.interactkey == KeyCode.A)
            {
                GameData.interactkey = GameData.leftkey;
                GameData.interacttx = GameData.lefttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.leftkey = KeyCode.A;
            GameData.lefttx = "A";
        }
        else
        {
            //if (GameData.rightkey != KeyCode.None && 
            //    GameData.downkey != KeyCode.None && 
            //    GameData.jumpkey != KeyCode.None && 
            //    GameData.attackkey != KeyCode.None && 
            //    GameData.dashkey != KeyCode.None && 
            //    GameData.healkey != KeyCode.None && 
            //    GameData.interactkey != KeyCode.None)
            //{
                //GameData.leftkey = KeyCode.None;
                //GameData.lefttx = "None";
            //}
            if (GameData.rightkey == KeyCode.None)
            {
                GameData.rightkey = GameData.leftkey;
                GameData.righttx = GameData.lefttx;
            }
            else if (GameData.downkey == KeyCode.None)
            {
                GameData.downkey = GameData.leftkey;
                GameData.downtx = GameData.lefttx;
            }
            else if (GameData.jumpkey == KeyCode.None)
            {
                GameData.jumpkey = GameData.leftkey;
                GameData.jumptx = GameData.lefttx;
            }
            else if (GameData.attackkey == KeyCode.None)
            {
                GameData.attackkey = GameData.leftkey;
                GameData.attacktx = GameData.lefttx;
            }
            else if (GameData.dashkey == KeyCode.None)
            {
                GameData.dashkey = GameData.leftkey;
                GameData.dashtx = GameData.lefttx;
            }
            else if (GameData.healkey == KeyCode.None)
            {
                GameData.healkey = GameData.leftkey;
                GameData.healtx = GameData.lefttx;
            }
            else if (GameData.interactkey == KeyCode.None)
            {
                GameData.interactkey = GameData.leftkey;
                GameData.interacttx = GameData.lefttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.leftkey = KeyCode.None;
            GameData.lefttx = "None";
        }
    }
    public void downreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.S && 
            //    GameData.rightkey != KeyCode.S && 
            //    GameData.jumpkey != KeyCode.S && 
            //    GameData.attackkey != KeyCode.S && 
            //    GameData.dashkey != KeyCode.S && 
            //    GameData.healkey != KeyCode.S && 
            //    GameData.interactkey != KeyCode.S)
            //{
                //GameData.downkey = KeyCode.S;
                //GameData.downtx = "S";
            //}
            if (GameData.rightkey == KeyCode.S)
            {
                GameData.rightkey = GameData.downkey;
                GameData.righttx = GameData.downtx;
            }
            else if (GameData.leftkey == KeyCode.S)
            {
                GameData.leftkey = GameData.downkey;
                GameData.lefttx = GameData.downtx;
            }
            else if (GameData.jumpkey == KeyCode.S)
            {
                GameData.jumpkey = GameData.downkey;
                GameData.jumptx = GameData.downtx;
            }
            else if (GameData.attackkey == KeyCode.S)
            {
                GameData.attackkey = GameData.downkey;
                GameData.attacktx = GameData.downtx;
            }
            else if (GameData.dashkey == KeyCode.S)
            {
                GameData.dashkey = GameData.downkey;
                GameData.dashtx = GameData.downtx;
            }
            else if (GameData.healkey == KeyCode.S)
            {
                GameData.healkey = GameData.downkey;
                GameData.healtx = GameData.downtx;
            }
            else if (GameData.interactkey == KeyCode.S)
            {
                GameData.interactkey = GameData.downkey;
                GameData.interacttx = GameData.downtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.downkey = KeyCode.S;
            GameData.downtx = "S";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.None && 
            //    GameData.rightkey != KeyCode.None && 
            //    GameData.jumpkey != KeyCode.None && 
            //    GameData.attackkey != KeyCode.None && 
            //    GameData.dashkey != KeyCode.None && 
            //    GameData.healkey != KeyCode.None && 
            //    GameData.interactkey != KeyCode.None)
            //{
                //GameData.downkey = KeyCode.None;
                //GameData.downtx = "None";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton5)
            {
                GameData.rightkey = GameData.downkey;
                GameData.righttx = GameData.downtx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton5)
            {
                GameData.leftkey = GameData.downkey;
                GameData.lefttx = GameData.downtx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton5)
            {
                GameData.jumpkey = GameData.downkey;
                GameData.jumptx = GameData.downtx;
            }
            else if (GameData.attackkey == KeyCode.JoystickButton5)
            {
                GameData.attackkey = GameData.downkey;
                GameData.attacktx = GameData.downtx;
            }
            else if (GameData.dashkey == KeyCode.JoystickButton5)
            {
                GameData.dashkey = GameData.downkey;
                GameData.dashtx = GameData.downtx;
            }
            else if (GameData.healkey == KeyCode.JoystickButton5)
            {
                GameData.healkey = GameData.downkey;
                GameData.healtx = GameData.downtx;
            }
            else if (GameData.interactkey == KeyCode.JoystickButton5)
            {
                GameData.interactkey = GameData.downkey;
                GameData.interacttx = GameData.downtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.downkey = KeyCode.JoystickButton5;
            GameData.downtx = "R1";
        }
    }
    public void jumpreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.Space && 
            //    GameData.rightkey != KeyCode.Space && 
            //    GameData.downkey != KeyCode.Space && 
            //    GameData.attackkey != KeyCode.Space && 
            //    GameData.dashkey != KeyCode.Space && 
            //    GameData.healkey != KeyCode.Space && 
            //    GameData.interactkey != KeyCode.Space)
            //{
                //GameData.jumpkey = KeyCode.Space;
                //GameData.jumptx = "Space";
            //}
            if (GameData.rightkey == KeyCode.Space)
            {
                GameData.rightkey = GameData.jumpkey;
                GameData.righttx = GameData.jumptx;
            }
            else if (GameData.leftkey == KeyCode.Space)
            {
                GameData.leftkey = GameData.jumpkey;
                GameData.lefttx = GameData.jumptx;
            }
            else if (GameData.downkey == KeyCode.Space)
            {
                GameData.downkey = GameData.jumpkey;
                GameData.downtx = GameData.jumptx;
            }
            else if (GameData.attackkey == KeyCode.Space)
            {
                GameData.attackkey = GameData.jumpkey;
                GameData.attacktx = GameData.jumptx;
            }
            else if (GameData.dashkey == KeyCode.Space)
            {
                GameData.dashkey = GameData.jumpkey;
                GameData.dashtx = GameData.jumptx;
            }
            else if (GameData.healkey == KeyCode.Space)
            {
                GameData.healkey = GameData.jumpkey;
                GameData.healtx = GameData.jumptx;
            }
            else if (GameData.interactkey == KeyCode.Space)
            {
                GameData.interactkey = GameData.jumpkey;
                GameData.interacttx = GameData.jumptx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.jumpkey = KeyCode.Space;
            GameData.jumptx = "Space";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.JoystickButton0 && 
            //    GameData.rightkey != KeyCode.JoystickButton0 && 
            //    GameData.downkey != KeyCode.JoystickButton0 && 
            //    GameData.attackkey != KeyCode.JoystickButton0 && 
            //    GameData.dashkey != KeyCode.JoystickButton0 && 
            //    GameData.healkey != KeyCode.JoystickButton0 && 
            //    GameData.interactkey != KeyCode.JoystickButton0)
            //{
                //GameData.jumpkey = KeyCode.JoystickButton0;
                //GameData.jumptx = "a";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton0)
            {
                GameData.rightkey = GameData.jumpkey;
                GameData.righttx = GameData.jumptx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton0)
            {
                GameData.leftkey = GameData.jumpkey;
                GameData.lefttx = GameData.jumptx;
            }
            else if (GameData.downkey == KeyCode.JoystickButton0)
            {
                GameData.downkey = GameData.jumpkey;
                GameData.downtx = GameData.jumptx;
            }
            else if (GameData.attackkey == KeyCode.JoystickButton0)
            {
                GameData.attackkey = GameData.jumpkey;
                GameData.attacktx = GameData.jumptx;
            }
            else if (GameData.dashkey == KeyCode.JoystickButton0)
            {
                GameData.dashkey = GameData.jumpkey;
                GameData.dashtx = GameData.jumptx;
            }
            else if (GameData.healkey == KeyCode.JoystickButton0)
            {
                GameData.healkey = GameData.jumpkey;
                GameData.healtx = GameData.jumptx;
            }
            else if (GameData.interactkey == KeyCode.JoystickButton0)
            {
                GameData.interactkey = GameData.jumpkey;
                GameData.interacttx = GameData.jumptx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.jumpkey = KeyCode.JoystickButton0;
            GameData.jumptx = "a";
        }
    }
    public void attackreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.Mouse0 && 
            //    GameData.rightkey != KeyCode.Mouse0 && 
            //    GameData.downkey != KeyCode.Mouse0 && 
            //    GameData.jumpkey != KeyCode.Mouse0 && 
            //    GameData.dashkey != KeyCode.Mouse0 && 
            //    GameData.healkey != KeyCode.Mouse0 && 
            //    GameData.interactkey != KeyCode.Mouse0)
            //{
                //GameData.attackkey = KeyCode.Mouse0;
                //GameData.attacktx = "Mouse0";
            //}
            if (GameData.rightkey == KeyCode.Mouse0)
            {
                GameData.rightkey = GameData.attackkey;
                GameData.righttx = GameData.attacktx;
            }
            else if (GameData.leftkey == KeyCode.Mouse0)
            {
                GameData.leftkey = GameData.attackkey;
                GameData.lefttx = GameData.attacktx;
            }
            else if (GameData.downkey == KeyCode.Mouse0)
            {
                GameData.downkey = GameData.attackkey;
                GameData.downtx = GameData.attacktx;
            }
            else if (GameData.jumpkey == KeyCode.Mouse0)
            {
                GameData.jumpkey = GameData.attackkey;
                GameData.jumptx = GameData.attacktx;
            }
            else if (GameData.dashkey == KeyCode.Mouse0)
            {
                GameData.dashkey = GameData.attackkey;
                GameData.dashtx = GameData.attacktx;
            }
            else if (GameData.healkey == KeyCode.Mouse0)
            {
                GameData.healkey = GameData.attackkey;
                GameData.healtx = GameData.attacktx;
            }
            else if (GameData.interactkey == KeyCode.Mouse0)
            {
                GameData.interactkey = GameData.attackkey;
                GameData.interacttx = GameData.attacktx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.attackkey = KeyCode.Mouse0;
            GameData.attacktx = "Mouse0";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.JoystickButton1 && 
            //    GameData.rightkey != KeyCode.JoystickButton1 && 
            //    GameData.downkey != KeyCode.JoystickButton1 && 
            //    GameData.jumpkey != KeyCode.JoystickButton1 && 
            //    GameData.dashkey != KeyCode.JoystickButton1 && 
            //    GameData.healkey != KeyCode.JoystickButton1 && 
            //    GameData.interactkey != KeyCode.JoystickButton1)
            //{
                //GameData.attackkey = KeyCode.JoystickButton1;
                //GameData.attacktx = "b";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton1)
            {
                GameData.rightkey = GameData.attackkey;
                GameData.righttx = GameData.attacktx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton1)
            {
                GameData.leftkey = GameData.attackkey;
                GameData.lefttx = GameData.attacktx;
            }
            else if (GameData.downkey == KeyCode.JoystickButton1)
            {
                GameData.downkey = GameData.attackkey;
                GameData.downtx = GameData.attacktx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton1)
            {
                GameData.jumpkey = GameData.attackkey;
                GameData.jumptx = GameData.attacktx;
            }
            else if (GameData.dashkey == KeyCode.JoystickButton1)
            {
                GameData.dashkey = GameData.attackkey;
                GameData.dashtx = GameData.attacktx;
            }
            else if (GameData.healkey == KeyCode.JoystickButton1)
            {
                GameData.healkey = GameData.attackkey;
                GameData.healtx = GameData.attacktx;
            }
            else if (GameData.interactkey == KeyCode.JoystickButton1)
            {
                GameData.interactkey = GameData.attackkey;
                GameData.interacttx = GameData.attacktx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.attackkey = KeyCode.JoystickButton1;
            GameData.attacktx = "b";
        }
    }
    public void dashreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.LeftShift && 
            //    GameData.rightkey != KeyCode.LeftShift && 
            //    GameData.downkey != KeyCode.LeftShift && 
            //    GameData.jumpkey != KeyCode.LeftShift && 
            //    GameData.attackkey != KeyCode.LeftShift && 
            //    GameData.healkey != KeyCode.LeftShift && 
            //    GameData.interactkey != KeyCode.LeftShift)
            //{
                //GameData.dashkey = KeyCode.LeftShift;
                //GameData.dashtx = "LShift";
            //}
            if (GameData.rightkey == KeyCode.LeftShift)
            {
                GameData.rightkey = GameData.dashkey;
                GameData.righttx = GameData.dashtx;
            }
            else if (GameData.leftkey == KeyCode.LeftShift)
            {
                GameData.leftkey = GameData.dashkey;
                GameData.lefttx = GameData.dashtx;
            }
            else if (GameData.downkey == KeyCode.LeftShift)
            {
                GameData.downkey = GameData.dashkey;
                GameData.downtx = GameData.dashtx;
            }
            else if (GameData.jumpkey == KeyCode.LeftShift)
            {
                GameData.jumpkey = GameData.dashkey;
                GameData.jumptx = GameData.dashtx;
            }
            else if (GameData.attackkey == KeyCode.LeftShift)
            {
                GameData.attackkey = GameData.dashkey;
                GameData.attacktx = GameData.dashtx;
            }
            else if (GameData.healkey == KeyCode.LeftShift)
            {
                GameData.healkey = GameData.dashkey;
                GameData.healtx = GameData.dashtx;
            }
            else if (GameData.interactkey == KeyCode.LeftShift)
            {
                GameData.interactkey = GameData.dashkey;
                GameData.interacttx = GameData.dashtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.dashkey = KeyCode.LeftShift;
            GameData.dashtx = "LShift";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.JoystickButton4 && 
            //    GameData.rightkey != KeyCode.JoystickButton4 && 
            //    GameData.downkey != KeyCode.JoystickButton4 && 
            //    GameData.jumpkey != KeyCode.JoystickButton4 && 
            //    GameData.attackkey != KeyCode.JoystickButton4 && 
            //    GameData.healkey != KeyCode.JoystickButton4 && 
            //    GameData.interactkey != KeyCode.JoystickButton4)
            //{
                //GameData.dashkey = KeyCode.JoystickButton4;
                //GameData.dashtx = "L1";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton4)
            {
                GameData.rightkey = GameData.dashkey;
                GameData.righttx = GameData.dashtx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton4)
            {
                GameData.leftkey = GameData.dashkey;
                GameData.lefttx = GameData.dashtx;
            }
            else if (GameData.downkey == KeyCode.JoystickButton4)
            {
                GameData.downkey = GameData.dashkey;
                GameData.downtx = GameData.dashtx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton4)
            {
                GameData.jumpkey = GameData.dashkey;
                GameData.jumptx = GameData.dashtx;
            }
            else if (GameData.attackkey == KeyCode.JoystickButton4)
            {
                GameData.attackkey = GameData.dashkey;
                GameData.attacktx = GameData.dashtx;
            }
            else if (GameData.healkey == KeyCode.JoystickButton4)
            {
                GameData.healkey = GameData.dashkey;
                GameData.healtx = GameData.dashtx;
            }
            else if (GameData.interactkey == KeyCode.JoystickButton4)
            {
                GameData.interactkey = GameData.dashkey;
                GameData.interacttx = GameData.dashtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.dashkey = KeyCode.JoystickButton4;
            GameData.dashtx = "L1";
        }
    }

    public void healreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.H && 
            //    GameData.rightkey != KeyCode.H && 
            //    GameData.downkey != KeyCode.H && 
            //    GameData.jumpkey != KeyCode.H && 
            //    GameData.attackkey != KeyCode.H && 
            //    GameData.dashkey != KeyCode.H && 
            //    GameData.interactkey != KeyCode.H)
            //{
                //GameData.healkey = KeyCode.H;
                //GameData.healtx = "H";
            //}
            if (GameData.rightkey == KeyCode.H)
            {
                GameData.rightkey = GameData.healkey;
                GameData.righttx = GameData.healtx;
            }
            else if (GameData.leftkey == KeyCode.H)
            {
                GameData.leftkey = GameData.healkey;
                GameData.lefttx = GameData.healtx;
            }
            else if (GameData.jumpkey == KeyCode.H)
            {
                GameData.downkey = GameData.healkey;
                GameData.downtx = GameData.healtx;
            }
            else if (GameData.jumpkey == KeyCode.H)
            {
                GameData.jumpkey = GameData.healkey;
                GameData.jumptx = GameData.healtx;
            }
            else if (GameData.attackkey == KeyCode.H)
            {
                GameData.attackkey = GameData.healkey;
                GameData.attacktx = GameData.healtx;
            }
            else if (GameData.dashkey == KeyCode.H)
            {
                GameData.dashkey = GameData.healkey;
                GameData.dashtx = GameData.healtx;
            }
            else if (GameData.interactkey == KeyCode.H)
            {
                GameData.interactkey = GameData.healkey;
                GameData.interacttx = GameData.healtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.healkey = KeyCode.H;
            GameData.healtx = "H";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.JoystickButton3 && 
            //    GameData.rightkey != KeyCode.JoystickButton3 && 
            //    GameData.downkey != KeyCode.JoystickButton3 && 
            //    GameData.jumpkey != KeyCode.JoystickButton3 && 
            //    GameData.attackkey != KeyCode.JoystickButton3 && 
            //    GameData.dashkey != KeyCode.JoystickButton3 && 
            //    GameData.interactkey != KeyCode.JoystickButton3)
            //{
                //GameData.healkey = KeyCode.JoystickButton3;
                //GameData.healtx = "y";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton3)
            {
                GameData.rightkey = GameData.healkey;
                GameData.righttx = GameData.healtx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton3)
            {
                GameData.leftkey = GameData.healkey;
                GameData.lefttx = GameData.healtx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton3)
            {
                GameData.downkey = GameData.healkey;
                GameData.downtx = GameData.healtx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton3)
            {
                GameData.jumpkey = GameData.healkey;
                GameData.jumptx = GameData.healtx;
            }
            else if (GameData.attackkey == KeyCode.JoystickButton3)
            {
                GameData.attackkey = GameData.healkey;
                GameData.attacktx = GameData.healtx;
            }
            else if (GameData.dashkey == KeyCode.JoystickButton3)
            {
                GameData.dashkey = GameData.healkey;
                GameData.dashtx = GameData.healtx;
            }
            else if (GameData.interactkey == KeyCode.JoystickButton3)
            {
                GameData.interactkey = GameData.healkey;
                GameData.interacttx = GameData.healtx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.healkey = KeyCode.JoystickButton3;
            GameData.healtx = "y";
        }
    }
    public void interactreset()
    {
        if (!conconnect.ConConnect)
        {
            //if (GameData.leftkey != KeyCode.E && 
            //    GameData.rightkey != KeyCode.E && 
            //    GameData.downkey != KeyCode.E && 
            //    GameData.jumpkey != KeyCode.E && 
            //    GameData.attackkey != KeyCode.E && 
            //    GameData.dashkey != KeyCode.E && 
            //    GameData.healkey != KeyCode.E)
            //{
                //GameData.interactkey = KeyCode.E;
                //GameData.interacttx = "E";
            //}
            if (GameData.rightkey == KeyCode.E)
            {
                GameData.rightkey = GameData.interactkey;
                GameData.righttx = GameData.interacttx;
            }
            else if (GameData.leftkey == KeyCode.E)
            {
                GameData.leftkey = GameData.interactkey;
                GameData.lefttx = GameData.interacttx;
            }
            else if (GameData.jumpkey == KeyCode.E)
            {
                GameData.downkey = GameData.interactkey;
                GameData.downtx = GameData.interacttx;
            }
            else if (GameData.jumpkey == KeyCode.E)
            {
                GameData.jumpkey = GameData.interactkey;
                GameData.jumptx = GameData.interacttx;
            }
            else if (GameData.attackkey == KeyCode.E)
            {
                GameData.attackkey = GameData.interactkey;
                GameData.attacktx = GameData.interacttx;
            }
            else if (GameData.dashkey == KeyCode.E)
            {
                GameData.dashkey = GameData.interactkey;
                GameData.dashtx = GameData.interacttx;
            }
            else if (GameData.healkey == KeyCode.E)
            {
                GameData.healkey = GameData.interactkey;
                GameData.healtx = GameData.interacttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.interactkey = KeyCode.E;
            GameData.interacttx = "E";
        }
        else
        {
            //if (GameData.leftkey != KeyCode.JoystickButton2 && 
            //    GameData.rightkey != KeyCode.JoystickButton2 && 
            //    GameData.downkey != KeyCode.JoystickButton2 && 
            //    GameData.jumpkey != KeyCode.JoystickButton2 && 
            //    GameData.attackkey != KeyCode.JoystickButton2 && 
            //    GameData.dashkey != KeyCode.JoystickButton2 && 
            //    GameData.healkey != KeyCode.JoystickButton2)
            //{
                //GameData.interactkey = KeyCode.JoystickButton2;
                //GameData.interacttx = "x";
            //}
            if (GameData.rightkey == KeyCode.JoystickButton2)
            {
                GameData.rightkey = GameData.interactkey;
                GameData.righttx = GameData.interacttx;
            }
            else if (GameData.leftkey == KeyCode.JoystickButton2)
            {
                GameData.leftkey = GameData.interactkey;
                GameData.lefttx = GameData.interacttx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton2)
            {
                GameData.downkey = GameData.interactkey;
                GameData.downtx = GameData.interacttx;
            }
            else if (GameData.jumpkey == KeyCode.JoystickButton2)
            {
                GameData.jumpkey = GameData.interactkey;
                GameData.jumptx = GameData.interacttx;
            }
            else if (GameData.attackkey == KeyCode.JoystickButton2)
            {
                GameData.attackkey = GameData.interactkey;
                GameData.attacktx = GameData.interacttx;
            }
            else if (GameData.dashkey == KeyCode.JoystickButton2)
            {
                GameData.dashkey = GameData.interactkey;
                GameData.dashtx = GameData.interacttx;
            }
            else if (GameData.healkey == KeyCode.JoystickButton2)
            {
                GameData.healkey = GameData.interactkey;
                GameData.healtx = GameData.interacttx;
            }
            else
            {
                Debug.Log("なんかダメ");
            }
            GameData.interactkey = KeyCode.JoystickButton2;
            GameData.interacttx = "x";
        }
    }
    public void allreset()
    {
        if (!conconnect.ConConnect)
        {
            GameData.rightkey = KeyCode.D;
            GameData.righttx = "D";
            GameData.leftkey = KeyCode.A;
            GameData.lefttx = "A";
            GameData.downkey = KeyCode.S;
            GameData.downtx = "S";
            GameData.jumpkey = KeyCode.Space;
            GameData.jumptx = "Space";
            GameData.attackkey = KeyCode.Mouse0;
            GameData.attacktx = "Mouse0";
            GameData.dashkey = KeyCode.LeftShift;
            GameData.dashtx = "LShift";
            GameData.healkey = KeyCode.H;
            GameData.healtx = "H";
            GameData.interactkey = KeyCode.E;
            GameData.interacttx = "E";
        }
        else
        {
            GameData.rightkey = KeyCode.None;
            GameData.righttx = "None";
            GameData.leftkey = KeyCode.None;
            GameData.lefttx = "None";
            GameData.downkey = KeyCode.None;
            GameData.downtx = "None";
            GameData.jumpkey = KeyCode.JoystickButton0;
            GameData.jumptx = "a";
            GameData.attackkey = KeyCode.JoystickButton1;
            GameData.attacktx = "b";
            GameData.dashkey = KeyCode.JoystickButton4;
            GameData.dashtx = "L1";
            GameData.healkey = KeyCode.JoystickButton3;
            GameData.healtx = "y";
            GameData.interactkey = KeyCode.JoystickButton2;
            GameData.interacttx = "x";
        }
    }
}
