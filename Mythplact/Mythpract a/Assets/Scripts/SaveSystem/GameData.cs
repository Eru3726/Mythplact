using UnityEngine;
//ゲーム中で保持しておきたい項目（初期の値は任意）

public class GameData
{
    // キーコンフィグ
    public static int testInt = 1;
    public static float testFloat = 1.0f;
    public static string testString = "Text0";
    public static bool testBool = true;
    public static KeyCode rightkey = KeyCode.D;
    public static string righttx = "D";
    public static KeyCode leftkey = KeyCode.A;
    public static string lefttx = "A";
    public static KeyCode jumpkey = KeyCode.Space;
    public static string jumptx = "Space";
    public static KeyCode attackkey = KeyCode.Mouse0;
    public static string attacktx = "Mouse0";
    public static KeyCode dashkey = KeyCode.LeftShift;
    public static string dashtx = "LShift";
    public static KeyCode healkey = KeyCode.H;
    public static string healtx = "H";
    public static KeyCode downkey = KeyCode.S;
    public static string downtx = "S";
    public static KeyCode interactkey = KeyCode.E;
    public static string interacttx = "E";
    public static KeyCode conjumpkey = KeyCode.JoystickButton0;
    public static KeyCode condownkey = KeyCode.Joystick1Button5;
    public static KeyCode conattackkey = KeyCode.JoystickButton1;
    public static KeyCode condashkey = KeyCode.JoystickButton4;
    public static KeyCode conhealkey = KeyCode.JoystickButton3;
    public static KeyCode coninteractkey = KeyCode.JoystickButton2;
    public static KeyCode keyrightkey = KeyCode.D;
    public static KeyCode keyleftkey = KeyCode.A;
    public static KeyCode keyjumpkey = KeyCode.Space;
    public static KeyCode keyattackkey = KeyCode.Mouse0;
    public static KeyCode keydashkey = KeyCode.LeftShift;
    public static KeyCode keyhealkey = KeyCode.H;
    public static KeyCode keydownkey = KeyCode.S;
    public static KeyCode keyinteractkey = KeyCode.E;

    // スキルピース
    public static bool saveSkill1 = false;
    public static bool saveSkill2 = false;
    public static bool saveSkill3 = false;

    public static bool setSkill1 = false;
    public static bool setSkill2 = false;
    public static bool setSkill3 = false;


    public static Vector3 skillPiece1Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece1Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece2Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece2Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece3Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece3Deg = new Quaternion(0, 0, 0, 0);

    public static string BeforeSceneName;

    // プレイヤーステータス
    public static int playerNowHp = 0;

    // フラグ管理
    public static bool ShoggothDead = false;
    public static bool FafnirDead = false;


    // リザルト
    public static float ClearTime = 0;
    public static int HitCount = 0;
    public static int SkillCount = 0;

}