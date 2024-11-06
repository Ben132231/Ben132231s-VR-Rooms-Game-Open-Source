using UnityEngine;

public class SetTurnSpeed : MonoBehaviour, ISaving
{
    public float Speed = 65;

    public void SetSpeed()
    {
        SavingManager.gameData.PlayerTurnSpeed = Speed;
        Save();
    }

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
}
