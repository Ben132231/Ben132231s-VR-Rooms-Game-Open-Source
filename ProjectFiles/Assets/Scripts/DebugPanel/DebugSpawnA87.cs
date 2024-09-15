using UnityEngine;

public class DebugSpawnA87 : MonoBehaviour
{
    public GameObject EntityPrefab;
    public float EntityHeight = 1.25f;

    public Transform SpawnPoint;

    public void Spawn()
    {
        Instantiate(EntityPrefab, new Vector3(SpawnPoint.position.x, EntityHeight, SpawnPoint.position.z), Quaternion.identity);
    }
}
