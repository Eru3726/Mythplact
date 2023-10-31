using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{

    GameObject gauge1;
    GameObject gauge2;
    GameObject gauge3;
    GameObject gauge4;
    GameObject gauge5;
    GameObject gauge6;
    GameObject gauge7;
    GameObject gauge8;
    GameObject gauge9;
    GameObject gauge10;


    ParticleSystem gaugeaura;
    Image img;
    SY.HitMng hitMng;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
        hitMng = GameObject.Find("Player").GetComponent<SY.HitMng>();
        gauge1 = GameObject.Find("UI/HPGauge/Gauge/1");
        gauge2 = GameObject.Find("UI/HPGauge/Gauge/2");
        gauge3 = GameObject.Find("UI/HPGauge/Gauge/3");
        gauge4 = GameObject.Find("UI/HPGauge/Gauge/4");
        gauge5 = GameObject.Find("UI/HPGauge/Gauge/5");
        gauge6 = GameObject.Find("UI/HPGauge/Gauge/6");
        gauge7 = GameObject.Find("UI/HPGauge/Gauge/7");
        gauge8 = GameObject.Find("UI/HPGauge/Gauge/8");
        gauge9 = GameObject.Find("UI/HPGauge/Gauge/9");
        gauge10 = GameObject.Find("UI/HPGauge/Gauge/10");


    }

    void Update()
    {
        switch (hitMng.HP)
        {
            case 0:
                gauge1.SetActive(false);
                gauge2.SetActive(false);
                gauge3.SetActive(false);
                gauge4.SetActive(false);
                gauge5.SetActive(false);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 1:
                gauge1.SetActive(true);
                gauge2.SetActive(false);
                gauge3.SetActive(false);
                gauge4.SetActive(false);
                gauge5.SetActive(false);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 2:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(false);
                gauge4.SetActive(false);
                gauge5.SetActive(false);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 3:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(false);
                gauge5.SetActive(false);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 4:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(false);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 5:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(false);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 6:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(true);
                gauge7.SetActive(false);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 7:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(true);
                gauge7.SetActive(true);
                gauge8.SetActive(false);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 8:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(true);
                gauge7.SetActive(true);
                gauge8.SetActive(true);
                gauge9.SetActive(false);
                gauge10.SetActive(false);
                break;
            case 9:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(true);
                gauge7.SetActive(true);
                gauge8.SetActive(true);
                gauge9.SetActive(true);
                gauge10.SetActive(false);
                break;
            case 10:
                gauge1.SetActive(true);
                gauge2.SetActive(true);
                gauge3.SetActive(true);
                gauge4.SetActive(true);
                gauge5.SetActive(true);
                gauge6.SetActive(true);
                gauge7.SetActive(true);
                gauge8.SetActive(true);
                gauge9.SetActive(true);
                gauge10.SetActive(true);
                break;

            default:
                break;
        }
    }
}
