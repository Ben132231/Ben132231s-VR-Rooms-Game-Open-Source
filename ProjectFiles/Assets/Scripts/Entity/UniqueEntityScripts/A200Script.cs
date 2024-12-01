using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A200Script : MonoBehaviour
{
    public float speed = 6.5f;
    public float ChasingSpeed = 10f;
    public float[] DespawnTimes = new float[]
    {
        20f,
        22.5f,
        25f
    };
    public AudioClip DespawnSound;

    [Header("Delay Movement")]
    public bool DelayMovement = true;
    public float DelayTimer = 5f;

    float DespawnTimer = 5f;

    void Awake()
    {
        DespawnTimer = DespawnTimes[Random.Range(0, DespawnTimes.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!DelayMovement)
        {
            A200Movement();
            A200Destroy();
        }
        else
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer < 0)
            {
                DelayMovement = false;
            }
        }
    }

    void A200Movement()
    {
        if (Player.Instance.HidingSpot != "" || Player.Instance.IsDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.EntitySpawnPoint.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, ChasingSpeed * Time.deltaTime);
        }
    }

    void A200Destroy()
    {
        DespawnTimer -= Time.deltaTime;
        if (DespawnTimer < 0)
        {
            Destroy(gameObject);
            StuffManager.Instance.fastAudioManager.CreateFastAudio(DespawnSound, transform.position, 0.4f, 1f, 300f, false);
        }
    }
}
