using UnityEngine;
using UnityEngine.UI;

public class Pickkey : MonoBehaviour
{
    public Controllerconnect controllerconnect;
    public Keyconfig keycon;

    public GameObject rk;             //���C�g�L�[
    public GameObject lk;             //���t�g�L�[
    public GameObject dwk;            //�_�E���L�[
    public GameObject ak;             //�A�^�b�N�L�[
    public GameObject jk;             //�W�����v�L�[
    public GameObject dk;             //�_�b�V���L�[
    public GameObject hk;             //�q�[���L�[
    public GameObject ik;             //�C���^���N�g�L�[
    public GameObject rkr;            //r�t���͂��̃L�[�̃��Z�b�g�L�[
    public GameObject lkr;            //
    public GameObject dwkr;           //
    public GameObject akr;            //
    public GameObject jkr;            //
    public GameObject dkr;            //
    public GameObject hkr;            //
    public GameObject ikr;            // 
    public GameObject save;           //�Z�[�u�L�[
    public GameObject escape;           //�G�X�P�[�v�L�[
    public GameObject skill;           //�X�L���L�[
    //public GameObject load;           //���[�h�L�[
    //public GameObject allr;           //�I�[�����Z�b�g�L�[

    private float buttonnumv = 1;     //�{�^���̏c�ɓ������߂̂��
    private float buttonnumh = 1;     //�{�^���̉��ɓ������߂̂��

    private GameObject Button;        //���̃{�^���ɂ��邩���ʂ��邽�߂̂��

    //���X�e�B�b�N���ǂ��ɓ|���Ă��邩�𔻕ʂ�����
    private bool lsvup = true;        //��
    private bool lsvdown = true;�@�@�@//��
    private bool lshup = true;        //�E
    private bool lshdown = true;      //��
    //�\���L�[���ǂ��ɓ|���Ă��邩�𔻕ʂ�����
    private bool dpvup = true;        //��
    private bool dpvdown = true;      //��
    private bool dphup = true;        //��
    private bool dphdown = true;      //�E

    private bool connect = false;      //�R���g���[���[�ڑ������Ƃ��̃��\�b�h�����x�����s����Ȃ��悤�ɂ������

    private float deadzone = 0.5f;     //�X�e�B�b�N���ǂꂾ���|�����甽�����邩�̒l

