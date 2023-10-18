using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopManager : MonoBehaviour
{
    // �ǂ�����ł��Ăяo����悤�ɂ���
    public static HitStopManager hitstop;

    private void Start()
    {
        hitstop = this;
    }

    // �q�b�g�X�g�b�v���J�n����֐�
    public void StartHitStop(float duration)
    {
        hitstop.StartCoroutine(hitstop.HitStopCoroutine(duration));
    }

    // �R���[�`���̓��e
    private IEnumerator HitStopCoroutine(float duration)
    {
        // �q�b�g�X�g�b�v�̊J�n
        Time.timeScale = 0.01f;

        // �w�肵�����Ԃ�����~
        yield return new WaitForSecondsRealtime(duration);

        // �q�b�g�X�g�b�v�̏I��
        Time.timeScale = 1f;
    }
}
