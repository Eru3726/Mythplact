using UnityEngine;
using UnityEngine.UI;

public class SkillSetDirector : MonoBehaviour
{
    [SerializeField] Button SkillSelect_Button;
    [SerializeField] Button Skill1_Button;
    [SerializeField] Button Skill2_Button;
    [SerializeField] Button Skill3_Button;
    [SerializeField] Button Skill4_Button;
    [SerializeField] Button Skill5_Button;
    [SerializeField] Button Skill6_Button;
    [SerializeField] Button Skill7_Button;
    [SerializeField] Button Skill8_Button;
    [SerializeField] Button Skill9_Button;
    [SerializeField] Button Skill10_Button;
    [SerializeField] Button Skill11_Button;
    [SerializeField] Button Skill12_Button;
    [SerializeField] Button Skill13_Button;
    [SerializeField] Button Skill14_Button;
    [SerializeField] Button Skill15_Button;
    [SerializeField] Button Skill16_Button;
    [SerializeField] Button Skill17_Button;
    [SerializeField] Button Skill18_Button;
    [SerializeField] Button Skill19_Button;


    [SerializeField] GameObject NotInteractablePanel;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject Skill1;
    [SerializeField] GameObject Skill2;
    [SerializeField] GameObject Skill3;
    [SerializeField] GameObject Skill4;
    [SerializeField] GameObject Skill5;
    [SerializeField] GameObject Skill6;
    [SerializeField] GameObject Skill7;
    [SerializeField] GameObject Skill8;
    [SerializeField] GameObject Skill9;
    [SerializeField] GameObject Skill10;
    [SerializeField] GameObject Skill11;
    [SerializeField] GameObject Skill12;
    [SerializeField] GameObject Skill13;
    [SerializeField] GameObject Skill14;
    [SerializeField] GameObject Skill15;
    [SerializeField] GameObject Skill16;
    [SerializeField] GameObject Skill17;
    [SerializeField] GameObject Skill18;
    [SerializeField] GameObject Skill19;

    public DataManager dataManager;

    SkillPieceData spdata;
    CursorController cursorcontroller;

    GameObject grid;

    private Button firstSelectButton;


    private bool useCursor;
    // 繧ｫ繝ｼ繧ｽ繝ｫ菴ｿ逕ｨ譎ゅ↓True
    public bool useCursorProp
    {
        get { return useCursor; }
        set { useCursor = value; }
    }



    void Start()
    {
        firstSelectButton = GameObject.Find("Canvas/SkillSelect").GetComponent<Button>();
        cursorcontroller = cursor.GetComponent<CursorController>();



        firstSelectButton.Select();

        spdata = GameObject.Find("SkillPieceData").GetComponent<SkillPieceData>();

        grid = GameObject.Find("Grid");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("スキルスロット1に入っているもの" + GameData.skillSlot1);

        if (useCursorProp == false)
        {
            cursor.gameObject.SetActive(false);

            NotInteractablePanel.SetActive(false);

        }
        else
        {
            cursor.gameObject.SetActive(true);

            NotInteractablePanel.SetActive(true);

        }
    }
    public void AllReset()
    {
        GameData.skillSlot1 = 0;
        GameData.skillSlot2 = 0;
        GameData.skillSlot3 = 0;
        GameData.skillSlot4 = 0;

        GameData.saveSkill1 = false;
        GameData.saveSkill2 = false;
        GameData.saveSkill3 = false;
        GameData.saveSkill4 = false;
        GameData.saveSkill5 = false;
        GameData.saveSkill10 = false;
        GameData.saveSkill11 = false;
        GameData.saveSkill12 = false;
        GameData.saveSkill13 = false;
        GameData.saveSkill14 = false;
        GameData.saveSkill15 = false;
        GameData.saveSkill16 = false;
        GameData.saveSkill17 = false;
        GameData.saveSkill18 = false;
        GameData.saveSkill19 = false;

        GameData.setSkill1 = false;
        GameData.setSkill2 = false;
        GameData.setSkill3 = false;
        GameData.setSkill4 = false;
        GameData.setSkill5 = false;
        GameData.setSkill10 = false;
        GameData.setSkill11 = false;
        GameData.setSkill12 = false;
        GameData.setSkill13 = false;
        GameData.setSkill14 = false;
        GameData.setSkill15 = false;
        GameData.setSkill16 = false;
        GameData.setSkill17 = false;
        GameData.setSkill18 = false;
        GameData.setSkill19 = false;

        dataManager.Save();
        dataManager.Read();


    }
    public void SkillSelect()
    {
        SkillSelect_Button.interactable = false;    // 謚ｼ縺励◆繝懊ち繝ｳ繧偵う繝ｳ繧ｿ繝ｩ繧ｯ繝亥・譚･縺ｪ縺上☆繧・
        useCursorProp = true;   // 繧ｫ繝ｼ繧ｽ繝ｫ菴ｿ逕ｨ
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // cursor縺ｮ菴咲ｽｮ繧貞・譛溷喧


    }
    public void SetSkill1() // スキルスラッシュ
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // 繧ｫ繝ｼ繧ｽ繝ｫ縺ｮ菴咲ｽｮ繧貞・譛溷喧

