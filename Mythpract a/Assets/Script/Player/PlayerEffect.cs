using UnityEngine;

partial class Player
{
    public GameObject EffectHit;
    public GameObject EffectHitC;
    public GameObject EffectJump;
    public GameObject EffectBrink;

    public ParticleSystem EffectGuard;
    public ParticleSystem EffectGuardBreak;
    public ParticleSystem EffectJustGuard;
    public ParticleSystem EffectDeath;
    public ParticleSystem EffectHeal;

    public ParticleSystem EffectSkillLoneWarrior;
    public ParticleSystem EffectSkillFleet;
    public ParticleSystem EffectCharge;
    public ParticleSystem EffectChargeAttack;

    BoxCollider2D atknormalcol;
    BoxCollider2D atkjumpcol;
    BoxCollider2D atkjumpupcol;
    BoxCollider2D atkjumpdowncol;
    BoxCollider2D atkskillfleetcol;
    BoxCollider2D atkchargecol;

    void InitEffect()
    {
        atknormalcol = GameObject.Find("AtkNormalCol").GetComponent<BoxCollider2D>();
        atkjumpcol = GameObject.Find("AtkJumpCol").GetComponent<BoxCollider2D>();
        atkjumpupcol = GameObject.Find("AtkJumpUpCol").GetComponent<BoxCollider2D>();
        atkjumpdowncol = GameObject.Find("AtkJumpDownCol").GetComponent<BoxCollider2D>();
        atkskillfleetcol = GameObject.Find("AtkSkillFleetCol").GetComponent<BoxCollider2D>();
        atkchargecol = GameObject.Find("AtkSkillHeepCol").GetComponent<BoxCollider2D>();



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
        else if(obj.name == "AtkJumpUpCol")
        {
            EffectInstiate(atkjumpupcol);

        }
        else if(obj.name == "AtkJumpDownCol")
        {
            EffectInstiate(atkjumpdowncol);
        }
        else if(obj.name == "AtkSkillFleetCol")
        {
            EffectInstiate(atkskillfleetcol);
        }
        else if(obj.name == "AtkSKillHeepCol")
        {
            EffectInstiate(atkchargecol);

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
