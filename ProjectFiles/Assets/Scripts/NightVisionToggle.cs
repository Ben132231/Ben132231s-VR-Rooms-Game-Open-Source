using UnityEngine.InputSystem;
using UnityEngine;

public class NightVisionToggle : MonoBehaviour
{
    bool UsingNightVision;

    public RoomGen roomGen;
    public GameObject Normal;
    public GameObject Active;

    public void ToggleNightVision()
    {
        UsingNightVision = !UsingNightVision;

        if (UsingNightVision)
        {
            roomGen.TakeLightingToggle = false;
            RenderSettings.ambientIntensity = 2;
            Active.SetActive(true);
            Normal.SetActive(false);
        }
        else
        {
            roomGen.TakeLightingToggle = true;
            RenderSettings.ambientIntensity = RoomGenManager.Instance.SkyIntensity;
            Active.SetActive(false);
            Normal.SetActive(true);
        }
    }
}
