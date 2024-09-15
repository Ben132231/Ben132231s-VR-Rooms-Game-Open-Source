using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class DeathScreenEffect : MonoBehaviour
{
    public float exposureValue;
    public bool toggle;
    public PostProcessProfile profile;
    PostProcessVolume postProcess;
    ColorGrading colorGrading;

    private void Awake()
    {
        postProcess = GetComponent<PostProcessVolume>();
        postProcess.profile = this.profile;
        postProcess.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (GorillaLocomotion.Player.Instance.IsDead)
        {
            postProcess.isGlobal = true;
            colorGrading.active = toggle;
            colorGrading.postExposure.value = exposureValue;
            RenderSettings.ambientIntensity = 1.2f;
        }
        else
        {
            RenderSettings.ambientIntensity = RoomGenManager.Instance.SunLight.intensity;
            postProcess.isGlobal = false;
        }
    }
}
