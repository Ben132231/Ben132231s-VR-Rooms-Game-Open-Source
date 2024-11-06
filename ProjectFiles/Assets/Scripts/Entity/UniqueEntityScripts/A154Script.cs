using System.Collections;
using UnityEngine;

public class A154Script : MonoBehaviour
{
    [Header("Entity Stuff")]
    public float speed = 10f;
    public float SetDelayBeforeChecking = 3;
    public Collider KillTrigger;
    public AudioClip DespawnSound;
    float DelayBeforeChecking;

    [Header("I cant check locker Stuff")]
    public GameObject explosionPrefab;

    [Header("Checking Stuff")]
    public float DelayCheck = 2f;
    public LockerCheckDeath checkDeath;
    public AudioClip lockerSound;
    GameObject Room_Target;
    Transform Locker_Target;
    CheckingPos checkingPos;
    bool IsChecking;

    private void Awake()
    {
        DelayBeforeChecking = SetDelayBeforeChecking;
        KillTrigger.enabled = false;
        Room_Target = RoomGenManager.Instance.CurrentGeneratedRoom;
    }

    private void Update()
    {
        if (IsChecking && Locker_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Locker_Target.position, speed * Time.deltaTime);
        }
        if (!IsChecking)
        {
            DelayBeforeChecking -= Time.deltaTime;

            if (DelayBeforeChecking < 0)
            {
                StartCoroutine(CheckLocker());
                KillTrigger.enabled = true;
                IsChecking = true;
            }
        }
    }

    IEnumerator CheckLocker()
    {
        if (Room_Target.GetComponentInChildren<LockerObject>() == null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            yield break;
        }
        foreach (var lockers in Room_Target.GetComponentsInChildren<LockerObject>())
        {
            Locker_Target = lockers.GetComponentInChildren<CheckingPos>().transform;
            checkingPos = lockers.GetComponentInChildren<CheckingPos>();
            yield return new WaitForSeconds(2f);
            if (Vector3.Distance(transform.position, checkingPos.transform.position) < 0.2f && checkingPos != null)
            {
                if (checkDeath != null)
                {
                    StuffManager.Instance.fastAudioManager.CreateFastAudio(lockerSound, transform.position, 0.4f, Random.Range(0.95f, 1.15f), 40f, false);
                    lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<Animator>().Play("LockerOpen");
                    yield return new WaitForSeconds(0.5f);
                    checkDeath.toggleTrigger = true;
                    yield return new WaitForSeconds(0.3f);
                    lockers.GetComponentInChildren<LockerDoorObject>().GetComponent<Animator>().Play("LockerClose");
                    checkDeath.toggleTrigger = false;
                }
                else
                {
                    Debug.LogError("You didn't add CheckLockerDeath script to checkDeath.");
                }
            }
            yield return new WaitForSeconds(1.4f);
        }
        Locker_Target.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
        yield return new WaitForSeconds(1.5f);
        StuffManager.Instance.fastAudioManager.CreateFastAudio(DespawnSound, transform.position, 0.4f, 0.7f, 100f, false);
        Destroy(gameObject);
    }
}
