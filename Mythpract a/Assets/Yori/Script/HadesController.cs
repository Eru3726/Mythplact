using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesController : MonoBehaviour
{

    enum ActNo
    {
        App,
        StaffAttack,
        ShockWave,
        Num         // 総数
    }

    // デリゲード
    // 関数を型にするためのもの
    private delegate void ActFunc();
    // 関数の配列
    private ActFunc[] actFuncTbl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
