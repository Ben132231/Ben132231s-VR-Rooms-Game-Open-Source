using UnityEngine;

public class A235Script : MonoBehaviour
{
    public float AddedSpeed = 1f;

    float speed;

    private void Update()
    {
        if (GorillaLocomotion.Player.Instance.playerRigidBody.velocity.magnitude > 0.2f)
        {
            speed = GorillaLocomotion.Player.Instance.playerRigidBody.velocity.magnitude * AddedSpeed;
        }
        else
        {
            speed = 0f;
        }

        transform.position = Vector3.MoveTowards(transform.position, GorillaLocomotion.Player.Instance.GorillaCamera.transform.position, speed * Time.deltaTime);
    }
}
