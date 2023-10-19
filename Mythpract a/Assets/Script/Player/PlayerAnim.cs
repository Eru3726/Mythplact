using UnityEngine;

partial class Player
{
    Animator plAnim;

    bool doublejumpAnim;
    bool hitAnim;
    bool hitJumpDown;
    void InitAnim()
    {
        plAnim = GetComponent<Animator>();
    }

    void ChangeAnim()
    {
        plAnim.SetBool("Jump", jumping);
        plAnim.SetBool("DoubleJump", doublejumpAnim);
        plAnim.SetBool("SpaceDown", spaceDown);
        plAnim.SetBool("IsGround", isGround);
        plAnim.SetBool("Attack", attack);
        plAnim.SetBool("Guard", isGuard);
        plAnim.SetBool("Hit",hitAnim);
        plAnim.SetBool("HitAtkJumpDown", hitJumpDown);
        plAnim.SetFloat("Walk", Mathf.Abs(inputDir.x));
        plAnim.SetFloat("VeloV", PlayerRb.velocity.y);
        plAnim.SetFloat("DirY", inputDir.y);

    }
    public void HitJumpDownEnd()    // �W�����v���U������ڍs�I��
    {
        hitJumpDown = false;
    }

    void AttackStart()
    {
        isAttack = true;

    }
    void AttackEnd()
    {
        isAttack = false;
    }

}
