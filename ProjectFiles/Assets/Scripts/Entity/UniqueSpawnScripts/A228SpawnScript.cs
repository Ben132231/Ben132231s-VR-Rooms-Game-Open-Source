using UnityEngine;

public class A228SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public float DistenceFromDoor = 60f;
    public float TimerMinValue = 168;
    public float TimerMaxValue = 252;
    public int SetDoor = 228;
    public StatsManager statsManager;
    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if (RoomGenInfo.Instance.DoorNumber > SetDoor)
        {
            if (SpawnedEntity == null && ReadyToSpawn)
            {
                SpawnedEntity = Instantiate(EntityPrefab, new Vector3(RoomGenInfo.Instance.DestroyPoint.position.x, RoomGenInfo.Instance.DestroyPoint.position.y, RoomGenInfo.Instance.DestroyPoint.position.z - DistenceFromDoor), Quaternion.identity);
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
