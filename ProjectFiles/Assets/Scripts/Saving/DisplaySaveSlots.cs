using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DisplaySaveSlots : MonoBehaviour
{
    [HelpBox("Make sure the list of numbers in SaveFileNums go up to the max number in AmountOfSaveSlots in SavingManager Prefab.\nAnd that the numbers list in SaveFileNums match the amount of names in SaveUsernames match.\nBen132231 Note : This is annoying just trying to get this to work.")]
    public TextMeshProUGUI[] SaveUsernames;

    public int[] SaveFileNums = new int[]
    {
        1,
        2,
        3,
        4,
        5,
        6
    };


    string DataPath;
    GameData gameData;

    private void OnEnable()
    {
        for (int i = 0; i < SaveFileNums.Length; i++)
        {
            DataPath = Application.persistentDataPath + "/SaveSlot" + SaveFileNums[i].ToString() + ".json";

            if (File.Exists(DataPath))
            {
                StreamReader reader = new StreamReader(DataPath);
                string dataString = reader.ReadToEnd();
                reader.Close();

                gameData = JsonUtility.FromJson<GameData>(dataString);

                if (SaveUsernames[i] != null)
                {
                    SaveUsernames[i].text = "Username : " + gameData.Username;
                }
            }
        }
    }
}
