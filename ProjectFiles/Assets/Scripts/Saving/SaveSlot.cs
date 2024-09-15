using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [Header("Save Stuff")]
    public string SaveFileSlotName = "SaveSlot1";

    [Header("Texts & Objects")]
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DeathCountText;
    public TextMeshProUGUI DoorsOpenedText;
    public TextMeshProUGUI EntitysEncounteredText;
    public GameObject HasBeatASectionBadge;
    public GameObject HasStupidBadge;

    public GameObject DeleleSaveButton;
    public GameObject LoadButton;
    public GameObject NewButton;
    public GameObject LockButton;
    public GameObject RenameButton;

    private void OnEnable()
    {
        SavingManager.instance.ChangeSaveSlotNum(SaveFileSlotName);
        SavingManager.instance.Load();
        bool HasSaveFile = SavingManager.instance.SaveFileExist();

        if (HasSaveFile)
        {
            NameText.text = "Name: " + SavingManager.gameData.Username;
            DeathCountText.text = "Death Count: " + SavingManager.gameData.deathCount.ToString();
            DoorsOpenedText.text = "Doors Opened: " + SavingManager.gameData.doorsOpened.ToString();
            EntitysEncounteredText.text = "Entitys Encountered: " + SavingManager.gameData.entitysEncounterd.ToString();
            if (SavingManager.gameData.HasBeatASection)
            {
                HasBeatASectionBadge.SetActive(true);
            }
            if (SavingManager.gameData.StupidBadge)
            {
                HasStupidBadge.SetActive(true);
            }

            DeleleSaveButton.SetActive(true);
            NewButton.SetActive(false);
            LoadButton.SetActive(true);
            LockButton.SetActive(true);
            RenameButton.SetActive(true);
        }
        else
        {
            NameText.text = "Name: " + "Empty";
            DeathCountText.text = "Death Count: " + "Empty";
            DoorsOpenedText.text = "Doors Opened: " + "Empty";
            EntitysEncounteredText.text = "Entitys Encountered: " + "Empty";
            if (!SavingManager.gameData.HasBeatASection)
            {
                HasBeatASectionBadge.SetActive(false);
            }
            if (!SavingManager.gameData.StupidBadge)
            {
                HasStupidBadge.SetActive(false);
            }


            DeleleSaveButton.SetActive(false);
            NewButton.SetActive(true);
            LoadButton.SetActive(false);
            LockButton.SetActive(false);
            RenameButton.SetActive(false);
        }
    }

    private void OnDisable()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Rooms");
    }
}
