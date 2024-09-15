using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HenryScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3f;
    public float gravity = 8f;

    [Header("Random Movement")]
    public float MinX = -1f;
    public float MaxX = 1f;
    public float MinZ = -1f;
    public float MaxZ = 1f;
    public float Height = 0.215f;
    public float newPositionWaitTime = 2f;

    Rigidbody rb;
    float moveX;
    float moveZ;
    float newX;
    float newZ;
    float targetDis;
    bool waitingForNewPosition;
    bool selectNewRandomPosition;
    Vector3 target;
    Vector3 offset;

    [Header("Despawn Stuff")]
    public float SetDespawnTimer = 15f;
    float DespawnTimer;

    void Awake()
    {
        DespawnTimer = SetDespawnTimer;
        selectNewRandomPosition = true;
        waitingForNewPosition = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DespawnTimer -= Time.deltaTime;
        if (DespawnTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        if (selectNewRandomPosition)
        {
            StartCoroutine(newRandomPosition());
        }
        else if (!waitingForNewPosition)
        {
            targetDis = Vector3.Distance(transform.position, offset);
            if (targetDis < 0.3)
            {
                waitingForNewPosition = true;
                selectNewRandomPosition = true;
            }
            rb.MovePosition(transform.position + target * speed * Time.deltaTime);
        }
    }

    IEnumerator newRandomPosition()
    {
        waitingForNewPosition = true;
        selectNewRandomPosition = false;
        yield return new WaitForSeconds(newPositionWaitTime);
        moveX = Random.Range(MinX, MaxX);
        moveZ = Random.Range(MinZ, MaxZ);
        newX = transform.position.x + moveX;
        newZ = transform.position.z + moveZ;
        target = new Vector3(moveX, Height, moveZ);
        offset = new Vector3(newX, Height, newZ);
        waitingForNewPosition = false;
    }
}
