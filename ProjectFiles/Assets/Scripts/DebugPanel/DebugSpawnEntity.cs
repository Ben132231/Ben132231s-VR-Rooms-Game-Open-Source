using UnityEngine;

public class DebugSpawnEntity : MonoBehaviour
{
    public GameObject EntityPrefab;

    public Transform SpawnPoint;

    public void Spawn()
    {
        Instantiate(EntityPrefab, SpawnPoint.position, Quaternion.identity);
    }
}
