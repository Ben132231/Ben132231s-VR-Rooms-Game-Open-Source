using UnityEngine;

public class A200SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public float TimerMinValue = 258;
    public float TimerMaxValue = 308;
    public int SetDoor = 200;
    public float DistenceFromDoor = 6f;
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
                SpawnedEntity = Instantiate(EntityPrefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, DistenceFromDoor), Quaternion.identity);
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
