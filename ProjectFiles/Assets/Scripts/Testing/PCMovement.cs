using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PCMovement : MonoBehaviour
{
    public Transform PlayerObject;

    public float MoveAmount;
    public float RotateAmount;


    [Header("Teleport Stuff")]
    public LayerMask LayerNothing;
    public LayerMask LayerDefault;
    public float waitTime = 0.4f;
    bool TeleportingPlayer;

    void FixedUpdate()
    {
        MovePlayerObject(MoveAmount);
        if (TeleportingPlayer)
        {
            GorillaLocomotion.Player.Instance.transform.position = RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0.75f, -7.5f);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            PlayerObject.Rotate(Vector3.up, RotateAmount);
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            PlayerObject.Rotate(Vector3.up, -RotateAmount);
        }
    }

    void MovePlayerObject(float MoveAmountValue)
    {
        if (Keyboard.current.wKey.isPressed)
        {
            PlayerObject.Translate(Vector3.forward * MoveAmountValue * Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            PlayerObject.Translate(-Vector3.forward * MoveAmountValue * Time.deltaTime);
        }
        if (SceneManager.GetActiveScene().name.Contains("Rooms") && Keyboard.current.rKey.isPressed)
        {
            StartCoroutine(teleport());
            GorillaLocomotion.Player.Instance.transform.position = RoomGenManager.Instance.DestroyPoint.position + new Vector3(0f, 0.25f, -7.5f);
        }

        if (Keyboard.current.uKey.isPressed)
        {
            GorillaLocomotion.Player.Instance.playerRigidBody.AddForce(Vector3.up * 18);
        }
    }

    IEnumerator teleport()
    {
        GorillaLocomotion.Player.Instance.locomotionEnabledLayers = LayerNothing;
        TeleportingPlayer = true;
        yield return new WaitForSeconds(waitTime);
        GorillaLocomotion.Player.Instance.locomotionEnabledLayers = LayerDefault;
        TeleportingPlayer = false;
    }
}
