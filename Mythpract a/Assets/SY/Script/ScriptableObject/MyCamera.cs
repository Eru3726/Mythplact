using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "ScriptableObjects/CameraData")]
    public class MyCamera : ScreenBase
    {
        [SerializeField, Tooltip("使用カメラ")] Camera mainCamera;

        public Camera MainCamera { get { return mainCamera; } }

        public void SetCameraData()
        {
            Vector2 leftBottom = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));
            Vector2 rightTop = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            SetData(leftBottom.x, rightTop.x, rightTop.y, leftBottom.y);
        }
    }
}