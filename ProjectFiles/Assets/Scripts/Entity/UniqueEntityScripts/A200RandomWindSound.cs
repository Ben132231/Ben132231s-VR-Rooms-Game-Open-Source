using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class A200RandomWindSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public float MinSetTimer = 8f;
    public float MaxSetTimer = 12f;

    float Timer;

    void Awake()
    {
        Timer = Random.Range(MinSetTimer, MaxSetTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            Timer = Random.Range(MinSetTimer, MaxSetTimer);
        }
    }
}
