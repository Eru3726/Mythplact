using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCmanager : MonoBehaviour
{
    public Controllerconnect conconnect;

    public Button start;

    public Button setting;

    public Button quit;

    public Button cbutton;
    
    public GameObject keycon;

    private GameObject Button;

    private float PickButton = 3;

    private bool connect = true;

    //���X�e�B�b�N���ǂ��ɓ|���Ă��邩�𔻕ʂ�����
    private bool lsvup = true;        //��
    private bool lsvdown = true;�@�@�@//��
    //�\���L�[���ǂ��ɓ|���Ă��邩�𔻕ʂ�����
    private bool dpvup = true;        //��
    private bool dpvdown = true;      //��

    private float deadzone = 0.5f;     //�X�e�B�b�N���ǂꂾ���|�����甽�����邩�̒l
    void Start()
    {

    }

    void Update()
    {
        if (conconnect.ConConnect)
        {
            if (connect == true)
            {
                start.Select();
                //ButtonSelect();
                connect = false;
                Debug.Log("�R���g���[���[�ڑ�");
            }
            //Debug.Log(Button);
            //�J�[�\���������Ȃ�����
            Cursor.visible = false;
            //�J�[�\������ʒ����Ƀ��b�N
            Cursor.lockState = CursorLockMode.Locked;
            //InputManager�ŐV���ɐݒ肵��Axis�̕ϐ����擾
            //float lsv = Input.GetAxis("L_stick_V");        //���X�e�B�b�N�c

            //if (lsv >= deadzone)     //���X�e�B�b�N�̓|�����݂��f�b�h�]�[���𒴂�����
            //{
            //    if (lsvup == true)�@ //�X�e�B�b�N�����|���������������Ȃ��悤�ɂ��邽�߂̂���
            //    {
            //        if (PickButton < 3)
            //        {
            //            PickButton += 1;
            //            Debug.Log("��");
            //        }
            //        else
            //        {
            //            PickButton = 1;
            //            Debug.Log("��1");
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        lsvup = false;
            //    }
            //}
            //else if (lsv <= -deadzone)
            //{
            //    if (lsvdown == true)
            //    {
            //        if (PickButton > 1)
            //        {
            //            PickButton -= 1;
            //            Debug.Log("��");
            //        }
            //        else
            //        {
            //            PickButton = 3;
            //            Debug.Log("��3");
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        lsvdown = false;
            //    }
            //}
            ////���|�����X�e�B�b�N��߂��Ƃ������|���Ĉړ��������悤�ɂ���
            //if (lsv <= deadzone)
            //{
            //    lsvup = true;
            //}
            //if (lsv >= -deadzone)
            //{
            //    lsvdown = true;
            //}

            //float dpv = Input.GetAxis("D_pad_V");        //�\���L�[�̏c���擾
            //if (dpv >= deadzone)
            //{
            //    if (dpvup == true)
            //    {
            //        if (PickButton < 3)
            //        {
            //            PickButton += 1;
            //        }
            //        else
            //        {
            //            PickButton = 1;
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        dpvup = false;
            //    }
            //}
            //else if (dpv <= -deadzone)
            //{
            //    if (dpvdown == true)
            //    {

            //        if (PickButton > 1)
            //        {
            //            PickButton -= 1;
            //        }
            //        else
            //        {
            //            PickButton = 3;
            //        }
            //        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
            //        ButtonSelect();
            //        dpvdown = false;
            //    }
            //}
            ////��̃X�e�B�b�N�Ɠ���
            //if (dpv <= deadzone)
            //{
            //    dpvup = true;
            //}
            //if (dpv >= -deadzone)
            //{
            //    dpvdown = true;
            //}


            //if (Input.GetKeyDown(KeyCode.JoystickButton0))
            //{
            //    Debug.Log("����");
            //    Button.GetComponent<Button>().onClick.Invoke();
            //    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.pressedSprite;
            //}
            //else if (Input.GetKeyUp(KeyCode.JoystickButton0))
            //{
            //    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            //}
        }
        else      //�R���g���[���[��ڑ�
        {
            if (connect == false)
            {
                //�J�[�\����\��
                Cursor.visible = true;
                //�J�[�\���̃��b�N������
                Cursor.lockState = CursorLockMode.None;
                //Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.selectedSprite;
                connect = true;
                Button = null;
                cbutton.Select();
                Debug.Log("�R���g���[���[��ڑ�");
            }
        }
    }

    public void ButtonSelect()
    {
        //if (PickButton == 1)
        //{
        //    Button = quit;
        //}
        //else if (PickButton == 2)
        //{
        //    Button = setting;
        //}
        //else
        //{
        //    Button = start;
        //}
        //Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
    }
}
