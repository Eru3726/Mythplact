//ファイルのデータを読み込みます

using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Read : MonoBehaviour
{
    public Controllerconnect Conconnect;
    void OnEnable()
    {
        DoRead();
    }

    private void DoRead()
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

        //セーブファイルがあるか
        if (File.Exists(SaveFilePath))
        {
            DataManager.saveData = true;

            //ファイルモードをオープンにする
            FileStream file = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // ファイル読み込み
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // 復号化
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte配列を文字列に変換
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSON形式の文字列をセーブデータのクラスに変換
                SaveData saveData = JsonUtility.FromJson<SaveData>(decryptStr);

                //データの反映
                ReadData(saveData);

            }
            finally
            {
                // ファイルを閉じる
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            Debug.Log("セーブファイルがありません");
            DataManager.saveData = false;
        }

        this.enabled = false;

    }

    //データの読み込み（反映）
    private void ReadData(SaveData saveData)
    {
        GameData.testInt = saveData.testInt;
        GameData.testFloat = saveData.testFloat;
        GameData.testString = saveData.testString;
        GameData.testBool = saveData.testBool;
        GameData.rightkey = saveData.rightkey;
        GameData.righttx = saveData.righttx;
        GameData.leftkey = saveData.leftkey;
        GameData.lefttx = saveData.lefttx;
        GameData.jumpkey = saveData.jumpkey;
        GameData.jumptx = saveData.jumptx;
        GameData.attackkey = saveData.attackkey;
        GameData.attacktx = saveData.attacktx;
        GameData.dashkey = saveData.dashkey;
        GameData.dashtx = saveData.dashtx;
        GameData.healkey = saveData.healkey;
        GameData.healtx = saveData.healtx;
        GameData.downkey = saveData.downkey;
        GameData.downtx = saveData.downtx;
        GameData.interactkey = saveData.interactkey;
        GameData.interacttx = saveData.interacttx;
        GameData.conjumpkey = saveData.conjumpkey;
        GameData.condownkey = saveData.condownkey;
        GameData.conattackkey = saveData.conattackkey;
        GameData.condashkey = saveData.condashkey;
        GameData.conhealkey = saveData.conhealkey;
        GameData.coninteractkey = saveData.coninteractkey;
        GameData.keyrightkey = saveData.keyrightkey;
        GameData.keyleftkey = saveData.keyleftkey;
        GameData.keyjumpkey = saveData.keyjumpkey;
        GameData.keyattackkey = saveData.keyattackkey;
        GameData.keydashkey = saveData.keydashkey;
        GameData.keyhealkey = saveData.keyhealkey;
        GameData.keydownkey = saveData.keydownkey;
        GameData.keyinteractkey = saveData.keyinteractkey; 
        GameData.saveSkill1 = saveData.saveSkill1;
        GameData.saveSkill2 = saveData.saveSkill2;
        GameData.saveSkill3 = saveData.saveSkill3;
        GameData.skillPiece1Pos = saveData.skillPiece1Pos;
        GameData.skillPiece1Deg = saveData.skillPiece1Deg;
        GameData.skillPiece2Pos = saveData.skillPiece2Pos;
        GameData.skillPiece2Deg = saveData.skillPiece2Deg;
        GameData.skillPiece3Pos = saveData.skillPiece3Pos;
        GameData.skillPiece3Deg = saveData.skillPiece3Deg;

        GameData.playerNowHp = saveData.playerNowHp;

        GameData.ClearTime = saveData.ClearTime;
        GameData.HitCount = saveData.HitCount;
        GameData.SkillCount = saveData.SkillCount;

        if (Conconnect != null)
        {
            if (Conconnect == false)
            {
                Conconnect.conread();
                Debug.Log("コントローラーロード");
                Debug.Log(GameData.rightkey);
                Debug.Log(GameData.leftkey);
                Debug.Log(GameData.downkey);
                Debug.Log(GameData.jumpkey);
                Debug.Log(GameData.attackkey);
                Debug.Log(GameData.dashkey);
                Debug.Log(GameData.healkey);
                Debug.Log(GameData.interactkey);
            }
            else
            {
                Conconnect.keyread();
                Debug.Log("キーボードロード");
                Debug.Log(GameData.rightkey);
                Debug.Log(GameData.leftkey);
                Debug.Log(GameData.downkey);
                Debug.Log(GameData.jumpkey);
                Debug.Log(GameData.attackkey);
                Debug.Log(GameData.dashkey);
                Debug.Log(GameData.healkey);
                Debug.Log(GameData.interactkey);
            }
        }
    }


    /// AesManagedマネージャーを取得
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Save.csと同じやつに)
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

    /// AES復号化
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        var aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}