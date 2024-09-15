using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour, ISaving
{
    bool DoorUsed;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand") && !DoorUsed)
        {
            StartCoroutine(EndingTutorials());
            DoorUsed = true;
        }
    }

    IEnumerator EndingTutorials()
    {
        SavingManager.gameData.HasBeatTutorial = true;
        Save();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Rooms");
    }

    public void Load()
    {
        
    }

    public void Save()
    {
        SavingManager.Save();
    }

    public void FinishSave()
    {
        
    }
}
