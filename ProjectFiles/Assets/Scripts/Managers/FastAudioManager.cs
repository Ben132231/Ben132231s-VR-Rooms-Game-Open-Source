using UnityEngine;

public class FastAudioManager : MonoBehaviour
{
    public GameObject FastAudioPrefab;
    GameObject FastAudioObject;

    public void CreateFastAudio(AudioClip audioClip, Vector3 position, float volume, float pitch, float audioMaxDistence, bool Is2dAudio)
    {
        FastAudioObject = Instantiate(FastAudioPrefab, position, Quaternion.identity);
        FastAudioObject.GetComponent<AudioSource>().clip = audioClip;
        FastAudioObject.GetComponent<AudioSource>().pitch = pitch;
        FastAudioObject.GetComponent<AudioSource>().volume = volume;
        FastAudioObject.GetComponent<AudioSource>().maxDistance = audioMaxDistence;
        FastAudioObject.GetComponent<AudioSource>().Play();
        if (Is2dAudio)
        {
            FastAudioObject.GetComponent<AudioSource>().spatialBlend = 0.0f;
        }
        else
        {
            FastAudioObject.GetComponent<AudioSource>().spatialBlend = 1.0f;
        }
        FastAudioObject.name = audioClip.name;
    }

    public GameObject GetFastAudioGameObject()
    {
        return FastAudioObject;
    }

    public AudioSource GetFastAudioSource()
    {
        return FastAudioObject.GetComponent<AudioSource>();
    }

    public void DeleteLastFastAudio()
    {
        if (FastAudioObject != null)
        {
            Destroy(FastAudioObject);
        }
    }
}
