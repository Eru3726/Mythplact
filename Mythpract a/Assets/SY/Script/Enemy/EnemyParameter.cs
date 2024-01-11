using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using SY;

[System.Serializable]
public class EnemyParameter
{
    [Header("プレイヤー")]
    [SerializeField, Tooltip("プレイヤー")] GameObject pl;
    [Header("UI")]
    [SerializeField, Tooltip("UI")] GameObject ui;

    [Header("カメラ")]
    [SerializeField, Tooltip("バーチャルカメラ")] CinemachineVirtualCamera virtualCamera;
    [SerializeField, Tooltip("Volume")] Volume volume;
    [Header("ステージ")]
    [SerializeField, Tooltip("ステージデータ")] Stage stageData;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting stage_Gizmo;

    [Header("本体")]
    [SerializeField, Tooltip("接触攻撃判定")] GameObject body;
    [SerializeField, Tooltip("接触威力")] float body_Power = 1.0f;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting body_Gizmo;

    public GameObject Player { get { return pl; } }
    public GameObject UI { get { return ui; } }

    public CinemachineVirtualCamera VirtualCamera { get { return virtualCamera; } set { virtualCamera = value; } }
    public Volume Volume { get { return volume; } set { volume = value; } }
    public Stage Stage { get { return stageData; } }
    public GizmoSetting Stage_Gizmo { get { return stage_Gizmo; } }

    public GameObject Body { get { return body; } }
    public float Body_Power { get { return body_Power; } }
    public GizmoSetting Body_Gizmo { get { return body_Gizmo; } }
}