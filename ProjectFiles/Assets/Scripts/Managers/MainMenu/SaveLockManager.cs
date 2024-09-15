using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLockManager : MonoBehaviour
{
    public Image LockIcon;
    public Sprite UnlockedIcon;
    public Sprite LockedIcon;

    public GameObject SaveMenu;
    public GameObject LoadGameWithCodeMenu;
    public GameObject SetCodeLockMenu;
    public GameObject RemoveLockCodeMenu;
    public GameObject MovementModeMenu;

    public Button DeleteSaveButton;
    public Button RenameSaveButton;
    public SaveSlot saveSlot;

    void Awake()
    {
        if (SavingManager.gameData.LockCode != "")
        {
            LockIcon.sprite = LockedIcon;
            DeleteSaveButton.interactable = false;
            RenameSaveButton.interactable = false;
        }
        else
        {
            DeleteSaveButton.interactable = true;
            RenameSaveButton.interactable = true;
            LockIcon.sprite = UnlockedIcon;
        }
    }

    public void UpdateLock()
    {
        if (SavingManager.gameData.LockCode != "")
        {
            LockIcon.sprite = LockedIcon;
            DeleteSaveButton.interactable = false;
            RenameSaveButton.interactable = false;
        }
        else
        {
            DeleteSaveButton.interactable = true;
            RenameSaveButton.interactable = true;
            LockIcon.sprite = UnlockedIcon;
        }
    }

    public void LoadButton()
    {
        if (SavingManager.gameData.LockedLoadButton && SavingManager.gameData.LockCode != "")
        {
            SaveMenu.SetActive(false);
            LoadGameWithCodeMenu.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Rooms");
        }
    }

    public void SetupLockCode()
    {
        if (SavingManager.gameData.LockCode != "")
        {
            RemoveLockCodeMenu.SetActive(true);
            SaveMenu.SetActive(false);
        }
        else
        {
            SetCodeLockMenu.SetActive(true);
            SaveMenu.SetActive(false);
        }
    }
}
