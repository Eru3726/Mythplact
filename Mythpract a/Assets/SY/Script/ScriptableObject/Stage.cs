using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    [CreateAssetMenu(fileName = "StageData_0x0_20x10", menuName = "ScriptableObjects/StageData")]
    public class Stage : ScreenBase
    {
        [SerializeField, Tooltip("中心座標")] Vector2 center = Vector2.zero;
        [SerializeField, Tooltip("大きさ")] Vector2 range = new Vector2(20, 10);

        public Vector2 Center { get { return center; } }
        public Vector2 Range { get { return range; } }

        public void SetStageData()
        {
            Vector2 leftBottom = new Vector2(center.x - range.x * 2.0f, center.y - range.y * 2.0f);
            Vector2 rightTop = new Vector2(center.x + range.x * 2.0f, center.y + range.y * 2.0f);

            SetData(leftBottom.x, rightTop.x, rightTop.y, leftBottom.y);
        }
    }
}