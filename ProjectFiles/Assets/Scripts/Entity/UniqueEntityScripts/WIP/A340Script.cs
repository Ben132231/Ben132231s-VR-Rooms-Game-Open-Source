using UnityEngine;
using System.Collections;

public class A340Script : MonoBehaviour
{
    public float defualtSpeed = 200f;
    public int MaxReboundAmount = 4;
    // Todo : make audio stop when the entity is ready to rebound

    float speed;
    bool ReachedCurrentRoom;
    bool ReadyToDestroy;
    bool ReadyToRebound;
    [SerializeField] int ReboundAmount;

    void Start()
    {
        speed = defualtSpeed;
    }

    void Update()
    {
        Movement();
        Detroyer();
    }

    void Movement()
    {
        if (!ReachedCurrentRoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
        if (ReadyToDestroy)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, 10 * Time.deltaTime);
        }
    }

    void Detroyer()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 6 && !ReachedCurrentRoom)
        {
            ReachedCurrentRoom = true;
            StartCoroutine(Desent());
        }
        if (ReboundAmount < MaxReboundAmount)
        {
            if (transform.position.y < -18 && !ReadyToRebound)
            {
                ReadyToRebound = true;
                StartCoroutine(Rebounding());
            }
        }
        if (transform.position.y < -28)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Desent()
    {
        yield return new WaitForSeconds(3f);
        ReadyToDestroy = true;
    }

    IEnumerator Rebounding()
    {
        speed = 0f;
        transform.position = RoomGenManager.Instance.EntitySpawnPoint.position;
        ReadyToDestroy = false;
        ReachedCurrentRoom = false;
        float RandomTimer = Random.Range(14f, 24f);
        yield return new WaitForSeconds(RandomTimer);
        ReboundAmount++;
        ReadyToRebound = false;
        speed = defualtSpeed;
    }
}
