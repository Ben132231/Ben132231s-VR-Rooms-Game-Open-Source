using TMPro;
using UnityEngine;

public class ToggleTurning : MonoBehaviour, ISaving
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
            textObject.text = "Turning : On";
            SavingManager.gameData.PlayerTurning = true;
            Save();
            toggle = true;
        }
        else
        {
            textObject.text = "Turning : Off";
            SavingManager.gameData.PlayerTurning = false;
            Save();
            toggle = false;
        }
    }

    void Start()
    {
        if (SavingManager.gameData.PlayerTurning)
        {
            textObject.text = "Turning : On";
        }
        else
        {
            textObject.text = "Turning : Off";
        }
    }
}
