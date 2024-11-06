using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] DoorSound;

    public RoomGen roomGen;
    Animator doorAnimator;
    Collider doorCollider;
    MeshRenderer doorMeshRenderer;

    void Awake()
    {
        doorCollider = GetComponent<Collider>();
        doorAnimator = GetComponent<Animator>();
        doorMeshRenderer = GetComponent<MeshRenderer>();
        roomGen = GameObject.FindGameObjectWithTag("RoomGen").GetComponent<RoomGen>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand") && !GorillaLocomotion.Player.Instance.IsDead)
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
        roomGen.RoomGenerate();
        Destroy(gameObject.GetComponent<DoorScript>());
    }
}
