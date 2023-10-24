using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffectEnd : MonoBehaviour
{
    bool deadeffectstoped;
    
    public bool DeadEffectStoped { get { return deadeffectstoped; } }

    private void Start()
    {
        deadeffectstoped = false;
    }
    private void OnParticleSystemStopped()
    {
        deadeffectstoped = true;
    }
}
