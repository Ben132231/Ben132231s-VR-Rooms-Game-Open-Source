using UnityEngine;

public class TomScript : MonoBehaviour
{
    public float speed = 3f;

    public float DefaultDespawnTime = 180f;
    float DespawnTimer;

    private void Awake()
    {
        DespawnTimer = DefaultDespawnTime;
    }

    void Update()
    {
        NormalMovement();

        DespawnTimer -= Time.deltaTime;
        if (DespawnTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    void NormalMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position - new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}
