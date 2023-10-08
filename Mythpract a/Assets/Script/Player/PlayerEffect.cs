using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class Player
{
    public GameObject EffectHit;
    public GameObject EffectHitC;
    public GameObject EffectJump;
    public GameObject EffectBrink;

    public ParticleSystem EffectGuard;
    public ParticleSystem EffectJustGuard;
    public ParticleSystem EffectDeath;
    public ParticleSystem EffectHeal;

    BoxCollider2D atknormalcol;
    BoxCollider2D atkjumpcol;
    void InitEffect()
    {
        atknormalcol = GameObject.Find("AtkNormalCol").GetComponent<BoxCollider2D>();
        atkjumpcol = GameObject.Find("AtkJumpCol").GetComponent<BoxCollider2D>();

    }
    public void HitEffect(GameObject obj)
    {
        if(obj.name == "AtkNormalCol")
        {
            EffectInstiate(atknormalcol);
        }
        else if(obj.name == "AtkJumpCol")
        {
            EffectInstiate(atkjumpcol);
        }


    }
    void EffectInstiate(BoxCollider2D atkcol)
    {
        Instantiate(EffectHit, new Vector3(atkcol.transform.position.x + (atkcol.offset.x + atkcol.size.x / 2) * dir.x,
            atkcol.transform.position.y + atkcol.offset.y, 0), Quaternion.identity);
        Instantiate(EffectHitC, new Vector3(atkcol.transform.position.x + (atkcol.offset.x + atkcol.size.x / 2) * dir.x,
            atkcol.transform.position.y + atkcol.offset.y, 0), Quaternion.identity);

    }

    public void JumpEffect()
    {
        Instantiate(EffectJump, new Vector3(transform.position.x, transform.position.y - col.size.y / 2, 0), Quaternion.identity);

    }


    public void BrinkEffect()
    {
        Instantiate(EffectBrink, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}
