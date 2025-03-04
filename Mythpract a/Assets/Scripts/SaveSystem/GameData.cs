using UnityEngine;
//ゲーム中で保持しておきたい項目（初期の値は任意）

public class GameData
{
    // キーコンフィグ
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
    public static bool saveSkill1= false;
    public static bool saveSkill2 = false;
    public static bool saveSkill3 = false;
    public static bool saveSkill4 = false;
    public static bool saveSkill5 = false;
    public static bool saveSkill6 = false;
    public static bool saveSkill7 = false;
    public static bool saveSkill8 = false;
    public static bool saveSkill9 = false;
    public static bool saveSkill10 = false;
    public static bool saveSkill11 = false;
    public static bool saveSkill12 = false;
    public static bool saveSkill13 = false;
    public static bool saveSkill14 = false;
    public static bool saveSkill15 = false;
    public static bool saveSkill16 = false;
    public static bool saveSkill17 = false;
    public static bool saveSkill18 = false;
    public static bool saveSkill19 = false;

    public static bool[] saveSkillPreset1 = new bool[20];
    public static bool[] saveSkillPreset2 = new bool[20];
    public static bool[] saveSkillPreset3 = new bool[20];




    public static bool setSkill1 = false;
    public static bool setSkill2 = false;
    public static bool setSkill3 = false;
    public static bool setSkill4 = false;
    public static bool setSkill5 = false;
    public static bool setSkill6 = false;
    public static bool setSkill7 = false;
    public static bool setSkill8 = false;
    public static bool setSkill9 = false;
    public static bool setSkill10 = false;
    public static bool setSkill11 = false;
    public static bool setSkill12 = false;
    public static bool setSkill13 = false;
    public static bool setSkill14 = false;
    public static bool setSkill15 = false;
    public static bool setSkill16 = false;
    public static bool setSkill17 = false;
    public static bool setSkill18 = false;
    public static bool setSkill19 = false;

    public static bool[] setSkillPreset1 = new bool[20];
    public static bool[] setSkillPreset2 = new bool[20];
    public static bool[] setSkillPreset3 = new bool[20];


    public static Vector3 skillPiece1Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece1Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece2Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece2Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece3Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece3Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece4Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece4Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece5Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece5Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece6Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece6Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece7Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece7Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece8Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece8Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece9Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece9Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece10Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece10Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece11Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece11Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece12Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece12Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece13Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece13Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece14Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece14Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece15Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece15Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece16Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece16Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece17Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece17Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece18Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece18Deg = new Quaternion(0, 0, 0, 0);
    public static Vector3 skillPiece19Pos = new Vector3(0, 0, 0);
    public static Quaternion skillPiece19Deg = new Quaternion(0, 0, 0, 0);

    public static Vector3[] skillPiecePosPreset1 = new Vector3[20];
    public static Vector3[] skillPiecePosPreset2 = new Vector3[20];
    public static Vector3[] skillPiecePosPreset3 = new Vector3[20];
    public static Quaternion[] skillPieceDegPreset1 = new Quaternion[20];
    public static Quaternion[] skillPieceDegPreset2 = new Quaternion[20];
    public static Quaternion[] skillPieceDegPreset3 = new Quaternion[20];


    public static int skillSlot1 = 0;
    public static int skillSlot2 = 0;
    public static int skillSlot3 = 0;
    public static int skillSlot4 = 0;

    public static int[] skillSlotPreset1 = new int[4];
    public static int[] skillSlotPreset2 = new int[4];
    public static int[] skillSlotPreset3 = new int[4];

    // プレイヤーステータス
    public static int playerNowHp = 0;

    // フラグ管理
    public static bool ShoggothDead = false;
    public static bool FafnirDead = false;
    public static bool QilinDead = false;

    // リザルト
    public static float ClearTime = 0;
    public static int HitCount = 0;
    public static int SkillCount = 0;
    public static int justGuardCount = 0;

    public static float bestTimeShoggoth = 0;
    public static float bestTimeFafnir = 0;
    public static float bestTimeQilin = 0;

    //プレイ時間とセーブ日時
    public static int playTime = 0;
    public static int lastYear = 2023;
    public static int lastMonth = 1;
    public static int lastDay = 1;
    public static int lastHour = 0;
    public static int lastMinute = 0;

    //実績
    public static bool dieXFlg;
    public static int dieXCount;

    public static bool blinkXFlg;
    public static int blinkXCount;

    public static bool allBossFlg;
    public static bool[] defeatedBoss = new bool[3];

    public static bool oneHpFlg;

    public static bool attackComboFlg;
    public static int attackComboCount;

    public static bool sheriffUseFlg;
    public static int sheriffUseCount;

    public static bool guardCountFlg;
    public static int guardCount;

    public static bool noDamage;

    public static bool justGuardFlg;
    public static int achvJustGuardCount;

    public static bool noGuard;

    public static bool activeSkillOnlyFlg;

    public static bool timeAttack;

    public static int clearAchv;

    public static int clearBoss;

    public static bool Firsttime;
}