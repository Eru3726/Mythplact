using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockDestroy : MonoBehaviour
{
    private float lifeTime = 2;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
