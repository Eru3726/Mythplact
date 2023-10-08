//�t�@�C���̃f�[�^��ǂݍ��݂܂�

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
        //UnityEditor��Ȃ�
        //Asset�t�@�C���̒���Save�t�@�C���̃p�X������
        string path = Application.dataPath + "/Save";

#else
        //�����łȂ����
        //.exe������Ƃ����Save�t�@�C�����쐬�������̃p�X������
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = path + "/save" + DataManager.saveFile + ".bytes";

        //�Z�[�u�t�@�C�������邩
        if (File.Exists(SaveFilePath))
        {
            DataManager.saveData = true;

            //�t�@�C�����[�h���I�[�v���ɂ���
            FileStream file = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // �t�@�C���ǂݍ���
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // ������
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte�z��𕶎���ɕϊ�
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSON�`���̕�������Z�[�u�f�[�^�̃N���X�ɕϊ�
                SaveData saveData = JsonUtility.FromJson<SaveData>(decryptStr);

                //�f�[�^�̔��f
                ReadData(saveData);

            }
            finally
            {
                // �t�@�C�������
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            Debug.Log("�Z�[�u�t�@�C��������܂���");
            DataManager.saveData = false;
        }

        this.enabled = false;

    }

    //�f�[�^�̓ǂݍ��݁i���f�j
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
                Debug.Log("�R���g���[���[���[�h");
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
                Debug.Log("�L�[�{�[�h���[�h");
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


    /// AesManaged�}�l�[�W���[���擾
    private AesManaged GetAesManager()
    {
        //�C�ӂ̔��p�p��16����(Save.cs�Ɠ������)
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

    /// AES������
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�擾
        var aes = GetAesManager();
        // ������
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}