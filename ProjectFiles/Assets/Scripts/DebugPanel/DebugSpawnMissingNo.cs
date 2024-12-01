using UnityEngine;

public class DebugSpawnMissingNo : MonoBehaviour
{
    public GameObject EntityPrefab;
    public float distenceFromDoor = 1;

    public void Spawn()
    {
        Instantiate(EntityPrefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -distenceFromDoor), Quaternion.identity);
    }
}
