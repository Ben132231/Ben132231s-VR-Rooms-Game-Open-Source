using UnityEngine;
using UnityEngine.InputSystem;

public class GorillaMovementTurningScript : MonoBehaviour
{
    public float Speed;
    Vector2 turnInput;

    public void OnTurning(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if(SavingManager.gameData.PlayerTurning)
        {
            GorillaLocomotion.Player.Instance.Turning(Speed * turnInput.x);
        }
    }
}