    private bool Cnotcon = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�R���g���[���[�ڑ�
        if (controllerconnect.ConConnect && !connect) 
        {
            buttonnumh = 2;
            buttonnumv = 1;
            Button = rk;
            Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            //Buttonselect();    //�c�Ɖ��̃{�^���̕ϐ��̒l�ɂ���ă{�^���̈ʒu�𓮂��� 
            connect = true;
            Debug.Log("�R���g���[���[�ڑ�");
        }
        //�R���g���[���[��ڑ�
        else if (!controllerconnect.ConConnect&&connect)
        {
            Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.disabledSprite;
            connect = false;
            Debug.Log("�R���g���[���[�ؒf");
        }
        //////////////////////////////////
        /////////////////////////////////
        ////////////////////////////////
        ///////////////////////////////
        
        //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.dash == false && keycon.attack == false && keycon.heal == false && keycon.interact == false)
        
        
        if (keycon.condec == false)         //�R���g���[���[�̌���{�^�����L�[�R���Őݒ�ł���悤�ɂ��邽�߂̂���
        {
            ConClick();                   //�R���g���[���[�Ń{�^�����N���b�N�����邽�߂̂���
        }
        else
        {
            keycon.condec = false;
        }
        //if (Button != rk && Button != lk && Button != dwk && keycon.button == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.JoystickButton0))
        //    {
        //        {
        //            Button.GetComponent<Button>().onClick.Invoke();
        //            Debug.Log("conclick");
        //        }
        //    }
        //}
        //�R���g���[���[�ڑ����̃X�e�B�b�N���͂𔻕�
        if (controllerconnect.ConConnect)
        {
            //�J�[�\���������Ȃ�����
            Cursor.visible = false;
            //�J�[�\������ʒ����Ƀ��b�N
            Cursor.lockState = CursorLockMode.Locked;
            //InputManager�ŐV���ɐݒ肵��Axis�̕ϐ����擾
            float lsh = Input.GetAxis("L_stick_H");�@�@�@�@//���X�e�B�b�N��
            float lsv = Input.GetAxis("L_stick_V");        //���X�e�B�b�N�c
            //if (Button != beforeb)
            //{
            //    if (Input.GetKeyDown(KeyCode.JoystickButton1))
            //    {
            //        Button.GetComponent<Button>().onClick.Invoke();
            //        beforeb = Button;
            //    }
            //}
            if (lsv >= deadzone)     //���X�e�B�b�N�̓|�����݂��f�b�h�]�[���𒴂�����
            {
                if (lsvup == true)�@ //�X�e�B�b�N�����|���������������Ȃ��悤�ɂ��邽�߂̂���
                {
                    Debug.Log("��");
                    //�{�^���̈ʒu�ɂ���Ď��ǂ̃{�^���Ɉړ����邩�����߂邽�߂�if��
                    if (buttonnumh == 2 && buttonnumv == 1 || buttonnumh == 3 && buttonnumv == 1)
                    {
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else
                    {
                        buttonnumv -= 1;
                    }
                    Buttonselect();    
                    lsvup = false;
                }
            }
            else if (lsv <= -deadzone)
            {
                if (lsvdown == true)
                {
                    Debug.Log("��");
                    if (buttonnumh == 2 && buttonnumv == 8 || buttonnumh == 3 && buttonnumv == 8)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumv += 1;
                    }
                    Buttonselect();
                    lsvdown = false;
                }
            }
            if (lsh <= -deadzone)
            {
                if (lshdown == true)
                {
                    Debug.Log("��");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 2 && buttonnumv >= 5)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 2 && buttonnumv <= 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 1;
                        }
                    }
                    else
                    {
                        buttonnumh -= 1;
                    }
                    Buttonselect();
                    lshdown = false;
                }
            }
            else if (lsh >= deadzone)
            {
                if (lshup == true)
                {
                    Debug.Log("�E");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumh += 1;
                    }
                    Buttonselect();
                    lshup = false;
                }
            }

            //���|�����X�e�B�b�N��߂��Ƃ������|���Ĉړ��������悤�ɂ���
            if (lsv <= deadzone)
            {
                lsvup = true;
            }
            if (lsv >= -deadzone)
            {
                lsvdown = true;
            }
            if (lsh <= deadzone)
            {
                lshup = true;
            }
            if (lsh >= -deadzone)
            {
                lshdown = true;
            }

            float dph = Input.GetAxis("D_pad_H");        //�\���L�[�̉����擾
            float dpv = Input.GetAxis("D_pad_V");        //�\���L�[�̏c���擾
            if (dpv >= deadzone)
            {
                if (dpvup == true)
                {
                    Debug.Log("��");
                    if (buttonnumh == 2 && buttonnumv == 1 || buttonnumh == 3 && buttonnumv == 1)
                    {
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else
                    {
                        buttonnumv -= 1;
                    }
                    Buttonselect();
                    dpvup = false;
                }
            }
            else if (dpv <= -deadzone)
            {
                if (dpvdown == true)
                {
                    Debug.Log("��");
                    if (buttonnumh == 2 && buttonnumv == 8 || buttonnumh == 3 && buttonnumv == 8)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 1 && skill)
                    {
                        buttonnumv = 2;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2 && skill)
                    {
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumv += 1;
                    }
                    Buttonselect();
                    dpvdown = false;
                }
            }
            if (dph <= -deadzone)
            {
                if (dphdown == true)
                {
                    Debug.Log("��");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 3;
                        buttonnumv = 8;
                    }
                    else if (buttonnumh == 2 && buttonnumv >= 5)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 2 && buttonnumv <= 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 1;
                        }
                    }
                    else
                    {
                        buttonnumh -= 1;
                    }
                    Buttonselect();
                    dphdown = false;
                }
            }
            else if (dph >= deadzone)
            {
                if (dphup == true)
                {
                    Debug.Log("�E");
                    if (buttonnumh == 1 && buttonnumv == 1)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else if (buttonnumh == 1 && buttonnumv == 2)
                    {
                        buttonnumh = 4;
                    }
                    else if (buttonnumh == 4)
                    {
                        buttonnumh = 1;
                        if (skill)
                        {
                            buttonnumv = 2;
                        }
                    }
                    else if (buttonnumh == 1 && !skill)
                    {
                        buttonnumh = 2;
                        buttonnumv = 1;
                    }
                    else
                    {
                        buttonnumh += 1;
                    }
                    Buttonselect();
                    dphup = false;
                }
            }

            //��̃X�e�B�b�N�Ɠ���
            if (dpv <= deadzone)
            {
                dpvup = true;
            }
            if (dpv >= -deadzone)
            {
                dpvdown = true;
            }
            if (dph <= deadzone)
            {
                dphup = true;
            }
            if (dph >= -deadzone)
            {
                dphdown = true;
            }
        }
        else//�R���g���[���[��ڑ�
        {
            //�J�[�\����\��
            Cursor.visible = true;
            //�J�[�\���̃��b�N������
            Cursor.lockState = CursorLockMode.None;
        }

        ////R Stick
        //float rsh = Input.GetAxis("R_stick_H");
        //float rsv = Input.GetAxis("R_stick_V");
        //if ((rsh != 0) || (rsv != 0))
        //{
        //    Debug.Log("R stick:" + rsh + "," + rsv);
        //}
        ////D-Pad
        //float dph = Input.GetAxis("D_pad_H");
        //float dpv = Input.GetAxis("D_pad_V");
        //if ((dph != 0) || (dpv != 0))
        //{
        //    Debug.Log("D Pad:" + dph + "," + dpv);
        //}
        ////Trigger
        ////float tri = Input.GetAxis("L_R_trigger");
        ////if (tri > 0)
        ////{
        ////    Debug.Log("L trigger:" + tri);
        ////}
        ////else if (tri < 0)
        ////{
        ////    Debug.Log("R trigger:" + tri);
        ////}
        ////else
        ////{
        ////    //Debug.Log("  trigger:none");
        ////}
        //LRTbutton();
    }

    //�Q�Ƃ��Ă���{�^����ύX���邽�߂̃��\�b�h
    public void Buttonselect()
    {
        //�Q�Ƃ��Ă��Ȃ���Ԃɂ���@�Ƃ�ܐF�ő�p
        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.disabledSprite;
        //Debug.Log("�� " + buttonnumh + "  �c " + buttonnumv);

        //�c���̕ϐ��ɂ���đΉ������{�^�����Q�Ƃ���
        if (buttonnumh == 1 && buttonnumv == 1)
        {
            Button = escape;
        }
        else if (buttonnumh == 1 && buttonnumv == 2 && skill)
        {
            Button = skill;
        }
        else if (buttonnumh == 2 && buttonnumv == 1)
        {
            Button = rk;
        }
        else if (buttonnumh == 2 && buttonnumv == 2)
        {
            Button = lk;
        }
        else if (buttonnumh == 2 && buttonnumv == 3)
        {
            Button = dwk;
        }
        else if (buttonnumh == 2 && buttonnumv == 4)
        {
            Button = jk;
        }
        else if (buttonnumh == 2 && buttonnumv == 5)
        {
            Button = ak;
        }
        else if (buttonnumh == 2 && buttonnumv == 6)
        {
            Button = dk;
        }
        else if (buttonnumh == 2 && buttonnumv == 7)
        {
            Button = hk;
        }
        else if (buttonnumh == 2 && buttonnumv == 8)
        {
            Button = ik;
        }
        else if (buttonnumh == 3 && buttonnumv == 1)
        {
            Button = rkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 2)
        {
            Button = lkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 3)
        {
            Button = dwkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 4)
        {
            Button = jkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 5)
        {
            Button = akr;
        }
        else if (buttonnumh == 3 && buttonnumv == 6)
        {
            Button = dkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 7)
        {
            Button = hkr;
        }
        else if (buttonnumh == 3 && buttonnumv == 8)
        {
            Button = ikr;
        }
        else if (buttonnumh == 4)
        {
            Button = save;
        }
        else if (buttonnumh == 1 && !skill)
        {
            Button = escape;
        }
        Debug.Log("Button " + Button);
        //�Q�Ɗm�F
        Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
    }
    public void LRTbutton()
    {
        //    float LT = Input.GetAxis("LT");
        //    if (Lt == true)
        //    {
        //        if (LT >= 0.00000000001f)
        //        {
        //            Lt = false;
        //            Debug.Log("LT");
        //        }
        //    }
        //    else
        //    {
        //        if (LT == 0)
        //        {
        //            Lt = true;
        //        }
        //    }
        //    float RT = Input.GetAxis("RT");
        //    if (Rt == true)
        //    {
        //        if (RT >= 0.00000000001f)
        //        {
        //            Rt = false;
        //            Debug.Log("RT");
        //        }
        //    }
        //    else
        //    {
        //        if (RT == 0)
        //        {
        //            Rt = true;
        //        }
        //    }
    }

    //�R���g���[���[�Ń{�^����onClick()���\�b�h���g�p���邽�߂̃��\�b�h
    public void ConClick()
    {
        if (Button != rk && Button != lk)        //�R���g���[���[�̏ꍇ�ړ��L�[�͂���Ȃ��̂ŏȂ�
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                {
                    Button.GetComponent<Button>().onClick.Invoke();    //Invoke()���\�b�h��onClick()���\�b�h���g�p
                    Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.pressedSprite;
                    Debug.Log("conclick");
                }
            }
            else if (Input.GetKeyUp(KeyCode.JoystickButton0))
            {
                Button.GetComponent<Image>().sprite = Button.GetComponent<Button>().spriteState.highlightedSprite;
            }
        }
    }

}