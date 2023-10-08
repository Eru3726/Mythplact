using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInt : MonoBehaviour
{
    public void Int()
    {
        GameData.testInt = Random.Range(1, 10);
    }
}
