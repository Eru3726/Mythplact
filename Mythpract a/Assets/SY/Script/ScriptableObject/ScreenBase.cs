using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    public class ScreenBase : ScriptableObject
    {
        float left, right, top, bottom;

        public float Left { get { return left; } }
        public float Right { get { return right; } }
        public float Top { get { return top; } }
        public float Bottom { get { return bottom; } }

        public void SetData(float left, float right, float top, float bottom)
        {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }
    }
}