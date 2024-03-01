using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSheriff : MonoBehaviour
{
    [SerializeField]
    private ExcelPlayerData playerData;
    void Start()
    {
        SetPower(gameObject ,playerData.Player[0].sheriffAtk_Power);

    }

    void SetPower(GameObject obj, float power)
    {
        obj.GetComponent<SY.HitData>().Power = power;
    }
}
