using UnityEngine;
using UnityEngine.InputSystem;

public class LightPower : MonoBehaviour
{
    public float DrainSpeed = 0.006f;
    public float AddPowerAmount = 0.06f;
    public float MaxPowerForHeadLight = 2f;
    public float MaxPowerForOtherLights = 1f;
    public AudioClip shakeAudio;

    void Update()
    {
        if (GorillaLocomotion.Player.Instance.CurrentHeadLight.intensity > 0)
        {
            GorillaLocomotion.Player.Instance.DrainLightsIntensity(DrainSpeed * Time.deltaTime);
        }
    }

    public void OnUseLightPower(InputAction.CallbackContext context)
    {
        if (context.performed && !GorillaLocomotion.Player.Instance.CurrentHeadLight.gameObject.name.Contains("NormalLight") && !GorillaLocomotion.Player.Instance.CurrentHeadLight.gameObject.name.Contains("NightVision"))
        {
            if (GorillaLocomotion.Player.Instance.CurrentHeadLight.intensity < MaxPowerForHeadLight)
            {
                GorillaLocomotion.Player.Instance.PowerHeadSpotLightIntensity(AddPowerAmount);
                GorillaLocomotion.Player.Instance.PlayAudioAtPlayer(shakeAudio, 0.4f, 1f);
            }
            if (GorillaLocomotion.Player.Instance.BodyLight.intensity < MaxPowerForOtherLights)
            {
                GorillaLocomotion.Player.Instance.PowerOtherLightsIntensity(AddPowerAmount);
            }
        }
    }
}
