using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�~
public class Circle
{
    Vector2 o;      //���S�_
    Vector2 r;      //���a
    Vector2 wave;   //�g
    int dir;        //����
    float pos;      //�ʒu(���W�A���l)

    //----------�v���p�e�B----------
    public Vector2 Center { get { return o; } }
    public Vector2 Radius { get { return r; } }
    public Vector2 Wave { get { return wave; } }
    public int Direction { get { return dir; } set { dir = value; } }
    public float RadPos { get { return pos; } set { pos = value; } }

    //----------�^��----------
    public Vector2 Move(float timer, float speed)
    {
        //���S�_ + cos�܂���sin((���Ԍo�� * ���x * �ړ����� + �����ʒu) * �g��) * ���a
        return new Vector2
            (o.x + Mathf.Cos((timer * speed * dir + pos * Mathf.PI) * wave.x) * r.x,
            o.y + Mathf.Sin((timer * speed * dir + pos * Mathf.PI) * wave.y) * r.y);
    }

    //public Vector2 Move(Vector2 center, Vector2 radius, Vector2 wave, int direction, float startPos, float timer, float speed)
    //{
    //    //���S�_ + cos�܂���sin((���Ԍo�� * ���x * �ړ����� + �����ʒu) * �g��) * ���a
    //    return new Vector2
    //        (center.x + Mathf.Cos((timer * speed * direction + startPos * Mathf.PI) * wave.x) * radius.x,
    //        center.y + Mathf.Sin((timer * speed * direction + startPos * Mathf.PI) * wave.y) * radius.y);
    //}

    //----------�\���f�[�^���----------
    public void Data(float centerX, float centerY, float radiusX, float radiusY)
    {
        o.x = centerX; o.y = centerY;
        r.x = radiusX; r.y = radiusY;
    }

    public void Data(float centerX, float centerY, float radiusX, float radiusY, float waveX, float waveY)
    {
        o.x = centerX; o.y = centerY;
        r.x = radiusX; r.y = radiusY;
        wave.x = waveX; wave.y = waveY;
    }

    public void Data(float centerX, float centerY, float radiusX, float radiusY, float waveX, float waveY,
        int direction, float startPos)
    {
        o.x = centerX; o.y = centerY;
        r.x = radiusX; r.y = radiusY;
        wave.x = waveX; wave.y = waveY;
        dir = direction;
        pos = startPos;
    }

    //----------���̑��T�[�r�X----------
    public void DataClear()    //������
    {
        o = Vector2.zero;
        r = Vector2.one;
        wave = Vector2.one;
        dir = 1;
        pos = 0;
    }
}