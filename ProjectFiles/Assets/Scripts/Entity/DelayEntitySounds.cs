using UnityEngine;

public class DelayEntitySounds : MonoBehaviour
{
    public AudioSource[] EntitysSounds;

    public void PlaySounds()
    {
        foreach (var sounds in EntitysSounds)
        {
            sounds.Play();
        }
    }

    public void StopSounds()
    {
        foreach (var sounds in EntitysSounds)
        {
            sounds.Stop();
        }
    }
}
