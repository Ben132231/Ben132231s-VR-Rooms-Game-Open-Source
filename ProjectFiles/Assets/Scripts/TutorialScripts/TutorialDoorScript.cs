using UnityEngine;

public class TutorialDoorScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] DoorSound;

    Animator doorAnimator;
    Collider doorCollider;
    MeshRenderer doorMeshRenderer;

    void Awake()
    {
        doorCollider = GetComponent<Collider>();
        doorAnimator = GetComponent<Animator>();
        doorMeshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            OpenDoor(true);
        }
    }

    public void OpenDoor(bool AnimationToggle)
    {
        if(AnimationToggle)
        {
            doorAnimator.SetTrigger("OpenDoor");
        }
        else
        {
            doorMeshRenderer.enabled = false;
        }
        doorCollider.enabled = false;
        audioSource.PlayOneShot(DoorSound[Random.Range(0, DoorSound.Length)]);
        Destroy(gameObject.GetComponent<TutorialDoorScript>());
    }
}
