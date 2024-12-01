using UnityEngine;
using System.Collections.Generic;

public class RoomGen : MonoBehaviour, ISaving
{
    [Header("Rooms To Generate")]
    public List<GameObject> OldRooms;
    public List<GameObject> ExpRooms;
    public GameObject EndingRoom;

    [Header("Room To Parent Transform")]
    public Transform RoomParentTransform;

    [Header("Lighting and Skybox")]
    public bool TakeLightingToggle = true;
    public Material skybox;

    [Header("Save Function")]
    public StatsManager statsManager;

    [Header("Entity Stuff")]
    public SpawnEntity[] BasicEntitySpawnScripts;
    public A60SpawnScript A60SpawnScript;
    public A87SpawnScript[] A87SpawnScripts;
    public A108SpawnScript[] A108SpawnScripts;
    public A132SpawnScript A132SpawnScript;
    public A154SpawnScript A154SpawnScript;
    public A176SpawnScript A176SpawnScript;
    public A228SpawnScript[] A228SpawnScripts;
    public A200SpawnScript[] A200SpawnScripts;
    public MissingNoSpawnScript[] MissingNoSpawnScripts;
    public TomSpawnScript TomSpawnScript;

    [Header("CheckPoint System")]
    public bool UsingCheckPoint;

    bool TriggerEndingRoom;
    GameObject[] Entitys;
    [SerializeField] List<GameObject> Rooms;

    void Start()
    {
        RenderSettings.ambientIntensity = 1f;
        RoomGenInfo.Instance.SunLight.intensity = 1f;
        RoomGenInfo.Instance.SkyIntensity = 1f;
        skybox.SetFloat("_Exposure", 1f);

        if (SavingManager.gameData.ExpRoomsToggle)
        {
            Rooms.AddRange(OldRooms);
            Rooms.AddRange(ExpRooms);
        }
        else
        {
            Rooms.AddRange(OldRooms);
        }
    }

    public void RoomGenerate()
    {
        // Basic Room Gen
        if (!TriggerEndingRoom)
        {
            RoomGenInfo.Instance.CurrentGeneratedRoom = Instantiate(Rooms[Random.Range(0, Rooms.Count)], RoomParentTransform);
            RoomGenInfo.Instance.CurrentGeneratedRoom.transform.position = RoomGenInfo.Instance.EndOfRoomPoint.position;
        }

        // Ending Room Gen
        if (TriggerEndingRoom)
        {
            RoomGenInfo.Instance.CurrentGeneratedRoom = Instantiate(EndingRoom, RoomParentTransform);
            RoomGenInfo.Instance.CurrentGeneratedRoom.transform.position = RoomGenInfo.Instance.EndOfRoomPoint.position;
        }

        // Makes TriggerEndingRoom = True when reached the EndingRoomNumber in RoomGenInfo
        if (RoomGenInfo.Instance.DoorNumber == RoomGenInfo.Instance.EndingRoomNumber)
        {
            if (!StuffManager.Instance.IsCheating && !SavingManager.gameData.HasBeatASection && RoomGenInfo.Instance.Section == "A")
            {
                statsManager.HasBeatASection();
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("B-Section Unlocked.", 5f);
            }
            TriggerEndingRoom = true;
            Entitys = GameObject.FindGameObjectsWithTag("Entity");
            foreach (var entitys in Entitys)
            {
                Destroy(entitys);
            }
        }

        // Slowly make the rooms darker and darker
        if (RoomGenInfo.Instance.DoorNumber > 48 && TakeLightingToggle)
        {
            RenderSettings.ambientIntensity -= 0.05f;
            RoomGenInfo.Instance.SunLight.intensity -= 0.05f;
            RoomGenInfo.Instance.SkyIntensity = RenderSettings.ambientIntensity;
            if (skybox.GetFloat("_Exposure") < 0.03f)
            {
                skybox.SetFloat("_Exposure", 0.03f);
            }
            else
            {
                skybox.SetFloat("_Exposure", skybox.GetFloat("_Exposure") - 0.05f);
            }
        }

        // Increase Door Number
        RoomGenInfo.Instance.DoorNumber++;

        // Updates Destroy Point Transfrom
        RoomGenInfo.Instance.DestroyPoint.position = RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<EndOfRoom>().transform.position + new Vector3(0f, 1.25f, 0f);

        // Updates End Of Room Transfrom
        RoomGenInfo.Instance.EndOfRoomPoint = RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<EndOfRoom>().transform;

        // Detect if A154SpawnPoint exist then updates A154SpawnTransform
        if (RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<A154SpawnPoint>() != null)
        {
            RoomGenInfo.Instance.A154SpawnTransform = RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<A154SpawnPoint>().transform;
        }
        else
        {
            RoomGenInfo.Instance.A154SpawnTransform = null;
        }

        // Updates DoorTitle in the current room if there is one
        if (RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<DoorTitle>() != null)
        {
            RoomGenInfo.Instance.CurrentGeneratedRoom.GetComponentInChildren<DoorTitle>().UpdateDoorTitle();
        }

        if (!UsingCheckPoint && !StuffManager.Instance.IsCheating)
        {
            statsManager.AddToDoorsOpened();
        }
        
        // Spawns Entitys Function
        SpawnEntity();

        // CheckPointSave will save the game once reached certain check point
        CheckPointSave();
    }

