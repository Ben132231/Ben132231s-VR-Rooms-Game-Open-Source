using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    public float speed = 8f;
    bool toggle;

    void Update()
    {
        if (GorillaLocomotion.Player.Instance.CanFly)
        {
            if (toggle)
            {
                GorillaLocomotion.Player.Instance.playerRigidBody.velocity = GorillaLocomotion.Player.Instance.GorillaCamera.transform.forward * speed * Time.deltaTime;
                GorillaLocomotion.Player.Instance.playerRigidBody.useGravity = false;
            }
            else if (!toggle)
            {
                GorillaLocomotion.Player.Instance.playerRigidBody.useGravity = true;
            }
        }
        else
        {
            GorillaLocomotion.Player.Instance.playerRigidBody.useGravity = true;
        }
    }

    public void Flying(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            toggle = true;
        }
        if (context.canceled)
        {
            toggle = false;
        }
    }
}