using UnityEngine;

public class DebugSpawnA330 : MonoBehaviour
{
    public GameObject EntityPrefab;

    // Makes spawning position away from the door. Also it goes backwards the higher the value and forwards when negative.
    public float distenceFromDoor = 20f;

    public AudioClip FailedToSpawnSound;

    public void Spawn()
    {
        // This makes a random chance 1 to SetChanceToSpawn Value
        if (RoomGenInfo.Instance.DoorNumber >= 30)
        {
            Instantiate(EntityPrefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -distenceFromDoor), Quaternion.identity);
        }
        else
        {
            StuffManager.Instance.fastAudioManager.CreateFastAudio(FailedToSpawnSound, transform.position, 0.4f, 1f, 30f, false);
        }
    }
}
