using UnityEngine;

namespace SY
{
    [CreateAssetMenu(fileName = "DamageData", menuName = "ScriptableObjects/DamageData")]
    public class Damage : ScriptableObject
    {
        [SerializeField, Tooltip("色")] Color color = Color.white;
        [SerializeField, Tooltip("点滅回数")] int time = 10;
        [SerializeField, Tooltip("点滅間隔")] float interval = 0.05f;

        public Color Color { get { return color; } }
        public int Time { get { return time; } }
        public float Interval { get { return interval; } }
    }
}