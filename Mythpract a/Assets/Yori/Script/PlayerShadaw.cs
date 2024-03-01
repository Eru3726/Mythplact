
using UnityEngine;

public class PlayerShadaw : MonoBehaviour
{

    public Animator sourceAnimator; // 同期させるアニメーター
    public Animator targetAnimator; // 同期させたいアニメーター

    [SerializeField, Header("プレイヤー")]
    private GameObject playerObj;

    private float firstPlPos;

    private float difPlPos;
    private Vector3 jumpPos;
    private Vector3 shadowpos;
    // Start is called before the first frame update
    void Start()
    {
        firstPlPos = playerObj.transform.position.y;
        shadowpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorClipInfo[] clipInfo = sourceAnimator.GetCurrentAnimatorClipInfo(0);
        string clipName = clipInfo[0].clip.name;
        // targetAnimatorを同期
        targetAnimator.Play(clipName);
        
        difPlPos = playerObj.transform.position.y - firstPlPos;
        jumpPos.y = shadowpos.y - difPlPos;
        jumpPos.x = playerObj.transform.position.x;
        transform.position = jumpPos;
    }
}
