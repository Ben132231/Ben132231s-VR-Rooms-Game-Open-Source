using UnityEngine;

public class LootAtPlayerScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - GorillaLocomotion.Player.Instance.GorillaCamera.transform.position);
    }
}