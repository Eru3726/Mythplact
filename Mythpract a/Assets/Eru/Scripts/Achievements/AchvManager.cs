using System.IO;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class AchvManager : MonoBehaviour
{
    [HideInInspector]
    public bool dieXFlg;

    [HideInInspector]
    public int dieXCount = 0;

    [Header("実績解除死亡回数")]
    public int dieClearCount = 3;



    [HideInInspector]
    public bool blinkXFlg;

    [HideInInspector]
    public int blinkXCount = 0;

    [Header("実績解除ブリンク回数")]
    public int blinkClearCount = 3;



    [HideInInspector]
    public bool allBossFlg;

    [SerializeField, Header("ボスの数")]
    private int boss = 3;

    [HideInInspector]
    public bool[] defeatedBoss;



    [HideInInspector]
    public bool oneHpFlg;



    [HideInInspector]
    public bool attackComboFlg;



    [HideInInspector]
    public bool sheriffUseFlg;

    [HideInInspector]
    public int sheriffUseCount = 0;

    [Header("実績解除シェリフ回数")]
    public int sheriffClearCount = 3;



    [HideInInspector]
    public bool guardCountFlg;

    [HideInInspector]
    public int guardCount = 0;

    [Header("実績解除ガード回数")]
    public int guardClearCount = 3;



    [HideInInspector]
    public bool noDamage;



    [HideInInspector]
    public bool justGuardFlg;

    [HideInInspector]
    public int justGuardCount = 0;

    [Header("実績解除ジャストガード回数")]
    public int justGuardClearCount = 3;



    [HideInInspector]
    public bool noGuard;



    [HideInInspector]
    public bool activeSkillOnlyFlg;



    //[HideInInspector]
    //private bool timeAttack;

    public static AchvManager instance;

    private void Awake()
    {
        defeatedBoss = new bool[boss];
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
            dieXFlg = false;
            dieXCount = 0;

            blinkXFlg = false;
            blinkXCount = 0;

            allBossFlg = false;
            for (int i = 0; i < boss; i++) defeatedBoss[i] = false;

            oneHpFlg = false;

            attackComboFlg = false;

            sheriffUseFlg = false;
            sheriffUseCount = 0;

            guardCountFlg = false;
            guardCount = 0;

            noDamage = false;

            justGuardFlg = false;
            justGuardCount = 0;

            noGuard = false;

            activeSkillOnlyFlg = false;

            //timeAttack = false;

            //更新
            //ChangeDisplay();
        }
    }



    // セーブデータの作成
    private AchvSaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        AchvSaveData saveData = new AchvSaveData();

        saveData.dieXFlg = dieXFlg;
        saveData.dieXCount = dieXCount;

        saveData.blinkX = blinkXFlg;
        for (int i = 0; i < boss; i++) saveData.defeatedBoss[i] = defeatedBoss[i];

        saveData.allBoss = allBossFlg;

        saveData.oneHp = oneHpFlg;

        saveData.attackCombo = attackComboFlg;

        saveData.SheriffUseCount = sheriffUseCount;
        saveData.SheriffUseFlg = sheriffUseFlg;

        saveData.guardCountFlg = guardCountFlg;
        saveData.guardCount = guardCount;

        saveData.noDamage = noDamage;

        saveData.justGuardFlg = justGuardFlg;
        saveData.justGuardCount = justGuardCount;

        saveData.noGuard = noGuard;

        saveData.activeSkillOnly = activeSkillOnlyFlg;

        //saveData.timeAttack = timeAttack;

        return saveData;
    }

    //データの読み込み（反映）
    private void ReadData(AchvSaveData saveData)
    {
        dieXFlg = saveData.dieXFlg;
        dieXCount = saveData.dieXCount;

        blinkXFlg = saveData.blinkX;
        for (int i = 0; i < boss; i++) defeatedBoss[i] = saveData.defeatedBoss[i];

        allBossFlg = saveData.allBoss;

        oneHpFlg = saveData.oneHp;

        attackComboFlg = saveData.attackCombo;

        sheriffUseCount = saveData.SheriffUseCount;
        sheriffUseFlg = saveData.SheriffUseFlg;

        guardCountFlg = saveData.guardCountFlg;
        guardCount = saveData.guardCount;

        noDamage = saveData.noDamage;

        justGuardFlg = saveData.justGuardFlg;
        justGuardCount = saveData.justGuardCount;

        noGuard = saveData.noGuard;

        activeSkillOnlyFlg = saveData.activeSkillOnly;

        //timeAttack = saveData.timeAttack;
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
    public bool dieXFlg;
    public int dieXCount;

    public bool blinkX;
    public int blinkXCount;

    public bool allBoss;
    public bool[] defeatedBoss;

    public bool oneHp;

    public bool attackCombo;
    public int attackComboCount;

    public bool SheriffUseFlg;
    public int SheriffUseCount;

    public bool guardCountFlg;
    public int guardCount;

    public bool noDamage;

    public bool justGuardFlg;
    public int justGuardCount;

    public bool noGuard;

    public bool activeSkillOnly;

    //public bool timeAttack;
}