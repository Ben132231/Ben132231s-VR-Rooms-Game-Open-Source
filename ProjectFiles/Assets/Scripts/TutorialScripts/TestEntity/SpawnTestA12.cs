using UnityEngine;

public class SpawnTestA12 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] DoorSound;

    [Header("Test A12")]
    public GameObject TestPrefab;

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
        if (other.CompareTag("PlayerHand"))
        {
            OpenDoor(true);
            Invoke("SpawnTest", 8f);
        }
    }

    public void OpenDoor(bool AnimationToggle)
    {
        if (AnimationToggle)
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

    void SpawnTest()
    {
        Instantiate(TestPrefab, RoomGenManager.Instance.EntitySpawnPoint.position, Quaternion.identity);
    }
}
