using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    [System.Serializable]
    public class PredictionSetting
    {
        [SerializeField, Tooltip("大きさ")] Vector3 scale = Vector3.one;
        [SerializeField, Tooltip("色")] Color color = Color.red;

        public Vector3 Scale { get { return scale; } }
        public Color Color { get { return color; } }
    }
}
