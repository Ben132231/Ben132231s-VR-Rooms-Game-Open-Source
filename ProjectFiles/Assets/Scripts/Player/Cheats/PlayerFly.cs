using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    public float speed = 8f;
    bool toggle;

    void Update()
    {
        if (Player.Instance.CanFly)
        {
            if (toggle)
            {
                Player.Instance.playerRigidBody.velocity = Player.Instance.GorillaCamera.transform.forward * speed * Time.deltaTime;
                Player.Instance.playerRigidBody.useGravity = false;
            }
            else if (!toggle)
            {
                Player.Instance.playerRigidBody.useGravity = true;
            }
        }
        else
        {
            Player.Instance.playerRigidBody.useGravity = true;
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
