using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    SkillSetDirector skillSetDirector;
    SkillPieceController skillPieceController;
    SkillPieceData spdata;
    Controllerconnect conconect;
    Keyconfig keycon;
    Pickkey pickkey;


    [SerializeField] Button Skill1_Button;
    [SerializeField] Button Skill2_Button;
    [SerializeField] Button Skill3_Button;


    Transform touchTfm;
    Transform pickupTfm;

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
    bool moving;
    bool pieceBack;
    bool onBase;
    private bool pickup;

    public static bool colorchange = false;

    Button backButton;

    float moveVertical = 0.87f; 
    float moveSide = 0.75f;

    public bool PickUpProp
    {
        get { return pickup; }
        set { pickup = value; }
    }
    void Start()
    {
        skillSetDirector = GameObject.Find("SkillSetDirector").GetComponent<SkillSetDirector>();

        backButton = GameObject.Find("Canvas/SkillSelect").GetComponent<Button>();

        spdata = GameObject.Find("SkillPieceData").GetComponent<SkillPieceData>();

        conconect = GameObject.Find("keycon").GetComponent<Controllerconnect>();
        keycon = GameObject.Find("keycon").GetComponent<Keyconfig>();


    }

    // Update is called once per frame
    void Update()
    {
        InputKey();

        MoveCursor();


    }
    public void PickupUpdate(Transform piece)
    {
        pickupTfm = piece;

    }


    void InputKey()
    {
        if(conconect.ConConnect == true)
        {

            float lsh = Input.GetAxis("L_stick_H");�@�@�@�@//���X�e�B�b�N��
            float lsv = Input.GetAxis("L_stick_V");        //���X�e�B�b�N�c

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

            if (Input.GetKeyDown(KeyCode.E)) Rspin = true;
            else Rspin = false;

            if (Input.GetKeyDown(KeyCode.Q)) Lspin = true;
            else Lspin = false;

            if (Input.GetKeyDown(KeyCode.Escape)) back = true;
            else back = false;

        }


    }

    void MoveCursor()
    {

        // �㉺���E�ړ�
        if (up) gameObject.transform.Translate(0, moveVertical, 0, Space.World);
        if (down) gameObject.transform.Translate(0, -moveVertical, 0, Space.World);
        if (left) gameObject.transform.Translate(-moveSide, -moveVertical / 2, 0, Space.World);
        if (right) gameObject.transform.Translate(moveSide, moveVertical / 2, 0, Space.World);

        if (left1) gameObject.transform.Translate(-moveSide, -moveVertical / 2, 0, Space.World);
        if (left2) gameObject.transform.Translate(-moveSide, moveVertical / 2, 0, Space.World);
        if (right1) gameObject.transform.Translate(moveSide, -moveVertical / 2, 0, Space.World);
        if (right2) gameObject.transform.Translate(moveSide, moveVertical / 2, 0, Space.World);

        // ��]
        if (Rspin) gameObject.transform.Rotate(0, 0, -60);
        if (Lspin) gameObject.transform.Rotate(0, 0, 60);


        // �����グ����
        if (PickUpProp)
        {
            pickupTfm = touchTfm;


            // �����グ���I�u�W�F�N�g�̎q�I�u�W�F�N�g���̐؂�ւ�
            // ��parent.parent�́A�����グ���I�u�W�F�N�g(SkillPiece�̎q��Splite)��
            // �e(SkillPiece)���q�I�u�W�F�N�g�ɂ��邽��
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
        Debug.Log("�����グ��Obj" + pickupTfm.parent.name);
        Debug.Log("�G�ꂽObj" + touchTfm.parent.name);

        // �s�[�X�������Ă��鎞�Ƀ��j���[�ɖ߂����Ƃ��̏���
        if (back && pickupTfm.root == transform)
        {
            if (pickupTfm.parent.name == "SkillPiece1(Clone)")
            {
                GameObject DeletePiece;

                pickupTfm.parent.parent = null;     // �X�L���s�[�X�ƃJ�[�\���̐e�q�֌W������
                Skill1_Button.interactable = true;  // ���̃X�L���̃{�^����I���\��
                SkillSetDirector.setSkill1 = false; // ���̃X�L���𖳌���
                

                DeletePiece = GameObject.Find("SkillPiece1(Clone)");    // �����Ă����X�L���s�[�X���擾
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);
                Destroy(DeletePiece);                                   // ���̃X�L���s�[�X������
            }
            else if (pickupTfm.parent.name == "SkillPiece2(Clone)")
            {
                GameObject DeletePiece;

                pickupTfm.parent.parent = null;
                Skill2_Button.interactable = true;
                SkillSetDirector.setSkill2 = false;

                DeletePiece = GameObject.Find("SkillPiece2(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);

                Destroy(DeletePiece);
            }
            else if(pickupTfm.parent.name == "SkillPiece3(Clone)")
            {
                GameObject DeletePiece;

                pickupTfm.parent.parent = null;
                Skill3_Button.interactable = true;
                SkillSetDirector.setSkill3 = false;

                DeletePiece = GameObject.Find("SkillPiece3(Clone)");
                DeletePiece.gameObject.transform.position = new Vector3(0, 0, 0);

                Destroy(DeletePiece);

            }
        }




    }

    private void OnTriggerStay2D(Collider2D col)
    {
        // �X�L���s�[�X�ɐG��Ă��邩����
        if(col.transform.tag == "SkillPiece")
        {
            Debug.Log("�J�[�\�����s�[�X�ɐG�ꂽ");
            // �G�ꂽ�X�L���s�[�X���擾
            touchTfm = col.transform;
            // �G�ꂽ�X�L���s�[�X�̃X�N���v�g���擾
            skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();
            Debug.Log(skillPieceController.OutBaseProp);

            if (space)
            {

                if (!skillPieceController.OutBaseProp)
                {
                    // �����グ����ɂ���
                    PickUpProp = true;

                }
            }


        }
    }


}
