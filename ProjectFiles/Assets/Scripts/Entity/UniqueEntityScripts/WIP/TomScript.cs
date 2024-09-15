using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomScript : MonoBehaviour
{
    public float speed = 3f;

    public float DefaultDespawnTime = 60f;
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
        transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.EntitySpawnPoint.position - new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}
