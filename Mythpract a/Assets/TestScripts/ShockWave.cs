using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField]
    GameObject Wave;
    [SerializeField]
    float Genetime;

    private float time;
    [SerializeField]
    private Vector3 Wavepos = new Vector3(-7, -5, 0);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= Genetime)
        {
            WaveCreate();
            time = 0;
        }
        time += 0.017f;

    }

    void WaveCreate()
    {
        Instantiate(Wave, Wavepos, Quaternion.identity);
        Wavepos += new Vector3(0.2f, 0, 0);
    }
}
