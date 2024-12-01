using UnityEngine.InputSystem;
using UnityEngine;

public class NightVisionToggle : MonoBehaviour
{
    bool UsingNightVision;

    public GameObject Normal;
    public GameObject Active;

    public void ToggleNightVision()
    {
        UsingNightVision = !UsingNightVision;

        if (UsingNightVision)
        {
            RoomGenInfo.Instance.roomGen.TakeLightingToggle = false;
            RenderSettings.ambientIntensity = 2;
            Active.SetActive(true);
            Normal.SetActive(false);
        }
        else
        {
            RoomGenInfo.Instance.roomGen.TakeLightingToggle = true;
            RenderSettings.ambientIntensity = RoomGenInfo.Instance.SkyIntensity;
            Active.SetActive(false);
            Normal.SetActive(true);
        }
    }
}
