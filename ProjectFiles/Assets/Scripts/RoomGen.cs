using UnityEngine;
using System.Collections.Generic;

public class RoomGen : MonoBehaviour, ISaving
{
    [Header("Rooms Objects")]
    public List<GameObject> OldRooms;
    public List<GameObject> NewRooms;
    public GameObject EndingRoom;

    [Header("Lighting and Skybox")]
    public bool TakeLightingToggle = true;
    public Material skybox;

    [Header("Save Function")]
    public StatsManager statsManager;

    [Header("Entity Stuff")]
    public SpawnEntity[] BasicEntitySpawnScripts;
    public A87SpawnScript[] A87SpawnScripts;
    public A108SpawnScript[] A108SpawnScripts;
    public A154SpawnScript A154SpawnScript;
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
        RoomGenManager.Instance.SunLight.intensity = 1f;
        RoomGenManager.Instance.SkyIntensity = 1f;
        skybox.SetFloat("_Exposure", 1f);

        if (SavingManager.gameData.NewRooms)
        {
            Rooms.AddRange(OldRooms);
            Rooms.AddRange(NewRooms);
        }
        else
        {
            Rooms.AddRange(OldRooms);
        }
    }

    public void RoomGenerate()
    {
        // A Section Room Gen
        if (RoomGenManager.Instance.Section == "A" && !TriggerEndingRoom)
        {
            RoomGenManager.Instance.CurrentGeneratedRoom = Instantiate(Rooms[Random.Range(0, Rooms.Count)], RoomGenManager.Instance.EndOfRoomPoint.position, Quaternion.identity);
        }

        // Start of B Section Room
        if (TriggerEndingRoom && RoomGenManager.Instance.Section == "A")
        {
            RoomGenManager.Instance.CurrentGeneratedRoom = Instantiate(EndingRoom, RoomGenManager.Instance.EndOfRoomPoint.position, Quaternion.identity);
        }

        // Makes TriggerEndingRoom = True when reached room 400
        if (RoomGenManager.Instance.DoorNumber == 399)
        {
            if (!StuffManager.Instance.IsCheating && !SavingManager.gameData.HasBeatASection)
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
        if (RoomGenManager.Instance.DoorNumber > 48 && TakeLightingToggle)
        {
            RenderSettings.ambientIntensity -= 0.05f;
            RoomGenManager.Instance.SunLight.intensity -= 0.05f;
            RoomGenManager.Instance.SkyIntensity = RenderSettings.ambientIntensity;
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
        RoomGenManager.Instance.DoorNumber++;

        // Updates Destroy Point Transfrom
        RoomGenManager.Instance.DestroyPoint.position = RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<EndOfRoom>().transform.position + new Vector3(0f, 1.25f, 0f);

        // Updates End Of Room Transfrom
        RoomGenManager.Instance.EndOfRoomPoint = RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<EndOfRoom>().transform;

        // Detect if A154SpawnPoint exist then updates A154SpawnTransform
        if (RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<A154SpawnPoint>() != null)
        {
            RoomGenManager.Instance.A154SpawnTransform = RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<A154SpawnPoint>().transform;
        }
        else
        {
            RoomGenManager.Instance.A154SpawnTransform = null;
        }

        // Updates DoorTitle in the current room if there is one
        if (RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<DoorTitle>() != null)
        {
            RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<DoorTitle>().UpdateDoorTitle();
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
        if(!UsingCheckPoint && !TriggerEndingRoom && !RoomGenManager.Instance.DisableEntitySpawning)
        {
            foreach (var entitySpawnScirpts in this.BasicEntitySpawnScripts)
            {
                entitySpawnScirpts.Spawn();
            }
            foreach (var a87SpawnScripts in this.A87SpawnScripts)
            {
                a87SpawnScripts.Spawn();
            }
            foreach (var a108SpawnScripts in this.A108SpawnScripts)
            {
                a108SpawnScripts.Spawn();
            }
            this.A154SpawnScript.Spawn();
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
        if (RoomGenManager.Instance.Section == "A" && !StuffManager.Instance.IsCheating)
        {
            if (RoomGenManager.Instance.DoorNumber == 50 && !SavingManager.gameData.Reach_A50)
            {
                SavingManager.gameData.Reach_A50 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-50 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenManager.Instance.DoorNumber == 100 && !SavingManager.gameData.Reach_A100)
            {
                SavingManager.gameData.Reach_A100 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-100 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenManager.Instance.DoorNumber == 150 && !SavingManager.gameData.Reach_A150)
            {
                SavingManager.gameData.Reach_A150 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-150 Checkpoint Unlocked.", 5f);

            }
            if (RoomGenManager.Instance.DoorNumber == 200 && !SavingManager.gameData.Reach_A200)
            {
                SavingManager.gameData.Reach_A200 = true;
                Save();
                StuffManager.Instance.subtitleManager.MakeMessage("A-200 Checkpoint Unlocked.", 5f);
            }
            if (RoomGenManager.Instance.DoorNumber == 300 && !SavingManager.gameData.Reach_A300)
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
