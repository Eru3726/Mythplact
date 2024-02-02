using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distortion : MonoBehaviour
{
    public Material dismat;
    private float disspd = 1f;
    [SerializeField,Header("消える速度")]
    private float fadeSpd = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if (disspd >= 0)
        {
            disspd -= fadeSpd;
        }
        
        dismat.SetFloat("DissolveAmount", disspd);
    }
}
