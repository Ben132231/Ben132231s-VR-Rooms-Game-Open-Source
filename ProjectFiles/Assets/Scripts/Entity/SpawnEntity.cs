using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public Transform SpawnTransfrom;
    public float TimerMinValue = 120;
    public float TimerMaxValue = 160;
    public int SetDoor = 24;
    public StatsManager statsManager;
    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if(RoomGenInfo.Instance.DoorNumber > SetDoor)
        {
            if(SpawnedEntity == null && ReadyToSpawn)
            {
                SpawnedEntity = Instantiate(EntityPrefab, SpawnTransfrom.position, Quaternion.identity);
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
