using UnityEngine;

public class MissingNoSpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;

    public int SetNumberToSpawn = 184;
    public int MaxChanceNumber = 256;

    // Makes spawning position away from the door. Also it goes backwards the higher the value and forwards when negative.
    public float distenceFromDoor = 1f;
    public StatsManager statsManager;

    int ChanceToSpawn;

    public void Spawn()
    {
        // This makes a random chance 1 to SetChanceToSpawn Value
        ChanceToSpawn = Random.Range(1, MaxChanceNumber);
        if (ChanceToSpawn == SetNumberToSpawn)
        {
            Instantiate(EntityPrefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -distenceFromDoor), Quaternion.identity);
            if (!StuffManager.Instance.IsCheating)
            {
                statsManager.AddToEntitysEncounterd();
                Save();
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
