using UnityEngine;

partial class Player
{
    AudioSource audioSource;
    [SerializeField] AudioClip brinkSE;
    [SerializeField] AudioClip jumpSE;
    [SerializeField] AudioClip landingSE;
    [SerializeField] AudioClip attackSE;
    [SerializeField] AudioClip hitSE;
    [SerializeField] AudioClip guardSE;
    [SerializeField] AudioClip skillSE;

    public void InitAudio()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void BrinkSE()
    {
        audioSource.PlayOneShot(brinkSE);
    }
    public void JumpSE()
    {
        audioSource.PlayOneShot(jumpSE);
    }
    public void LandingSE()
    {
        audioSource.PlayOneShot(landingSE);
    }

    public void AttackSE()
    {
        audioSource.PlayOneShot(attackSE);

    }
    public void HitSE()
    {
        audioSource.PlayOneShot(hitSE);

    }
    public void GuardSE()
    {
        audioSource.PlayOneShot(guardSE);

    }

    public void SkillSE()
    {
        audioSource.PlayOneShot(skillSE);
    }
}
