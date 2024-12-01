using UnityEngine;

public class TableDeathScript : MonoBehaviour
{
    public string HidingSpotKiller = "Table";

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && Player.Instance.HidingSpot == HidingSpotKiller)
        {
            if (!Player.Instance.IsDead)
            {
                Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
