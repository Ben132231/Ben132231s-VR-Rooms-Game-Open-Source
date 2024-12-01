using UnityEngine;
using System.Collections;

public class A295Script : MonoBehaviour
{
    [Header("Main Stuff")]
    public float speed = 50f;

    public GameObject[] Clones;
    public int SetMaxSpawnedClones = 4;

    public GameObject ExplosionPrefab;
    public GameObject SpiteObject;
    public Collider KillCollider;

    [Header("Delay Movement")]
    public float DelayTimer = 5f;

    [Header("Audio Stuff")]
    public AudioSource Audio_Despawning;
    public AudioSource Audio_Near;

    bool ExplodingTime;
    bool DelayMovement;

    void Awake()
    {
        if (SetMaxSpawnedClones == 0)
        {
            SetMaxSpawnedClones = 4;
        }
        DelayMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DelayMovement)
        {
            Movement();
        }
        else
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer < 0)
            {
                DelayMovement = false;
                Audio_Near.Play();
            }
        }
    }

    void Movement()
    {
        if (Vector3.Distance(transform.position, RoomGenInfo.Instance.DestroyPoint.position) < 7.5f && !ExplodingTime)
        {
            ExplodingTime = true;
            StartCoroutine(AboutToUseClones());
        }
        if (!ExplodingTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenInfo.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
    }

    IEnumerator AboutToUseClones()
    {
        Audio_Despawning.Play();
        Audio_Near.Stop();
        yield return new WaitForSeconds(4f);
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        SpiteObject.SetActive(false);
        KillCollider.enabled = false;
        SpawningClones();
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    void SpawningClones()
    {
        for (int i = 0; i < SetMaxSpawnedClones; i++)
        {
            int SelectedClone = Random.Range(0, Clones.Length);
            Instantiate(Clones[SelectedClone], transform.position, Quaternion.identity);
        }
    }
}
