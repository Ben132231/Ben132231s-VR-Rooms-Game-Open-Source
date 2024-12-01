using UnityEngine;

public class TomSpawnScript : MonoBehaviour, ISaving
{
    public GameObject EntityPrefab;

    public int SetNumberToSpawn = 1793;
    public int MaxChanceNumber = 5000;

    public StatsManager statsManager;

    int ChanceToSpawn;

    public void Spawn()
    {
        ChanceToSpawn = Random.Range(1, MaxChanceNumber);
        if (ChanceToSpawn == SetNumberToSpawn)
        {
            Instantiate(EntityPrefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, -1, 10), Quaternion.identity);
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
