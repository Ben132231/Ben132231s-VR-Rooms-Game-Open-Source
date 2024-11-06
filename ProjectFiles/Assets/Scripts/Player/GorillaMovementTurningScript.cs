using UnityEngine;
using UnityEngine.InputSystem;

public class GorillaMovementTurningScript : MonoBehaviour
{
    Vector2 turnInput;

    public void OnTurning(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if(SavingManager.gameData.PlayerTurning)
        {
            GorillaLocomotion.Player.Instance.Turning(SavingManager.gameData.PlayerTurnSpeed * turnInput.x);
        }
    }
}
