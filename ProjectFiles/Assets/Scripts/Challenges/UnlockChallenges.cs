using UnityEngine;

public class UnlockChallenges : MonoBehaviour, ISaving
{
    public void FinishSave()
    {
        
    }

    public void Load()
    {
        if (SavingManager.gameData.doorsOpened >= 100)
        {
            gameObject.SetActive(false);
        }
    }

    public void Save()
    {
        
    }
}
