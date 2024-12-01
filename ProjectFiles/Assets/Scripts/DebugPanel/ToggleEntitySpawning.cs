using UnityEngine.UI;
using UnityEngine;

public class ToggleEntitySpawning : MonoBehaviour
{
    public Button[] buttonsToDisable;

    public Image CheckMarkBox;
    public Sprite Checked;
    public Sprite Unchecked;

    bool toggle;
    GameObject[] Entitys;

    public void toggleEntitySpawning()
    {
        if (!toggle)
        {
            RoomGenInfo.Instance.DisableEntitySpawning = true;

            foreach (var buttons in buttonsToDisable)
            {
                buttons.interactable = false;
            }
            Entitys = GameObject.FindGameObjectsWithTag("Entity");
            foreach (var entitys in Entitys)
            {
                Destroy(entitys);
            }

            CheckMarkBox.sprite = Checked;
            toggle = true;
        }
        else
        {
            RoomGenInfo.Instance.DisableEntitySpawning = false;

            foreach (var buttons in buttonsToDisable)
            {
                buttons.interactable = true;
            }

            CheckMarkBox.sprite = Unchecked;
            toggle = false;
        }
    }
}
