using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class A176ScreenEffect : MonoBehaviour
{
    public float postExposureValue;
    public Color colorFilterValue;
    public bool colorGradingToggle;
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
        colorGrading.active = colorGradingToggle;
        colorGrading.colorFilter.value = colorFilterValue;
        colorGrading.postExposure.value = postExposureValue;

        if (screenEffectAnimatior.GetCurrentAnimatorStateInfo(0).IsName("A176_ScreenEffectAnim") && !Player.Instance.IsDead)
        {
            postProcess.isGlobal = true;
        }
        else
        {
            postProcess.isGlobal = false;
        }
    }
}
