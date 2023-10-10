using UnityEngine;

//�A�j���[�^�[���A�^�b�`
[RequireComponent(typeof(Animator))]
public class Anim : MonoBehaviour
{
    Animator anim;
    [SerializeField] RuntimeAnimatorController animatorController;

    [Header("�Đ����̃A�j���[�V�������")]
    [SerializeField, ReadOnly] string play;
    [SerializeField, ReadOnly] Products.Type action;
    [SerializeField, ReadOnly] bool isLoop;

    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField] Products[] products;

    float normalizedTime;       //�A�j���[�V�����̍Đ�����(0�`1)

    //�v���p�e�B
    public string Play { get { return play; } }
    public Products.Type Action { get { return action; } }
    public float NormalizedTime { get { return normalizedTime; } }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animatorController;

        //1�ԏ��Idle�A�N�V�����̃A�j���[�V�������Đ�
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

    //�A�j���[�V�����Đ�
    void Playing()
    {
        anim.Play(play);
    }

    //�A�j���[�V�����I����Idle�A�j���[�V�����Đ�
    void Default()
    {
        //�A�j���[�V�������J�ڂ���܂őҋ@
        if (play != anim.GetCurrentAnimatorClipInfo(0)[0].clip.name) { normalizedTime = 0; return; }
        //���A�j���[�V�����A���Đ����ԕۑ�
        normalizedTime =
            anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Base Layer")).normalizedTime;
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name + " : " + play + " : " + normalizedTime);

        //�A�j���[�V�����I���܂őҋ@
        if (normalizedTime <= 1) { return; }
        //�Đ����̃A�j���[�V���������[�v�A�j���[�V�����łȂ��Ƃ�
        if (!isLoop)
        {
            //1�ԏ��Idle�A�N�V�����̃A�j���[�V�������Đ�
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ActionType == Products.Type.Idle)
                { AnimChage(products[i].Name, false); break; }
            }
        }
        //���݂̃A�j���[�V�������Đ�������
        else { Playing(); }
    }

    //�A�j���[�V�����J��(���̃A�j���[�V������,�D��x�ݒ�̗L��)
    public void AnimChage(string nextAnim, bool isPriority)
    {
        int breakFlg = 0;
        int playProductsNo = 0; //�v�f�ۑ�(���݂̃A�j���[�V����)
        int nextProductsNo = 0; //�v�f�ۑ�(���N�G�X�g���̃A�j���[�V����)

        //�������A��v����v�f�𔭌�����ۑ�
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Clips.name == play && breakFlg != 1)
            { playProductsNo = i; breakFlg += 1; }
            if (products[i].Name == nextAnim && breakFlg != 2)
            { nextProductsNo = i; breakFlg += 2; }

            //for�����o��
            if (breakFlg == 3) { break; }
        }

        //�v�f��ۑ��ł��Ă��Ȃ���΃G���[�o��
        switch (breakFlg)
        {
            case 0:
                Debug.LogError("products�̗v�f���擾�ł��Ȃ�");
                break;
            case 1:
                Debug.LogError("nextProducts�̗v�f���擾�ł��Ȃ�");
                break;
            case 2:
                Debug.LogError("playProducts�̗v�f���擾�ł��Ȃ�");
                break;
        }

        if (isPriority &&
            (products[playProductsNo].Priority != null || products[playProductsNo].Priority.Length != 0))
        {
            //���݂̃A�j���[�V�����̗D��x�v�f�𑖍�
            for (int i = 0; i < products[playProductsNo].Priority.Length; i++)
            {
                if (products[playProductsNo].Priority[i] == products[nextProductsNo].ActionType)
                { return; }
            }
        }

        SetPlayAnim(nextProductsNo);
        Playing();
    }

    //�A�j���[�V�����J��
    void SetPlayAnim(int animNo)
    {
        play = products[animNo].Clips.name;
        action = products[animNo].ActionType;
        isLoop = products[animNo].IsLoop;
    }
}