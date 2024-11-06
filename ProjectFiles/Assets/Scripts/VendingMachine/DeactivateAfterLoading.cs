using UnityEngine;

public class DeactivateAfterLoading : MonoBehaviour, ISaving
{
    public void FinishSave()
    {
        
    }

    public void Load()
    {
        gameObject.SetActive(false);
    }

    public void Save()
    {
        
    }
}
