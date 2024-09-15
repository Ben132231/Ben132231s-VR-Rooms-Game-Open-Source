using UnityEngine;

public class DispensePotion : MonoBehaviour
{
    public GameObject PotionObject;

    public GameObject EnjoyMenu;
    public GameObject SelectedMenu;

    public Transform PotionDispenseTransform;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            EnjoyMenu.SetActive(true);
            SelectedMenu.SetActive(false);

            Instantiate(PotionObject, PotionDispenseTransform.position, PotionDispenseTransform.rotation);

            // Add Sound Here
        }
    }
}
