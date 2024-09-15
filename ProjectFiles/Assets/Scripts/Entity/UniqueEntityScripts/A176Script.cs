using UnityEngine;

public class A176Script : MonoBehaviour
{
    public float speed = 20;
    public AudioClip ReboundSound;
    public float MaxReboundAmount = 5.5f;
    public float SpeedMultiplyAmount = 1.45f;

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
            transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
        }
    }

    void ReboundDestroy()
    {
        if (!ReboundDirection)
        {
            if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 0.4f)
            {
                ReboundDirection = true;
                ReboundAmount += 0.5f;
                speed *= SpeedMultiplyAmount;
                StuffManager.Instance.a176ScreenEffect.Play("A176_ScreenEffectAnim");
                StuffManager.Instance.fastAudioManager.CreateFastAudio(ReboundSound, transform.position, 0.4f, 1f, 999999f, false);
                if (ReboundAmount >= MaxReboundAmount)
                {
                    Destroy(gameObject);
                    RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, RoomGenManager.Instance.EntitySpawnPoint.position) < 1)
            {
                ReboundDirection = false;
                ReboundAmount += 0.5f;
                speed *= SpeedMultiplyAmount;
                StuffManager.Instance.a176ScreenEffect.Play("A176_ScreenEffectAnim");
                StuffManager.Instance.fastAudioManager.CreateFastAudio(ReboundSound, transform.position, 0.4f, 1f, 999999f, false);
                if (ReboundAmount >= MaxReboundAmount)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
