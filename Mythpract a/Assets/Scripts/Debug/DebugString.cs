using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugString : MonoBehaviour
{
    string[] test = { "Text0", "Text1", "Text2", "Text3", "Text4", "Text5", "Text6", "Text7", "Text8", "Text9" };

    public void String()
    {
        int rand = Random.Range(0, 10);
        GameData.testString = test[rand];
    }
}
