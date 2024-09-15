using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTpCurrentRoom : MonoBehaviour
{
    [Header("Teleport Stuff")]
    public LayerMask LayerNothing;
    public LayerMask LayerDefault;
    public float waitTime = 0.4f;
    bool TeleportingPlayer;

    public void TeleportPlayer()
    {
        StartCoroutine(teleport());
    }

    void Update()
    {
        if (TeleportingPlayer)
        {
            GorillaLocomotion.Player.Instance.transform.position = RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0.75f, -7.5f);
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
