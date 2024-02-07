using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SY;

public class Eruption : PillarBase
{
    // Start is called before the first frame update
    void Start()
    {
        SetUp();

        SetPower(Atk, qP.Eruption_Power);
    }

    // Update is called once per frame
    void Update()
    {
        ReNew();

        switch (state)
        {
            case Qilin_PillarType.Up:
                if (Up()) { state = SY.Qilin_PillarType.Keep; }
                break;
            case Qilin_PillarType.Keep:
                if (Keep()) { state = Qilin_PillarType.Death; }
                break;
            case Qilin_PillarType.Death:
                Die();
                break;
        }
    }
}