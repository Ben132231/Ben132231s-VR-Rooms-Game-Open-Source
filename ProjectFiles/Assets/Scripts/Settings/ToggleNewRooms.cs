using UnityEngine;
using TMPro;

public class ToggleNewRooms : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    bool toggle;

    public void FinishSave()
    {

    }

    public void Load()
    {

    }

    public void Save()
    {
        SavingManager.Save();
    }

    public void Toggle()
    {
        if (!toggle)
        {
            textObject.text = "Experimental Rooms : On";
            SavingManager.gameData.ExpRoomsToggle = true;
            Save();
            toggle = true;
        }
        else
        {
            textObject.text = "Experimental Rooms : Off";
            SavingManager.gameData.ExpRoomsToggle = false;
            Save();
            toggle = false;
        }
    }

    void Start()
    {
        if (SavingManager.gameData.ExpRoomsToggle)
        {
            textObject.text = "Experimental Rooms : On";
        }
        else
        {
            textObject.text = "Experimental Rooms : Off";
        }
    }
}
