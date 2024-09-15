using UnityEngine;
using TMPro;

public class StatsBoard : MonoBehaviour
{
    public float SetTimer = 4f;

    public TextMeshPro DeathCountText;
    public TextMeshPro DoorsOpenedText;
    public TextMeshPro EntitysEncounterdText;

    float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            DeathCountText.text = "Death Count: " + SavingManager.gameData.deathCount;
            DoorsOpenedText.text = "Doors Opened: " + SavingManager.gameData.doorsOpened;
            EntitysEncounterdText.text = "Entitys Encounterd: " + SavingManager.gameData.entitysEncounterd;
            Timer = SetTimer;
        }
    }
}
