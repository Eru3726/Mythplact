/*旧アニメーション制御

using System;
using UnityEngine;

[Serializable]
public class Products
{
    [SerializeField] string name;           //配列の名前
    [SerializeField] AnimationClip clips;   //アニメーション
    [SerializeField] Type actionType;       //アニメーションのアクションタイプ
    [SerializeField] bool isLoop;           //ループアニメーション
    [SerializeField] Type[] priority;       //優先度   上書き防止みたいなもの

    //プロパティ
    public string Name { get { return name; } }
    public AnimationClip Clips { get { return clips; } }
    public Type ActionType { get { return actionType; } }
    public bool IsLoop { get { return isLoop; } }
    public Type[] Priority { get { return priority; } }

    //アクションタイプ一覧
    public enum Type
    {
//      None,   //非アクティブ
        Entry,  //登場時
        Idle,   //アクティブ時待機
        Move,   //移動
        Avoid,  //回避(ダッシュ)
        Jump,   //ジャンプ
        Attack, //攻撃
        Guard,  //ガード
        Buff,   //強化
        Debuff, //弱体化
        Damage, //ダメージ
        Heal,   //回復
        Die,    //死
        Revive, //蘇生
    }
}
*/