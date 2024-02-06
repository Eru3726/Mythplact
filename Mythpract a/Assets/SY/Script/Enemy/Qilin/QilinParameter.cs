using UnityEngine;
using SY;

[System.Serializable]
public class QilinParameter : EnemyParameter
{
    [Header("行動")]
    [SerializeField, ReadOnly ,Tooltip("現在の行動")] Qilin_MoveType moveType = Qilin_MoveType.Idle;
    [SerializeField, Tooltip("行動テーブル")] Qilin_MoveTable[] moveTable;

    [Header("登場")]
    [SerializeField, Tooltip("初期位置")] Vector2 entry_StartPos = Vector2.zero;
    [SerializeField, Tooltip("寝時間")] float entry_SleepTime = 1.0f;
    [SerializeField, Tooltip("待機時間")] float entry_BreakTime = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting entry_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting entry_SE;

    [Header("待機")]
    [SerializeField, Tooltip("待機時間")] float idle_Time = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting idle_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting idle_SE;
    [SerializeField, Tooltip("攻撃前隙")] float attackAnticipation_Time = 1.0f;
    [SerializeField, Tooltip("攻撃前エフェクト")] ParticleSetting attackAnticipation_Effect;
    [SerializeField, Tooltip("攻撃前サウンド")] AudioSetting attackAnticipation_SE;

    [Header("移動")]
    [SerializeField, Tooltip("速度")] float move_Speed = 1.0f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting move_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting move_SE;

    [Header("ブレス")]
    [SerializeField, Tooltip("ブレス")] GameObject breath;
    [SerializeField, Tooltip("威力")] float breath_Power = 1.0f;
    [SerializeField, Tooltip("攻撃距離")] float breath_AtkDis = 5.0f;
    [SerializeField, Tooltip("クールタイム")] float breath_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting breath_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting breath_SE;

