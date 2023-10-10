//データをファイルに保存します

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{
    void OnEnable()
    {
        DoSave();
    }

    private void DoSave()
    {
#if UNITY_EDITOR
        //UnityEditor上なら
        //Assetファイルの中のSaveファイルのパスを入れる
        string path = Application.dataPath + "/Save";

#else
        //そうでなければ
        //.exeがあるところにSaveファイルを作成しそこのパスを入れる
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";
        
#endif

        //セーブファイルのパスを設定
        string SaveFilePath = path + "/save" + DataManager.saveFile + ".bytes";

        // セーブデータの作成
        SaveData saveData = CreateSaveData();

        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);

        // 文字列をbyte配列に変換
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

        // AES暗号化
        byte[] arrEncrypted = AesEncrypt(bytes);

        // 指定したパスにファイルを作成
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        //ファイルに保存する
        try
        {
            // ファイルに保存
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // ファイルを閉じる
            if (file != null)
            {
                file.Close();
            }
        }
        this.enabled = false;//このスクリプトをオフにする
    }

    // セーブデータの作成
    private SaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        SaveData saveData = new SaveData();

        //ゲームデータの値をセーブデータに代入
        saveData.testInt = GameData.testInt;
        saveData.testFloat = GameData.testFloat;
        saveData.testString = GameData.testString;
        saveData.testBool = GameData.testBool;
        saveData.rightkey = GameData.rightkey;
        saveData.righttx = GameData.righttx;
        saveData.leftkey = GameData.leftkey;
        saveData.lefttx = GameData.lefttx;
        saveData.jumpkey = GameData.jumpkey;
        saveData.jumptx = GameData.jumptx;
        saveData.attackkey = GameData.attackkey;
        saveData.attacktx = GameData.attacktx;
        saveData.dashkey = GameData.dashkey;
        saveData.dashtx = GameData.dashtx;
        saveData.healkey = GameData.healkey;
        saveData.healtx = GameData.healtx;
        saveData.downkey = GameData.downkey;
        saveData.downtx = GameData.downtx;
        saveData.interactkey = GameData.interactkey;
        saveData.interacttx = GameData.interacttx;
        saveData.conjumpkey = GameData.conjumpkey;
        saveData.condownkey = GameData.condownkey;
        saveData.conattackkey = GameData.conattackkey;
        saveData.condashkey = GameData.condashkey;
        saveData.conhealkey = GameData.conhealkey;
        saveData.coninteractkey = GameData.coninteractkey;
        saveData.keyrightkey = GameData.keyrightkey;
        saveData.keyleftkey = GameData.keyleftkey;
        saveData.keyjumpkey = GameData.keyjumpkey;
        saveData.keyattackkey = GameData.keyattackkey;
        saveData.keydashkey = GameData.keydashkey;
        saveData.keyhealkey = GameData.keyhealkey;
        saveData.keydownkey = GameData.keydownkey;
        saveData.keyinteractkey = GameData.keyinteractkey;

        saveData.saveSkill1 = GameData.saveSkill1;
        saveData.saveSkill2 = GameData.saveSkill2;
        saveData.saveSkill3 = GameData.saveSkill3;
        saveData.setSkill1 = GameData.setSkill1;
        saveData.setSkill2 = GameData.setSkill2;
        saveData.setSkill3 = GameData.setSkill3;
        saveData.skillPiece1Pos = GameData.skillPiece1Pos;
        saveData.skillPiece1Deg = GameData.skillPiece1Deg;
        saveData.skillPiece2Pos = GameData.skillPiece2Pos;
        saveData.skillPiece2Deg = GameData.skillPiece2Deg;
        saveData.skillPiece3Pos = GameData.skillPiece3Pos;
        saveData.skillPiece3Deg = GameData.skillPiece3Deg;
        saveData.BeforeSceneName = GameData.BeforeSceneName;

        saveData.playerNowHp = GameData.playerNowHp;

        saveData.ShoggothDead = GameData.ShoggothDead;
        saveData.FafnirDead = GameData.FafnirDead;

        saveData.ClearTime = GameData.ClearTime;
        saveData.HitCount = GameData.HitCount;
        saveData.SkillCount = GameData.SkillCount;

        return saveData;
    }


    /// AesManagedマネージャーを取得

    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Read.csと同じやつに)
        string aesIv = "0987654321098765";
        string aesKey = "1234567890123456";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// AES暗号化
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}