using UnityEngine;

public class FirstDoorSetup : MonoBehaviour
{
    public GameObject[] objectToDisable;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            foreach (var item in objectToDisable)
            {
                item.SetActive(false);
            }
        }
    }
}
