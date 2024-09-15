using UnityEngine;

public class TestA12Movement : MonoBehaviour
{
    public float speed = 10;

    public AudioClip PlayerFailed;
    public AudioClip PlayerPassed;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Despawn();
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, RoomGenManager.Instance.DestroyPoint.position, speed * Time.deltaTime);
    }

    void Despawn()
    {
        if (Vector3.Distance(transform.position, RoomGenManager.Instance.DestroyPoint.position) < 0.4f)
        {
            Destroy(gameObject);
        }
    }
}
