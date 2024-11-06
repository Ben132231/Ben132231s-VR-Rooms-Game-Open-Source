using UnityEngine;

public class HidingScript : MonoBehaviour
{
    public HideSpotType hidingSpotType;
    public AudioClip HideSound;
    public AudioClip UnhideSound;

    AudioSource audioSource;
    bool toggle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            audioSource.PlayOneShot(HideSound);
            GorillaLocomotion.Player.Instance.HidingSpot = hidingSpotType.ToString();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            audioSource.PlayOneShot(UnhideSound);
            GorillaLocomotion.Player.Instance.HidingSpot = "";
        }
    }
}

public enum HideSpotType
{
    Table,
    Locker
}
