namespace SY
{
    public enum Shoggoth_MoveType
    {
        Entry,
        Eight = 1,  //基本
        Rotation,   //旋回
        UpDown,     //上下
        Rush,       //突進
        Death,      //死
    }

    public enum Fafnir_MoveType
    {
        Entry,
        Idle = 1,   //仮
        Pound,      //はたく
        Rush,       //突進
        Breath,     //ブレス
        Earthquake, //地震
        Death,      //死
    }

    public enum Qilin_MoveType
    {
        DebugOff = -1,  //デバックオフ

        Entry,
        Idle = 1,   //仮
        Breath,     //ブレス
        Eruption,   //炎柱
        PushUp,     //突き上げ
        Rush,       //突進
        Spin,       //炎渦
        Meteor,     //隕石
        Death,      //死
    }

    public enum Qilin_PillarType
    {

        None = 0,    //非アクティブ
        Generate = 1,    //生成
        Up = 2,    //上昇
        Move = 3,    //移動
        Keep = 4,    //停滞
        Death = 5,    //消滅
    }

    public enum Qilin_MeteorType
    {
        None = 0,    //非アクティブ
        Generate = 1,    //生成
        Fall = 2,    //落下
        Impact = 3,    //爆発
        Death = 4,    //消滅
    }
}