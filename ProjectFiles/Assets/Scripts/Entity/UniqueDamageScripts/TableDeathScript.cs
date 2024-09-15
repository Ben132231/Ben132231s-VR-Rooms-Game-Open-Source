using UnityEngine;

public class TableDeathScript : MonoBehaviour
{
    public string HidingSpotKiller = "Table";

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && GorillaLocomotion.Player.Instance.HidingSpot == HidingSpotKiller)
        {
            if (!GorillaLocomotion.Player.Instance.IsDead)
            {
                GorillaLocomotion.Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
