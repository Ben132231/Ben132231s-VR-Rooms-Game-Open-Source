using UnityEngine.InputSystem;
using UnityEngine;

public class PCMainMenuCamera : MonoBehaviour
{
    public Vector3 SetCameraPosition;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            transform.position = SetCameraPosition;
        }
    }
}
