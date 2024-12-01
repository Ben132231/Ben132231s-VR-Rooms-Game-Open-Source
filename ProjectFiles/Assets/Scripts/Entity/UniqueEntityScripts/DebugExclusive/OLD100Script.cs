using UnityEngine;

public class OLD100Script : MonoBehaviour
{
    public float speed = 0f;

    [Header("Delay Movement")]
    public float DelayTimer = 3f;
    bool DelayMovement;

    void Awake()
    {
        DelayMovement = true;
    }

    void Update()
    {
        if (!DelayMovement)
        {
            Movement();
            DestroyTrigger();
        }
        else
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer < 0)
            {
                DelayMovement = false;
            }
        }
    }

    void Movement()
    {
        speed += 0.05f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
    }

    void DestroyTrigger()
    {
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position) < 0.4f)
        {
            Destroy(gameObject);
        }
    }
}
