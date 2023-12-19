using UnityEngine;
//セーブするための項目

[System.Serializable]
public class SaveData
{
    // キーコンフィグ
    public KeyCode rightkey;
    public string righttx;
    public KeyCode leftkey;
    public string lefttx;
    public KeyCode jumpkey;
    public string jumptx;
    public KeyCode attackkey;
    public string attacktx;
    public KeyCode dashkey;
    public string dashtx;
    public KeyCode healkey;
    public string healtx;
    public KeyCode downkey;
    public string downtx;
    public KeyCode interactkey;
    public string interacttx;
    public KeyCode conrightkey;
    public KeyCode conleftkey;
    public KeyCode conjumpkey;
    public KeyCode conattackkey;
    public KeyCode condashkey;
    public KeyCode conhealkey;
    public KeyCode conmenukey;
    public KeyCode condownkey;
    public KeyCode coninteractkey;
    public KeyCode keyrightkey;
    public KeyCode keyleftkey;
    public KeyCode keyjumpkey;
    public KeyCode keyattackkey;
    public KeyCode keydashkey;
    public KeyCode keyhealkey;
    public KeyCode keymenukey;
    public KeyCode keydownkey;
    public KeyCode keyinteractkey;

    // スキルピース
    public bool saveSkill1;
    public bool saveSkill2;
    public bool saveSkill3;
    public bool saveSkill4;
    public bool saveSkill5;
    public bool saveSkill6;
    public bool saveSkill7;
    public bool saveSkill8;
    public bool saveSkill9;
    public bool saveSkill10;
    public bool saveSkill11;
    public bool saveSkill12;
    public bool saveSkill13;
    public bool saveSkill14;
    public bool saveSkill15;
    public bool saveSkill16;
    public bool saveSkill17;
    public bool saveSkill18;
    public bool saveSkill19;

    public bool[] saveSkillPreset1 = new bool[20];
    public bool[] saveSkillPreset2 = new bool[20];
    public bool[] saveSkillPreset3 = new bool[20];

    public bool setSkill1;
    public bool setSkill2;
    public bool setSkill3;
    public bool setSkill4;
    public bool setSkill5;
    public bool setSkill6;
    public bool setSkill7;
    public bool setSkill8;
    public bool setSkill9;
    public bool setSkill10;
    public bool setSkill11;
    public bool setSkill12;
    public bool setSkill13;
    public bool setSkill14;
    public bool setSkill15;
    public bool setSkill16;
    public bool setSkill17;
    public bool setSkill18;
    public bool setSkill19;

    public bool[] setSkillPreset1 = new bool[20];
    public bool[] setSkillPreset2 = new bool[20];
    public bool[] setSkillPreset3 = new bool[20];

    public Vector3 skillPiece1Pos;
    public Quaternion skillPiece1Deg;
    public Vector3 skillPiece2Pos;
    public Quaternion skillPiece2Deg;
    public Vector3 skillPiece3Pos;
    public Quaternion skillPiece3Deg;
    public Vector3 skillPiece4Pos;
    public Quaternion skillPiece4Deg;
    public Vector3 skillPiece5Pos;
    public Quaternion skillPiece5Deg;
    public Vector3 skillPiece6Pos;
    public Quaternion skillPiece6Deg;
    public Vector3 skillPiece7Pos;
    public Quaternion skillPiece7Deg;
    public Vector3 skillPiece8Pos;
    public Quaternion skillPiece8Deg;
    public Vector3 skillPiece9Pos;
    public Quaternion skillPiece9Deg;
    public Vector3 skillPiece10Pos;
    public Quaternion skillPiece10Deg;
    public Vector3 skillPiece11Pos;
    public Quaternion skillPiece11Deg;
    public Vector3 skillPiece12Pos;
    public Quaternion skillPiece12Deg;
    public Vector3 skillPiece13Pos;
    public Quaternion skillPiece13Deg;
    public Vector3 skillPiece14Pos;
    public Quaternion skillPiece14Deg;
    public Vector3 skillPiece15Pos;
    public Quaternion skillPiece15Deg;
    public Vector3 skillPiece16Pos;
    public Quaternion skillPiece16Deg;
    public Vector3 skillPiece17Pos;
    public Quaternion skillPiece17Deg;
    public Vector3 skillPiece18Pos;
    public Quaternion skillPiece18Deg;
    public Vector3 skillPiece19Pos;
    public Quaternion skillPiece19Deg;

    public Vector3[] skillPiecePosPreset1 = new Vector3[20];
    public Vector3[] skillPiecePosPreset2 = new Vector3[20];
    public Vector3[] skillPiecePosPreset3 = new Vector3[20];
    public Quaternion[] skillPieceDegPreset1 = new Quaternion[20];
    public Quaternion[] skillPieceDegPreset2 = new Quaternion[20];
    public Quaternion[] skillPieceDegPreset3 = new Quaternion[20];

    public int skillSlot1;
    public int skillSlot2;
    public int skillSlot3;
    public int skillSlot4;

    public int[] skillSlotPreset1 = new int[4];
    public int[] skillSlotPreset2 = new int[4];
    public int[] skillSlotPreset3 = new int[4];

    // プレイヤーステータス
    public int playerNowHp;

    // フラグ管理
    public bool ShoggothDead;
    public bool FafnirDead;
    public bool QilinDead;

    // リザルト
    public float ClearTime;
    public int HitCount;
    public int SkillCount;
    public int justGuardCount;

    public float bestTimeShoggoth = 0;
    public float bestTimeFafnir = 0;
    public float bestTimeQilin = 0;

    //プレイ時間とセーブ日時
    public int playTime = 0;
    public int lastYear = 2023;
    public int lastMonth = 1;
    public int lastDay = 1;
    public int lastHour = 0;
    public int lastMinute = 0;

    //実績
    public bool dieXFlg;
    public int dieXCount;

    public bool blinkX;
    public int blinkXCount;

    public bool allBoss;
    public bool[] defeatedBoss = new bool[3];

    public bool oneHp;

    public bool attackCombo;
    public int attackComboCount;

    public bool SheriffUseFlg;
    public int SheriffUseCount;

    public bool guardCountFlg;
    public int guardCount;

    public bool noDamage;

    public bool justGuardFlg;
    public int achvJustGuardCount;

    public bool noGuard;

    public bool activeSkillOnly;

    public bool timeAttack;

    public int clearAchv;

    public int clearBoss;
}