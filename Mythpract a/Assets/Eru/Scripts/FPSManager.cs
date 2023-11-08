using UnityEngine;

public class FPSManager : MonoBehaviour
{
    [SerializeField]
    private int fps = 60;

    void Awake()
    {
        Application.targetFrameRate = fps;
    }
}
