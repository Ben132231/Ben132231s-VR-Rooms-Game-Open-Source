using UnityEngine;

public class AnywhereKillScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!GorillaLocomotion.Player.Instance.IsDead && !GorillaLocomotion.Player.Instance.GodMode)
            {
                GorillaLocomotion.Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
