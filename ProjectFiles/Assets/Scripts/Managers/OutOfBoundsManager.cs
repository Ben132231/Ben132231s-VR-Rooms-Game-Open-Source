using UnityEngine;

public class OutOfBoundsManager : MonoBehaviour
{
    void Update()
    {
        if (Player.Instance.GorillaCamera.transform.position.y < -40f && !Player.Instance.IsDead)
        {
            Player.Instance.DamagePlayer(9999);
        }
    }
}
