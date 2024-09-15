using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointButton : MonoBehaviour
{
    [Header("Door Opening Settings")]
    public float DoorOpenDelayFrequency = 0.4f;
    float DoorOpenDelay = 0.4f;

    [Header("Script Ref")]
    public RoomGen roomGen;

    [Header("Disabling Mesh And Collider")]
    public GameObject MeshesToDisable;
    public Collider CollidersToDisable;
    public GameObject[] ButtonsToDisable;

    [Header("Amount Of Door To Open")]
    public int MaxDoorsOpen = 49;

    [Header("Teleport Stuff")]
    public LayerMask LayerNothing;
    public LayerMask LayerDefault;
    public float waitTime = 0.4f;
    bool TeleportingPlayer;

    void Start()
    {
        DoorOpenDelay = DoorOpenDelayFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (roomGen.UsingCheckPoint)
        {
            DoorOpenDelay -= Time.deltaTime;
            if (DoorOpenDelay > 0)
            {
                RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<DoorScript>().OpenDoor(true);
                DoorOpenDelay = DoorOpenDelayFrequency;
            }
            if (RoomGenManager.Instance.DoorNumber > MaxDoorsOpen)
            {
                StartCoroutine(teleport());
                roomGen.UsingCheckPoint = false;
            }
        }

        if (TeleportingPlayer)
        {
            GorillaLocomotion.Player.Instance.transform.position = RoomGenManager.Instance.DestroyPoint.position + new Vector3(0, 0.75f, -7.5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            roomGen.UsingCheckPoint = true;
            StuffManager.Instance.HasUsedCheckpoints = true;
            MeshesToDisable.SetActive(false);
            CollidersToDisable.enabled = false;
            foreach (var buttons in ButtonsToDisable)
            {
                buttons.SetActive(false);
            }
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

