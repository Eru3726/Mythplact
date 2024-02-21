using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    public class SnakeRig : MonoBehaviour
    {
        [SerializeField, Tooltip("親")] GameObject root;
        [SerializeField, Tooltip("子")] GameObject[] body;
        [SerializeField, Tooltip("隙間")] float space = 1.0f;

        Vector2 rootPos;    //親位置
        Vector2[] bodyPos;  //子位置
        Quaternion rot;     //回転値
        Vector3 angle;      //角度(deg)
        Vector3 defScale;   //初期拡大率
        Vector3 scale;      //拡大率(上下反転)

        Vector2 del;    //移動量

        public GameObject Root { get { return root; } }
        public GameObject[] Body { get { return body; } }
        public float Space { get { return space; } }

        // Start is called before the first frame update
        void Start()
        {
            bodyPos = new Vector2[body.Length];     //配列要素数指定
            defScale = root.transform.lossyScale;   //拡大率保存

            //各オブジェクト座標保存
            rootPos = root.transform.position;
            for (int i = 0; i < body.Length; i++)
            {
                bodyPos[i] = body[i].transform.position;
            }
        }

        // Update is called once per frame
        void Update()
        {
            rootPos = root.transform.position;

            for (int i = 0; i < body.Length; i++)
            {
                //初回のみ親の座標を参照
                if (0 <= i - 1) { del = Delta(bodyPos[i], bodyPos[i - 1]); }
                else { del = Delta(bodyPos[i], rootPos); }

                //一定以上の隙間があれば処理
                if (Magnitude(del) <= space) { break; }

                bodyPos[i] += del - (Normalize(del) * space);   //移動
                body[i].transform.position = bodyPos[i];        //移動適用

                Rotate(body[i], del);   //回転
            }
        }

        /// <summary>
        /// 移動方向に回転
        /// </summary>
        /// <param name="obj">適用オブジェクト</param>
        /// <param name="vec">移動方向</param>
        public void Rotate(GameObject obj, Vector2 vec)
        {
            if (vec == Vector2.zero) { return; }    //動いていなければ現状維持

            //回転
            rot = Quaternion.FromToRotation(Vector3.up, vec);   //移動方向の回転値を取得
            angle = rot.eulerAngles;        //クォータニオンをディグリーに変換
            angle.z -= 90;                  //ディグリー値を調整
            rot = Quaternion.Euler(angle);  //ディグリーをクォータニオンに変換

            //上下反転
            scale = defScale;
            //反転判定
            if (Mathf.Abs(angle.z) < 90.0f) { scale.y = defScale.y; }
            else if (90.0f < Mathf.Abs(angle.z)) { scale.y = -defScale.y; }

            //適用
            obj.transform.rotation = rot;       //回転
            obj.transform.localScale = scale;   //上下反転
        }

        //----------ベクトル----------
        /// <summary>
        /// 移動量
        /// </summary>
        /// <param name="root">根本</param>
        /// <param name="tip">先端</param>
        /// <returns></returns>
        Vector2 Delta(Vector2 root, Vector2 tip) { return tip - root; }

        /// <summary>
        /// 2点間の長さ
        /// </summary>
        /// <param name="delta">移動量</param>
        /// <returns></returns>
        float Magnitude(Vector2 delta) { return delta.magnitude; }

        /// <summary>
        /// 正規化
        /// </summary>
        /// <param name="delta">移動量</param>
        /// <returns></returns>
        Vector2 Normalize(Vector2 delta) { return delta.normalized; }
    }
}