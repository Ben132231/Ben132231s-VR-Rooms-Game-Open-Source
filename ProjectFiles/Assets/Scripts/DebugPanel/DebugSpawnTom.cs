using UnityEngine;

public class DebugSpawnTom : MonoBehaviour
{
    public GameObject EntityPrefab;

    public void Spawn()
    {
        Instantiate(EntityPrefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, -1, 10), Quaternion.identity);
    }
}
