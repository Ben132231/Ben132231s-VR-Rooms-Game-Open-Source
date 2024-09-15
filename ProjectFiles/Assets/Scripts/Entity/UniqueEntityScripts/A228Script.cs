using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A228Script : MonoBehaviour
{
    public float speed = 75f;
    public bool CanBreakDoor = false;
    public AudioClip BreakLockerClip;
    public Mesh BrokenLockerDoorMesh;
    public float DelayCheck = 1.8f;

    GameObject Room_Target;
    Transform Locker_Target;
    CheckingPos checkingPos;
    bool isChecking;
    bool isCheckingTriggerd;

    void Awake()
    {
        isChecking = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLockerMovement();
        NormalDestroy();
    }

    void NormalDestroy()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 0.4f)
        {
            Destroy(gameObject);
            if (CanBreakDoor)
            {
                RoomGenManager.Instance.CurrentGeneratedRoom.GetComponentInChildren<CurrentDoor>().GetComponent<DoorScript>().OpenDoor(false);
            }
        }
    }

    void CheckLockerMovement()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 6 && !isChecking)
        {
            if (Room_Target == null)
            {
                Room_Target = RoomGenManager.Instance.CurrentGeneratedRoom;
                isChecking = true;
            }
        }
        if (Room_Target != null && isChecking && !isCheckingTriggerd)
        {
            isCheckingTriggerd = true;
            StartCoroutine(CheckLocker());
        }
        if (!isChecking && !isCheckingTriggerd)
        {
            transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
        }
        if (isChecking && Locker_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Locker_Target.position, speed * Time.deltaTime);
        }
    }

    IEnumerator CheckLocker()
    {
        foreach (var lockers in Room_Target.GetComponentsInChildren<HidingScript>())
        {
            if (lockers.name.Contains("Locker"))
            {
                if (lockers.hidingSpotType == HideSpotType.Locker)
                {
                    Locker_Target = lockers.GetComponentInChildren<CheckingPos>().transform;
                    checkingPos = lockers.GetComponentInChildren<CheckingPos>();
                }
                yield return new WaitForSeconds(0.15f);
                if (Vector3.Distance(transform.position, checkingPos.transform.position) < 0.2f && checkingPos != null)
                {
                    StuffManager.Instance.fastAudioManager.CreateFastAudio(BreakLockerClip, transform.position, 0.4f, Random.Range(0.95f, 1.15f), 40f, false);
                    if (lockers.GetComponentInChildren<LockerDoorObject>() != null)
                    {
                        lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<MeshFilter>().mesh = BrokenLockerDoorMesh;
                        lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<MeshRenderer>().materials[1] = null;
                    }
                    if (lockers.GetComponent<BoxCollider>() != null)
                    {
                        Destroy(lockers.GetComponent<BoxCollider>());
                    }
                }
            }
            else
            {
                Locker_Target = RoomGenManager.Instance.DestroyPoint;
            }
        }
        Locker_Target = RoomGenManager.Instance.DestroyPoint;
    }
}
