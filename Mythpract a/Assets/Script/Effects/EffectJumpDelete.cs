using UnityEngine;

public class EffectJumpDelete : MonoBehaviour
{
    ParticleSystem jumppat;
    void Start()
    {
        jumppat = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumppat.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
