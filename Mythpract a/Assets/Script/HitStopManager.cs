using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopManager : MonoBehaviour
{
    // どこからでも呼び出せるようにする
    public static HitStopManager hitstop;

    private void Start()
    {
        hitstop = this;
    }

    // ヒットストップを開始する関数
    public void StartHitStop(float duration)
    {
        hitstop.StartCoroutine(hitstop.HitStopCoroutine(duration));
    }

    // コルーチンの内容
    private IEnumerator HitStopCoroutine(float duration)
    {
        // ヒットストップの開始
        Time.timeScale = 0.01f;

        // 指定した時間だけ停止
        yield return new WaitForSecondsRealtime(duration);

        // ヒットストップの終了
        Time.timeScale = 1f;
    }
}
