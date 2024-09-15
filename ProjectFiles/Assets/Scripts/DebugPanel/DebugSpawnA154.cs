using UnityEngine;

public class DebugSpawnA154 : MonoBehaviour
{
    public GameObject EntityPrefab;
    public AudioClip FailedToSpawn;
    GameObject SpawnedEntity;

    public void Spawn()
    {
        if (SpawnedEntity == null && RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<A154SpawnPoint>() != null)
        {
            SpawnedEntity = Instantiate(EntityPrefab, RoomGenManager.Instance.A154SpawnTransform.position, RoomGenManager.Instance.A154SpawnTransform.rotation);
        }
        else
        {
            StuffManager.Instance.fastAudioManager.CreateFastAudio(FailedToSpawn, transform.position, 0.4f, 1f, 30f, false);
        }
    }
}
