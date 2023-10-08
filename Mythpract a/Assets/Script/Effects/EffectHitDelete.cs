using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHitDelete : MonoBehaviour
{
    ParticleSystem hitpat;

    private void Start()
    {
        hitpat = gameObject.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if (hitpat.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
