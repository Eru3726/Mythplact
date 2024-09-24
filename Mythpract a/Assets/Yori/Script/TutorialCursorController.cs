using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class TutorialCursorController : MonoBehaviour
{
    SkillSetDirector skillSetDirector;
    SkillPieceController skillPieceController;
    SkillPieceDisplay skillPieceDisplay;
    SkillText skillText;
    SkillPieceData spdata;
    Controllerconnect conconect;
    Keyconfig keycon;
    Pickkey pickkey;

    AudioSource audioSource;

    [SerializeField] AudioClip SkillSetSE;

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

    [SerializeField, Header("移動")]
    private InputActionProperty Move;

    [SerializeField, Header("右回転")]
    private InputActionReference RSpin;

    [SerializeField, Header("左回転")]
    private InputActionReference LSpin;

    [SerializeField, Header("持ち上げ")]
    private InputActionReference Pick;

    [SerializeField, Header("戻る")]
    private InputActionReference Back;


    [SerializeField, Header("スキルチュートリアル")]
    SkillTutorial sTutorial;



    Transform touchTfm;
    Transform pickupTfm;

    RaycastHit2D hit;


    bool up;
    bool down;
    bool left;
    bool right;
    bool left1;
    bool left2;
    bool right1;
    bool right2;


    bool space;
    bool Rspin;
    bool Lspin;
    bool back;
    bool moveonce;
    bool moveCursor;
    bool pieceBack;
    bool onBase;
    private bool pickup;

    public static bool colorchange = false;

    Button backButton;

    const float moveVertical = 0.87f;
    const float moveSide = 0.75f;

    public bool PickUpProp
    {
        get { return pickup; }
        set { pickup = value; }
    }
    void Start()
    {
        skillSetDirector = GameObject.Find("SkillSetDirector").GetComponent<SkillSetDirector>();
        skillPieceDisplay = GameObject.Find("Canvas/SkillPieceDisplay").GetComponent<SkillPieceDisplay>();
        skillText = GameObject.Find("Canvas/SkillText").GetComponent<SkillText>();

        backButton = GameObject.Find("Canvas/SkillSelect").GetComponent<Button>();

        spdata = GameObject.Find("SkillPieceData").GetComponent<SkillPieceData>();

        conconect = GameObject.Find("keycon").GetComponent<Controllerconnect>();
        keycon = GameObject.Find("keycon").GetComponent<Keyconfig>();

        audioSource = gameObject.GetComponent<AudioSource>();

        Move.action.Enable();
        Pick.action.Enable();
        RSpin.action.Enable();
        LSpin.action.Enable();
        Back.action.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        InputKey();

        MoveCursor();

        MouseCursorCtrl();

        SkillPieceInfo();
    }
    public void PickupUpdate(Transform piece)
    {
        pickupTfm = piece;
    }


    void InputKey()
    {
#if false
        if(conconect.ConConnect == true)
        {

            float lsh = Input.GetAxis("L_stick_H");　　　　//左スティック横
            float lsv = Input.GetAxis("L_stick_V");        //左スティック縦

            if (lsv > 0 && (lsh > -0.1f && lsh < 0.1f) && !moveonce)
            {
                up = true;
                moveonce = true;
            }
            else up = false;

            if (lsv < 0 && (lsh > -0.1f && lsh < 0.1f) && !moveonce)
            {
                down = true;
                moveonce = true;
            }
            else down = false;

            if (lsh > 0 && (lsv > -0.9f && lsv < 0) && !moveonce) 
            { 
                right1 = true;
                moveonce = true;
            }
            else right1 = false;

            if (lsh > 0 && (lsv >= 0 && lsv < 0.9f) && !moveonce)
            {
                right2 = true;
                moveonce = true;
            }
            else right2 = false;

            if (lsh < 0 && (lsv > -0.9f && lsv < 0) && !moveonce)
            {
                left1 = true;
                moveonce = true;
            }
            else left1 = false;

            if (lsh < 0 && (lsv >= 0 && lsv < 0.9f) && !moveonce)
            {
                left2 = true;
                moveonce = true;

            }
            else left2 = false;

            if(lsv == 0 && lsh == 0)
            {
                moveonce = false;
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button0)) space = true;
            else space = false;

            if (Input.GetKeyDown(KeyCode.Joystick1Button5)) Rspin = true;
            else Rspin = false;

            if (Input.GetKeyDown(KeyCode.Joystick1Button4)) Lspin = true;
            else Lspin = false;

            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) back = true;
            else back = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W)) up = true;
            else up = false;

            if (Input.GetKeyDown(KeyCode.S)) down = true;
            else down = false;

            if (Input.GetKeyDown(KeyCode.A)) left = true;
            else left = false;

            if (Input.GetKeyDown(KeyCode.D)) right = true;
            else right = false;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) space = true;
            else space = false;

            if (Input.GetKeyDown(KeyCode.Q)) Rspin = true;
            else Rspin = false;

            if (Input.GetKeyDown(KeyCode.E)) Lspin = true;
            else Lspin = false;

            if (Input.GetKeyDown(KeyCode.Escape)) back = true;
            else back = false;

        }

