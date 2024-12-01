using UnityEngine;

public class LockerCheckDeath : MonoBehaviour
{
    public bool toggleTrigger;
    public string HidingSpotKiller = "Locker";

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && Player.Instance.HidingSpot == HidingSpotKiller && toggleTrigger)
        {
            if (!Player.Instance.IsDead)
            {
                Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
