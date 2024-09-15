using UnityEngine;

public class A87Script : MonoBehaviour
{
    public Animator animator;
    public ShakeScript shake;
    public float SpeedIncreaseAmount;
    public AudioSource NotAngrySound;
    public AudioSource AngrySound;
    public AudioClip DespawnSound;
    public float StayTime = 22f;

    SphereCollider EnrageCollider;
    float DespawnTimer = 22f;
    float EnableTriggerTimer;
    float speed;
    bool isAngry;

    void Awake()
    {
        EnrageCollider = GetComponent<SphereCollider>();
        DespawnTimer = StayTime;
        EnableTriggerTimer = 1.6f;
        EnrageCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);
            speed += SpeedIncreaseAmount * Time.deltaTime;
        }
        if (!isAngry)
        {
            DespawnTimer -= Time.deltaTime;
            if (DespawnTimer < 0)
            {
                StuffManager.Instance.fastAudioManager.CreateFastAudio(DespawnSound, transform.position, 0.3f, 1f, 30f, false);
                Destroy(gameObject);
            }
        }
        if (EnableTriggerTimer < 0)
        {
            EnrageCollider.enabled = true;
        }
        if (EnableTriggerTimer > -1)
        {
            EnableTriggerTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !isAngry)
        {
            isAngry = true;
            animator.SetTrigger("TriggerAngry");
            shake.minShake = 0.3f;
            shake.maxShake = 0.3f;
            NotAngrySound.Stop();
            AngrySound.Play();
        }
    }
}
