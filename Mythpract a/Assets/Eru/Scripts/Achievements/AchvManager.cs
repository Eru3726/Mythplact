using System.IO;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class AchvManager : MonoBehaviour
{
    private bool slimeDontKill;
    private bool withinTime;
    private bool useActiveSkillsOnly;
    private bool withoutSettingActiveSkill;
    private bool dontGuard;
    private bool deathMatch;
    private bool justGuardonly;
    private bool dontBlink;

    private void Awake()
    {
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }


    // 上書き情報の保存
    public void Save()
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
        string SaveFilePath = path + "/achievements.bytes";

        // セーブデータの作成
        AchvSaveData saveData = CreateSaveData();

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
    }


    public void Load()
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
        string SaveFilePath = path + "/achievements.bytes";

        //セーブファイルがあるか
        if (File.Exists(SaveFilePath))
        {
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
                AchvSaveData saveData = JsonUtility.FromJson<AchvSaveData>(decryptStr);

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
            //初期化
            slimeDontKill = false;
            withinTime = false;
            useActiveSkillsOnly = false;
            withoutSettingActiveSkill = false;
            dontGuard = false;
            deathMatch = false;
            justGuardonly = false;
            dontBlink = false;

            //更新
            //ChangeDisplay();
        }
    }



    // セーブデータの作成
    private AchvSaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        AchvSaveData saveData = new AchvSaveData();

        saveData.slimeDontKill = slimeDontKill;
        saveData.withinTime = withinTime;
        saveData.useActiveSkillsOnly = useActiveSkillsOnly;
        saveData.withoutSettingActiveSkill = withoutSettingActiveSkill;
        saveData.dontGuard = dontGuard;
        saveData.deathMatch = deathMatch;
        saveData.justGuardonly = justGuardonly;
        saveData.dontBlink = dontBlink;

        return saveData;
    }

    //データの読み込み（反映）
    private void ReadData(AchvSaveData saveData)
    {
        slimeDontKill = saveData.slimeDontKill;
        withinTime = saveData.withinTime;
        useActiveSkillsOnly = saveData.useActiveSkillsOnly;
        withoutSettingActiveSkill = saveData.withoutSettingActiveSkill;
        dontGuard = saveData.dontGuard;
        deathMatch = saveData.deathMatch;
        justGuardonly = saveData.justGuardonly;
        dontBlink = saveData.dontBlink;
    }


    /// <summary>
    ///  AesManagedマネージャーを取得
    /// </summary>
    /// <returns></returns>
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字
        string aesIv = "9783515974534791";
        string aesKey = "8794605659865454";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// <summary>
    /// AES暗号化
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    /// <summary>
    /// AES復号化
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        var aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

    //セーブデータ削除
    public void Init()
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

        //ファイル削除
        File.Delete(path + "/achievements.bytes");

        //リロード
        Load();

        Debug.Log("データの初期化が終わりました");
    }
}

[System.Serializable]
public class AchvSaveData
{
    public bool slimeDontKill = false;
    public bool withinTime = false;
    public bool useActiveSkillsOnly = false;
    public bool withoutSettingActiveSkill = false;
    public bool dontGuard = false;
    public bool deathMatch = false;
    public bool justGuardonly = false;
    public bool dontBlink = false;
}