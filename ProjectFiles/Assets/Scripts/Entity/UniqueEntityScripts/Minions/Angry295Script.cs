using System.Collections;
using UnityEngine;

public class Angry295Script : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip YellingAudio;

    public int SetAudiosPlayedUntilDespawn = 4;

    public Animator animator;
    public string RageAnimStateName;

    int SnoreAmount;

    void Awake()
    {
        StartCoroutine(AngryAudio());
        rb.AddExplosionForce(2.4f, transform.position, 2.4f);
    }

    IEnumerator AngryAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.8f);
            audioSource.PlayOneShot(YellingAudio);
            yield return new WaitForSeconds(0.89f);
            animator.Play(RageAnimStateName);
            yield return new WaitForSeconds(7.2f);
            SnoreAmount++;
            if (SnoreAmount >= SetAudiosPlayedUntilDespawn)
            {
                Destroy(gameObject);
            }
        }
    }
}
