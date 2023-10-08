using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    Image img;
    SY.HitMng hitMng;
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        hitMng = GameObject.Find("Player").GetComponent<SY.HitMng>();
    }

    void Update()
    {
        img.fillAmount = hitMng.HP / hitMng.MaxHP;

        if(img.fillAmount > 0.3f)
        {
            img.color = new Color(0.6f, 1, 0.6f);
        }
        else
        {
            img.color = new Color(1, 0.6f, 0.6f);
        }
    }
}
