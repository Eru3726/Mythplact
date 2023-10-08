using UnityEngine;

public class DebugFloat : MonoBehaviour
{
    public void Float()
    {
        GameData.testFloat = Random.Range(0.0f, 9.9f);
    }
}
