using UnityEngine;

public class AchvSave : MonoBehaviour
{
    void Start()
    {
        AchvManager.instance.Save();
    }
}
