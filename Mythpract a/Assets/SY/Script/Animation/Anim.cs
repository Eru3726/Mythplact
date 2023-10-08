using UnityEngine;

//アニメーターをアタッチ
[RequireComponent(typeof(Animator))]
public class Anim : MonoBehaviour
{
    Animator anim;
    [SerializeField] RuntimeAnimatorController animatorController;

    [Header("再生中のアニメーション情報")]
    [SerializeField, ReadOnly] string play;
    [SerializeField, ReadOnly] Products.Type action;
    [SerializeField, ReadOnly] bool isLoop;

    [Header("アニメーションの設定")]
    [SerializeField] Products[] products;

    float normalizedTime;       //アニメーションの再生時間(0～1)

    //プロパティ
    public string Play { get { return play; } }
    public Products.Type Action { get { return action; } }
    public float NormalizedTime { get { return normalizedTime; } }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animatorController;

        //1番上のIdleアクションのアニメーションを再生
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ActionType == Products.Type.Idle)
            {
                SetPlayAnim(i); break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Default();
    }

    //アニメーション再生
    void Playing()
    {
        anim.Play(play);
    }

    //アニメーション終了でIdleアニメーション再生
    void Default()
    {
        //アニメーションが遷移するまで待機
        if (play != anim.GetCurrentAnimatorClipInfo(0)[0].clip.name) { normalizedTime = 0; return; }
        //同アニメーション連続再生時間保存
        normalizedTime =
            anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Base Layer")).normalizedTime;
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name + " : " + play + " : " + normalizedTime);

        //アニメーション終了まで待機
        if (normalizedTime <= 1) { return; }
        //再生中のアニメーションがループアニメーションでないとき
        if (!isLoop)
        {
            //1番上のIdleアクションのアニメーションを再生
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ActionType == Products.Type.Idle)
                { AnimChage(products[i].Name, false); break; }
            }
        }
        //現在のアニメーションを再生し直す
        else { Playing(); }
    }

    //アニメーション遷移(次のアニメーション名,優先度設定の有無)
    public void AnimChage(string nextAnim, bool isPriority)
    {
        int breakFlg = 0;
        int playProductsNo = 0; //要素保存(現在のアニメーション)
        int nextProductsNo = 0; //要素保存(リクエスト中のアニメーション)

        //走査し、一致する要素を発見次第保存
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Clips.name == play && breakFlg != 1)
            { playProductsNo = i; breakFlg += 1; }
            if (products[i].Name == nextAnim && breakFlg != 2)
            { nextProductsNo = i; breakFlg += 2; }

            //for文を出る
            if (breakFlg == 3) { break; }
        }

        //要素を保存できていなければエラー出力
        switch (breakFlg)
        {
            case 0:
                Debug.LogError("productsの要素を取得できない");
                break;
            case 1:
                Debug.LogError("nextProductsの要素を取得できない");
                break;
            case 2:
                Debug.LogError("playProductsの要素を取得できない");
                break;
        }

        if (isPriority &&
            (products[playProductsNo].Priority != null || products[playProductsNo].Priority.Length != 0))
        {
            //現在のアニメーションの優先度要素を走査
            for (int i = 0; i < products[playProductsNo].Priority.Length; i++)
            {
                if (products[playProductsNo].Priority[i] == products[nextProductsNo].ActionType)
                { return; }
            }
        }

        SetPlayAnim(nextProductsNo);
        Playing();
    }

    //アニメーション遷移
    void SetPlayAnim(int animNo)
    {
        play = products[animNo].Clips.name;
        action = products[animNo].ActionType;
        isLoop = products[animNo].IsLoop;
    }
}