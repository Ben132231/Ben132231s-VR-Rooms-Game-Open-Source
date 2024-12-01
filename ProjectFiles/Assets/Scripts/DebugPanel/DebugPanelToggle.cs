using UnityEngine;
using UnityEngine.InputSystem;

public class DebugPanelToggle : MonoBehaviour
{
    [Header("Main Stuff")]
    public string DebugUIObjectName = "DebugUI";
    public GameObject OtherSpawnTransform;
    public GameObject InteractionRayObject;
    public Transform RespawnDebugUITransform;

    [Header("Debug Helper Text")]
    public GameObject HelperTextObject;
    public Transform RightHand;

    [Header("Other Useless Stuff")]
    public LineRenderer StupidLineToOtherSpawnTransform;
    public Transform LeftHandTransform;
    public Transform SpawnStuffHereText;
    // This is litterly just for looks

    bool toggle;
    GameObject DebugUIObject;

    void Awake()
    {
        InteractionRayObject.SetActive(false);
        OtherSpawnTransform.SetActive(false);
        DebugUIObject = GameObject.Find(DebugUIObjectName);
        DebugUIObject.SetActive(false);
    }

    void Update()
    {
        if (toggle)
        {
            DebugUIObject.transform.rotation = Quaternion.LookRotation(DebugUIObject.transform.position - Player.Instance.GorillaCamera.transform.position);
            HelperTextObject.transform.rotation = Quaternion.LookRotation(HelperTextObject.transform.position - Player.Instance.GorillaCamera.transform.position);
            HelperTextObject.transform.position = new Vector3(RightHand.position.x, RightHand.position.y + 0.08f, RightHand.position.z);
            if (StupidLineToOtherSpawnTransform != null)
            {
                StupidLineToOtherSpawnTransform.SetPosition(0, LeftHandTransform.position);
                StupidLineToOtherSpawnTransform.SetPosition(1, OtherSpawnTransform.transform.position);
            }
            if (SpawnStuffHereText != null)
            {
                SpawnStuffHereText.position = new Vector3(OtherSpawnTransform.transform.position.x, OtherSpawnTransform.transform.position.y + 0.4f, OtherSpawnTransform.transform.position.z);
                SpawnStuffHereText.rotation = Quaternion.LookRotation(SpawnStuffHereText.position - Player.Instance.GorillaCamera.transform.position);
            }
        }
    }

    public void OnDebugButton(InputAction.CallbackContext context)
    {
        if (SavingManager.gameData.DebugPanel_Enabled && RoomGenInfo.Instance.DoorNumber > 0)
        {
            toggle = !toggle;

            if (toggle)
            {
                InteractionRayObject.SetActive(true);
                DebugUIObject.SetActive(true);
                OtherSpawnTransform.SetActive(true);
                HelperTextObject.SetActive(true);
                StuffManager.Instance.IsCheating = true;
                DebugUIObject.transform.position = new Vector3(RespawnDebugUITransform.position.x, Player.Instance.GorillaCamera.transform.position.y, RespawnDebugUITransform.position.z);
            }
            else
            {
                InteractionRayObject.SetActive(false);
                DebugUIObject.SetActive(false);
                OtherSpawnTransform.SetActive(false);
                HelperTextObject.SetActive(false);
            }
        }
    }

    public void OnRespawnDebugUI(InputAction.CallbackContext context)
    {
        if (toggle)
        {
            DebugUIObject.transform.position = new Vector3(RespawnDebugUITransform.position.x, Player.Instance.GorillaCamera.transform.position.y, RespawnDebugUITransform.position.z);
        }
    }
}