using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SY
{
    public class CameraData : MonoBehaviour
    {
        //----------変数----------
        [SerializeField] Camera mainCamera;
        Vector2 leftBottom;
        Vector2 leftTop;
        Vector2 rightBottom;
        Vector2 rightTop;
        Vector2 center;
        float screenWidth;
        float screenHeight;

        float halfScreenWidth;
        float quarterScreenWidth;
        float halfScreenHeight;
        float quarterScreenHeight;

        //----------プロパティ----------
        public Camera MainCamera { get { return mainCamera; } }
        public Vector2 LeftBottom { get { return leftBottom; } }
        public Vector2 LeftTop { get { return leftTop; } }
        public Vector2 RightBottom { get { return rightBottom; } }
        public Vector2 RightTop { get { return rightTop; } }
        public Vector2 Center { get { return center; } }
        public float ScreenWidth { get { return screenWidth; } }
        public float ScreenHeight { get { return screenHeight; } }

        public float HalfScreenWidth { get { return halfScreenWidth; } }
        public float QuarterScreenWidth { get { return quarterScreenWidth; } }
        public float HalfScreenHeight { get { return halfScreenHeight; } }
        public float QuarterScreenHeight { get { return quarterScreenHeight; } }

        void Awake()
        {
            SetCameraData();
        }

        //----------サービス----------
        //使用カメラ切り替え
        public void SetMainCamera(Camera setCamera)
        {
            mainCamera = setCamera;
            SetCameraData();
        }

        //各画面データ
        public void SetCameraData()
        {
            leftBottom = mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
            leftTop = mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
            rightBottom = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0));
            rightTop = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            screenWidth = rightBottom.x - leftBottom.x;
            screenHeight = leftTop.y - leftBottom.y;
            center = new Vector2(leftBottom.x + (screenWidth / 2), leftBottom.y + (screenHeight / 2));

            halfScreenWidth = screenWidth / 2;
            halfScreenHeight = screenHeight / 2;
            quarterScreenWidth = screenWidth / 4;
            quarterScreenHeight = screenHeight / 4;
        }
    }
}