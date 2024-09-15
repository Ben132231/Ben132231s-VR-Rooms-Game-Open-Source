using UnityEngine;

public class A228SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public float DistenceFromDoor = 60f;
    public float TimerMinValue = 120;
    public float TimerMaxValue = 160;
    public int SetDoor = 24;
    public string SetSection = "A";
    public StatsManager statsManager;
    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if (RoomGenManager.Instance.DoorNumber > SetDoor && RoomGenManager.Instance.Section == SetSection)
        {
            if (SpawnedEntity == null && ReadyToSpawn)
            {
                SpawnedEntity = Instantiate(EntityPrefab, new Vector3(RoomGenManager.Instance.DestroyPoint.position.x, RoomGenManager.Instance.DestroyPoint.position.y, RoomGenManager.Instance.DestroyPoint.position.z - DistenceFromDoor), Quaternion.identity);
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

    void Awake()
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
