using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPreset : MonoBehaviour
{
    public SkillPieceData spdata;
    public SkillSetDirector ssd;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            spdata.SaveSkillPiece();
            Debug.Log("プリセット1保存");
            Preset1save();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            spdata.SaveSkillPiece();
            Debug.Log("プリセット2保存");
            Preset2save();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            spdata.SaveSkillPiece();
            Debug.Log("プリセット3保存");
            Preset3save();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            //ssd.AllReset();
            Preset1read();
            Debug.Log("セーブスキル１" + GameData.saveSkill1);
            Debug.Log("プリセット1読込");
            spdata.ReadSkillPiece();
            //spdata.SaveSkillPiece();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            //ssd.AllReset();

            Preset2read();
            Debug.Log("セーブスキル１" + GameData.saveSkill1);

            Debug.Log("プリセット2読込");
            spdata.ReadSkillPiece();
            //spdata.SaveSkillPiece();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            //ssd.AllReset();

            Preset3read();
            Debug.Log("プリセット3読込");
            spdata.ReadSkillPiece();
            //spdata.SaveSkillPiece();
        }
    }
    public void Preset1save()
    {
        GameData.saveSkillPreset1[0] = GameData.saveSkill1;
        GameData.saveSkillPreset1[1] = GameData.saveSkill2;
        GameData.saveSkillPreset1[2] = GameData.saveSkill3;
        GameData.saveSkillPreset1[3] = GameData.saveSkill4;
        GameData.saveSkillPreset1[4] = GameData.saveSkill5;
        GameData.saveSkillPreset1[5] = GameData.saveSkill10;
        GameData.saveSkillPreset1[6] = GameData.saveSkill11;
        GameData.saveSkillPreset1[7] = GameData.saveSkill12;
        GameData.saveSkillPreset1[8] = GameData.saveSkill13;
        GameData.saveSkillPreset1[9] = GameData.saveSkill14;
        GameData.saveSkillPreset1[10] = GameData.saveSkill15;
        GameData.saveSkillPreset1[11] = GameData.saveSkill16;
        GameData.saveSkillPreset1[12] = GameData.saveSkill17;
        GameData.saveSkillPreset1[13] = GameData.saveSkill18;
        GameData.saveSkillPreset1[14] = GameData.saveSkill19;
        GameData.setSkillPreset1[0] = GameData.setSkill1;
        GameData.setSkillPreset1[1] = GameData.setSkill2;
        GameData.setSkillPreset1[2] = GameData.setSkill3;
        GameData.setSkillPreset1[3] = GameData.setSkill4;
        GameData.setSkillPreset1[4] = GameData.setSkill5;
        GameData.setSkillPreset1[5] = GameData.setSkill10;
        GameData.setSkillPreset1[6] = GameData.setSkill11;
        GameData.setSkillPreset1[7] = GameData.setSkill12;
        GameData.setSkillPreset1[8] = GameData.setSkill13;
        GameData.setSkillPreset1[9] = GameData.setSkill14;
        GameData.setSkillPreset1[10] = GameData.setSkill15;
        GameData.setSkillPreset1[11] = GameData.setSkill16;
        GameData.setSkillPreset1[12] = GameData.setSkill17;
        GameData.setSkillPreset1[13] = GameData.setSkill18;
        GameData.setSkillPreset1[14] = GameData.setSkill19;
        GameData.skillPieceDegPreset1[0] = GameData.skillPiece1Deg;
        GameData.skillPieceDegPreset1[1] = GameData.skillPiece2Deg;
        GameData.skillPieceDegPreset1[2] = GameData.skillPiece3Deg;
        GameData.skillPieceDegPreset1[3] = GameData.skillPiece4Deg;
        GameData.skillPieceDegPreset1[4] = GameData.skillPiece5Deg;
        GameData.skillPieceDegPreset1[5] = GameData.skillPiece10Deg;
        GameData.skillPieceDegPreset1[6] = GameData.skillPiece11Deg;
        GameData.skillPieceDegPreset1[7] = GameData.skillPiece12Deg;
        GameData.skillPieceDegPreset1[8] = GameData.skillPiece13Deg;
        GameData.skillPieceDegPreset1[9] = GameData.skillPiece14Deg;
        GameData.skillPieceDegPreset1[10] = GameData.skillPiece15Deg;
        GameData.skillPieceDegPreset1[11] = GameData.skillPiece16Deg;
        GameData.skillPieceDegPreset1[12] = GameData.skillPiece17Deg;
        GameData.skillPieceDegPreset1[13] = GameData.skillPiece18Deg;
        GameData.skillPieceDegPreset1[14] = GameData.skillPiece19Deg;
        GameData.skillPiecePosPreset1[0] = GameData.skillPiece1Pos;
        GameData.skillPiecePosPreset1[1] = GameData.skillPiece2Pos;
        GameData.skillPiecePosPreset1[2] = GameData.skillPiece3Pos;
        GameData.skillPiecePosPreset1[3] = GameData.skillPiece4Pos;
        GameData.skillPiecePosPreset1[4] = GameData.skillPiece5Pos;
        GameData.skillPiecePosPreset1[5] = GameData.skillPiece10Pos;
        GameData.skillPiecePosPreset1[6] = GameData.skillPiece11Pos;
        GameData.skillPiecePosPreset1[7] = GameData.skillPiece12Pos;
        GameData.skillPiecePosPreset1[8] = GameData.skillPiece13Pos;
        GameData.skillPiecePosPreset1[9] = GameData.skillPiece14Pos;
        GameData.skillPiecePosPreset1[10] = GameData.skillPiece15Pos;
        GameData.skillPiecePosPreset1[11] = GameData.skillPiece16Pos;
        GameData.skillPiecePosPreset1[12] = GameData.skillPiece17Pos;
        GameData.skillPiecePosPreset1[13] = GameData.skillPiece18Pos;
        GameData.skillPiecePosPreset1[14] = GameData.skillPiece19Pos;
        GameData.skillSlotPreset1[0] = GameData.skillSlot1;
        GameData.skillSlotPreset1[1] = GameData.skillSlot2;
        GameData.skillSlotPreset1[2] = GameData.skillSlot3;
        GameData.skillSlotPreset1[3] = GameData.skillSlot4;
    }
    public void Preset2save()
    {
        GameData.saveSkillPreset2[0] = GameData.saveSkill1;
        GameData.saveSkillPreset2[1] = GameData.saveSkill2;
        GameData.saveSkillPreset2[2] = GameData.saveSkill3;
        GameData.saveSkillPreset2[3] = GameData.saveSkill4;
        GameData.saveSkillPreset2[4] = GameData.saveSkill5;
        GameData.saveSkillPreset2[5] = GameData.saveSkill10;
        GameData.saveSkillPreset2[6] = GameData.saveSkill11;
        GameData.saveSkillPreset2[7] = GameData.saveSkill12;
        GameData.saveSkillPreset2[8] = GameData.saveSkill13;
        GameData.saveSkillPreset2[9] = GameData.saveSkill14;
        GameData.saveSkillPreset2[10] = GameData.saveSkill15;
        GameData.saveSkillPreset2[11] = GameData.saveSkill16;
        GameData.saveSkillPreset2[12] = GameData.saveSkill17;
        GameData.saveSkillPreset2[13] = GameData.saveSkill18;
        GameData.saveSkillPreset2[14] = GameData.saveSkill19;
        GameData.setSkillPreset2[0] = GameData.setSkill1;
        GameData.setSkillPreset2[1] = GameData.setSkill2;
        GameData.setSkillPreset2[2] = GameData.setSkill3;
        GameData.setSkillPreset2[3] = GameData.setSkill4;
        GameData.setSkillPreset2[4] = GameData.setSkill5;
        GameData.setSkillPreset2[5] = GameData.setSkill10;
        GameData.setSkillPreset2[6] = GameData.setSkill11;
        GameData.setSkillPreset2[7] = GameData.setSkill12;
        GameData.setSkillPreset2[8] = GameData.setSkill13;
        GameData.setSkillPreset2[9] = GameData.setSkill14;
        GameData.setSkillPreset2[10] = GameData.setSkill15;
        GameData.setSkillPreset2[11] = GameData.setSkill16;
        GameData.setSkillPreset2[12] = GameData.setSkill17;
        GameData.setSkillPreset2[13] = GameData.setSkill18;
        GameData.setSkillPreset2[14] = GameData.setSkill19;
        GameData.skillPieceDegPreset2[0] = GameData.skillPiece1Deg;
        GameData.skillPieceDegPreset2[1] = GameData.skillPiece2Deg;
        GameData.skillPieceDegPreset2[2] = GameData.skillPiece3Deg;
        GameData.skillPieceDegPreset2[3] = GameData.skillPiece4Deg;
        GameData.skillPieceDegPreset2[4] = GameData.skillPiece5Deg;
        GameData.skillPieceDegPreset2[5] = GameData.skillPiece10Deg;
        GameData.skillPieceDegPreset2[6] = GameData.skillPiece11Deg;
        GameData.skillPieceDegPreset2[7] = GameData.skillPiece12Deg;
        GameData.skillPieceDegPreset2[8] = GameData.skillPiece13Deg;
        GameData.skillPieceDegPreset2[9] = GameData.skillPiece14Deg;
        GameData.skillPieceDegPreset2[10] = GameData.skillPiece15Deg;
        GameData.skillPieceDegPreset2[11] = GameData.skillPiece16Deg;
        GameData.skillPieceDegPreset2[12] = GameData.skillPiece17Deg;
        GameData.skillPieceDegPreset2[13] = GameData.skillPiece18Deg;
        GameData.skillPieceDegPreset2[14] = GameData.skillPiece19Deg;
        GameData.skillPiecePosPreset2[0] = GameData.skillPiece1Pos;
        GameData.skillPiecePosPreset2[1] = GameData.skillPiece2Pos;
        GameData.skillPiecePosPreset2[2] = GameData.skillPiece3Pos;
        GameData.skillPiecePosPreset2[3] = GameData.skillPiece4Pos;
        GameData.skillPiecePosPreset2[4] = GameData.skillPiece5Pos;
        GameData.skillPiecePosPreset2[5] = GameData.skillPiece10Pos;
        GameData.skillPiecePosPreset2[6] = GameData.skillPiece11Pos;
        GameData.skillPiecePosPreset2[7] = GameData.skillPiece12Pos;
        GameData.skillPiecePosPreset2[8] = GameData.skillPiece13Pos;
        GameData.skillPiecePosPreset2[9] = GameData.skillPiece14Pos;
        GameData.skillPiecePosPreset2[10] = GameData.skillPiece15Pos;
        GameData.skillPiecePosPreset2[11] = GameData.skillPiece16Pos;
        GameData.skillPiecePosPreset2[12] = GameData.skillPiece17Pos;
        GameData.skillPiecePosPreset2[13] = GameData.skillPiece18Pos;
        GameData.skillPiecePosPreset2[14] = GameData.skillPiece19Pos;
        GameData.skillSlotPreset2[0] = GameData.skillSlot1;
        GameData.skillSlotPreset2[1] = GameData.skillSlot2;
        GameData.skillSlotPreset2[2] = GameData.skillSlot3;
        GameData.skillSlotPreset2[3] = GameData.skillSlot4;
    }
    public void Preset3save()
    {
        GameData.saveSkillPreset3[0] = GameData.saveSkill1;
        GameData.saveSkillPreset3[1] = GameData.saveSkill2;
        GameData.saveSkillPreset3[2] = GameData.saveSkill3;
        GameData.saveSkillPreset3[3] = GameData.saveSkill4;
        GameData.saveSkillPreset3[4] = GameData.saveSkill5;
        GameData.saveSkillPreset3[5] = GameData.saveSkill10;
        GameData.saveSkillPreset3[6] = GameData.saveSkill11;
        GameData.saveSkillPreset3[7] = GameData.saveSkill12;
        GameData.saveSkillPreset3[8] = GameData.saveSkill13;
        GameData.saveSkillPreset3[9] = GameData.saveSkill14;
        GameData.saveSkillPreset3[10] = GameData.saveSkill15;
        GameData.saveSkillPreset3[11] = GameData.saveSkill16;
        GameData.saveSkillPreset3[12] = GameData.saveSkill17;
        GameData.saveSkillPreset3[13] = GameData.saveSkill18;
        GameData.saveSkillPreset3[14] = GameData.saveSkill19;
        GameData.setSkillPreset3[0] = GameData.setSkill1;
        GameData.setSkillPreset3[1] = GameData.setSkill2;
        GameData.setSkillPreset3[2] = GameData.setSkill3;
        GameData.setSkillPreset3[3] = GameData.setSkill4;
        GameData.setSkillPreset3[4] = GameData.setSkill5;
        GameData.setSkillPreset3[5] = GameData.setSkill10;
        GameData.setSkillPreset3[6] = GameData.setSkill11;
        GameData.setSkillPreset3[7] = GameData.setSkill12;
        GameData.setSkillPreset3[8] = GameData.setSkill13;
        GameData.setSkillPreset3[9] = GameData.setSkill14;
        GameData.setSkillPreset3[10] = GameData.setSkill15;
        GameData.setSkillPreset3[11] = GameData.setSkill16;
        GameData.setSkillPreset3[12] = GameData.setSkill17;
        GameData.setSkillPreset3[13] = GameData.setSkill18;
        GameData.setSkillPreset3[14] = GameData.setSkill19;
        GameData.skillPieceDegPreset3[0] = GameData.skillPiece1Deg;
        GameData.skillPieceDegPreset3[1] = GameData.skillPiece2Deg;
        GameData.skillPieceDegPreset3[2] = GameData.skillPiece3Deg;
        GameData.skillPieceDegPreset3[3] = GameData.skillPiece4Deg;
        GameData.skillPieceDegPreset3[4] = GameData.skillPiece5Deg;
        GameData.skillPieceDegPreset3[5] = GameData.skillPiece10Deg;
        GameData.skillPieceDegPreset3[6] = GameData.skillPiece11Deg;
        GameData.skillPieceDegPreset3[7] = GameData.skillPiece12Deg;
        GameData.skillPieceDegPreset3[8] = GameData.skillPiece13Deg;
        GameData.skillPieceDegPreset3[9] = GameData.skillPiece14Deg;
        GameData.skillPieceDegPreset3[10] = GameData.skillPiece15Deg;
        GameData.skillPieceDegPreset3[11] = GameData.skillPiece16Deg;
        GameData.skillPieceDegPreset3[12] = GameData.skillPiece17Deg;
        GameData.skillPieceDegPreset3[13] = GameData.skillPiece18Deg;
        GameData.skillPieceDegPreset3[14] = GameData.skillPiece19Deg;
        GameData.skillPiecePosPreset3[0] = GameData.skillPiece1Pos;
        GameData.skillPiecePosPreset3[1] = GameData.skillPiece2Pos;
        GameData.skillPiecePosPreset3[2] = GameData.skillPiece3Pos;
        GameData.skillPiecePosPreset3[3] = GameData.skillPiece4Pos;
        GameData.skillPiecePosPreset3[4] = GameData.skillPiece5Pos;
        GameData.skillPiecePosPreset3[5] = GameData.skillPiece10Pos;
        GameData.skillPiecePosPreset3[6] = GameData.skillPiece11Pos;
        GameData.skillPiecePosPreset3[7] = GameData.skillPiece12Pos;
        GameData.skillPiecePosPreset3[8] = GameData.skillPiece13Pos;
        GameData.skillPiecePosPreset3[9] = GameData.skillPiece14Pos;
        GameData.skillPiecePosPreset3[10] = GameData.skillPiece15Pos;
        GameData.skillPiecePosPreset3[11] = GameData.skillPiece16Pos;
        GameData.skillPiecePosPreset3[12] = GameData.skillPiece17Pos;
        GameData.skillPiecePosPreset3[13] = GameData.skillPiece18Pos;
        GameData.skillPiecePosPreset3[14] = GameData.skillPiece19Pos;
        GameData.skillSlotPreset3[0] = GameData.skillSlot1;
        GameData.skillSlotPreset3[1] = GameData.skillSlot2;
        GameData.skillSlotPreset3[2] = GameData.skillSlot3;
        GameData.skillSlotPreset3[3] = GameData.skillSlot4;
    }
    public void Preset1read()
    {
        GameData.saveSkill1 = GameData.saveSkillPreset1[0];
        GameData.saveSkill2 = GameData.saveSkillPreset1[1];
        GameData.saveSkill3 = GameData.saveSkillPreset1[2];
        GameData.saveSkill4 = GameData.saveSkillPreset1[3];
        GameData.saveSkill5 = GameData.saveSkillPreset1[4];
        GameData.saveSkill10 = GameData.saveSkillPreset1[5];
        GameData.saveSkill11 = GameData.saveSkillPreset1[6];
        GameData.saveSkill12 = GameData.saveSkillPreset1[7];
        GameData.saveSkill13 = GameData.saveSkillPreset1[8];
        GameData.saveSkill14 = GameData.saveSkillPreset1[9];
        GameData.saveSkill15 = GameData.saveSkillPreset1[10];
        GameData.saveSkill16 = GameData.saveSkillPreset1[11];
        GameData.saveSkill17 = GameData.saveSkillPreset1[12];
        GameData.saveSkill18 = GameData.saveSkillPreset1[13];
        GameData.saveSkill19 = GameData.saveSkillPreset1[14];
        GameData.setSkill1 = GameData.setSkillPreset1[0];
        GameData.setSkill2 = GameData.setSkillPreset1[1];
        GameData.setSkill3 = GameData.setSkillPreset1[2];
        GameData.setSkill4 = GameData.setSkillPreset1[3];
        GameData.setSkill5 = GameData.setSkillPreset1[4];
        GameData.setSkill10 = GameData.setSkillPreset1[5];
        GameData.setSkill11 = GameData.setSkillPreset1[6];
        GameData.setSkill12 = GameData.setSkillPreset1[7];
        GameData.setSkill13 = GameData.setSkillPreset1[8];
        GameData.setSkill14 = GameData.setSkillPreset1[9];
        GameData.setSkill15 = GameData.setSkillPreset1[10];
        GameData.setSkill16 = GameData.setSkillPreset1[11];
        GameData.setSkill17 = GameData.setSkillPreset1[12];
        GameData.setSkill18 = GameData.setSkillPreset1[13];
        GameData.setSkill19 = GameData.setSkillPreset1[14];
        GameData.skillPiece1Pos = GameData.skillPiecePosPreset1[0];
        GameData.skillPiece2Pos = GameData.skillPiecePosPreset1[1];
        GameData.skillPiece3Pos = GameData.skillPiecePosPreset1[2];
        GameData.skillPiece4Pos = GameData.skillPiecePosPreset1[3];
        GameData.skillPiece5Pos = GameData.skillPiecePosPreset1[4];
        GameData.skillPiece10Pos = GameData.skillPiecePosPreset1[5];
        GameData.skillPiece11Pos = GameData.skillPiecePosPreset1[6];
        GameData.skillPiece12Pos = GameData.skillPiecePosPreset1[7];
        GameData.skillPiece13Pos = GameData.skillPiecePosPreset1[8];
        GameData.skillPiece14Pos = GameData.skillPiecePosPreset1[9];
        GameData.skillPiece15Pos = GameData.skillPiecePosPreset1[10];
        GameData.skillPiece16Pos = GameData.skillPiecePosPreset1[11];
        GameData.skillPiece17Pos = GameData.skillPiecePosPreset1[12];
        GameData.skillPiece18Pos = GameData.skillPiecePosPreset1[13];
        GameData.skillPiece19Pos = GameData.skillPiecePosPreset1[14];
        GameData.skillPiece1Deg = GameData.skillPieceDegPreset1[0];
        GameData.skillPiece2Deg = GameData.skillPieceDegPreset1[1];
        GameData.skillPiece3Deg = GameData.skillPieceDegPreset1[2];
        GameData.skillPiece4Deg = GameData.skillPieceDegPreset1[3];
        GameData.skillPiece5Deg = GameData.skillPieceDegPreset1[4];
        GameData.skillPiece10Deg = GameData.skillPieceDegPreset1[5];
        GameData.skillPiece11Deg = GameData.skillPieceDegPreset1[6];
        GameData.skillPiece12Deg = GameData.skillPieceDegPreset1[7];
        GameData.skillPiece13Deg = GameData.skillPieceDegPreset1[8];
        GameData.skillPiece14Deg = GameData.skillPieceDegPreset1[9];
        GameData.skillPiece15Deg = GameData.skillPieceDegPreset1[10];
        GameData.skillPiece16Deg = GameData.skillPieceDegPreset1[11];
        GameData.skillPiece17Deg = GameData.skillPieceDegPreset1[12];
        GameData.skillPiece18Deg = GameData.skillPieceDegPreset1[13];
        GameData.skillPiece19Deg = GameData.skillPieceDegPreset1[14];
        GameData.skillSlot1 = GameData.skillSlotPreset1[0];
        GameData.skillSlot2 = GameData.skillSlotPreset1[1];
        GameData.skillSlot3 = GameData.skillSlotPreset1[2];
        GameData.skillSlot4 = GameData.skillSlotPreset1[3];
    }
    public void Preset2read()
    {
        GameData.saveSkill1 = GameData.saveSkillPreset2[0];
        GameData.saveSkill2 = GameData.saveSkillPreset2[1];
        GameData.saveSkill3 = GameData.saveSkillPreset2[2];
        GameData.saveSkill4 = GameData.saveSkillPreset2[3];
        GameData.saveSkill5 = GameData.saveSkillPreset2[4];
        GameData.saveSkill10 = GameData.saveSkillPreset2[5];
        GameData.saveSkill11 = GameData.saveSkillPreset2[6];
        GameData.saveSkill12 = GameData.saveSkillPreset2[7];
        GameData.saveSkill13 = GameData.saveSkillPreset2[8];
        GameData.saveSkill14 = GameData.saveSkillPreset2[9];
        GameData.saveSkill15 = GameData.saveSkillPreset2[10];
        GameData.saveSkill16 = GameData.saveSkillPreset2[11];
        GameData.saveSkill17 = GameData.saveSkillPreset2[12];
        GameData.saveSkill18 = GameData.saveSkillPreset2[13];
        GameData.saveSkill19 = GameData.saveSkillPreset2[14];
        GameData.setSkill1 = GameData.setSkillPreset2[0];
        GameData.setSkill2 = GameData.setSkillPreset2[1];
        GameData.setSkill3 = GameData.setSkillPreset2[2];
        GameData.setSkill4 = GameData.setSkillPreset2[3];
        GameData.setSkill5 = GameData.setSkillPreset2[4];
        GameData.setSkill10 = GameData.setSkillPreset2[5];
        GameData.setSkill11 = GameData.setSkillPreset2[6];
        GameData.setSkill12 = GameData.setSkillPreset2[7];
        GameData.setSkill13 = GameData.setSkillPreset2[8];
        GameData.setSkill14 = GameData.setSkillPreset2[9];
        GameData.setSkill15 = GameData.setSkillPreset2[10];
        GameData.setSkill16 = GameData.setSkillPreset2[11];
        GameData.setSkill17 = GameData.setSkillPreset2[12];
        GameData.setSkill18 = GameData.setSkillPreset2[13];
        GameData.setSkill19 = GameData.setSkillPreset2[14];
        GameData.skillPiece1Pos = GameData.skillPiecePosPreset2[0];
        GameData.skillPiece2Pos = GameData.skillPiecePosPreset2[1];
        GameData.skillPiece3Pos = GameData.skillPiecePosPreset2[2];
        GameData.skillPiece4Pos = GameData.skillPiecePosPreset2[3];
        GameData.skillPiece5Pos = GameData.skillPiecePosPreset2[4];
        GameData.skillPiece10Pos = GameData.skillPiecePosPreset2[5];
        GameData.skillPiece11Pos = GameData.skillPiecePosPreset2[6];
        GameData.skillPiece12Pos = GameData.skillPiecePosPreset2[7];
        GameData.skillPiece13Pos = GameData.skillPiecePosPreset2[8];
        GameData.skillPiece14Pos = GameData.skillPiecePosPreset2[9];
        GameData.skillPiece15Pos = GameData.skillPiecePosPreset2[10];
        GameData.skillPiece16Pos = GameData.skillPiecePosPreset2[11];
        GameData.skillPiece17Pos = GameData.skillPiecePosPreset2[12];
        GameData.skillPiece18Pos = GameData.skillPiecePosPreset2[13];
        GameData.skillPiece19Pos = GameData.skillPiecePosPreset2[14];
        GameData.skillPiece1Deg = GameData.skillPieceDegPreset2[0];
        GameData.skillPiece2Deg = GameData.skillPieceDegPreset2[1];
        GameData.skillPiece3Deg = GameData.skillPieceDegPreset2[2];
        GameData.skillPiece4Deg = GameData.skillPieceDegPreset2[3];
        GameData.skillPiece5Deg = GameData.skillPieceDegPreset2[4];
        GameData.skillPiece10Deg = GameData.skillPieceDegPreset2[5];
        GameData.skillPiece11Deg = GameData.skillPieceDegPreset2[6];
        GameData.skillPiece12Deg = GameData.skillPieceDegPreset2[7];
        GameData.skillPiece13Deg = GameData.skillPieceDegPreset2[8];
        GameData.skillPiece14Deg = GameData.skillPieceDegPreset2[9];
        GameData.skillPiece15Deg = GameData.skillPieceDegPreset2[10];
        GameData.skillPiece16Deg = GameData.skillPieceDegPreset2[11];
        GameData.skillPiece17Deg = GameData.skillPieceDegPreset2[12];
        GameData.skillPiece18Deg = GameData.skillPieceDegPreset2[13];
        GameData.skillPiece19Deg = GameData.skillPieceDegPreset2[14];
        GameData.skillSlot1 = GameData.skillSlotPreset2[0];
        GameData.skillSlot2 = GameData.skillSlotPreset2[1];
        GameData.skillSlot3 = GameData.skillSlotPreset2[2];
        GameData.skillSlot4 = GameData.skillSlotPreset2[3];
    }
    public void Preset3read()
    {
        GameData.saveSkill1 = GameData.saveSkillPreset3[0];
        GameData.saveSkill2 = GameData.saveSkillPreset3[1];
        GameData.saveSkill3 = GameData.saveSkillPreset3[2];
        GameData.saveSkill4 = GameData.saveSkillPreset3[3];
        GameData.saveSkill5 = GameData.saveSkillPreset3[4];
        GameData.saveSkill10 = GameData.saveSkillPreset3[5];
        GameData.saveSkill11 = GameData.saveSkillPreset3[6];
        GameData.saveSkill12 = GameData.saveSkillPreset3[7];
        GameData.saveSkill13 = GameData.saveSkillPreset3[8];
        GameData.saveSkill14 = GameData.saveSkillPreset3[9];
        GameData.saveSkill15 = GameData.saveSkillPreset3[10];
        GameData.saveSkill16 = GameData.saveSkillPreset3[11];
        GameData.saveSkill17 = GameData.saveSkillPreset3[12];
        GameData.saveSkill18 = GameData.saveSkillPreset3[13];
        GameData.saveSkill19 = GameData.saveSkillPreset3[14];
        GameData.setSkill1 = GameData.setSkillPreset3[0];
        GameData.setSkill2 = GameData.setSkillPreset3[1];
        GameData.setSkill3 = GameData.setSkillPreset3[2];
        GameData.setSkill4 = GameData.setSkillPreset3[3];
        GameData.setSkill5 = GameData.setSkillPreset3[4];
        GameData.setSkill10 = GameData.setSkillPreset3[5];
        GameData.setSkill11 = GameData.setSkillPreset3[6];
        GameData.setSkill12 = GameData.setSkillPreset3[7];
        GameData.setSkill13 = GameData.setSkillPreset3[8];
        GameData.setSkill14 = GameData.setSkillPreset3[9];
        GameData.setSkill15 = GameData.setSkillPreset3[10];
        GameData.setSkill16 = GameData.setSkillPreset3[11];
        GameData.setSkill17 = GameData.setSkillPreset3[12];
        GameData.setSkill18 = GameData.setSkillPreset3[13];
        GameData.setSkill19 = GameData.setSkillPreset3[14];
        GameData.skillPiece1Pos = GameData.skillPiecePosPreset3[0];
        GameData.skillPiece2Pos = GameData.skillPiecePosPreset3[1];
        GameData.skillPiece3Pos = GameData.skillPiecePosPreset3[2];
        GameData.skillPiece4Pos = GameData.skillPiecePosPreset3[3];
        GameData.skillPiece5Pos = GameData.skillPiecePosPreset3[4];
        GameData.skillPiece10Pos = GameData.skillPiecePosPreset3[5];
        GameData.skillPiece11Pos = GameData.skillPiecePosPreset3[6];
        GameData.skillPiece12Pos = GameData.skillPiecePosPreset3[7];
        GameData.skillPiece13Pos = GameData.skillPiecePosPreset3[8];
        GameData.skillPiece14Pos = GameData.skillPiecePosPreset3[9];
        GameData.skillPiece15Pos = GameData.skillPiecePosPreset3[10];
        GameData.skillPiece16Pos = GameData.skillPiecePosPreset3[11];
        GameData.skillPiece17Pos = GameData.skillPiecePosPreset3[12];
        GameData.skillPiece18Pos = GameData.skillPiecePosPreset3[13];
        GameData.skillPiece19Pos = GameData.skillPiecePosPreset3[14];
        GameData.skillPiece1Deg = GameData.skillPieceDegPreset3[0];
        GameData.skillPiece2Deg = GameData.skillPieceDegPreset3[1];
        GameData.skillPiece3Deg = GameData.skillPieceDegPreset3[2];
        GameData.skillPiece4Deg = GameData.skillPieceDegPreset3[3];
        GameData.skillPiece5Deg = GameData.skillPieceDegPreset3[4];
        GameData.skillPiece10Deg = GameData.skillPieceDegPreset3[5];
        GameData.skillPiece11Deg = GameData.skillPieceDegPreset3[6];
        GameData.skillPiece12Deg = GameData.skillPieceDegPreset3[7];
        GameData.skillPiece13Deg = GameData.skillPieceDegPreset3[8];
        GameData.skillPiece14Deg = GameData.skillPieceDegPreset3[9];
        GameData.skillPiece15Deg = GameData.skillPieceDegPreset3[10];
        GameData.skillPiece16Deg = GameData.skillPieceDegPreset3[11];
        GameData.skillPiece17Deg = GameData.skillPieceDegPreset3[12];
        GameData.skillPiece18Deg = GameData.skillPieceDegPreset3[13];
        GameData.skillPiece19Deg = GameData.skillPieceDegPreset3[14];
        GameData.skillSlot1 = GameData.skillSlotPreset3[0];
        GameData.skillSlot2 = GameData.skillSlotPreset3[1];
        GameData.skillSlot3 = GameData.skillSlotPreset3[2];
        GameData.skillSlot4 = GameData.skillSlotPreset3[3];
    }
}