        Instantiate(Skill1,new Vector3(cursor.transform.position.x,cursor.transform.position.y,0),Quaternion.identity);   
        Skill1_Button.interactable = false;
        GameData.setSkill1 = true;
        if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 1;
        else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 1;
        else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 1;
        else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 1;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece1(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill2()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // 繧ｫ繝ｼ繧ｽ繝ｫ縺ｮ菴咲ｽｮ繧貞・譛溷喧

        Instantiate(Skill2, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill2_Button.interactable = false;
        GameData. setSkill2 = true;
        useCursorProp = true;
        CursorController.colorchange = true;

        if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 2;
        else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 2;
        else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 2;
        else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 2;


        GameObject piece = GameObject.Find("SkillPiece2(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill3()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // 繧ｫ繝ｼ繧ｽ繝ｫ縺ｮ菴咲ｽｮ繧貞・譛溷喧

        Instantiate(Skill3, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill3_Button.interactable = false;
        GameData.setSkill3 = true;
        useCursorProp = true;
        CursorController.colorchange = true;


        if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 3;
        else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 3;
        else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 3;
        else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 3;

        GameObject piece = GameObject.Find("SkillPiece3(Clone)");

        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));
        piece.transform.parent = cursor.transform;



    }
    public void SetSkill4()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   

        Instantiate(Skill4, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill4_Button.interactable = false;
        GameData.setSkill4 = true;
        useCursorProp = true;
        CursorController.colorchange = true;


        if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 4;
        else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 4;
        else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 4;
        else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 4;

        GameObject piece = GameObject.Find("SkillPiece4(Clone)");

        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));
        piece.transform.parent = cursor.transform;



    }
    public void SetSkill5()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   

        Instantiate(Skill5, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill5_Button.interactable = false;
        GameData.setSkill5 = true;
        useCursorProp = true;
        CursorController.colorchange = true;


        if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 5;
        else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 5;
        else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 5;
        else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 5;

        GameObject piece = GameObject.Find("SkillPiece5(Clone)");

        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));
        piece.transform.parent = cursor.transform;



    }

    public void SetSkill10() // パッシブスキル体力増強
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill10, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill10_Button.interactable = false;
        GameData.setSkill10 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece10(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill11() // パッシブスキルブリンク距離
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill11, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill11_Button.interactable = false;
        GameData.setSkill11 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece11(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill12() // パッシブスキルジャストガード
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill12, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill12_Button.interactable = false;
        GameData.setSkill12 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece12(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill13() // パッシブスキルジャストガード
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill13, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill13_Button.interactable = false;
        GameData.setSkill13 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece13(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }

    public void SetSkill14() 
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill14, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill14_Button.interactable = false;
        GameData.setSkill14 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece14(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill15()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill15, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill15_Button.interactable = false;
        GameData.setSkill15 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece15(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill16()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill16, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill16_Button.interactable = false;
        GameData.setSkill16 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece16(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill17()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill17, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill17_Button.interactable = false;
        GameData.setSkill17 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece17(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill18()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill18, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill18_Button.interactable = false;
        GameData.setSkill18 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece18(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill19()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill19, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill19_Button.interactable = false;
        GameData.setSkill19 = true;
        //if (SkillUIDirector.setSlot1) GameData.skillSlot1 = 10;
        //else if (SkillUIDirector.setSlot2) GameData.skillSlot2 = 10;
        //else if (SkillUIDirector.setSlot3) GameData.skillSlot3 = 10;
        //else if (SkillUIDirector.setSlot4) GameData.skillSlot4 = 10;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece19(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }



}
