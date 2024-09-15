using UnityEngine;

[CreateAssetMenu(menuName = "ChaosEffects/SpawnRandomEntityEffect")]
public class SpawnRandomEntityEffect : ChaosEffect
{
    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.EntitySpawning;
    }

    protected override void OnActivate()
    {
        int EntityIndex = Random.Range(0, ChaosStuffManager.Instance.Entities.Length);
        GameObject EntityPrefab = ChaosStuffManager.Instance.Entities[EntityIndex];
        
        if (EntityPrefab.name.Contains("A132"))
        {
            Instantiate(EntityPrefab, new Vector3(GorillaLocomotion.Player.Instance.transform.position.x, 0.75f, GorillaLocomotion.Player.Instance.transform.position.z + 2f), Quaternion.identity);
        }
        else if (EntityPrefab.name.Contains("A154"))
        {
            Instantiate(EntityPrefab, new Vector3(GorillaLocomotion.Player.Instance.transform.position.x, 0.75f, GorillaLocomotion.Player.Instance.transform.position.z + 2f), Quaternion.identity);
        }
        else if (EntityPrefab.name.Contains("A200"))
        {
            Instantiate(EntityPrefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0 ,0 ,4.5f), Quaternion.identity);
        }
        else if (EntityPrefab.name.Contains("A228"))
        {
            Instantiate(EntityPrefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -55f), Quaternion.identity);
        }
        else
        {
            Instantiate(EntityPrefab, RoomGenManager.Instance.EntitySpawnPoint.position, Quaternion.identity);
        }
    }

    protected override void OnDeactivate()
    {
        
    }
}
