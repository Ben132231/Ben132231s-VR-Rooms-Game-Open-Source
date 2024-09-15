using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public Transform startingPos;

    public float minShake;
    public float maxShake;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Random.Range(minShake, -maxShake) + startingPos.position.x, Random.Range(minShake, -maxShake) + startingPos.position.y, Random.Range(minShake, -maxShake) + startingPos.position.z);
    }
}
