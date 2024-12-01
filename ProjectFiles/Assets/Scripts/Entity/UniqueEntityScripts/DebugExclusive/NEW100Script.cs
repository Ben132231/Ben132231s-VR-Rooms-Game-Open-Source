using UnityEngine;

public class NEW100Script : MonoBehaviour
{
    public float speed = 0.1f;
    public float DetectDistance = 75f;
    float EntityHeight;

    [Header("Delay Movement")]
    public float DelayTimer = 5f;
    bool DelayMovement;

    void Awake()
    {
        DelayMovement = true;
        EntityHeight = RoomGenInfo.Instance.EntitySpawnPoint.position.y;
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
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < DetectDistance)
        {
            if (Player.Instance.HidingSpot != "" || Player.Instance.IsDead)
            {
                transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.Instance.transform.position.x, EntityHeight, Player.Instance.transform.position.z), speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
        }
    }

    void DestroyTrigger()
    {
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position) < 0.4f)
        {
            Destroy(gameObject);
        }
    }
}
