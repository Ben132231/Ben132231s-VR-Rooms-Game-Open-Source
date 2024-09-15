using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteSaveData : MonoBehaviour
{
    public int SetPressedAmount = 40;
    public TextMeshProUGUI textObject;
    public Button DeleteSaveButton;
    public Button BackButton;

    int PressedAmount = 45;

    void OnEnable()
    {
        ResetPressedAmount();
    }

    public void PressDeleteDataButton()
    {
        PressedAmount -= 1;
        textObject.text = "Presses Left: " + PressedAmount;
        if (PressedAmount <= 0)
        {
            SavingManager.instance.DeleteSaveFile();
            DeleteSaveButton.interactable = false;
            BackButton.interactable = false;
            StartCoroutine(ResetLevel());
        }
    }

    public void ResetPressedAmount()
    {
        PressedAmount = SetPressedAmount;
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
