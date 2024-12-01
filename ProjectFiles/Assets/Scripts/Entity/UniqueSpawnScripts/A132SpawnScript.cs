using UnityEngine;

public class A132SpawnScript : MonoBehaviour, ISaving
{
    [SerializeField] int Chances;
    public int SetChance = 32;
    public int MaxRandomNumber = 36;
    public int SetDoor = 132;
    public GameObject EntityPrefab;
    public GameObject HVarEntityPrefab;
    public StatsManager statsManager;

    [Header("H Variant Stuff")]
    public int HVarSetChance = 24;
    public int HVarMaxRandomNumber = 52;

    [Header("Spawning Positions")]
    public float xPositionMin = -5f;
    public float xPositionMax = 5f;
    public float zPositionMin = 11f;
    public float zPositionMax = 6f;
    public float yPositionHeight = 0.75f;

    public void Spawn()
    {
        if (RoomGenInfo.Instance.DoorNumber > SetDoor)
        {
            Chances = Random.Range(1, MaxRandomNumber);
            if (Chances > SetChance)
            {
                int HVarChance = Random.Range(1, HVarMaxRandomNumber);
                if (HVarChance == HVarSetChance)
                {
                    float xPosition = RoomGenInfo.Instance.EndOfRoomPoint.position.x - Random.Range(xPositionMin, xPositionMax);
                    float zPosition = RoomGenInfo.Instance.EndOfRoomPoint.position.z - Random.Range(zPositionMin, zPositionMax);
                    Instantiate(HVarEntityPrefab, new Vector3(xPosition, yPositionHeight, zPosition), Quaternion.identity);
                    if (!StuffManager.Instance.IsCheating)
                    {
                        statsManager.AddToEntitysEncounterd();
                        Save();
                    }
                }
                else
                {
                    float xPosition = RoomGenInfo.Instance.EndOfRoomPoint.position.x - Random.Range(xPositionMin, xPositionMax);
                    float zPosition = RoomGenInfo.Instance.EndOfRoomPoint.position.z - Random.Range(zPositionMin, zPositionMax);
                    Instantiate(EntityPrefab, new Vector3(xPosition, yPositionHeight, zPosition), Quaternion.identity);
                    if (!StuffManager.Instance.IsCheating)
                    {
                        statsManager.AddToEntitysEncounterd();
                        Save();
                    }
                }
            }
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
