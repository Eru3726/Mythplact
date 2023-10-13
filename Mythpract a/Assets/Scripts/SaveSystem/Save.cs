//�f�[�^���t�@�C���ɕۑ����܂�

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

        // �Z�[�u�f�[�^�̍쐬
        SaveData saveData = CreateSaveData();

        // �Z�[�u�f�[�^��JSON�`���̕�����ɕϊ�
        string jsonString = JsonUtility.ToJson(saveData);

        // �������byte�z��ɕϊ�
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);

        // AES�Í���
        byte[] arrEncrypted = AesEncrypt(bytes);

        // �w�肵���p�X�Ƀt�@�C�����쐬
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        //�t�@�C���ɕۑ�����
        try
        {
            // �t�@�C���ɕۑ�
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // �t�@�C�������
            if (file != null)
            {
                file.Close();
            }
        }
        this.enabled = false;//���̃X�N���v�g���I�t�ɂ���
    }

    // �Z�[�u�f�[�^�̍쐬
    private SaveData CreateSaveData()
    {
        //�Z�[�u�f�[�^�̃C���X�^���X��
        SaveData saveData = new SaveData();

        //�Q�[���f�[�^�̒l���Z�[�u�f�[�^�ɑ��
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

        saveData.skillSlot1 = GameData.skillSlot1;
        saveData.skillSlot2 = GameData.skillSlot2;
        saveData.skillSlot3 = GameData.skillSlot3;
        saveData.skillSlot4 = GameData.skillSlot4;

        saveData.playerNowHp = GameData.playerNowHp;

        saveData.ShoggothDead = GameData.ShoggothDead;
        saveData.FafnirDead = GameData.FafnirDead;

        saveData.ClearTime = GameData.ClearTime;
        saveData.HitCount = GameData.HitCount;
        saveData.SkillCount = GameData.SkillCount;

        return saveData;
    }


    /// AesManaged�}�l�[�W���[���擾

    private AesManaged GetAesManager()
    {
        //�C�ӂ̔��p�p��16����(Read.cs�Ɠ������)
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

    /// AES�Í���
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�̎擾
        AesManaged aes = GetAesManager();
        // �Í���
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}