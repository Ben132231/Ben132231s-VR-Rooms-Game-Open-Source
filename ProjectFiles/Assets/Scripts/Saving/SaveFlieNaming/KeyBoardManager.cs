using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class KeyBoardManager : MonoBehaviour, ISaving
{
    public string UsernameInput;
	public TextMeshProUGUI UsernameText;
	public AudioClip NameTakenSound;
    public int InputLength = 12;

    [Header("Reset Code Stuff")]
    public GameObject SetLockCodeMenu;
    public GameObject SaveSlotsMenu;

    public ToggleLockLoadButton toggleLockLoad;

    public AudioClip IncorrectCodeSound;

    public SaveLockManager[] lockManager;

    [Header("Replace Text")]
    public KeyBoardConfirm confirmKey;

    List<GameData> GameDatas;
    bool NameIsTaken;
    bool HasSetNewUsername;
    bool HasCorrectCode;

    void Awake()
    {
        GameDatas = SavingManager.instance.GetAllSaveFiles();
        HasSetNewUsername = false;
        HasCorrectCode = false;
    }

    void Update()
	{
		UsernameText.text = UsernameInput;
		if (UsernameInput.Length > InputLength)
		{
			UsernameInput = UsernameInput.Substring(0, InputLength);
		}
	}

	public void SetUsername()
    {
        foreach (var gameData in GameDatas)
        {
            if (UsernameInput == gameData.Username)
            {
                NameIsTaken = true;
            }
        }
        if (!NameIsTaken)
        {
            SavingManager.gameData.Username = UsernameInput;
            HasSetNewUsername = true;
            Save();
        }
        else
        {
            UsernameInput = "";
            NameIsTaken = false;
            StuffManager.Instance.fastAudioManager.CreateFastAudio(NameTakenSound, transform.position, 0.4f, 1f, 999f, true);
            foreach (var keys in confirmKey.AllKeys)
            {
                keys.interactable = true;
            }
        }
	}

    public void SetLockCode()
    {
        if (UsernameInput != "" && UsernameInput.Length == 4 || UsernameInput.Length == 6)
        {
            if (toggleLockLoad.toggle)
            {
                SavingManager.gameData.LockedLoadButton = true;
            }
            SavingManager.gameData.LockCode = UsernameInput;
            Save();

            // Stupid Code
            for (int i = 0; i < lockManager.Length; i++)
            {
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("1"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("2"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("3"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("4"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("5"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("6"))
                {
                    lockManager[i].UpdateLock();
                }
            }

            if (SetLockCodeMenu != null && SaveSlotsMenu != null)
            {
                SetLockCodeMenu.SetActive(false);
                SaveSlotsMenu.SetActive(true);
            }
            else
            {
                Debug.Log("MENU MISSING FROM KEYBOARD MANAGER HELP");
            }
        }
    }

    public void RemoveLockCode()
    {
        if (SavingManager.gameData.LockCode == UsernameInput)
        {
            SavingManager.gameData.LockCode = "";
            Save();

            // Stupid Code
            for (int i = 0; i < lockManager.Length; i++)
            {
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("1"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("2"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("3"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("4"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("5"))
                {
                    lockManager[i].UpdateLock();
                }
                if (lockManager[i].saveSlot.SaveFileSlotName.Contains("6"))
                {
                    lockManager[i].UpdateLock();
                }
            }

            if (SetLockCodeMenu != null && SaveSlotsMenu != null)
            {
                SetLockCodeMenu.SetActive(false);
                SaveSlotsMenu.SetActive(true);
            }
            else
            {
                Debug.Log("MENU MISSING FROM KEYBOARD MANAGER HELP");
            }
        }
        else
        {
            StuffManager.Instance.fastAudioManager.CreateFastAudio(IncorrectCodeSound, transform.position, 0.4f, 1f, 999f, true);
        }
    }

    public void LoadGameWithCode()
    {
        if (SavingManager.gameData.LockCode == UsernameInput)
        {
            HasCorrectCode = true;
            Save();
        }
        else
        {
            StuffManager.Instance.fastAudioManager.CreateFastAudio(IncorrectCodeSound, transform.position, 0.4f, 1f, 999f, true);
        }
    }

    public void Load()
    {
        
    }

    public void Save()
    {
        SavingManager.Save();
        UsernameInput = "";
    }

    public void FinishSave()
    {
        if (HasSetNewUsername)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (HasCorrectCode)
        {
            SceneManager.LoadScene("Rooms");
        }
    }
}
