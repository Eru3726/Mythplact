using UnityEngine;

public class Distortion : MonoBehaviour
{
    public Material dismat;
    private float disspd = 1f;
    [SerializeField, Header("出現速度")]
    private float fadeSpd = 0.01f;

    [SerializeField, Header("タイトルキャンバス")]
    private GameObject titleCanvas;


    private void Awake()
    {
        titleCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // デバッグ用プログラム
        if (Input.GetKeyDown(KeyCode.Z))
        {
            disspd = 1;
            titleCanvas.SetActive(false);
        }
        
        if (disspd >= 0)
        {
            disspd -= fadeSpd;
        }
        else
        {
            titleCanvas.SetActive(true);
        }
        dismat.SetFloat("DissolveAmount", disspd);
    }
}
