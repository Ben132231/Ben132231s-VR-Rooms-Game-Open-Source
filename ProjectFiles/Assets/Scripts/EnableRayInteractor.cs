using UnityEngine;

public class EnableRayInteractor : MonoBehaviour
{
    public GameObject Ray;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Ray.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Ray.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (Ray != null)
        {
            Ray.SetActive(false);
        }
    }
}