    void SpawnEntity()
    {
        if(!UsingCheckPoint && !TriggerEndingRoom && !RoomGenInfo.Instance.DisableEntitySpawning)
        {
            foreach (var entitySpawnScirpts in this.BasicEntitySpawnScripts)
            {
                entitySpawnScirpts.Spawn();
            }
            this.A60SpawnScript.Spawn();
            foreach (var a87SpawnScripts in this.A87SpawnScripts)
            {
                a87SpawnScripts.Spawn();
            }
            foreach (var a108SpawnScripts in this.A108SpawnScripts)
            {
                a108SpawnScripts.Spawn();
            }
            this.A132SpawnScript.Spawn();
            this.A154SpawnScript.Spawn();
            this.A176SpawnScript.Spawn();
            foreach (var a228SpawnScripts in this.A228SpawnScripts)
            {
                a228SpawnScripts.Spawn();
            }
            foreach (var a200SpawnScripts in this.A200SpawnScripts)
            {
                a200SpawnScripts.Spawn();
            }
            foreach (var missingnoSpawnScripts in this.MissingNoSpawnScripts)
            {
                missingnoSpawnScripts.Spawn();
            }
            this.TomSpawnScript.Spawn();
        }
    }

    void CheckPointSave()
    {
        if (RoomGenInfo.Instance.Section == "A" && !StuffManager.Instance.IsCheating)
        {
            if (RoomGenInfo.Instance.DoorNumber == 50 && !SavingManager.gameData.Reach_A50)
            {
                SavingManager.gameData.Reach_A50 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-50 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenInfo.Instance.DoorNumber == 100 && !SavingManager.gameData.Reach_A100)
            {
                SavingManager.gameData.Reach_A100 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-100 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenInfo.Instance.DoorNumber == 150 && !SavingManager.gameData.Reach_A150)
            {
                SavingManager.gameData.Reach_A150 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-150 Checkpoint Unlocked.", 5f);

            }
            if (RoomGenInfo.Instance.DoorNumber == 200 && !SavingManager.gameData.Reach_A200)
            {
                SavingManager.gameData.Reach_A200 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-200 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenInfo.Instance.DoorNumber == 300 && !SavingManager.gameData.Reach_A300)
            {
                SavingManager.gameData.Reach_A300 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-300 Checkpoint Unlocked.", 5f);
            }
        }

        if (TriggerEndingRoom && !StuffManager.Instance.IsCheating)
        {
            SavingManager.gameData.DebugPanel_Enabled = true;
            Save();
            Debug.Log("Player Has Reached Room the end of A-Section and Enabled Debug Menu");
        }
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
