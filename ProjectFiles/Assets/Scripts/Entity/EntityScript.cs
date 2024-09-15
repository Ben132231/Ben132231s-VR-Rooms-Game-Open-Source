using UnityEngine;
using System.Collections;


public class EntityScript : MonoBehaviour
{
    [HelpBox("Note: CanRebound and CanCheckLocker only one can be set to true." + "\n" + "\n" + "If both set to true it's will just do normal move ment" + "\n" + "\n" + "Note 2: ReboundIncreaseSpeed speed will be times by SpeedTimesAmount", HelpBoxMessageType.None)]

    public float speed = 10;

    [Header("Rebound Stuff")]
    public bool CanRebound = false;
    public float ReboundMaxAmount = 0.5f;
    public bool ReboundsIncreaseSpeed;
    public float SpeedMultiplyAmount = 2f;

    [Header("Rebound Random Amount")]
    public bool DoRandomReboundAmount;
    public float[] RandomReboundAmount = new float[]
    {
        4f,
        4.5f,
        5f,
        5.5f,
        6,
        6.5f,
    };

    // Note : CanBreakDoor will not work with CanRebound if entity gets destroy at EntitySpawnPoint
    // Make sure that ReboundMaxAmount is set to 1.5f, 2.5f, etc.
    [Header("Door Breaking Stuff")]
    public bool CanBreakDoor = false;


    [Header("Locker Checking Stuff")]
    public bool CanCheckLockers = false;

    [Tooltip("The delay of checking")]
    public float DelayCheck = 5f;

    [Tooltip("Stuff for LockerCheckDeath script")]
    public LockerCheckDeath checkDeath;

    [Tooltip("Locker Sound")]
    public AudioClip lockerSound;

    [Header("Delay Movement")]
    public bool DelayMovement;
    public float DelayTimer = 5f;
    public DelayEntitySounds DelaySounds;

    // Locker Checking Privite Variables
    GameObject Room_Target;
    Transform Locker_Target;
    CheckingPos checkingPos;
    bool isChecking;
    bool isCheckingTriggerd;

    // Rebound Privite Variables
    float ReboundAmount;
    bool ReboundDirection;
    // false = To Current Room, true = To Entity Spawn

    void Awake()
    {
        isChecking = false;
        if (DoRandomReboundAmount)
        {
            ReboundMaxAmount = RandomReboundAmount[Random.Range(0, RandomReboundAmount.Length)];
        }
    }

    void Update()
    {
        if (!DelayMovement)
        {
            if (CanRebound && !CanCheckLockers)
            {
                ReboundMovement();
                ReboundDestroy();
            }
            else if (CanCheckLockers && !CanRebound)
            {
                CheckLockerMovement();
                NormalDestroy();
            }
            else
            {
                NormalMovement();
                NormalDestroy();
            }
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

    void NormalMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
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

    void NormalDestroy()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 0.4f)
        {
            Destroy(gameObject);
            if (CanBreakDoor)
            {
                RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
            }
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
                if (ReboundsIncreaseSpeed)
                {
                    speed *= SpeedMultiplyAmount;
                }
                if (ReboundAmount >= ReboundMaxAmount)
                {
                    Destroy(gameObject);
                    if (CanBreakDoor)
                    {
                        RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
                    }
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, RoomGenManager.Instance.EntitySpawnPoint.position) < 1)
            {
                ReboundDirection = false;
                ReboundAmount += 0.5f;
                if (ReboundsIncreaseSpeed)
                {
                    speed *= SpeedMultiplyAmount;
                }
                if (ReboundAmount >= ReboundMaxAmount)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void CheckLockerMovement()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 6 && !isChecking)
        {
            if (Room_Target == null)
            {
                Room_Target = RoomGenManager.Instance.CurrentGeneratedRoom;
                isChecking = true;
            }
        }
        if (Room_Target != null && isChecking && !isCheckingTriggerd)
        {
            isCheckingTriggerd = true;
            StartCoroutine(CheckLocker());
        }
        if (!isChecking && !isCheckingTriggerd)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
        if (isChecking && Locker_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Locker_Target.position, speed * Time.deltaTime);
        }
    }

    IEnumerator CheckLocker()
    {
        foreach (var lockers in Room_Target.GetComponentsInChildren<HidingScript>())
        {
            if (lockers.name.Contains("Locker"))
            {
                if (lockers.hidingSpotType == HideSpotType.Locker)
                {
                    Locker_Target = lockers.GetComponentInChildren<CheckingPos>().transform;
                    checkingPos = lockers.GetComponentInChildren<CheckingPos>();
                }
                yield return new WaitForSeconds(3f);
                if (Vector3.Distance(transform.position, checkingPos.transform.position) < 0.2f && checkingPos != null)
                {
                    if (checkDeath != null && lockers.GetComponentInChildren<LockerDoorObject>() != null)
                    {
                        StuffManager.Instance.fastAudioManager.CreateFastAudio(lockerSound, transform.position, 0.4f, Random.Range(0.95f, 1.15f), 40f, false);
                        lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<Animator>().Play("LockerOpen");
                        yield return new WaitForSeconds(0.5f);
                        checkDeath.toggleTrigger = true;
                        yield return new WaitForSeconds(0.3f);
                        lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<Animator>().Play("LockerClose");
                        checkDeath.toggleTrigger = false;
                    }
                    else
                    {
                        Debug.LogError("You didn't add CheckLockerDeath script to checkDeath.");
                    }
                }
                yield return new WaitForSeconds(1.8f);
            }
            else
            {
                Locker_Target = RoomGenManager.Instance.DestroyPoint;
            }
        }
        Locker_Target = RoomGenManager.Instance.DestroyPoint;
    }
}
