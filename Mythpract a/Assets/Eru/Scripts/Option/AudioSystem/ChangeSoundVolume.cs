using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField,Header("ミキサー")]
    private AudioMixer audioMixer;

    [SerializeField, Header("MASTERボリュームスライダー")]
    private Slider masterSlider;

    [SerializeField, Header("BGMボリュームスライダー")]
    private Slider bgmSlider;

    [SerializeField, Header("SEボリュームスライダー")]
    private Slider seSlider;

    [SerializeField, Header("MASTERミュートトグル")]
    private Toggle masterToggle;

    [SerializeField, Header("BGMミュートトグル")]
    private Toggle bgmToggle;

    [SerializeField, Header("SEミュートトグル")]
    private Toggle seToggle;

    private void Start()
    {
        Load();
        StartCoroutine(StartTpggle());
    }

    private IEnumerator StartTpggle()
    {
        yield return new WaitForSeconds(1.0f);

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
        string SaveFilePath = path + "/SoundVolume.bytes";

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
                AudioSaveData saveData = JsonUtility.FromJson<AudioSaveData>(decryptStr);

                //データの反映
                masterToggle.isOn = saveData.masFlg;
                bgmToggle.isOn = saveData.bgmFlg;
                seToggle.isOn = saveData.seFlg;

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
            //セーブファイルがない場合
            //初期化
            masterToggle.isOn = true;
            bgmToggle.isOn = true;
            seToggle.isOn = true;
        }
    }

    private void OnDestroy()
    {
        Save();
    }

    public void SetBGM(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            bgmToggle.isOn = false;
        }
        else bgmToggle.isOn = true;
        audioMixer.SetFloat("BgmVolume", volume);
    }

    public void SetSE(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            seToggle.isOn = false;
        }
        else seToggle.isOn = true;
        audioMixer.SetFloat("SeVolume", volume);
    }

    public void SetMASTER(float volume)
    {
        if (volume <= -50f)
        {
            volume = -80f;
            masterToggle.isOn = false;
        }
        else masterToggle.isOn = true;
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void MuteMASTER(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = masterSlider.value;

        audioMixer.SetFloat("MasterVolume", vol);
    }

    public void MuteBGM(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = bgmSlider.value;

        audioMixer.SetFloat("BgmVolume", vol);
    }

    public void MuteSE(bool mute)
    {
        float vol;
        if (!mute) vol = -80f;
        else vol = seSlider.value;

        audioMixer.SetFloat("SeVolume", vol);
    }


    /// <summary>
    /// セーブ
    /// </summary>
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
        string SaveFilePath = path + "/SoundVolume.bytes";

        // セーブデータの作成
        AudioSaveData saveData = CreateSaveData();

        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);

        // 文字列をbyte配列に変換
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

        // AES暗号化
        byte[] arrEncrypted = AesEncrypt(bytes);

        // 指定したパスにファイルを作成
        FileStream file = new(SaveFilePath, FileMode.Create, FileAccess.Write);

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


    /// <summary>
    /// ロード
    /// </summary>
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
        string SaveFilePath = path + "/SoundVolume.bytes";

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
                AudioSaveData saveData = JsonUtility.FromJson<AudioSaveData>(decryptStr);

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
            //セーブファイルがない場合
            //初期化
            masterSlider.value = 0;
            bgmSlider.value = 0;
            seSlider.value = 0;
            masterToggle.isOn = true;
            bgmToggle.isOn = true;
            seToggle.isOn = true;
        }
    }


    /// <summary>
    /// セーブデータの作成
    /// </summary>
    /// <returns></returns>
    private AudioSaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        AudioSaveData saveData = new()
        {
            //ゲームデータの値をセーブデータに代入
            //Master
            masVol = masterSlider.value,
            masFlg = masterToggle.isOn,

            //Bgm
            bgmVol = bgmSlider.value,
            bgmFlg = bgmToggle.isOn,

            //Se
            seVol = seSlider.value,
            seFlg = seToggle.isOn
        };

        return saveData;
    }

    /// <summary>
    /// データの読み込み（反映）
    /// </summary>
    /// <param name="saveData"></param>
    private void ReadData(AudioSaveData saveData)
    {
        //Master
        masterToggle.isOn = saveData.masFlg;
        masterSlider.value = saveData.masVol;
        audioMixer.SetFloat("MasterVolume", saveData.masVol);

        //Bgm
        bgmToggle.isOn = saveData.bgmFlg;
        bgmSlider.value = saveData.bgmVol;
        audioMixer.SetFloat("BgmVolume", saveData.bgmVol);

        //Se
        seToggle.isOn = saveData.seFlg;
        seSlider.value = saveData.seVol;
        audioMixer.SetFloat("SeVolume", saveData.seVol);
    }



    /// <summary>
    ///  AesManagedマネージャーを取得
    /// </summary>
    /// <returns></returns>
    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字(Read.csと同じやつに)
        string aesIv = "ndfiu89f329ifgh7";
        string aesKey = "otg3mene43ui238o";

        AesManaged aes = new()
        {
            KeySize = 128,
            BlockSize = 128,
            Mode = CipherMode.CBC,
            IV = Encoding.UTF8.GetBytes(aesIv),
            Key = Encoding.UTF8.GetBytes(aesKey),
            Padding = PaddingMode.PKCS7
        };
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

    /// <summary>
    /// セーブデータ削除
    /// </summary>
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
        File.Delete(path + "/SoundVolume.bytes");

        //リロード
        Load();

        Debug.Log("データの初期化が終わりました");
    }
}

[System.Serializable]
public class AudioSaveData
{
    public float masVol;
    public float bgmVol;
    public float seVol;
    public bool masFlg;
    public bool bgmFlg;
    public bool seFlg;
}
