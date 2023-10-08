using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{
    Animator plAnim;

    bool doublejumpAnim;
    bool hitAnim;
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
        plAnim.SetFloat("Walk", Mathf.Abs(inputDir.x));
        plAnim.SetFloat("VeloV", PlayerRb.velocity.y);

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
