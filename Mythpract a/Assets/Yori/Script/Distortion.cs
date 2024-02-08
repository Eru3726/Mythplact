using UnityEngine;

public class Distortion : MonoBehaviour
{
    public Material dismat;
    private float disspd = 1f;
    [SerializeField, Header("出現速度")]
    private float fadeSpd = 0.01f;

    [SerializeField, Header("タイトルキャンバス")]
    private Canvas titleCanvas;

    // Update is called once per frame
    void Update()
    {
        // デバッグ用プログラム
        if (Input.GetKeyDown(KeyCode.Z))
        {
            disspd = 1;
        }
        
        if (disspd <= 1)
        {
            disspd -= fadeSpd;
        }
        else
        {
            
        }
        dismat.SetFloat("DissolveAmount", disspd);
    }
}
