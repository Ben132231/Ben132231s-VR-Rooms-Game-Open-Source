using UnityEngine;

public class VendingMachineCheckUnlock : MonoBehaviour, ISaving
{
    public UnlockType unlockType;
    public int UnlockAmount = 100;

    public GameObject InfoToUnlockText;
    public GameObject DispenseOption;

    public void FinishSave()
    {

    }

    public void Load()
    {
        if (unlockType == UnlockType.Doors)
        {
            if (SavingManager.gameData.doorsOpened >= UnlockAmount)
            {
                DispenseOption.SetActive(true);
                InfoToUnlockText.SetActive(false);
            }
            else
            {
                DispenseOption.SetActive(false);
                InfoToUnlockText.SetActive(true);
            }
        }
        if (unlockType == UnlockType.Deaths)
        {
            if (SavingManager.gameData.deathCount >= UnlockAmount)
            {
                DispenseOption.SetActive(true);
                InfoToUnlockText.SetActive(false);
            }
            else
            {
                DispenseOption.SetActive(false);
                InfoToUnlockText.SetActive(true);
            }
        }
        if (unlockType == UnlockType.Entitys)
        {
            if (SavingManager.gameData.entitysEncounterd >= UnlockAmount)
            {
                DispenseOption.SetActive(true);
                InfoToUnlockText.SetActive(false);
            }
            else
            {
                DispenseOption.SetActive(false);
                InfoToUnlockText.SetActive(true);
            }
        }
    }

    public void Save()
    {

    }
}

public enum UnlockType
{
    Doors,
    Deaths,
    Entitys
}