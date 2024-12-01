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
            Player.Instance.transform.position = RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0.75f, -7.5f);
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
