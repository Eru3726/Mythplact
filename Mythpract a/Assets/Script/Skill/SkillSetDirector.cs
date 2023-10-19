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


    SkillPieceData spdata;
    CursorController cursorcontroller;

    GameObject grid;

    private Button firstSelectButton;


    private bool useCursor;
    // ã‚«ãƒ¼ã‚½ãƒ«ä½¿ç”¨æ™‚ã«True
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
        Debug.Log("ƒXƒLƒ‹ƒXƒƒbƒg1‚É“ü‚Á‚Ä‚¢‚é‚à‚Ì" + GameData.skillSlot1);

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
    public void SkillSelect()
    {
        SkillSelect_Button.interactable = false;    // æŠ¼ã—ãŸãƒœã‚¿ãƒ³ã‚’ã‚¤ãƒ³ã‚¿ãƒ©ã‚¯ãƒˆå‡ºæ¥ãªãã™ã‚‹
        useCursorProp = true;   // ã‚«ãƒ¼ã‚½ãƒ«ä½¿ç”¨
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // cursorã®ä½ç½®ã‚’åˆæœŸåŒ–

    }
    public void SetSkill1() // ƒXƒLƒ‹ƒXƒ‰ƒbƒVƒ…
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ã‚«ãƒ¼ã‚½ãƒ«ã®ä½ç½®ã‚’åˆæœŸåŒ–

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
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ã‚«ãƒ¼ã‚½ãƒ«ã®ä½ç½®ã‚’åˆæœŸåŒ–

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
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ã‚«ãƒ¼ã‚½ãƒ«ã®ä½ç½®ã‚’åˆæœŸåŒ–

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
    public void SetSkill10() // ƒpƒbƒVƒuƒXƒLƒ‹‘Ì—Í‘‹­
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ƒJ[ƒ\ƒ‹‚ÌˆÊ’u‚ğ‰Šú‰»

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
    public void SetSkill11() // ƒpƒbƒVƒuƒXƒLƒ‹ƒuƒŠƒ“ƒN‹——£
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ƒJ[ƒ\ƒ‹‚ÌˆÊ’u‚ğ‰Šú‰»

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
    public void SetSkill12() // ƒpƒbƒVƒuƒXƒLƒ‹ƒWƒƒƒXƒgƒK[ƒh
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ƒJ[ƒ\ƒ‹‚ÌˆÊ’u‚ğ‰Šú‰»

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
    public void SetSkill13() // ƒpƒbƒVƒuƒXƒLƒ‹ƒWƒƒƒXƒgƒK[ƒh
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ƒJ[ƒ\ƒ‹‚ÌˆÊ’u‚ğ‰Šú‰»

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

    public void SetSkill14() // ƒpƒbƒVƒuƒXƒLƒ‹ƒWƒƒƒXƒgƒK[ƒh
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // ƒJ[ƒ\ƒ‹‚ÌˆÊ’u‚ğ‰Šú‰»

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



}
