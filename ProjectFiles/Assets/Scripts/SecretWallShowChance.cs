using UnityEngine;

public class SecretWallShowChance : MonoBehaviour
{
    public Material MatToChanged;
    public int MaxChanceNumber = 1300;

    void Start()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var randomNumber = Random.Range(0, MaxChanceNumber);
        if (randomNumber == MaxChanceNumber - 5)
        {
            meshRenderer.material = MatToChanged;
        }
    }
}
