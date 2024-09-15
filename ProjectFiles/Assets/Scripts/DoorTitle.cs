using TMPro;
using UnityEngine;

public class DoorTitle : MonoBehaviour
{
    TextMeshPro PlateNumberText;

    void Awake()
    {
        PlateNumberText = GetComponentInChildren<TextMeshPro>();
    }

    public void UpdateDoorTitle()
    {
        if (RoomGenManager.Instance.DoorNumber < 10)
        {
            PlateNumberText.text = RoomGenManager.Instance.Section + "-00" + RoomGenManager.Instance.DoorNumber;
        }
        else if (RoomGenManager.Instance.DoorNumber < 100)
        {
            PlateNumberText.text = RoomGenManager.Instance.Section + "-0" + RoomGenManager.Instance.DoorNumber;
        }
        else if (RoomGenManager.Instance.DoorNumber < 1000)
        {
            PlateNumberText.text = RoomGenManager.Instance.Section + "-" + RoomGenManager.Instance.DoorNumber;
        }
    }
}
