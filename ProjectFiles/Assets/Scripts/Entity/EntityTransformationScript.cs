using UnityEngine;

public class EntityTransformationScript : MonoBehaviour
{
    [Header("Entity Stuff")]
    public EntityScript entityScript;
    public ShakeScript entityShakeScript;

    [Header("Animations")]
    public Animator TransformationAnimator;
    public string TransformingAnimationName;
    public string VariantAnimationName;

    [Header("Timer To Transform")]
    public float MinSetTimeToTransform = 180;
    public float MaxSetTimeToTransform = 300;

    [Header("Other Settings")]
    public float SetReduceSpeed = 8;
    public float SetReduceVolume = 0.8f;
    public float SetEntitySpeedWhenDone = 20;
    public float SetShake = 0.22f;
    
    public float SetDelayTimer = 5.2f;

    [Header("Audio")]
    public AudioSource EntityAudioSource;
    public AudioClip VariantEntityAudioClip;
    public AudioClip finishTransformationAudio;
    public float AudioVolume = 0.4f;
    public float AudioPitch = 1f;
    public float AudioMaxDis = 280f;
    public float SetEntityAudio = 0.2f;

    public float EntityAudioMaxDis = 245f;

    [SerializeField] float Timer;
    float DelayTimer;
    bool DoingTransformation;
    bool DoneTransforming;

    void Awake()
    {
        Timer = Random.Range(MinSetTimeToTransform, MaxSetTimeToTransform);
        DelayTimer = SetDelayTimer;
        DoingTransformation = false;
        DoneTransforming = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            DelayTimer -= Time.deltaTime;
            if (!DoingTransformation)
            {
                entityScript.speed -= SetReduceSpeed * Time.deltaTime;
                EntityAudioSource.volume -= SetReduceVolume * Time.deltaTime;
                TransformationAnimator.Play(TransformingAnimationName);
            }
            if (entityScript.speed <= 0)
            {
                entityShakeScript.enabled = false;
                DoingTransformation = true;
            }
            if (DelayTimer < 0 && !DoneTransforming)
            {
                entityScript.speed = SetEntitySpeedWhenDone;
                entityShakeScript.enabled = true;
                entityShakeScript.minShake = SetShake;
                entityShakeScript.maxShake = SetShake;
                TransformationAnimator.Play(VariantAnimationName);
                StuffManager.Instance.fastAudioManager.CreateFastAudio(finishTransformationAudio, transform.position, AudioVolume, AudioPitch, AudioMaxDis, false);
                EntityAudioSource.volume = SetEntityAudio;
                EntityAudioSource.maxDistance = EntityAudioMaxDis;
                EntityAudioSource.clip = VariantEntityAudioClip;
                EntityAudioSource.Play();
                DoneTransforming = true;
                Destroy(gameObject.GetComponent<EntityTransformationScript>());
            }
        }
    }
}
