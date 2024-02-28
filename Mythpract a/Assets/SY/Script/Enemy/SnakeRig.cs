using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SY
{
    public class SnakeRig : MonoBehaviour
    {
        [Header("オブジェクト")]
        [SerializeField, Tooltip("親")] GameObject rootBone;
        [SerializeField, Tooltip("子")] GameObject[] childBone;
        [SerializeField, Tooltip("スプライト")] GameObject[] model;

        [Header("隙間")]
        [SerializeField, Tooltip("親子")] float rootSpace = 1.0f; //ver3.0で追加
        [SerializeField, Tooltip("子")] float BodySpace = 1.0f;

        [Header("描画設定")]
        [SerializeField, Tooltip("子描画順")] Sort modelSpriteOrder = Sort.None;

        enum Sort
        {
            None,
            Zero,
            BodyLength,
            Ascending,
            Descending,
        }

        Vector2 rootPos;        //親位置
        Vector2 beforeRootPos;  //親位置保存
        Vector2[] childPos;     //子位置
        Quaternion rot;         //回転値
        Vector3 angle;          //角度(deg)
        Vector3 defScale;       //初期拡大率
        Vector3 scale;          //拡大率(上下反転)

        Vector2 del;    //移動量

        public GameObject Root { get { return rootBone; } }
        public GameObject[] Body { get { return childBone; } }
        public GameObject[] Model { get { return model; } }

        // Start is called before the first frame update
        void Start()
        {
            childPos = new Vector2[childBone.Length];   //配列要素数定義
            defScale = model[0].transform.lossyScale;   //大きさ保存

            rootPos = rootBone.transform.position;  //親位置保存
            beforeRootPos = rootPos;
            for (int i = 0; i < childBone.Length; i++)
            {
                childPos[i] = childBone[i].transform.position;  //子位置保存
                SpriteOrder(model[i], modelSpriteOrder, i);     //モデル描画順設定
            }
        }

        // Update is called once per frame
        void Update()
        {
            rootPos = rootBone.transform.position;

            del = Delta(childPos[0], rootPos);  //ボーン間距離
            Move(del, rootSpace, 0);            //移動

            for (int i = 1; i < childBone.Length; i++)
            {
                del = Delta(childPos[i], childPos[i - 1]);

                Move(del, BodySpace, i);
            }

            beforeRootPos = rootPos;
        }

        /// <summary>
        /// 移動（ver3.0で追加）
        /// </summary>
        /// <param name="delta">移動量</param>
        /// <param name="space">隙間</param>
        /// <param name="no">配列要素数</param>
        void Move(Vector2 delta, float space, int no)
        {
            if (rootPos == beforeRootPos) { return; }

            //一定以上の隙間があれば処理
            if (space < Magnitude(delta))
            {
                childPos[no] += delta - (Normalize(delta) * (space - 0.01f));  //移動
                childBone[no].transform.position = childPos[no];  //移動適用
            }

            if (no == 0)    //初回のみ親参照
            {
                //2点の中心座標
                model[no].transform.position = new Vector2(
                    (rootPos.x + childPos[no].x) * 0.5f,
                    (rootPos.y + childPos[no].y) * 0.5f);
            }
            else            //初回以外は子同士
            {
                model[no].transform.position = new Vector2(
                    (childPos[no - 1].x + childPos[no].x) * 0.5f,
                    (childPos[no - 1].y + childPos[no].y) * 0.5f);
            }

            Rotate(model[no], del); //回転
        }

        /// <summary>
        /// 移動方向に回転
        /// </summary>
        /// <param name="obj">適用オブジェクト</param>
        /// <param name="vec">移動方向</param>
        public void Rotate(GameObject obj, Vector2 vec)
        {
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

        //----------描画順
        void SpriteOrder(GameObject obj, Sort sort, int value)
        {
            switch (sort)
            {
                case Sort.Zero:
                    obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    break;
                case Sort.BodyLength:
                    obj.GetComponent<SpriteRenderer>().sortingOrder = model.Length;
                    break;
                case Sort.Ascending:
                    obj.GetComponent<SpriteRenderer>().sortingOrder = value;
                    break;
                case Sort.Descending:
                    obj.GetComponent<SpriteRenderer>().sortingOrder = model.Length - 1 - value;
                    break;
            }
        }
    }
}