    [Header("炎柱")]
    [SerializeField, Tooltip("炎柱")] GameObject eruption;
    [SerializeField, Tooltip("威力")] float eruption_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 eruption_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 eruption_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("攻撃間隙")] float eruption_AtkBreakTime = 1.0f;
    [SerializeField, Tooltip("生成数")] int eruption_Generate = 10;
    [SerializeField, Tooltip("クールタイム")] float eruption_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting eruption_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting eruption_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting eruption_Gizmo;

    [Header("突き上げ")]
    [SerializeField, Tooltip("突き上げ")] GameObject pushUp;
    [SerializeField, Tooltip("威力")] float pushUp_Power = 1.0f;
    [SerializeField, Tooltip("移動速度")] float pushUp_MoveSpd = 10.0f;
    [SerializeField, Tooltip("攻撃距離")] float pushUp_AtkDis = 5.0f;
    [SerializeField, Tooltip("クールタイム")] float pushUp_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting pushUp_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting pushUp_SE;

    [Header("突進")]
    [SerializeField, Tooltip("突き上げ")] GameObject rush;
    [SerializeField, Tooltip("威力")] float rush_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 rush_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 rush_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("移動速度")] float rush_MoveSpd = 10.0f;
    [SerializeField, Tooltip("回数")] int rush_AtkTime = 4;
    [SerializeField, Tooltip("攻撃間隙")] float rush_AtkBreakTime = 1.0f;
    [SerializeField, Tooltip("クールタイム")] float rush_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting rush_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting rush_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting rush_Gizmo;

    [Header("炎渦")]
    [SerializeField, Tooltip("炎渦")] GameObject spin;
    [SerializeField, Tooltip("威力")] float spin_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 spin_Center;
    [SerializeField, Tooltip("攻撃範囲")] Vector2 spin_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("クールタイム")] float spin_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting spin_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting spin_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting spin_Gizmo;

    [Header("隕石")]
    [SerializeField, Tooltip("隕石")] GameObject meteor;
    [SerializeField, Tooltip("威力")] float meteor_Power = 1.0f;
    [SerializeField, Tooltip("中心座標")] Vector2 meteor_Center = new Vector2(0.0f, 0.0f);
    [SerializeField, Tooltip("攻撃範囲")] Vector2 meteor_AtkRange = new Vector2(10.0f, 10.0f);
    [SerializeField, Tooltip("攻撃時間")] float meteor_AtkTime = 5.0f;
    [SerializeField, Tooltip("生成数")] float meteor_Generate = 10.0f;
    [SerializeField, Tooltip("クールタイム")] float meteor_CoolTime = 0.5f;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting meteor_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting meteor_SE;
    [SerializeField, Tooltip("ギズモ")] GizmoSetting meteor_Gizmo;


    [Header("被ダメージ")]
    [SerializeField, Tooltip("アセット")] Damage damageData;
    [SerializeField, Tooltip("エフェクト")] ParticleSetting damage_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting damage_SE;

    [Header("死")]
    [SerializeField, Tooltip("エフェクト")] ParticleSetting die_Effect;
    [SerializeField, Tooltip("サウンド")] AudioSetting die_SE;


    //----------プロパティ----------
    public Qilin_MoveType MoveType { get { return moveType; } set { moveType = value; } }
    public Qilin_MoveTable[] MoveTable { get { return moveTable; } }

    public Vector2 Entry_StartPos { get { return entry_StartPos; } }
    public float Entry_SleepTime { get { return entry_SleepTime; } }
    public float Entry_BreakTime { get { return entry_BreakTime; } }
    public ParticleSetting Entry_Effect { get { return entry_Effect; } }
    public AudioSetting Entry_SE { get { return entry_SE; } }

    public float Idle_Time { get { return idle_Time; } }
    public ParticleSetting Idle_Effect { get { return idle_Effect; } }
    public AudioSetting Idle_SE { get { return idle_SE; } }
    public float AttackAnticipation_Time { get { return attackAnticipation_Time; } }
    public ParticleSetting AttackAnticipation_Effect { get { return attackAnticipation_Effect; } }
    public AudioSetting AttackAnticipation_SE { get { return attackAnticipation_SE; } }

    public float Move_Speed { get { return move_Speed; } }
    public ParticleSetting Move_Effect { get { return move_Effect; } }
    public AudioSetting Move_SE { get { return move_SE; } }

    public GameObject Breath { get { return breath; } }
    public float Breath_Power { get { return breath_Power; } }
    public float Breath_AtkDis { get { return breath_AtkDis; } }
    public float Breath_CoolTime { get { return breath_CoolTime; } }
    public ParticleSetting Breath_Effect { get { return breath_Effect; } }
    public AudioSetting Breath_SE { get { return breath_SE; } }

    public GameObject Eruption { get { return eruption; } }
    public float Eruption_Power { get { return eruption_Power; } }
    public Vector2 Eruption_Center { get { return eruption_Center; } }
    public Vector2 Eruption_AtkRange { get { return eruption_AtkRange; } }
    public float Eruption_AtkBreakTime { get { return eruption_AtkBreakTime; } }
    public int Eruption_Generate { get { return eruption_Generate; } }
    public float Eruption_CoolTime { get { return eruption_CoolTime; } }
    public ParticleSetting Eruption_Effect { get { return eruption_Effect; } }
    public AudioSetting Eruption_SE { get { return eruption_SE; } }
    public GizmoSetting Eruption_Gizmo { get { return eruption_Gizmo; } }

    public GameObject PushUp { get { return pushUp; } }
    public float PushUp_Power { get { return pushUp_Power; } }
    public float PushUp_MoveSpd { get { return pushUp_MoveSpd; } }
    public float PushUp_AtkDis { get { return pushUp_AtkDis; } }
    public float PushUp_CoolTime { get { return pushUp_CoolTime; } }
    public ParticleSetting PushUp_Effect { get { return pushUp_Effect; } }
    public AudioSetting PushUp_SE { get { return pushUp_SE; } }

    public GameObject Rush { get { return rush; } }
    public float Rush_Power { get { return rush_Power; } }
    public Vector2 Rush_Center { get { return rush_Center; } }
    public Vector2 Rush_AtkRange { get { return rush_AtkRange; } }
    public float Rush_MoveSpd { get { return rush_MoveSpd; } }
    public int Rush_AtkTime { get { return rush_AtkTime; } }
    public float Rush_AtkBreakTime { get { return rush_AtkBreakTime; } }
    public float Rush_CoolTime { get { return rush_CoolTime; } }
    public ParticleSetting Rush_Effect { get { return rush_Effect; } }
    public AudioSetting Rush_SE { get { return rush_SE; } }
    public GizmoSetting Rush_Gizmo { get { return rush_Gizmo; } }

    public GameObject Spin { get { return spin; } }
    public float Spin_Power { get { return spin_Power; } }
    public Vector2 Spin_Center { get { return spin_Center; } }
    public Vector2 Spin_AtkRange { get { return spin_AtkRange; } }
    public float Spin_CoolTime { get { return spin_CoolTime; } }
    public ParticleSetting Spin_Effect { get { return spin_Effect; } }
    public AudioSetting Spin_SE { get { return spin_SE; } }
    public GizmoSetting Spin_Gizmo { get { return spin_Gizmo; } }

    public GameObject Meteor { get { return meteor; } }
    public float Meteor_Power { get { return meteor_Power; } }
    public Vector2 Meteor_Center { get { return meteor_Center; } }
    public Vector2 Meteor_AtkRange { get { return meteor_AtkRange; } }
    public float Meteor_AtkTime { get { return meteor_AtkTime; } }
    public float Meteor_Generate { get { return meteor_Generate; } }
    public float Meteor_CoolTime { get { return meteor_CoolTime; } }
    public ParticleSetting Meteor_Effect { get { return meteor_Effect; } }
    public AudioSetting Meteor_SE { get { return meteor_SE; } }
    public GizmoSetting Meteor_Gizmo { get { return meteor_Gizmo; } }

    public Damage DamageData { get { return damageData; } }
    public ParticleSetting Damage_Effect { get { return damage_Effect; } }
    public AudioSetting Damage_SE { get { return damage_SE; } }

    public ParticleSetting Die_Effect { get { return die_Effect; } }
    public AudioSetting Die_SE { get { return die_SE; } }
}