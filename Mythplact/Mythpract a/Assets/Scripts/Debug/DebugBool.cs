using UnityEngine;

public class DebugBool : MonoBehaviour
{
    public void Bool()
    {
        if (GameData.testBool)
        {
            GameData.testBool = false;
        }
        else
        {
            GameData.testBool = true;
        }
    }
}
