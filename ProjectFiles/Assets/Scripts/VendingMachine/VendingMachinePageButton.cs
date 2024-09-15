using UnityEngine;

public class VendingMachinePageButton : MonoBehaviour
{
    public GameObject PageToDisable;
    public GameObject PageToEnable;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            PageToEnable.SetActive(true);
            PageToDisable.SetActive(false);
        }
    }
}
