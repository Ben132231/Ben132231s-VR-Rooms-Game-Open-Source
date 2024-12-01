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
        if (RoomGenInfo.Instance.DoorNumber < 10)
        {
            PlateNumberText.text = RoomGenInfo.Instance.Section + "-00" + RoomGenInfo.Instance.DoorNumber;
        }
        else if (RoomGenInfo.Instance.DoorNumber < 100)
        {
            PlateNumberText.text = RoomGenInfo.Instance.Section + "-0" + RoomGenInfo.Instance.DoorNumber;
        }
        else if (RoomGenInfo.Instance.DoorNumber < 1000)
        {
            PlateNumberText.text = RoomGenInfo.Instance.Section + "-" + RoomGenInfo.Instance.DoorNumber;
        }
    }
}
