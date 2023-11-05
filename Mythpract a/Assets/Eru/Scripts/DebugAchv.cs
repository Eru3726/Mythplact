using UnityEngine;

public class DebugAchv : MonoBehaviour
{
    private readonly AchvMeasurement achv = new AchvMeasurement();

    public void Button()
    {
        achv.PlayerDie();
        Debug.Log("プレイヤーが死んだ");
    }
}
