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
            Player.Instance.transform.position = RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0.75f, -7.5f);
        }
        if (Keyboard.current.dKey.isPressed && Application.isEditor)
        {
            PlayerObject.Rotate(Vector3.up, RotateAmount);
        }
        else if (Keyboard.current.aKey.isPressed && Application.isEditor)
        {
            PlayerObject.Rotate(Vector3.up, -RotateAmount);
        }
    }

    void MovePlayerObject(float MoveAmountValue)
    {
        if (Keyboard.current.wKey.isPressed && Application.isEditor)
        {
            PlayerObject.Translate(Vector3.forward * MoveAmountValue * Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed && Application.isEditor)
        {
            PlayerObject.Translate(-Vector3.forward * MoveAmountValue * Time.deltaTime);
        }
        if (SceneManager.GetActiveScene().name.Contains("Rooms") && Keyboard.current.rKey.isPressed && Application.isEditor)
        {
            StartCoroutine(teleport());
        }

        if (Keyboard.current.uKey.isPressed && Application.isEditor)
        {
            Player.Instance.playerRigidBody.AddForce(Vector3.up * 18);
        }
    }

    IEnumerator teleport()
    {
        Player.Instance.locomotionEnabledLayers = LayerNothing;
        TeleportingPlayer = true;
        yield return new WaitForSeconds(waitTime);
        Player.Instance.locomotionEnabledLayers = LayerDefault;
        TeleportingPlayer = false;
    }
}
