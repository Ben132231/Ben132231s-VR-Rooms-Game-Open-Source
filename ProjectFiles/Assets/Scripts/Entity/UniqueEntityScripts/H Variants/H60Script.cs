using UnityEngine;

public class H60Script : MonoBehaviour
{
    public float speed = 65f;
    public DelayEntitySounds DelaySounds;

    bool DelayMovement;
    float DelayTimer;
    int DoorOpenCount;

    void Awake()
    {
        DelayMovement = true;
        DelayTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DelayMovement)
        {
            A60Movement();
            A60Destroy();
        }
        else
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer < 0)
            {
                DelayMovement = false;
                if (DelaySounds != null)
                {
                    DelaySounds.PlaySounds();
                }
            }
        }
    }

    void A60Movement()
    {
        
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 7.5f)
        {
            speed = 25f;
        }
        transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.DestroyPoint.position, speed * Time.deltaTime);
    }

    void A60Destroy()
    {
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 0.6f)
        {
            if (DoorOpenCount >= 2)
            {
                Destroy(gameObject);
            }
            RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
            DoorOpenCount++;
        }
    }
}
