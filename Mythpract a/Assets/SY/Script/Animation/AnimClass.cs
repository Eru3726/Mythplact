using System;
using UnityEngine;

[Serializable]
public class Products
{
    [SerializeField] string name;           //�z��̖��O
    [SerializeField] AnimationClip clips;   //�A�j���[�V����
    [SerializeField] Type actionType;       //�A�j���[�V�����̃A�N�V�����^�C�v
    [SerializeField] bool isLoop;           //���[�v�A�j���[�V����
    [SerializeField] Type[] priority;       //�D��x   �㏑���h�~�݂����Ȃ���

    //�v���p�e�B
    public string Name { get { return name; } }
    public AnimationClip Clips { get { return clips; } }
    public Type ActionType { get { return actionType; } }
    public bool IsLoop { get { return isLoop; } }
    public Type[] Priority { get { return priority; } }

    //�A�N�V�����^�C�v�ꗗ
    public enum Type
    {
//      None,   //��A�N�e�B�u
        Entry,  //�o�ꎞ
        Idle,   //�A�N�e�B�u���ҋ@
        Move,   //�ړ�
        Avoid,  //���(�_�b�V��)
        Jump,   //�W�����v
        Attack, //�U��
        Guard,  //�K�[�h
        Buff,   //����
        Debuff, //��̉�
        Damage, //�_���[�W
        Heal,   //��
        Die,    //��
        Revive, //�h��
    }
}