using UnityEngine;

public class EasyAccessDebugPanel : MonoBehaviour, ISaving
{
    public void FinishSave()
    {
        
    }

    public void Load()
    {
        if (SavingManager.gameData.DebugPanel_Enabled)
        {
            gameObject.SetActive(false);
        }
    }

    public void Save()
    {
        SavingManager.Save();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            SavingManager.gameData.DebugPanel_Enabled = true;
            Save();
            gameObject.SetActive(false);
        }
    }
}
