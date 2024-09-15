using UnityEngine;

public class DeadHenryScript : MonoBehaviour
{
    public float SetDespawnTimer = 15f;
    float DespawnTimer;

    void Awake()
    {
        DespawnTimer = SetDespawnTimer;
    }

    void Update()
    {
        DespawnTimer -= Time.deltaTime;

        if (DespawnTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
