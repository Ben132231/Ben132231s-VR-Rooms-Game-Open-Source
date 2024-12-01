using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class A12TransformationScript : MonoBehaviour
{
    [Header("Entity Stuff")]
    public EntityScript a12Script;
    public ShakeScript entityShakeScript;

    public Animator animator;
    public string transformingAnimationName;
    public string variantAnimationName;

    public float[] RandomTimes;
    public float setSpeedWhenDone = 20;
    public float setShake = 0.22f;

    [Header("Audio")]
    public AudioSource entityAudioSource;
    public AudioClip variantEntityAudio;
    public AudioClip finishTransformationAudio;

    float DelayTimer;
    bool TriggerOnce;

    // Debug
    bool DebugTriggerOnce;

    void Awake()
    {
        TriggerOnce = false;
        DebugTriggerOnce = false;
        DelayTimer = RandomTimes[Random.Range(0, RandomTimes.Length)];
    }

    void Update()
    {
        if (!TriggerOnce)
        {
            DelayTimer -= Time.deltaTime;
        }
        if (DelayTimer < 0f && !TriggerOnce)
        {
            StartCoroutine(Transformation());
            TriggerOnce = true;
        }
        if (Keyboard.current.numpad1Key.wasPressedThisFrame && !DebugTriggerOnce && Application.isEditor)
        {
            StartCoroutine(Transformation());
            DelayTimer = 9999f;
            TriggerOnce = true;
            DebugTriggerOnce = true;
        }
    }

    IEnumerator Transformation()
    {
        animator.Play(transformingAnimationName);
        while (a12Script.speed >= 0)
        {
            a12Script.speed -= Time.deltaTime * 8;
            entityAudioSource.volume -= Time.deltaTime * 0.8f;
            yield return null;
        }
        a12Script.speed = 0f;
        entityAudioSource.volume = 0f;
        entityShakeScript.enabled = false;
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(transformingAnimationName))
        {
            yield return null;
        }
        a12Script.speed = setSpeedWhenDone;
        entityShakeScript.enabled = true;
        entityShakeScript.minShake = setShake;
        entityShakeScript.maxShake = setShake;
        animator.Play(variantAnimationName);
        StuffManager.Instance.fastAudioManager.CreateFastAudio(finishTransformationAudio, transform.position, 0.4f, 1f, 760f, false);
        entityAudioSource.volume = 0.5f;
        entityAudioSource.maxDistance = 220f;
        entityAudioSource.clip = variantEntityAudio;
        entityAudioSource.Play();
        Destroy(gameObject.GetComponent<A12TransformationScript>());
    }
}
