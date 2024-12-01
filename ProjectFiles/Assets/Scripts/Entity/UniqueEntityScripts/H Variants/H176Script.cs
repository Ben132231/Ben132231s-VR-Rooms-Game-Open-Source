using UnityEngine;

public class H176Script : MonoBehaviour
{
    public float speed = 40;
    public AudioClip ReboundSound;
    public float MaxReboundAmount = 4.5f;
    public float SpeedMultiplyAmount = 1.82f;

    [Header("Delay Movement")]
    public bool DelayMovement = true;
    public float DelayTimer = 5f;
    public DelayEntitySounds DelaySounds;

    float ReboundAmount;
    bool ReboundDirection;

    void Update()
    {
        if (!DelayMovement)
        {
            ReboundMovement();
            ReboundDestroy();
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

    void ReboundMovement()
    {
        if (!ReboundDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
        }
    }

    void ReboundDestroy()
    {
        if (!ReboundDirection)
        {
            if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 0.4f)
            {
                ReboundDirection = true;
                ReboundAmount += 0.5f;
                speed *= SpeedMultiplyAmount;
                StuffManager.Instance.h176ScreenEffect.Play("H176_ScreenEffectAnim");
                StuffManager.Instance.fastAudioManager.CreateFastAudio(ReboundSound, transform.position, 0.4f, 1.2f, 999999f, false);
                if (ReboundAmount >= MaxReboundAmount)
                {
                    Destroy(gameObject);
                    RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position) < 1)
            {
                ReboundDirection = false;
                ReboundAmount += 0.5f;
                speed *= SpeedMultiplyAmount;
                StuffManager.Instance.h176ScreenEffect.Play("H176_ScreenEffectAnim");
                StuffManager.Instance.fastAudioManager.CreateFastAudio(ReboundSound, transform.position, 0.4f, 1.2f, 999999f, false);
                if (ReboundAmount >= MaxReboundAmount)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
