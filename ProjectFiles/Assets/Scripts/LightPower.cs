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
        if (Player.Instance.CurrentHeadLight.intensity > 0)
        {
            Player.Instance.DrainLightsIntensity(DrainSpeed * Time.deltaTime);
        }
    }

    public void OnUseLightPower(InputAction.CallbackContext context)
    {
        if (context.performed && !Player.Instance.CurrentHeadLight.gameObject.name.Contains("NormalLight") && !Player.Instance.CurrentHeadLight.gameObject.name.Contains("NightVision"))
        {
            if (Player.Instance.CurrentHeadLight.intensity < MaxPowerForHeadLight)
            {
                Player.Instance.PowerHeadSpotLightIntensity(AddPowerAmount);
                Player.Instance.PlayAudioAtPlayer(shakeAudio, 0.4f, 1f);
            }
            if (Player.Instance.BodyLight.intensity < MaxPowerForOtherLights)
            {
                Player.Instance.PowerOtherLightsIntensity(AddPowerAmount);
            }
        }
    }
}
