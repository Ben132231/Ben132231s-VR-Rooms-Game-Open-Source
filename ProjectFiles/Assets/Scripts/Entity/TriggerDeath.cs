using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(Player.Instance.HidingSpot == "" && other.CompareTag("MainCamera"))
        {
            if(!Player.Instance.IsDead && !Player.Instance.GodMode)
            {
                Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
