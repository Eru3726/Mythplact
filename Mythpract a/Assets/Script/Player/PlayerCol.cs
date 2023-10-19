using UnityEngine;

partial class Player
{
    public LayerMask layerMask_Ground;
    public LayerMask layerMask_Hit;

    bool isGround;

    BoxCollider2D col;

    [SerializeField] GameObject AtkNormalCol;


    void InitCol()
    {
        col = GetComponent<BoxCollider2D>();
    }

    Vector3 GetCenterPos()
    {
        Vector3 pos = transform.position;
        // ボックスコライダーのオフセットから中心を計算
        pos.y += col.offset.y;

        return pos;
    }

    Vector3 GetFootPos()
    {
        Vector3 pos = GetCenterPos();
        // ボックスコライダーのサイズから足元を計算
        pos.y += -col.size.y / 2;
        return pos;
    }

    // 地面に設置しているかチェック
    void CheckGround()
    {
        isGround = false;   // 一旦空中判定にしておく

        Vector3 foot = GetFootPos();            // 始点
        Vector3 len = Vector3.up * -0.2f;         // 長さ
        float width = col.size.x / 2;           // 当たり判定の幅

        // 左端、中央、、右端の順にチェックしていく
        foot.x += -width;
        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // 当たり判定の結果用の変数
            // レイを飛ばして、指定したレイヤーにぶつかるかチェック
            resultGround = Physics2D.Linecast(foot, foot + len, layerMask_Ground);

            // デバッグ表示
            Debug.DrawLine(foot, foot + len);

            foot.x += width;                // x座標をずらす
            // コライダーと接触したかチェック
            if (resultGround.collider)
            {
                isGround = true;            // 地面と接触した
                                            //Debug.Log("地面と接触");
                return;                     // 終了
            }

        }

    }

    Vector3 GetRightPos()
    {
        Vector3 pos = GetCenterPos();
        pos.x += col.size.x / 2 + col.offset.x;
        return pos;
    }

    public bool CheckRightHit()
    {
        Vector3 right = GetRightPos();
        Vector3 len = Vector3.right * 0.05f;         // 長さ
        float width = col.size.y / 2;           // 当たり判定の幅

        right.y -= width;

        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // 当たり判定の結果用の変数
            // レイを飛ばして、指定したレイヤーにぶつかるかチェック
            resultGround = Physics2D.Linecast(right, right + len, layerMask_Hit);

            // デバッグ表示
            Debug.DrawLine(right, right + len);

            right.y += width;                // y座標をずらす
            // コライダーと接触したかチェック
            if (resultGround.collider)
            {
                return true;
            }

        }
            return false;
    }
    Vector3 GetLeftPos()
    {
        Vector3 pos = GetCenterPos();
        pos.x += -col.size.x / 2 + col.offset.x;
        return pos;
    }

    public bool CheckLeftHit()
    {
        Vector3 left = GetLeftPos();
        Vector3 len = Vector3.left * 0.05f;         // 長さ
        float width = col.size.y / 2;           // 当たり判定の幅

        left.y -= width;

        for (int no = 0; no < 3; ++no)
        {
            RaycastHit2D resultGround;    // 当たり判定の結果用の変数
            // レイを飛ばして、指定したレイヤーにぶつかるかチェック
            resultGround = Physics2D.Linecast(left, left + len, layerMask_Hit);

            // デバッグ表示
            Debug.DrawLine(left, left + len);

            left.y += width;                // y座標をずらす
            // コライダーと接触したかチェック
            if (resultGround.collider)
            {
                return true;
            }

        }
        return false;
    }


    public void AtkNormalHit()
    {
        Debug.Log("攻撃が接触");
    }

}
