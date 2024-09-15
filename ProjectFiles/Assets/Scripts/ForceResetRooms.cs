using UnityEngine.InputSystem;
using UnityEngine;

public class ForceResetRooms : MonoBehaviour
{
    public float ResetTimerValue = 5f;
    public AudioClip SaveFinishClip;
    public GameObject SavedGameText;

    bool DidSave;
    bool IsHeld;
    public float Timer;

    // Update is called once per frame
    void Update()
    {
        if (IsHeld)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0 && !DidSave)
            {
                DidSave = true;
                SavedGameText.SetActive(true);
                
            }
        }
        else
        {
            DidSave = false;
            SavedGameText.SetActive(false);
            Timer = ResetTimerValue;
        }
    }

    void OnHoldingForceSave(InputValue isHeld)
    {
        IsHeld = isHeld.isPressed;
    }
}
