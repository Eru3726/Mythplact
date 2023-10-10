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
    public bool setSkill1;
    public bool setSkill2;
    public bool setSkill3;
    public Vector3 skillPiece1Pos;
    public Quaternion skillPiece1Deg;
    public Vector3 skillPiece2Pos;
    public Quaternion skillPiece2Deg;
    public Vector3 skillPiece3Pos;
    public Quaternion skillPiece3Deg;
    public string BeforeSceneName;

    // プレイヤーステータス
    public int playerNowHp;

    // フラグ管理
    public bool ShoggothDead = false;
    public bool FafnirDead = false;

    // リザルト
    public float ClearTime;
    public int HitCount;
    public int SkillCount;


}