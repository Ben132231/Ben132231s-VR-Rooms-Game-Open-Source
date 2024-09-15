using UnityEngine;

public class OutOfBoundsManager : MonoBehaviour
{
    void Update()
    {
        if (GorillaLocomotion.Player.Instance.GorillaCamera.transform.position.y < -40f && !GorillaLocomotion.Player.Instance.IsDead)
        {
            GorillaLocomotion.Player.Instance.DamagePlayer(9999);
        }
    }
}
