using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A60SpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;
    public Transform SpawnTransfrom;
    public float TimerMinValue = 312;
    public float TimerMaxValue = 384;
    public int SetDoor = 60;
    public StatsManager statsManager;
    
    [Header("H Variant")]
    public GameObject HVariantPrefab;
    public int HVarSpawnChance = 28;
    public int MaxRandomNumber = 46;

    float TimerDelay;
    GameObject SpawnedEntity;
    bool ReadyToSpawn;

    public void Spawn()
    {
        if(RoomGenInfo.Instance.DoorNumber > SetDoor)
        {
            if(SpawnedEntity == null && ReadyToSpawn)
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
