using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetDirector : MonoBehaviour
{
    [SerializeField] Button SkillSelect_Button;
    [SerializeField] Button Skill1_Button;
    [SerializeField] Button Skill2_Button;
    [SerializeField] Button Skill3_Button;

    [SerializeField] GameObject NotInteractablePanel;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject Skill1;
    [SerializeField] GameObject Skill2;
    [SerializeField] GameObject Skill3;

    SkillPieceData spdata;
    CursorController cursorcontroller;

    GameObject grid;

    private Button firstSelectButton;


    private bool useCursor;
    // カーソル使用時にTrue
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

        Debug.Log("スキル1" + GameData.setSkill1);
        Debug.Log("スキル2" + GameData.setSkill2);
        Debug.Log("スキル3" + GameData.setSkill3);
    }
    public void SkillSelect()
    {
        SkillSelect_Button.interactable = false;    // 押したボタンをインタラクト出来なくする
        useCursorProp = true;   // カーソル使用
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // cursorの位置を初期化

    }
    public void SetSkill1()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill1,new Vector3(cursor.transform.position.x,cursor.transform.position.y,0),Quaternion.identity);   
        Skill1_Button.interactable = false;
        GameData.setSkill1 = true;

        useCursorProp = true;
        CursorController.colorchange = true;

        GameObject piece = GameObject.Find("SkillPiece1(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill2()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill2, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill2_Button.interactable = false;
        GameData.setSkill2 = true;
        useCursorProp = true;
        CursorController.colorchange = true;



        GameObject piece = GameObject.Find("SkillPiece2(Clone)");
        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));


        piece.transform.parent = cursor.transform;


    }
    public void SetSkill3()
    {
        cursor.transform.position = new Vector3(-0.75f, 0.435f, 0);   // カーソルの位置を初期化

        Instantiate(Skill3, new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0), Quaternion.identity);
        Skill3_Button.interactable = false;
        GameData.setSkill3 = true;
        useCursorProp = true;
        CursorController.colorchange = true;



        GameObject piece = GameObject.Find("SkillPiece3(Clone)");

        cursorcontroller.PickupUpdate(piece.transform.GetChild(0));
        piece.transform.parent = cursor.transform;



    }

}
