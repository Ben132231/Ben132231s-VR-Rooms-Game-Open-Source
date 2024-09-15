using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public void AddToDeathCount()
    {
        SavingManager.gameData.deathCount += 1;
    }

    public void AddToDoorsOpened()
    {
        SavingManager.gameData.doorsOpened += 1;
    }

    public void AddToEntitysEncounterd()
    {
        SavingManager.gameData.entitysEncounterd += 1;
    }

    public void HasBeatASection()
    {
        SavingManager.gameData.HasBeatASection = true;
    }
}
