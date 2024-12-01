using UnityEngine;

public class A60Script : MonoBehaviour
{
    public float speed = 30;
    public DelayEntitySounds DelaySounds;

    bool DelayMovement;
    float DelayTimer;

    void Awake()
    {
        DelayMovement = true;
        DelayTimer = 5f;
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
        
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 12.5f)
        {
            speed = 2f;
        }
        transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.DestroyPoint.position, speed * Time.deltaTime);
    }

    void A60Destroy()
    {
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 0.6f)
        {
            Destroy(gameObject);
            RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
        }
    }
}
