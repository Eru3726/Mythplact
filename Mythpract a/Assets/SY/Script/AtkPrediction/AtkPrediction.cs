using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkPrediction : MonoBehaviour
{
    GameObject obj;
    float timer = 0;

    [SerializeField, Tooltip("表示時間")] float displayTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < displayTime) { return; }
        Destroy(obj);
    }
}
