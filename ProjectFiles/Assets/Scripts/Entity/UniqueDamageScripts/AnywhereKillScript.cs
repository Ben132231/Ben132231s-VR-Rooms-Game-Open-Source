using UnityEngine;

public class AnywhereKillScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!Player.Instance.IsDead && !Player.Instance.GodMode)
            {
                Player.Instance.DamagePlayer(9999);
            }
        }
    }
}
