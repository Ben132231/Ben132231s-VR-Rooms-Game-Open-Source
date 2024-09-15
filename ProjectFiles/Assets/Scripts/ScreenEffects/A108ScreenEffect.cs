using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class A108ScreenEffect : MonoBehaviour
{
    public float saturationValue;
    public float postExposureValue;
    public PostProcessProfile profile;
    PostProcessVolume postProcess;
    ColorGrading colorGrading;
    Animator screenEffectAnimatior;

    private void Awake()
    {
        postProcess = GetComponent<PostProcessVolume>();
        postProcess.profile = this.profile;
        postProcess.profile.TryGetSettings(out colorGrading);
        screenEffectAnimatior = GetComponent<Animator>();
    }

    private void Update()
    {
        colorGrading.saturation.value = saturationValue;
        colorGrading.postExposure.value = postExposureValue;

        if (screenEffectAnimatior.GetCurrentAnimatorStateInfo(0).IsName("A108_ScreenEffectAnim") && !GorillaLocomotion.Player.Instance.IsDead)
        {
            postProcess.isGlobal = true;
        }
        else
        {
            postProcess.isGlobal = false;
        }
    }
}
