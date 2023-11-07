using UnityEngine;

partial class Player
{
    Animator plAnim;

    bool doublejumpAnim;
    bool hitAnim;
    bool hitJumpDown;
    bool canHitDown;
    bool canHitUp;

    void InitAnim()
    {
        plAnim = GetComponent<Animator>();

        atkJumpDownCount = 0;
    }

    void ChangeAnim()
    {
        plAnim.SetBool("Jump", jumping);
        plAnim.SetBool("DoubleJump", doublejumpAnim);
        plAnim.SetBool("SpaceDown", spaceDown);
        plAnim.SetBool("IsGround", isGround);
        plAnim.SetBool("Attack", attack);
        plAnim.SetBool("NormalAttack", normalAttack);
        plAnim.SetBool("ChargeAttack", chargeAttack);
        plAnim.SetBool("ChargeFlag", GameData.saveSkill19);
        plAnim.SetBool("Guard", isGuard);
        plAnim.SetBool("Hit",hitAnim);
        plAnim.SetBool("HitAtkJumpDown", hitJumpDown);
        plAnim.SetBool("CanHitDown", canHitDown);
        plAnim.SetBool("CanHitUp", canHitUp);
        plAnim.SetBool("IsFleet", isFleet);
        plAnim.SetFloat("Walk", Mathf.Abs(inputDir.x));
        plAnim.SetFloat("VeloV", PlayerRb.velocity.y);
        plAnim.SetFloat("DirY", inputDir.y);

    }
    public void HitJumpDownEnd()    // ジャンプ下攻撃から移行終了
    {
        hitJumpDown = false;
    }
    public void AtkJumpDownEnd()
    {
        atkJumpDownCount = 0;
        canHitDown = false;
    }
    public void AtkJumpUpEnd()
    {
        atkJumpUpCount = 0;
        canHitUp = false;
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
