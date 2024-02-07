using System;
using UnityEngine;

namespace SY
{
    public class MoveTable
    {
        [SerializeField] string name = "行動テーブル";

        public string Name { get { return name; } }
    }

    [Serializable]
    public class Shoggoth_MoveTable : MoveTable
    {
        [SerializeField] Shoggoth_MoveType[] move;

        public Shoggoth_MoveType[] Move { get { return move; } }
    }

    [Serializable]
    public class Fafnir_MoveTable : MoveTable
    {
        [SerializeField] Fafnir_MoveType[] move;

        public Fafnir_MoveType[] Move { get { return move; } }
    }

    [Serializable]
    public class Qilin_MoveTable : MoveTable
    {
        [SerializeField] Qilin_MoveType[] move;

        public Qilin_MoveType[] Move { get { return move; } }
    }
}