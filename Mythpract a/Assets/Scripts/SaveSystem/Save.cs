//データをファイルに保存します
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{

    void OnEnable()
    {
        Debug.Log("セーブ開始");
        DoSave();
    }

    private void GetDateTime()
    {
        DateTime dt = DateTime.Now;
        GameData.lastYear = dt.Year;
        GameData.lastMonth = dt.Month;
        GameData.lastDay = dt.Day;
        GameData.lastHour = dt.Hour;
        GameData.lastMinute = dt.Minute;

        Debug.Log("今回のプレイ時間：" + ((int)Time.time - TitleManager.startTime));
        GameData.playTime += ((int)Time.time - TitleManager.startTime);
    }

    private void DoSave()
    {
        GetDateTime();

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
        saveData.saveSkill4 = GameData.saveSkill4;
        saveData.saveSkill5 = GameData.saveSkill5;
        saveData.saveSkill6 = GameData.saveSkill6;
        saveData.saveSkill7 = GameData.saveSkill7;
        saveData.saveSkill8 = GameData.saveSkill8;
        saveData.saveSkill9 = GameData.saveSkill9;
        saveData.saveSkill10 = GameData.saveSkill10;
        saveData.saveSkill11 = GameData.saveSkill11;
        saveData.saveSkill12 = GameData.saveSkill12;
        saveData.saveSkill13 = GameData.saveSkill13;
        saveData.saveSkill14 = GameData.saveSkill14;
        saveData.saveSkill15 = GameData.saveSkill15;
        saveData.saveSkill16 = GameData.saveSkill16;
        saveData.saveSkill17 = GameData.saveSkill17;
        saveData.saveSkill18 = GameData.saveSkill18;
        saveData.saveSkill19 = GameData.saveSkill19;


        saveData.setSkill1 = GameData.setSkill1;
        saveData.setSkill2 = GameData.setSkill2;
        saveData.setSkill3 = GameData.setSkill3;
        saveData.setSkill4 = GameData.setSkill4;
        saveData.setSkill5 = GameData.setSkill5;
        saveData.setSkill6 = GameData.setSkill6;
        saveData.setSkill7 = GameData.setSkill7;
        saveData.setSkill8 = GameData.setSkill8;
        saveData.setSkill9 = GameData.setSkill9;
        saveData.setSkill10 = GameData.setSkill10;
        saveData.setSkill11 = GameData.setSkill11;
        saveData.setSkill12 = GameData.setSkill12;
        saveData.setSkill13 = GameData.setSkill13;
        saveData.setSkill14 = GameData.setSkill14;
        saveData.setSkill15 = GameData.setSkill15;
        saveData.setSkill16 = GameData.setSkill16;
        saveData.setSkill17 = GameData.setSkill17;
        saveData.setSkill18 = GameData.setSkill18;
        saveData.setSkill19 = GameData.setSkill19;



        saveData.skillPiece1Pos = GameData.skillPiece1Pos;
        saveData.skillPiece1Deg = GameData.skillPiece1Deg;
        saveData.skillPiece2Pos = GameData.skillPiece2Pos;
        saveData.skillPiece2Deg = GameData.skillPiece2Deg;
        saveData.skillPiece3Pos = GameData.skillPiece3Pos;
        saveData.skillPiece3Deg = GameData.skillPiece3Deg;
        saveData.skillPiece4Pos = GameData.skillPiece4Pos;
        saveData.skillPiece4Deg = GameData.skillPiece4Deg;
        saveData.skillPiece5Pos = GameData.skillPiece5Pos;
        saveData.skillPiece5Deg = GameData.skillPiece5Deg;
        saveData.skillPiece6Pos = GameData.skillPiece6Pos;
        saveData.skillPiece6Deg = GameData.skillPiece6Deg;
        saveData.skillPiece7Pos = GameData.skillPiece7Pos;
        saveData.skillPiece7Deg = GameData.skillPiece7Deg;
        saveData.skillPiece8Pos = GameData.skillPiece8Pos;
        saveData.skillPiece8Deg = GameData.skillPiece8Deg;
        saveData.skillPiece9Pos = GameData.skillPiece9Pos;
        saveData.skillPiece9Deg = GameData.skillPiece9Deg;
        saveData.skillPiece10Pos = GameData.skillPiece10Pos;
        saveData.skillPiece10Deg = GameData.skillPiece10Deg;
        saveData.skillPiece11Pos = GameData.skillPiece11Pos;
        saveData.skillPiece11Deg = GameData.skillPiece11Deg;
        saveData.skillPiece12Pos = GameData.skillPiece12Pos;
        saveData.skillPiece12Deg = GameData.skillPiece12Deg;
        saveData.skillPiece13Pos = GameData.skillPiece13Pos;
        saveData.skillPiece13Deg = GameData.skillPiece13Deg;
        saveData.skillPiece14Pos = GameData.skillPiece14Pos;
        saveData.skillPiece14Deg = GameData.skillPiece14Deg;
        saveData.skillPiece15Pos = GameData.skillPiece15Pos;
        saveData.skillPiece15Deg = GameData.skillPiece15Deg;
        saveData.skillPiece16Pos = GameData.skillPiece16Pos;
        saveData.skillPiece16Deg = GameData.skillPiece16Deg;
        saveData.skillPiece17Pos = GameData.skillPiece17Pos;
        saveData.skillPiece17Deg = GameData.skillPiece17Deg;
        saveData.skillPiece18Pos = GameData.skillPiece18Pos;
        saveData.skillPiece18Deg = GameData.skillPiece18Deg;
        saveData.skillPiece19Pos = GameData.skillPiece19Pos;
        saveData.skillPiece19Deg = GameData.skillPiece19Deg;

        for(int i = 0;i<20;i++)
        {
            saveData.saveSkillPreset1[i] = GameData.saveSkillPreset1[i];
            saveData.saveSkillPreset2[i] = GameData.saveSkillPreset2[i];
            saveData.saveSkillPreset3[i] = GameData.saveSkillPreset3[i];
            saveData.setSkillPreset1[i] = GameData.setSkillPreset1[i];
            saveData.setSkillPreset2[i] = GameData.setSkillPreset2[i];
            saveData.setSkillPreset3[i] = GameData.setSkillPreset3[i];
            saveData.skillPieceDegPreset1[i] = GameData.skillPieceDegPreset1[i];
            saveData.skillPieceDegPreset2[i] = GameData.skillPieceDegPreset2[i];
            saveData.skillPieceDegPreset3[i] = GameData.skillPieceDegPreset3[i];
            saveData.skillPiecePosPreset1[i] = GameData.skillPiecePosPreset1[i];
            saveData.skillPiecePosPreset2[i] = GameData.skillPiecePosPreset2[i];
            saveData.skillPiecePosPreset3[i] = GameData.skillPiecePosPreset3[i];
        }


        saveData.skillSlot1 = GameData.skillSlot1;
        saveData.skillSlot2 = GameData.skillSlot2;
        saveData.skillSlot3 = GameData.skillSlot3;
        saveData.skillSlot4 = GameData.skillSlot4;

        for(int i = 0;i<4;i++)
        {
            saveData.skillSlotPreset1[i] = GameData.skillSlotPreset1[i];
            saveData.skillSlotPreset2[i] = GameData.skillSlotPreset2[i];
            saveData.skillSlotPreset3[i] = GameData.skillSlotPreset3[i];
        }

        saveData.playerNowHp = GameData.playerNowHp;

        saveData.ShoggothDead = GameData.ShoggothDead;
        saveData.FafnirDead = GameData.FafnirDead;
        saveData.QilinDead = GameData.QilinDead;

        saveData.ClearTime = GameData.ClearTime;
        saveData.HitCount = GameData.HitCount;
        saveData.SkillCount = GameData.SkillCount;
        saveData.justGuardCount = GameData.justGuardCount;

        saveData.bestTimeShoggoth = GameData.bestTimeShoggoth;
        saveData.bestTimeFafnir = GameData.bestTimeFafnir;
        saveData.bestTimeQilin = GameData.bestTimeQilin;

        saveData.playTime = GameData.playTime;
        saveData.lastYear = GameData.lastYear;
        saveData.lastMonth = GameData.lastMonth;
        saveData.lastDay = GameData.lastDay;
        saveData.lastHour = GameData.lastHour;
        saveData.lastMinute = GameData.lastMinute;


        saveData.dieXFlg = GameData.dieXFlg;
        saveData.dieXCount = GameData.dieXCount;

        saveData.blinkX = GameData.blinkXFlg;
        for (int i = 0; i < 3; i++) saveData.defeatedBoss[i] = GameData.defeatedBoss[i];

        saveData.allBoss = GameData.allBossFlg;

        saveData.oneHp = GameData.oneHpFlg;

        saveData.attackCombo = GameData.attackComboFlg;

        saveData.SheriffUseCount = GameData.sheriffUseCount;
        saveData.SheriffUseFlg = GameData.sheriffUseFlg;

        saveData.guardCountFlg = GameData.guardCountFlg;
        saveData.guardCount = GameData.guardCount;

        saveData.noDamage = GameData.noDamage;

        saveData.justGuardFlg = GameData.justGuardFlg;
        saveData.justGuardCount = GameData.justGuardCount;

        saveData.noGuard = GameData.noGuard;

        saveData.activeSkillOnly = GameData.activeSkillOnlyFlg;

        saveData.timeAttack = GameData.timeAttack;

        saveData.clearAchv = GameData.clearAchv;

        saveData.clearBoss = GameData.clearBoss;


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