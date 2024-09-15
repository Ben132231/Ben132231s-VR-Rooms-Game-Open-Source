using UnityEngine;

public class A154SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public int SetDoor = 154;
    public string SetSection = "A";
    public StatsManager statsManager;

    [Header("Timer Stuff")]
    public float TimerMinValue = 120;
    public float TimerMaxValue = 160;

    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if (RoomGenManager.Instance.DoorNumber > SetDoor && RoomGenManager.Instance.Section == SetSection && RoomGenManager.Instance.A154SpawnTransform != null)
        {
            if (SpawnedEntity == null && ReadyToSpawn)
            {
                SpawnedEntity = Instantiate(EntityPrefab, RoomGenManager.Instance.A154SpawnTransform.position, RoomGenManager.Instance.A154SpawnTransform.rotation);
                ReadyToSpawn = false;
                if (!StuffManager.Instance.IsCheating)
                {
                    statsManager.AddToEntitysEncounterd();
                    Save();
                }
            }
        }
    }

    void Update()
    {
        if (!ReadyToSpawn && SpawnedEntity == null)
        {
            TimerDelay -= Time.deltaTime;
        }
        if (TimerDelay < 0)
        {
            ReadyToSpawn = true;
            TimerDelay = Random.Range(TimerMinValue, TimerMaxValue);
        }
    }

    void Start()
    {
        ReadyToSpawn = true;
        TimerDelay = Random.Range(TimerMinValue, TimerMaxValue);
    }

    public void Load()
    {

    }

    public void Save()
    {
        SavingManager.Save();
    }

    public void FinishSave()
    {

    }
}
