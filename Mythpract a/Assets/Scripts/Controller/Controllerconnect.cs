using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllerconnect : MonoBehaviour
{
    bool conconnect = false;    //�R���g���[���[��ڑ����Ă��邩�ǂ���
    string[] connect;           //�R���g���[���[�̎�ނ𔻕ʂ��邽�߂̂��
    public Keyconfig keycon;    //�L�[�R�����R���g���[���[�ڑ����ɕς��邽�߂ɂԂ�����

    //�R���g���[���[�ڑ��̃v���p�e�B��ݒ�
    public bool ConConnect       
    {
        get { return conconnect; }
        
        set { conconnect = value; }
    }

    void Start()
    {
        keyread();
    }

    void Update()
    {
        if (Input.GetJoystickNames().Length > 0)  //�R���g���[���[�ڑ����Ă邩�ǂ���
        {
            connect = Input.GetJoystickNames();  //�ڑ����Ă���R���g���[���[�̖��O���擾
            if (connect[0] == ("Controller (JC-U3613M - Xinput Mode)") && conconnect == false)�@�@//�R���g���[���[�ڑ�
            {
                conread();  //�L�[�R�����R���g���[���[�p�ɕύX
                //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.attack == false && keycon.dash == false && keycon.heal == false && keycon.interact == false)
                {
                    conconnect = true;�@�@�@�@//�����̓v���p�e�B
                }
                Debug.Log("�R���g���[���[�ڑ�" + conconnect);
            }
        }

        if (connect[0] == "" && conconnect == true)     //�R���g���[���[��ڑ�
        {
            keyread();       //�L�[�R�����L�[�{�[�h�p�ɕύX
            //if (keycon.right == false && keycon.left == false && keycon.down == false && keycon.jump == false && keycon.attack == false && keycon.dash == false && keycon.heal == false && keycon.interact == false)
            {
                conconnect = false;�@�@�@�@//�����̓v���p�e�B
            }
            Debug.Log("�R���g���[���[�ڑ�" + conconnect);
        }
    }

    //�L�[�R�����R���g���[���[�p�ɕύX���郁�\�b�h
    public void conread()
    {
        //GameData.keyrightkey = GameData.rightkey;
        //GameData.keyleftkey = GameData.leftkey;
        //GameData.keyjumpkey = GameData.jumpkey;
        //GameData.keyattackkey = GameData.attackkey;
        //GameData.keydashkey = GameData.dashkey;
        //GameData.keyhealkey = GameData.healkey;
        //GameData.keyinteractkey = GameData.interactkey;
        //GameData.keydownkey = GameData.downkey;
        //Debug.Log(GameData.keyrightkey);
        //Debug.Log(GameData.keyleftkey);
        //Debug.Log(GameData.keydownkey);
        //Debug.Log(GameData.keyjumpkey);
        //Debug.Log(GameData.keyattackkey);
        //Debug.Log(GameData.keydashkey);
        //Debug.Log(GameData.keyhealkey);
        //Debug.Log(GameData.keyinteractkey);
        GameData.rightkey = KeyCode.None;�@�@�@�@�@�@�@�@//GameData�̃L�[��ς���
        keycon.keyStr = GameData.rightkey.ToString();�@�@//�ς����L�[���X�g�����O�^�Ŏ擾
        Debug.Log(keycon.keyStr);
        keycon.right = true;                             //�ǂ̃L�[��ς��邩�𔻕ʂ���bool����true��
        keycon.codechange = GameData.rightkey;           //�ύX����L�[�R�[�h���Ԃ�����ł���
        keycon.KeyChange();                              //�L�[��ύX���郁�\�b�h���g�p     //�ȉ�����
        Debug.Log("right" + GameData.rightkey);
        GameData.leftkey = KeyCode.None;
        keycon.keyStr = GameData.leftkey.ToString();
        Debug.Log(keycon.keyStr);
        keycon.left = true;
        keycon.codechange = GameData.leftkey;
        keycon.KeyChange();
        Debug.Log("left" + GameData.leftkey);
        GameData.downkey = GameData.condownkey;
        keycon.keyStr = GameData.downkey.ToString();
        Debug.Log(keycon.keyStr);
        keycon.down = true;
        keycon.codechange = GameData.downkey;
        keycon.KeyChange();
        //Debug.Log("down" + GameData.downkey);
        GameData.jumpkey = GameData.conjumpkey;
        keycon.keyStr = GameData.jumpkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.jump = true;
        keycon.codechange = GameData.jumpkey;
        keycon.KeyChange();
        //Debug.Log("jump" + GameData.jumpkey);
        GameData.attackkey = GameData.conattackkey;
        keycon.keyStr = GameData.attackkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.attack = true;
        keycon.codechange = GameData.attackkey;
        keycon.KeyChange();
        //Debug.Log("attack" + GameData.attackkey);
        GameData.dashkey = GameData.condashkey;
        keycon.keyStr = GameData.dashkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.dash = true;
        keycon.codechange = GameData.dashkey;
        keycon.KeyChange();
        //Debug.Log("dash" + GameData.dashkey);
        GameData.healkey = GameData.conhealkey;
        keycon.keyStr = GameData.healkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.heal = true;
        keycon.codechange = GameData.healkey;
        keycon.KeyChange();
        //Debug.Log("heal" + GameData.healkey);
        GameData.interactkey = GameData.coninteractkey;
        keycon.keyStr = GameData.interactkey.ToString();
        //Debug.Log(keycon.keyStr);
        keycon.interact = true;
        keycon.codechange = GameData.interactkey;
        keycon.KeyChange();
        //Debug.Log("interact" + GameData.interactkey);
    }

    //�L�[�R�����L�[�{�[�h�p�ɕύX���郁�\�b�h
    public void keyread()
    {
        //GameData.conjumpkey = GameData.jumpkey;
        //GameData.conattackkey = GameData.attackkey;
        //GameData.condashkey = GameData.dashkey;
        //GameData.conhealkey = GameData.healkey;
        //GameData.coninteractkey = GameData.interactkey;
        //Debug.Log(GameData.conjumpkey);
        //Debug.Log(GameData.conattackkey);
        //Debug.Log(GameData.condashkey);
        //Debug.Log(GameData.conhealkey);
        //Debug.Log(GameData.coninteractkey);
        GameData.rightkey = GameData.keyrightkey;
        keycon.keyStr = GameData.rightkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.right = true;
        Debug.Log("keyright" + GameData.keyrightkey);
        keycon.codechange = GameData.rightkey;
        keycon.KeyChange();
        //Debug.Log("right" + GameData.rightkey);
        GameData.leftkey = GameData.keyleftkey;
        keycon.keyStr = GameData.leftkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.left = true;
        //Debug.Log("keyleft" + GameData.keyleftkey);
        keycon.codechange = GameData.leftkey;
        keycon.KeyChange();
        //Debug.Log("left" + GameData.leftkey);
        GameData.jumpkey = GameData.keyjumpkey;
        keycon.keyStr = GameData.jumpkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.jump = true;
        //Debug.Log("keyjump" + GameData.keyjumpkey);
        keycon.codechange = GameData.jumpkey;
        keycon.KeyChange();
        //Debug.Log("jump" + GameData.jumpkey);
        GameData.attackkey = GameData.keyattackkey;
        keycon.keyStr = GameData.attackkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.attack = true;
        //Debug.Log("keyattack" + GameData.keyattackkey);
        keycon.codechange = GameData.attackkey;
        keycon.KeyChange();
        //Debug.Log("attack" + GameData.attackkey);
        GameData.dashkey = GameData.keydashkey;
        keycon.keyStr = GameData.dashkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.dash = true;
        //Debug.Log("keydash" + GameData.keydashkey);
        keycon.codechange = GameData.dashkey;
        keycon.KeyChange();
        //Debug.Log("dash" + GameData.dashkey);
        GameData.healkey = GameData.keyhealkey;
        keycon.keyStr = GameData.healkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.heal = true;
        //Debug.Log("keyheal" + GameData.keyhealkey);
        keycon.codechange = GameData.healkey;
        keycon.KeyChange();
        //Debug.Log("heal" + GameData.healkey);
        GameData.downkey = GameData.keydownkey;
        keycon.keyStr = GameData.downkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.down = true;
        //Debug.Log("keydown" + GameData.keydownkey);
        keycon.codechange = GameData.downkey;
        keycon.KeyChange();
        //Debug.Log("down" + GameData.downkey);
        GameData.interactkey = GameData.keyinteractkey;
        keycon.keyStr = GameData.interactkey.ToString();
        //Debug.Log("KeyStr" + keycon.keyStr);
        keycon.interact = true;
        //Debug.Log("keyinteract" + GameData.keyinteractkey);
        keycon.codechange = GameData.interactkey;
        keycon.KeyChange();
        //Debug.Log("interact" + GameData.interactkey);
    }

    //�L�[�{�[�h�p�̃L�[�R����ۑ�
    public void keysave()
    {
        GameData.keyrightkey = GameData.rightkey;
        GameData.keyleftkey = GameData.leftkey;
        GameData.keydownkey = GameData.downkey;
        GameData.keyjumpkey = GameData.jumpkey;
        GameData.keyattackkey = GameData.attackkey;
        GameData.keydashkey = GameData.dashkey;
        GameData.keyhealkey = GameData.healkey;
        GameData.keyinteractkey = GameData.interactkey;
    }
    
    //�R���g���[���[�p�̃L�[�R����ۑ�
    public void consave()
    {
        GameData.condownkey = GameData.downkey;
        GameData.conjumpkey = GameData.jumpkey;
        GameData.conattackkey = GameData.attackkey;
        GameData.condashkey = GameData.dashkey;
        GameData.conhealkey = GameData.healkey;
        GameData.coninteractkey = GameData.interactkey;
    }
}
