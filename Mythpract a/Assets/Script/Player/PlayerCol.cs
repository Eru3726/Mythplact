using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{
    public LayerMask layerMask_Ground;
    public LayerMask layerMask_Hit;

    bool isGround;

    BoxCollider2D col;

    [SerializeField] GameObject AtkNormalCol;


    void InitCol()
    {
        col = GetComponent<BoxCollider2D>();
    }

    Vector3 GetCenterPos()
    {
        Vector3 pos = transform.position;
        // �{�b�N�X�R���C�_�[�̃I�t�Z�b�g���璆�S���v�Z
        pos.y += col.offset.y;

        return pos;
    }

    Vector3 GetFootPos()
    {
        Vector3 pos = GetCenterPos();
        // �{�b�N�X�R���C�_�[�̃T�C�Y���瑫�����v�Z
        pos.y += -col.size.y / 2;
        return pos;
    }

    // �n�ʂɐݒu���Ă��邩�`�F�b�N
    void CheckGround()
    {
        isGround = false;   // ��U�󒆔���ɂ��Ă���

        Vector3 foot = GetFootPos();            // �n�_
        Vector3 len = Vector3.up * -0.2f;         // ����
        float width = col.size.x / 2;           // �����蔻��̕�

        // ���[�A�����A�A�E�[�̏��Ƀ`�F�b�N���Ă���
        foot.x += -width;
        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // �����蔻��̌��ʗp�̕ϐ�
            // ���C���΂��āA�w�肵�����C���[�ɂԂ��邩�`�F�b�N
            resultGround = Physics2D.Linecast(foot, foot + len, layerMask_Ground);

            // �f�o�b�O�\��
            Debug.DrawLine(foot, foot + len);

            foot.x += width;                // x���W�����炷
            // �R���C�_�[�ƐڐG�������`�F�b�N
            if (resultGround.collider)
            {
                isGround = true;            // �n�ʂƐڐG����
                                            //Debug.Log("�n�ʂƐڐG");
                return;                     // �I��
            }

        }

    }

    Vector3 GetRightPos()
    {
        Vector3 pos = GetCenterPos();
        pos.x += col.size.x / 2 + col.offset.x;
        return pos;
    }

    public bool CheckRightHit()
    {
        Vector3 right = GetRightPos();
        Vector3 len = Vector3.right * 0.05f;         // ����
        float width = col.size.y / 2;           // �����蔻��̕�

        right.y -= width;

        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // �����蔻��̌��ʗp�̕ϐ�
            // ���C���΂��āA�w�肵�����C���[�ɂԂ��邩�`�F�b�N
            resultGround = Physics2D.Linecast(right, right + len, layerMask_Hit);

            // �f�o�b�O�\��
            Debug.DrawLine(right, right + len);

            right.y += width;                // y���W�����炷
            // �R���C�_�[�ƐڐG�������`�F�b�N
            if (resultGround.collider)
            {
                return true;
            }

        }
            return false;
    }
    Vector3 GetLeftPos()
    {
        Vector3 pos = GetCenterPos();
        pos.x += -col.size.x / 2 + col.offset.x;
        return pos;
    }

    public bool CheckLeftHit()
    {
        Vector3 left = GetLeftPos();
        Vector3 len = Vector3.left * 0.05f;         // ����
        float width = col.size.y / 2;           // �����蔻��̕�

        left.y -= width;

        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // �����蔻��̌��ʗp�̕ϐ�
            // ���C���΂��āA�w�肵�����C���[�ɂԂ��邩�`�F�b�N
            resultGround = Physics2D.Linecast(left, left + len, layerMask_Hit);

            // �f�o�b�O�\��
            Debug.DrawLine(left, left + len);

            left.y += width;                // y���W�����炷
            // �R���C�_�[�ƐڐG�������`�F�b�N
            if (resultGround.collider)
            {
                return true;
            }

        }
        return false;
    }


    public void AtkNormalHit()
    {
        Debug.Log("�U�����ڐG");
    }

}
