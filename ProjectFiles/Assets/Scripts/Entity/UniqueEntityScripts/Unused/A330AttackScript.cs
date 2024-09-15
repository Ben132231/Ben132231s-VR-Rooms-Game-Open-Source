using System.Collections;
using UnityEngine;

public class A330AttackScript : MonoBehaviour
{
    public Animator animator;
    public string WarningStateName;
    public string AttackStateName;
    public AudioSource WarningAudioSoruce;
    public AudioClip WarningSound;
    public AudioClip AttackImpactSound;
    public Transform HitGroundTransform;

    bool IsFollowing;
    bool AttackHitGround;

    void Awake()
    {
        StartCoroutine(TriggerAttack());
        IsFollowing = true;
    }

    void Update()
    {
        if (IsFollowing)
        {
            transform.position = GorillaLocomotion.Player.Instance.GorillaCamera.transform.position;
        }
        if (HitGroundTransform.position.y < 0 && !AttackHitGround)
        {
            AttackHitGround = true;
            StuffManager.Instance.fastAudioManager.CreateFastAudio(AttackImpactSound, HitGroundTransform.position, 0.4f, 1f, 145f, false);
        }
    }

    IEnumerator TriggerAttack()
    {
        animator.Play(WarningStateName);
        WarningAudioSoruce.PlayOneShot(WarningSound);
        yield return new WaitForSeconds(1.4f);
        IsFollowing = false;
        yield return new WaitForSeconds(0.2f);
        animator.Play(AttackStateName);
        yield return new WaitForSeconds(4.2f);
        Destroy(gameObject);
    }
}
