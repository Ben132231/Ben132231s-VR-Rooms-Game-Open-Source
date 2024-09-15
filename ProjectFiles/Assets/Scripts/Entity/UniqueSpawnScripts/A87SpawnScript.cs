using UnityEngine;

public class A87SpawnScript : MonoBehaviour, ISaving
{
    [SerializeField] int Chances;
    public int SetChance = 12;
    public int SetDoor = 87;
    public string SetSection = "A";
    public GameObject EntityPrefab;
    public StatsManager statsManager;

    [Header("Spawning Positions")]
    public float xPositionMin = -5f;
    public float xPositionMax = 5f;
    public float zPositionMin = 11f;
    public float zPositionMax = 6f;
    public float yPositionHeight = 1.25f;

    public void Spawn()
    {
        if (RoomGenManager.Instance.DoorNumber > SetDoor && RoomGenManager.Instance.Section == SetSection)
        {
            int setChance2 = SetChance - 2;
            Chances = Random.Range(1, SetChance);
            if (Chances > setChance2)
            {
                float xPosition = RoomGenManager.Instance.EndOfRoomPoint.position.x - Random.Range(xPositionMin, xPositionMax);
                float zPosition = RoomGenManager.Instance.EndOfRoomPoint.position.z - Random.Range(zPositionMin, zPositionMax);
                Instantiate(EntityPrefab, new Vector3(xPosition, yPositionHeight, zPosition), Quaternion.identity);
                if (!StuffManager.Instance.IsCheating)
                {
                    statsManager.AddToEntitysEncounterd();
                    Save();
                }
            }
        }
    }

    public void ForceSpawn()
    {
        float xPosition = RoomGenManager.Instance.EndOfRoomPoint.position.x - Random.Range(xPositionMin, xPositionMax);
        float zPosition = RoomGenManager.Instance.EndOfRoomPoint.position.z - Random.Range(zPositionMin, zPositionMax);
        Instantiate(EntityPrefab, new Vector3(xPosition, yPositionHeight, zPosition), Quaternion.identity);
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
