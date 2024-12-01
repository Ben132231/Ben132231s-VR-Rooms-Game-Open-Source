using UnityEngine;

public class A176SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public Transform SpawnTransfrom;
    public float TimerMinValue = 240;
    public float TimerMaxValue = 384;
    public int SetDoor = 176;
    public StatsManager statsManager;

    [Header("H Variant Stuff")]
    public GameObject HVariantPrefab;
    public int HVarSpawnChance = 24;
    public int MaxRandomNumber = 45;

    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if(RoomGenInfo.Instance.DoorNumber > SetDoor)
        {
            if (SpawnedEntity == null && ReadyToSpawn)
            {
                int RandomNumber = Random.Range(0, MaxRandomNumber);
                if (RandomNumber != HVarSpawnChance)
                {
                    SpawnedEntity = Instantiate(EntityPrefab, SpawnTransfrom.position, Quaternion.identity);
                    ReadyToSpawn = false;
                    if (!StuffManager.Instance.IsCheating)
                    {
                        statsManager.AddToEntitysEncounterd();
                        Save();
                    }
                }
                else
                {
                    SpawnedEntity = Instantiate(HVariantPrefab, SpawnTransfrom.position, Quaternion.identity);
                    ReadyToSpawn = false;
                    if (!StuffManager.Instance.IsCheating)
                    {
                        statsManager.AddToEntitysEncounterd();
                        Save();
                    }
                }
            }
        }
    }

    void Update()
    {
        if(!ReadyToSpawn && SpawnedEntity == null)
        {
            TimerDelay -= Time.deltaTime;
        }
        if(TimerDelay < 0)
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
