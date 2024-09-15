using UnityEngine;
using UnityEngine.UI;

public class A132Script : MonoBehaviour
{
    public Image A132Sprite;
    public Image A132SpriteHat;
    public AudioSource audioSource;
    public AudioClip LineAudioClip;
    public AudioClip MagicAudioClip;
    public Animator animator;
    public float EntitySpawnDis = 150f;


    int MaxEntitysToPick;
    int EntityToPick;
    float SpawnEntityTimer;
    bool FinishLineAudio;
    bool FinishMagicAudio;
    bool DoingAnimation;

    [Header("Entity Prefabs and Spawn Scripts")]
    public GameObject A12Prefab;
    public GameObject A38Prefab;
    public GameObject A60Prefab;
    public GameObject A108Prefab;
    public GameObject A176Prefab;
    public GameObject A200Prefab;
    public GameObject A228Prefab;

    void Awake()
    {
        A132Sprite.enabled = true;
        A132SpriteHat.enabled = true;
        FinishMagicAudio = false;
        FinishLineAudio = false;
        SpawnEntityTimer = 12;
        MaxEntitysToPick = 8;
        EntityToPick = Random.Range(1, MaxEntitysToPick);
    }

    void Update()
    {
        SpawnEntityTimer -= Time.deltaTime;
        if (EntityToPick == 1)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A12Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A12Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 2)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A38Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A38Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 3)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A60Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A60Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 4)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A87Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                StuffManager.Instance.a87SpawnScript.ForceSpawn();
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 5)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A108Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A108Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                StuffManager.Instance.a108ScreenEffect.Play("A108_ScreenEffectAnim");
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 6)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A176Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A176Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 7)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A200Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A200Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, 4.5f), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (EntityToPick == 8)
        {
            if (SpawnEntityTimer < 9 && !DoingAnimation)
            {
                animator.Play("A132_A228Anim");
                DoingAnimation = true;
            }
            if (SpawnEntityTimer < 6)
            {
                if (!audioSource.isPlaying && !FinishLineAudio)
                {
                    audioSource.PlayOneShot(LineAudioClip);
                    FinishLineAudio = true;
                }
            }
            if (SpawnEntityTimer < 1)
            {
                A132Sprite.enabled = false;
                A132SpriteHat.enabled = false;
                if (!audioSource.isPlaying && !FinishMagicAudio)
                {
                    audioSource.PlayOneShot(MagicAudioClip);
                    FinishMagicAudio = true;
                }
            }
            if (SpawnEntityTimer < 0)
            {
                Instantiate(A228Prefab, RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
