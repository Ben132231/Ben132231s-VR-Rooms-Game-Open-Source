using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(GorillaLocomotion.Player.Instance.HidingSpot == "" && other.CompareTag("MainCamera"))
        {
            if(!GorillaLocomotion.Player.Instance.IsDead && !GorillaLocomotion.Player.Instance.GodMode)
            {
                GorillaLocomotion.Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
