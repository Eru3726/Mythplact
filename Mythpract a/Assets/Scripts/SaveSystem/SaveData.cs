using UnityEngine;
//セーブするための項目

[System.Serializable]
public class SaveData
{
    // キーコンフィグ
    public int testInt;
    public float testFloat;
    public string testString;
    public bool testBool;
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
    public Quaternion skillPiece9Deg ;
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
    public int skillSlot1;
    public int skillSlot2;
    public int skillSlot3;
    public int skillSlot4;

    // プレイヤーステータス
    public int playerNowHp;

    // フラグ管理
    public bool ShoggothDead;
    public bool FafnirDead;

    // リザルト
    public float ClearTime;
    public int HitCount;
    public int SkillCount;


}