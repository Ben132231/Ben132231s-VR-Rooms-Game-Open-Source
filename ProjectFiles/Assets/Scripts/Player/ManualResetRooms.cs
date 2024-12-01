using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class ManualResetRooms : MonoBehaviour
{
    public float DefualtTimer = 6f;

    float Timer;
    bool IsHolding;

    void Awake()
    {
        Timer = 6f;
    }

    void Update()
    {
        if (IsHolding)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void HoldingResetRoomsButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsHolding = true;
        }
        else if (context.canceled)
        {
            IsHolding = false;
            Timer = DefualtTimer;
        }
    }
}
