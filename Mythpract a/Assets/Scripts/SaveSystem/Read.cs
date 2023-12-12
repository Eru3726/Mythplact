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
        GameData.saveSkill4 = saveData.saveSkill4;
        GameData.saveSkill5 = saveData.saveSkill5;
        GameData.saveSkill6 = saveData.saveSkill6;
        GameData.saveSkill7 = saveData.saveSkill7;
        GameData.saveSkill8 = saveData.saveSkill8;
        GameData.saveSkill9 = saveData.saveSkill9;
        GameData.saveSkill10 = saveData.saveSkill10;
        GameData.saveSkill11 = saveData.saveSkill11;
        GameData.saveSkill12 = saveData.saveSkill12;
        GameData.saveSkill13 = saveData.saveSkill13;
        GameData.saveSkill14 = saveData.saveSkill14;
        GameData.saveSkill15 = saveData.saveSkill15;
        GameData.saveSkill16 = saveData.saveSkill16;
        GameData.saveSkill17 = saveData.saveSkill17;
        GameData.saveSkill18 = saveData.saveSkill18;
        GameData.saveSkill19 = saveData.saveSkill19;


        GameData.setSkill1 = saveData.setSkill1;
        GameData.setSkill2 = saveData.setSkill2;
        GameData.setSkill3 = saveData.setSkill3;
        GameData.setSkill4 = saveData.setSkill4;
        GameData.setSkill5 = saveData.setSkill5;
        GameData.setSkill6 = saveData.setSkill6;
        GameData.setSkill7 = saveData.setSkill7;
        GameData.setSkill8 = saveData.setSkill8;
        GameData.setSkill9 = saveData.setSkill9;
        GameData.setSkill10 = saveData.setSkill10;
        GameData.setSkill11 = saveData.setSkill11;
        GameData.setSkill12 = saveData.setSkill12;
        GameData.setSkill13 = saveData.setSkill13;
        GameData.setSkill14 = saveData.setSkill14;
        GameData.setSkill15 = saveData.setSkill15;
        GameData.setSkill16 = saveData.setSkill16;
        GameData.setSkill17 = saveData.setSkill17;
        GameData.setSkill18 = saveData.setSkill18;
        GameData.setSkill19 = saveData.setSkill19;



        GameData.skillPiece1Pos = saveData.skillPiece1Pos;
        GameData.skillPiece1Deg = saveData.skillPiece1Deg;
        GameData.skillPiece2Pos = saveData.skillPiece2Pos;
        GameData.skillPiece2Deg = saveData.skillPiece2Deg;
        GameData.skillPiece3Pos = saveData.skillPiece3Pos;
        GameData.skillPiece3Deg = saveData.skillPiece3Deg;
        GameData.skillPiece4Pos = saveData.skillPiece4Pos;
        GameData.skillPiece4Deg = saveData.skillPiece4Deg;
        GameData.skillPiece5Pos = saveData.skillPiece5Pos;
        GameData.skillPiece5Deg = saveData.skillPiece5Deg;
        GameData.skillPiece6Pos = saveData.skillPiece6Pos;
        GameData.skillPiece6Deg = saveData.skillPiece6Deg;
        GameData.skillPiece7Pos = saveData.skillPiece7Pos;
        GameData.skillPiece7Deg = saveData.skillPiece7Deg;
        GameData.skillPiece8Pos = saveData.skillPiece8Pos;
        GameData.skillPiece8Deg = saveData.skillPiece8Deg;
        GameData.skillPiece9Pos = saveData.skillPiece9Pos;
        GameData.skillPiece9Deg = saveData.skillPiece9Deg;
        GameData.skillPiece10Pos = saveData.skillPiece10Pos;
        GameData.skillPiece10Deg = saveData.skillPiece10Deg;
        GameData.skillPiece11Pos = saveData.skillPiece11Pos;
        GameData.skillPiece11Deg = saveData.skillPiece11Deg;
        GameData.skillPiece12Pos = saveData.skillPiece12Pos;
        GameData.skillPiece12Deg = saveData.skillPiece12Deg;
        GameData.skillPiece13Pos = saveData.skillPiece13Pos;
        GameData.skillPiece13Deg = saveData.skillPiece13Deg;
        GameData.skillPiece14Pos = saveData.skillPiece14Pos;
        GameData.skillPiece14Deg = saveData.skillPiece14Deg;
        GameData.skillPiece15Pos = saveData.skillPiece15Pos;
        GameData.skillPiece15Deg = saveData.skillPiece15Deg;
        GameData.skillPiece16Pos = saveData.skillPiece16Pos;
        GameData.skillPiece16Deg = saveData.skillPiece16Deg;
        GameData.skillPiece17Pos = saveData.skillPiece17Pos;
        GameData.skillPiece17Deg = saveData.skillPiece17Deg;
        GameData.skillPiece18Pos = saveData.skillPiece18Pos;
        GameData.skillPiece18Deg = saveData.skillPiece18Deg;
        GameData.skillPiece19Pos = saveData.skillPiece19Pos;
        GameData.skillPiece19Deg = saveData.skillPiece19Deg;
        GameData.saveSkillPreset1[0] = saveData.saveSkillPreset1[0];
        for (int i = 0; i < 20; i++)
        {
            GameData.saveSkillPreset1[i] = saveData.saveSkillPreset1[i];
            GameData.saveSkillPreset2[i] = saveData.saveSkillPreset2[i];
            GameData.saveSkillPreset3[i] = saveData.saveSkillPreset3[i];
            GameData.setSkillPreset1[i] = saveData.setSkillPreset1[i];
            GameData.setSkillPreset2[i] = saveData.setSkillPreset2[i];
            GameData.setSkillPreset3[i] = saveData.setSkillPreset3[i];
            GameData.skillPieceDegPreset1[i] = saveData.skillPieceDegPreset1[i];
            GameData.skillPieceDegPreset2[i] = saveData.skillPieceDegPreset2[i];
            GameData.skillPieceDegPreset3[i] = saveData.skillPieceDegPreset3[i];
            GameData.skillPiecePosPreset1[i] = saveData.skillPiecePosPreset1[i];
            GameData.skillPiecePosPreset2[i] = saveData.skillPiecePosPreset2[i];
            GameData.skillPiecePosPreset3[i] = saveData.skillPiecePosPreset3[i];
        }

        GameData.skillSlot1 = saveData.skillSlot1;
        GameData.skillSlot2 = saveData.skillSlot2;
        GameData.skillSlot3 = saveData.skillSlot3;
        GameData.skillSlot4 = saveData.skillSlot4;

        for (int i = 0; i < 4; i++)
        {
            GameData.skillSlotPreset1[i] = saveData.skillSlotPreset1[i];
            GameData.skillSlotPreset2[i] = saveData.skillSlotPreset2[i];
            GameData.skillSlotPreset3[i] = saveData.skillSlotPreset3[i];
        }

        GameData.playerNowHp = saveData.playerNowHp;

        GameData.ShoggothDead = saveData.ShoggothDead;
        GameData.FafnirDead = saveData.FafnirDead;
        GameData.QilinDead = saveData.QilinDead;

        GameData.ClearTime = saveData.ClearTime;
        GameData.HitCount = saveData.HitCount;
        GameData.SkillCount = saveData.SkillCount;
        GameData.justGuardCount = saveData.justGuardCount;

        GameData.bestTimeShoggoth = saveData.bestTimeShoggoth;
        GameData.bestTimeFafnir = saveData.bestTimeFafnir;
        GameData.bestTimeQilin = saveData.bestTimeQilin;

        GameData.playTime = saveData.playTime;
        GameData.lastYear = saveData.lastYear;
        GameData.lastMonth = saveData.lastMonth;
        GameData.lastDay = saveData.lastDay;
        GameData.lastHour = saveData.lastHour;
        GameData.lastMinute = saveData.lastMinute;

        if (Conconnect != null)
        {
            if (Conconnect == false)
            {
                Conconnect.conread();
                Debug.Log("コントローラーロード");
                //Debug.Log(GameData.rightkey);
                //Debug.Log(GameData.leftkey);
                //Debug.Log(GameData.downkey);
                //Debug.Log(GameData.jumpkey);
                //Debug.Log(GameData.attackkey);
                //Debug.Log(GameData.dashkey);
                //Debug.Log(GameData.healkey);
                //Debug.Log(GameData.interactkey);
            }
            else
            {
                Conconnect.keyread();
                Debug.Log("キーボードロード");
                //Debug.Log(GameData.rightkey);
                //Debug.Log(GameData.leftkey);
                //Debug.Log(GameData.downkey);
                //Debug.Log(GameData.jumpkey);
                //Debug.Log(GameData.attackkey);
                //Debug.Log(GameData.dashkey);
                //Debug.Log(GameData.healkey);
                //Debug.Log(GameData.interactkey);
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