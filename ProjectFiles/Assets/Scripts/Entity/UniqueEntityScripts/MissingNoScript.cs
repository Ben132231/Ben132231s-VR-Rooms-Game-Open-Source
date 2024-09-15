using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MissingNoScript : MonoBehaviour
{
    public float speed = 50f;
    public float SetAttackTimer = 1f;

    float AttackTimer;
    AudioSource Jumpscare_Audio;

    void Awake()
    {
        AttackTimer = SetAttackTimer;
        Jumpscare_Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        AttackTimer -= Time.deltaTime;
        if (AttackTimer < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);
            if (Jumpscare_Audio != Jumpscare_Audio.isPlaying)
            {
                Jumpscare_Audio.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }
}