#endif



        Vector2 MoveInp = Move.action.ReadValue<Vector2>();
        Vector2 beforeVec = Vector2.zero;
        //Debug.Log(MoveInp);



        if (MoveInp.x == 0 && MoveInp.y > 0 && moveonce)
        {
            up = true;
            moveonce = false;
            beforeVec = MoveInp;
        }
        else up = false;

        if (MoveInp.x == 0 && MoveInp.y < 0 && moveonce)
        {
            down = true;
            moveonce = false;
            beforeVec = MoveInp;

        }
        else down = false;


        if (MoveInp.x > 0 && MoveInp.y >= 0 && moveonce)
        {

            right2 = true;
            moveonce = false;
            beforeVec = MoveInp;

        }
        else right2 = false;

        if (MoveInp.x > 0 && MoveInp.y < 0 && moveonce)
        {
            right1 = true;
            moveonce = false;
            beforeVec = MoveInp;

        }
        else right1 = false;

        if (MoveInp.x < 0 && MoveInp.y > 0 && moveonce)
        {
            left2 = true;
            moveonce = false;
            beforeVec = MoveInp;

        }
        else left2 = false;

        if (MoveInp.x < 0 && MoveInp.y <= 0 && moveonce)
        {
            left1 = true;
            moveonce = false;
            beforeVec = MoveInp;

        }
        else left1 = false;


        if (/*Move.action.WasPerformedThisFrame()*/MoveInp.x == 0 && MoveInp.y == 0)
        {
            moveonce = true;
            beforeVec = MoveInp;
        }

        if (Pick.action.WasPressedThisFrame()) space = true;
        else space = false;

        if (RSpin.action.WasPressedThisFrame() || Input.GetAxis("Mouse ScrollWheel") > 0) Rspin = true;
        else Rspin = false;

        if (LSpin.action.WasPressedThisFrame() || Input.GetAxis("Mouse ScrollWheel") < 0) Lspin = true;
        else Lspin = false;

        if (Back.action.WasPressedThisFrame()) back = true;
        else back = false;
    }

    void MoveCursor()
    {
        if (touchTfm != null)
        {
            skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();
            //Debug.Log("outprop" + skillPieceController.OutBaseProp);
            skillPieceController.PieceOnBase();
            if (!skillPieceController.OutBaseProp)
            {
                if (space)
                {
                    // 持ち上げ判定にする
                    sTutorial.skillLog++;
                    sTutorial.setSkill = true;
                    PickUpProp = true;
                    Debug.Log("a");
                }
            }
        }

        // 上下左右移動
        if (gameObject.transform.position.y < 2.175f && gameObject.transform.position.x == -0.75f ||
            gameObject.transform.position.y < 1.74f && gameObject.transform.position.x == 0 ||
            gameObject.transform.position.y < 1.74f && gameObject.transform.position.x == -1.5f ||
            gameObject.transform.position.y < 0.87f && gameObject.transform.position.x == 0.75f ||
            gameObject.transform.position.y < 0.87f && gameObject.transform.position.x == -2.25f)
        {
            if (up)
            {
                gameObject.transform.Translate(0, moveVertical, 0, Space.World);
            }

        }


        //if ((gameObject.transform.position.x != 0.75f && gameObject.transform.position.y <= 2.175f) &&
        //    (((gameObject.transform.position.x != 0f) || (gameObject.transform.position.x != 1.5f)) && gameObject.transform.position.y <= 1.74f) ||
        //    (((gameObject.transform.position.x != -0.75f) || (gameObject.transform.position.x != 2.25f)) && gameObject.transform.position.y <= 0.87f)
        //    )
        //{
        if (gameObject.transform.position.y > -1.304f && gameObject.transform.position.x == -0.75f ||
            gameObject.transform.position.y > -0.86f && gameObject.transform.position.x == 0 ||
            gameObject.transform.position.y > -0.86f && gameObject.transform.position.x == -1.5f ||
            gameObject.transform.position.y > -0.43f && gameObject.transform.position.x == 0.75f ||
            gameObject.transform.position.y > -0.34f && gameObject.transform.position.x == -2.25f)
        {
            if (down)
            {
                gameObject.transform.Translate(0, -moveVertical, 0, Space.World);
            }

        }



        if (gameObject.transform.position.x < 0.75f)
        {
            if (!(gameObject.transform.position.x == -0.75f && gameObject.transform.position.y >= 2.1f ||
                gameObject.transform.position.x == 0 && gameObject.transform.position.y >= 1.7f))
            {
                if (right)
                {
                    gameObject.transform.Translate(moveSide, moveVertical / 2, 0, Space.World);
                }
                if (right2)
                {
                    gameObject.transform.Translate(moveSide, moveVertical / 2, 0, Space.World);
                }

            }

            if (!(gameObject.transform.position.x == -0.75f && gameObject.transform.position.y <= 1.304f ||
                gameObject.transform.position.x == 0 && gameObject.transform.position.y <= 0.86f))
            {
                if (right1)
                {
                    gameObject.transform.Translate(moveSide, -moveVertical / 2, 0, Space.World);
                }

            }


        }
        if (gameObject.transform.position.x > -2.25f)
        {
            if (!(gameObject.transform.position.x == -0.75f && gameObject.transform.position.y < -1.3f ||
                 gameObject.transform.position.x == -1.5f && gameObject.transform.position.y < -0.8f))
            {
                if (left)
                {
                    gameObject.transform.Translate(-moveSide, -moveVertical / 2, 0, Space.World);
                }
                if (left1)
                {
                    gameObject.transform.Translate(-moveSide, -moveVertical / 2, 0, Space.World);
                }

            }

            if (!(gameObject.transform.position.x == -0.75f && gameObject.transform.position.y >= 2.1f ||
                 gameObject.transform.position.x == -1.5f && gameObject.transform.position.y >= 1.7f))
            {
                if (left2)
                {
                    gameObject.transform.Translate(-moveSide, moveVertical / 2, 0, Space.World);
                }

            }

        }

        // 回転
        if (Rspin) gameObject.transform.Rotate(0, 0, -60);
        if (Lspin) gameObject.transform.Rotate(0, 0, 60);

        //if(up || down || left || right || left1 || left2 || right1 || right2 || Rspin || Lspin)
        //{
        //    moveCursor = true;
        //}
        //else
        //{
        //    moveCursor = false;
        //}

        //if (moveCursor)
        //{
        //    skillPieceController.OutOnceProp = false;
        //}
        //else
        //{
        //    skillPieceController.OutOnceProp = true;

        //}

        // 持ち上げ判定
        if (PickUpProp)
        {
            pickupTfm = touchTfm;
            audioSource.PlayOneShot(SkillSetSE);

            // 持ち上げたオブジェクトの子オブジェクト化の切り替え
            // ※parent.parentは、持ち上げたオブジェクト(SkillPieceの子のSplite)の
            // 親(SkillPiece)を子オブジェクトにするため
            if (pickupTfm.parent.parent == null)
            {
                pickupTfm.parent.position = gameObject.transform.position + (touchTfm.parent.position - touchTfm.position);
                pickupTfm.parent.parent = transform;

                colorchange = true;
                pickupTfm = touchTfm;


            }
            else
            {
                pickupTfm.parent.parent = null;

                colorchange = false;
                pickupTfm = touchTfm;


            }
            PickUpProp = false;
        }




        if (back)
        {
            backButton.interactable = true;
            backButton.Select();
            skillSetDirector.useCursorProp = false;

        }
        //Debug.Log("持ち上げたObj" + pickupTfm.parent.name);
        //Debug.Log("触れたObj" + touchTfm.parent.name);

        // ピースを持っている時にメニューに戻ったときの処理
        if (back && pickupTfm.root == transform)
        {
            if (pickupTfm.parent.name == "SkillPiece1(Clone)")
            {
                GameObject DeletePiece;

                if (GameData.skillSlot1 == 1) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                else if (GameData.skillSlot2 == 1) GameData.skillSlot2 = 0;
                else if (GameData.skillSlot3 == 1) GameData.skillSlot3 = 0;
                else if (GameData.skillSlot4 == 1) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill1_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill1 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece1(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);

                // スキルピースの情報を表示
                skillPieceDisplay.Skill1Select();
                skillText.Skill1Text();

                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece2(Clone)")
            {
                GameObject DeletePiece;

                if (GameData.skillSlot1 == 2) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に
                else if (GameData.skillSlot2 == 2) GameData.skillSlot2 = 0;
                else if (GameData.skillSlot3 == 2) GameData.skillSlot3 = 0;
                else if (GameData.skillSlot4 == 2) GameData.skillSlot4 = 0;


                pickupTfm.parent.parent = null;
                Skill2_Button.interactable = true;
                GameData.setSkill2 = false;

                DeletePiece = GameObject.Find("SkillPiece2(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                // スキルピースの情報を表示
                skillPieceDisplay.Skill2Select();
                skillText.Skill2Text();


                Destroy(DeletePiece);
            }
            else if (pickupTfm.parent.name == "SkillPiece3(Clone)")
            {
                GameObject DeletePiece;

                if (GameData.skillSlot1 == 3) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に
                else if (GameData.skillSlot2 == 3) GameData.skillSlot2 = 0;
                else if (GameData.skillSlot3 == 3) GameData.skillSlot3 = 0;
                else if (GameData.skillSlot4 == 3) GameData.skillSlot4 = 0;


                pickupTfm.parent.parent = null;
                Skill3_Button.interactable = true;
                GameData.setSkill3 = false;


                DeletePiece = GameObject.Find("SkillPiece3(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                // スキルピースの情報を表示
                skillPieceDisplay.Skill3Select();
                skillText.Skill3Text();


                Destroy(DeletePiece);

            }
            else if (pickupTfm.parent.name == "SkillPiece4(Clone)")
            {
                GameObject DeletePiece;

                if (GameData.skillSlot1 == 4) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に
                else if (GameData.skillSlot2 == 4) GameData.skillSlot2 = 0;
                else if (GameData.skillSlot3 == 4) GameData.skillSlot3 = 0;
                else if (GameData.skillSlot4 == 4) GameData.skillSlot4 = 0;


                pickupTfm.parent.parent = null;
                Skill4_Button.interactable = true;
                GameData.setSkill4 = false;


                DeletePiece = GameObject.Find("SkillPiece4(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                // スキルピースの情報を表示
                skillPieceDisplay.Skill4Select();
                skillText.Skill4Text();


                Destroy(DeletePiece);

            }

            else if (pickupTfm.parent.name == "SkillPiece5(Clone)")
            {
                GameObject DeletePiece;

                if (GameData.skillSlot1 == 5) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に
                else if (GameData.skillSlot2 == 5) GameData.skillSlot2 = 0;
                else if (GameData.skillSlot3 == 5) GameData.skillSlot3 = 0;
                else if (GameData.skillSlot4 == 5) GameData.skillSlot4 = 0;


                pickupTfm.parent.parent = null;
                Skill5_Button.interactable = true;
                GameData.setSkill5 = false;


                DeletePiece = GameObject.Find("SkillPiece5(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                // スキルピースの情報を表示
                skillPieceDisplay.Skill5Select();
                skillText.Skill5Text();

                Destroy(DeletePiece);

            }

            else if (pickupTfm.parent.name == "SkillPiece10(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill10_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill10 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece10(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece11(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill11_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill11 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece11(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece12(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill12_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill12 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece12(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece13(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill13_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill13 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece13(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece14(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill14_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill14 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece14(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece15(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill15_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill15 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece15(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece16(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill16_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill16 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece16(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece17(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill17_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill17 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece17(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece18(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill18_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill18 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece18(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }
            else if (pickupTfm.parent.name == "SkillPiece19(Clone)")
            {
                GameObject DeletePiece;

                //if (GameData.skillSlot1 == 10) GameData.skillSlot1 = 0;    // スキルスロットの登録を無効に (アクティブスキルのみ)
                //else if (GameData.skillSlot2 == 10) GameData.skillSlot2 = 0;
                //else if (GameData.skillSlot3 == 10) GameData.skillSlot3 = 0;
                //else if (GameData.skillSlot4 == 10) GameData.skillSlot4 = 0;

                pickupTfm.parent.parent = null;     // スキルピースとカーソルの親子関係を解除
                Skill19_Button.interactable = true;  // そのスキルのボタンを選択可能に
                GameData.setSkill19 = false; // そのスキルを無効に


                DeletePiece = GameObject.Find("SkillPiece19(Clone)");    // 持っていたスキルピースを取得
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // そのスキルピースを消去
            }

        }




    }


    void SkillPieceInfo()
    {
        if (touchTfm != null)
        {
            if (touchTfm.parent.name == "SkillPiece1(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill1Select();
                skillText.Skill1Text();
            }
            else if (touchTfm.parent.name == "SkillPiece2(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill2Select();
                skillText.Skill2Text();
            }
            else if (touchTfm.parent.name == "SkillPiece3(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill3Select();
                skillText.Skill3Text();
            }
            else if (touchTfm.parent.name == "SkillPiece4(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill4Select();
                skillText.Skill4Text();

            }

            else if (touchTfm.parent.name == "SkillPiece5(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill5Select();
                skillText.Skill5Text();
            }
            else if (touchTfm.parent.name == "SkillPiece10(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill10Select();
                skillText.Skill10Text();
            }
            else if (touchTfm.parent.name == "SkillPiece11(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill11Select();
                skillText.Skill11Text();
            }
            else if (touchTfm.parent.name == "SkillPiece12(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill12Select();
                skillText.Skill12Text();
            }
            else if (touchTfm.parent.name == "SkillPiece13(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill13Select();
                skillText.Skill13Text();
            }
            else if (touchTfm.parent.name == "SkillPiece14(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill14Select();
                skillText.Skill14Text();
            }
            else if (touchTfm.parent.name == "SkillPiece15(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill15Select();
                skillText.Skill15Text();
            }
            else if (touchTfm.parent.name == "SkillPiece16(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill16Select();
                skillText.Skill16Text();
            }
            else if (touchTfm.parent.name == "SkillPiece17(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill17Select();
                skillText.Skill17Text();
            }
            else if (touchTfm.parent.name == "SkillPiece18(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill18Select();
                skillText.Skill18Text();
            }
            else if (touchTfm.parent.name == "SkillPiece19(Clone)")
            {
                // スキルピースの情報を表示
                skillPieceDisplay.Skill19Select();
                skillText.Skill19Text();
            }
        }

    }
    void MouseCursorCtrl()
    {

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider!=null)
        {
            if (hit.collider.tag == "SkillBase")
            {
                int skillBaseNum = 19;
                for (int i = 1; i <= skillBaseNum; i++)
                {
                    if (hit.collider.name == i.ToString())
                    {
                        // Debug.Log(hit.collider.transform.position);
                        this.gameObject.transform.position = hit.collider.transform.position;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        touchTfm = null;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        // スキルピースに触れているか判定
        if (col.transform.tag == "SkillPiece")
        {
            //Debug.Log("カーソルがピースに触れた");
            // 触れたスキルピースを取得
            touchTfm = col.transform;
            // 触れたスキルピースのスクリプトを取得
            skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();

            //Debug.Log(skillPieceController.OutBaseProp);

            //if (space)
            //{
            //    skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();
            //    if (!skillPieceController.OutBaseProp)
            //    {
            //        // 持ち上げ判定にする
            //        PickUpProp = true;
            //    }
            //}
        }
    }
}
