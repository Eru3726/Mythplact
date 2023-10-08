using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRotate : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f);
    }
}
