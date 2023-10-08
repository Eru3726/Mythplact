using UnityEngine;

//InputSystemを使えるようにする
using UnityEngine.InputSystem;

public class SampleScript : MonoBehaviour
{
    [SerializeField]
    private InputActionReference jump;

    void Start()
    {
        //キーの有効化
        jump.action.Enable();
    }

    void Update()
    {
        if (jump.action.triggered) Debug.Log("ジャンプキーが押された！");

        if (jump.action.inProgress) Debug.Log("ジャンプキーが押されてる！");

        if (jump.action.ReadValue<float>() == 0f) Debug.Log("ジャンプキーが離された！");
    }
}
