using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    private float lifeTime = 2;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
