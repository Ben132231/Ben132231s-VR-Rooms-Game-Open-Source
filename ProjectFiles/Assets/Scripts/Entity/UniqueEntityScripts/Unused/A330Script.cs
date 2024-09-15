using UnityEngine;
using System.Collections;

public class A330Script : MonoBehaviour
{
    public float speed = 4.5f;

    [Header("Delay Movement")]
    public bool DelayMovement;
    public float DelayTimer = 5f;
    public DelayEntitySounds DelaySounds;

    [Header("Animation")]
    public Animator EntityAnimator;
    public string AngryAniamtion;
    public AudioClip AudioSpeaking;

    [Header("Cut Scene Stuff")]
    public Transform InFrontTransform;
    public float SetShiftLightsTimer = 2.2f;

    [Header("Despawn Stuff")]
    public AudioClip DespawnSound;
    public int SetDoorUntilDespawn = 40;
    public Collider DisableKillTrigger;
    public GameObject EntityCanvas;

    [Header("Increase Speed Stuff")]
    // Phase 2
    public float IncreaseSpeed1 = 6.5f;
    public int IncreaseSpeed1SetDoor = 15;
    public float IncreaseAttack1Min = 8.2f;
    public float IncreaseAttack1Max = 12.2f;

    // Phase 3
    public float IncreaseSpeed2 = 8.5f;
    public int IncreaseSpeed2SetDoor = 35;
    public float IncreaseAttack2Min = 6.6f;
    public float IncreaseAttack2Max = 8.6f;

    // Alarm
    public AudioClip IncreaseSpeedAlarm;

    [Header("Audio Stuff")]
    public AudioSource NearAudio;

    [Header("Attack Stuff")]
    public GameObject AttackPrefab;
    public float SetMinAttackTimer = 10f;
    public float SetMaxAttackTimer = 14f;

    int SetDoorThenDestroyEntity;
    int SetDoorToInceaseSpeed1;
    bool HasInceaseSpeed1;
    int SetDoorToInceaseSpeed2;
    bool HasInceaseSpeed2;
    bool FinishRun;
    float AttackTimer;
    GameObject AttackObject;

    void Awake()
    {
        SetDoorThenDestroyEntity = RoomGenManager.Instance.DoorNumber + SetDoorUntilDespawn;
        SetDoorToInceaseSpeed1 = RoomGenManager.Instance.DoorNumber + IncreaseSpeed1SetDoor;
        SetDoorToInceaseSpeed2 = RoomGenManager.Instance.DoorNumber + IncreaseSpeed2SetDoor;
        AttackTimer = Random.Range(SetMinAttackTimer, SetMaxAttackTimer);
    }

    void Update()
    {
        if (!DelayMovement)
        {
            Movement();
            CheckingStatUpdate();
            TriggerEnding();
            IncreaseSpeedByDoorOpenAmount();
            Attacks();
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

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
    }

    void OtherDestroy()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 0.4f)
        {
            Destroy(gameObject);
        }
    }

    void CheckingStatUpdate()
    {
        if (GorillaLocomotion.Player.Instance.HidingSpot == "")
        {
            EntityAnimator.SetBool("IsChecking", false);
        }
        if (GorillaLocomotion.Player.Instance.HidingSpot != "")
        {
            EntityAnimator.SetBool("IsChecking", true);
        }
    }

    void TriggerEnding()
    {
        if (RoomGenManager.Instance.DoorNumber > SetDoorThenDestroyEntity && !FinishRun)
        {
            FinishRun = true;
            if (AttackObject != null)
            {
                Destroy(AttackObject);
            }
            Destroy(gameObject);
        }
    }

    void IncreaseSpeedByDoorOpenAmount()
    {
        // Phase 2
        if (RoomGenManager.Instance.DoorNumber > SetDoorToInceaseSpeed1 && !HasInceaseSpeed1)
        {
            speed = IncreaseSpeed1;
            StuffManager.Instance.fastAudioManager.CreateFastAudio(IncreaseSpeedAlarm, transform.position, 0.4f, 1f, 800f, true);
            HasInceaseSpeed1 = true;
            SetMinAttackTimer = IncreaseAttack1Min;
            SetMaxAttackTimer = IncreaseAttack1Max;
        }
        // Phase 3
        else if (RoomGenManager.Instance.DoorNumber > SetDoorToInceaseSpeed2 && !HasInceaseSpeed2)
        {
            speed = IncreaseSpeed2;
            StuffManager.Instance.fastAudioManager.CreateFastAudio(IncreaseSpeedAlarm, transform.position, 0.4f, 1f, 800f, true);
            HasInceaseSpeed2 = true;
            SetMinAttackTimer = IncreaseAttack2Min;
            SetMaxAttackTimer = IncreaseAttack2Max;
        }
    }

    void Attacks()
    {
        if (!GorillaLocomotion.Player.Instance.IsDead)
        {
            AttackTimer -= Time.deltaTime;
        }
        if (AttackTimer < 0 && !FinishRun && !GorillaLocomotion.Player.Instance.IsDead)
        {
            AttackObject = Instantiate(AttackPrefab, transform.position, Quaternion.identity);
            AttackTimer = Random.Range(SetMinAttackTimer, SetMaxAttackTimer);
        }
    }
}
