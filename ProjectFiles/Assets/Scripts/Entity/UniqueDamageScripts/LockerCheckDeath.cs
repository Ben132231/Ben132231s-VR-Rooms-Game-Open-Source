using UnityEngine;

public class LockerCheckDeath : MonoBehaviour
{
    public bool toggleTrigger;
    public string HidingSpotKiller = "Locker";

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && GorillaLocomotion.Player.Instance.HidingSpot == HidingSpotKiller && toggleTrigger)
        {
            if (!GorillaLocomotion.Player.Instance.IsDead)
            {
                GorillaLocomotion.Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
