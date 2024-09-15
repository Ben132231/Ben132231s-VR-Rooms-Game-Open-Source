using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SavingManager : MonoBehaviour
{
    public static SavingManager instance;

    private string dataPath;

    [SerializeField] private string CurrentSaveSlotName = "SaveSlot0";

    [SerializeField] private int AmountOfSaveSlots = 6;

    public static GameData gameData { get; private set; }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Load();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Find more then one SavingManager. Deleting one in scene");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        dataPath = Application.persistentDataPath + "/" + CurrentSaveSlotName + ".json";
    }

    public void LocalSave()
    {
        StreamWriter writer = new StreamWriter(dataPath);
        string dataString = JsonUtility.ToJson(gameData);

        writer.WriteLine(dataString);

        writer.Close();

        foreach (ISaving saveables in FindObjectsOfType<MonoBehaviour>().OfType<ISaving>())
        {
            saveables.FinishSave();
        }
    }

    public void Load()
    {
        if (!File.Exists(dataPath))
        {
            gameData = new GameData();
        }
        else
        {
            StreamReader reader = new StreamReader(dataPath);
            string dataString = reader.ReadToEnd();
            reader.Close();

            gameData = JsonUtility.FromJson<GameData>(dataString);

            foreach (ISaving saveables in FindObjectsOfType<MonoBehaviour>().OfType<ISaving>())
            {
                saveables.Load();
            }
        }
    }

    public void ChangeSaveSlotNum(string saveName)
    {
        CurrentSaveSlotName = saveName;
        dataPath = Application.persistentDataPath + "/" + saveName + ".json";
    }

    public bool SaveFileExist()
    {
        dataPath = Application.persistentDataPath + "/" + CurrentSaveSlotName + ".json";
        if (File.Exists(dataPath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<GameData> GetAllSaveFiles()
    {
        List<GameData> allGameDatas = new List<GameData>();
        GameData SelectedGameData = new GameData();

        for (int i = 1; i < AmountOfSaveSlots; i++)
        {
            string AllDataPath = Application.persistentDataPath + "/SaveSlot" + i.ToString() + ".json";
            if (File.Exists(AllDataPath))
            {
                StreamReader reader = new StreamReader(AllDataPath);
                string dataString = reader.ReadToEnd();
                reader.Close();

                SelectedGameData = JsonUtility.FromJson<GameData>(dataString);
                allGameDatas.Add(SelectedGameData);

                /* I'm not sure this is required.
                foreach (ISaving saveables in FindObjectsOfType<MonoBehaviour>().OfType<ISaving>())
                {
                    saveables.Load();
                }
                */
            }
        }

        return allGameDatas;
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(dataPath))
        {
            File.Delete(dataPath);
        }
    }

    public static void Save()
    {
        instance.LocalSave();
    }
}
