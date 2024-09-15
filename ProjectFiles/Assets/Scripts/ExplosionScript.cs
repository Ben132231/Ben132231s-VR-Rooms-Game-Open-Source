using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionScript : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && audioSource != null)
        {
            Destroy(gameObject);
        }
    }
}
