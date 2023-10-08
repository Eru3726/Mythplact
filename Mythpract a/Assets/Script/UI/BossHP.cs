using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHP : MonoBehaviour
{
    Image img;
    SY.HitMng hitMng;

    [SerializeField] GameObject Boss;
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        hitMng = Boss.GetComponent<SY.HitMng>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = hitMng.HP / hitMng.MaxHP;

    }
}
