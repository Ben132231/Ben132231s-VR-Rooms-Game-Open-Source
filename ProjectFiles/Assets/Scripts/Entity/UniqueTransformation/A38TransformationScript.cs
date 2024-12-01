using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class A38TransformationScript : MonoBehaviour
{
    public EntityScript a38Script;
    public float setSpeedWhenDone = 36.5f;
    public float setMaxReboundAmount = 2;
    public float[] RandomTimes;
    public Animator animator;
    public string transformingAnimationName;
    public string VariantAnimationName;
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
        if (Keyboard.current.numpad2Key.wasPressedThisFrame && !DebugTriggerOnce && Application.isEditor)
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
        while (a38Script.speed >= 0)
        {
            a38Script.speed -= Time.deltaTime * 14f;
            entityAudioSource.volume -= Time.deltaTime * 0.8f;
            yield return null;
        }
        a38Script.speed = 0f;
        entityAudioSource.volume = 0f;
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(transformingAnimationName))
        {
            yield return null;
        }
        a38Script.speed = setSpeedWhenDone;
        a38Script.ReboundMaxAmount = setMaxReboundAmount;
        animator.Play(VariantAnimationName);
        StuffManager.Instance.fastAudioManager.CreateFastAudio(finishTransformationAudio, transform.position, 0.4f, 1f, 760f, false);
        entityAudioSource.volume = 0.5f;
        entityAudioSource.clip = variantEntityAudio;
        entityAudioSource.maxDistance = 345f;
        entityAudioSource.Play();
        Destroy(gameObject.GetComponent<A38TransformationScript>());
    }
}
