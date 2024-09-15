using UnityEngine;

public class DebugSpawnA108 : MonoBehaviour
{
    public GameObject EntityPrefab;

    public Transform SpawnPoint;

    public string AnimatorStatName = "A108_ScreenEffectAnim";

    public void Spawn()
    {
        Instantiate(EntityPrefab, SpawnPoint.position, Quaternion.identity);
        StuffManager.Instance.a108ScreenEffect.Play(AnimatorStatName);
    }
}
