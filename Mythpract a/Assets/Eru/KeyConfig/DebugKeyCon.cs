using UnityEngine;
using UnityEngine.InputSystem;

public class DebugKeyCon : MonoBehaviour
{
    [SerializeField, Header("攻撃")]
    private InputActionReference attack;

    [SerializeField, Header("防御")]
    private InputActionReference guard;

    [SerializeField, Header("右移動")]
    private InputActionReference right;

    [SerializeField, Header("左移動")]
    private InputActionReference left;

    [SerializeField, Header("ジャンプ")]
    private InputActionReference jump;

    [SerializeField, Header("ブリンク")]
    private InputActionReference blink;

    [SerializeField, Header("スキル1")]
    private InputActionReference skill1;

    [SerializeField, Header("スキル2")]
    private InputActionReference skill2;

    [SerializeField, Header("スキル3")]
    private InputActionReference skill3;

    [SerializeField, Header("スキル4")]
    private InputActionReference skill4;

    private void Start()
    {
        //有効化
        attack.action.Enable();
        guard.action.Enable();
        right.action.Enable();
        left.action.Enable();
        jump.action.Enable();
        blink.action.Enable();
        skill1.action.Enable();
        skill2.action.Enable();
        skill3.action.Enable();
        skill4.action.Enable();
    }

    void Update()
    {
        //押された
        if (attack.action.triggered) Debug.Log("攻撃！");
        else if (guard.action.triggered) Debug.Log("防御！");

        //押されている
        else if (right.action.inProgress) Debug.Log("右へ移動中！");
        else if (left.action.inProgress) Debug.Log("左へ移動中！");

        //押された
        else if (jump.action.triggered) Debug.Log("ジャンプした！！");
        else if (blink.action.triggered) Debug.Log("ブリンク発動！");
        else if (skill1.action.triggered) Debug.Log("スキル1発動！");
        else if (skill2.action.triggered) Debug.Log("スキル2発動！");
        else if (skill3.action.triggered) Debug.Log("スキル3発動！");
        else if (skill4.action.triggered) Debug.Log("スキル4発動！");
    }
}
