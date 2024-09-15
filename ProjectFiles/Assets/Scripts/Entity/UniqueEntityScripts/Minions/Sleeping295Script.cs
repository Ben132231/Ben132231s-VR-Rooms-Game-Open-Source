using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping295Script : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip SnoreAudio;
    public AudioClip ExhaleAudio;

    public int SetAudiosPlayedUntilDespawn = 6;

    int SnoreAmount;

    void Awake()
    {
        StartCoroutine(SleepingAudio());
        rb.AddExplosionForce(2.4f, transform.position, 2.4f);
    }

    IEnumerator SleepingAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.8f);
            audioSource.PlayOneShot(SnoreAudio);
            yield return new WaitForSeconds(1.15f);
            audioSource.PlayOneShot(ExhaleAudio);
            yield return new WaitForSeconds(5.2f);
            SnoreAmount++;
            if (SnoreAmount >= SetAudiosPlayedUntilDespawn)
            {
                Destroy(gameObject);
            }
        }
    }
}
