using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A154SpawnerScript : MonoBehaviour
{
    public GameObject EntityPrefab;
    public float SetTimerToSpawn = 6.5f;
    // Make sure you set SetTimerToDestroySpawner 40 to 60
    public float SetTimerToDestroySpawner = 20f;
    public GameObject TrapedEntitySprite;
    public ParticleSystem SpawnedParticles;
    float TimerToSpawn;
    float TimerToDestroySpawner;
    bool hasSpawned;

    private void Awake()
    {
        TimerToSpawn = SetTimerToSpawn;
        TimerToDestroySpawner = SetTimerToDestroySpawner;
    }

    // Update is called once per frame
    void Update()
    {
        TimerToSpawn -= Time.deltaTime;
        TimerToDestroySpawner -= Time.deltaTime;
        if (TimerToSpawn < 0 && !hasSpawned)
        {
            hasSpawned = true;
            Instantiate(EntityPrefab, transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
            TrapedEntitySprite.SetActive(false);
            if (SpawnedParticles != null)
            {
                SpawnedParticles.Play();
            }
        }
        if (TimerToDestroySpawner < 0)
        {
            Destroy(gameObject);
        }
    }
}
