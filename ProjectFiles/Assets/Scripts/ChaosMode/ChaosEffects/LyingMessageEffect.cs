using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "ChaosEffects/LyingMessageEffect")]
public class LyingMessageEffect : ChaosEffect
{
    GameObject message;

    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.Message;
    }

    protected override void OnActivate()
    {
        Vector3 playerPos = new Vector3(GorillaLocomotion.Player.Instance.GorillaCamera.transform.position.x, GorillaLocomotion.Player.Instance.GorillaCamera.transform.position.y, GorillaLocomotion.Player.Instance.GorillaCamera.transform.position.z + 3f);
        message = Instantiate(ChaosStuffManager.Instance.MessageBoard, playerPos, Quaternion.identity);
        message.transform.rotation = Quaternion.LookRotation(message.transform.position - GorillaLocomotion.Player.Instance.GorillaCamera.transform.position);

        int messageIndex = Random.Range(0, ChaosStuffManager.Instance.LyingMessages.Length);
        message.GetComponent<TextMeshPro>().text = ChaosStuffManager.Instance.LyingMessages[messageIndex];
    }

    protected override void OnDeactivate()
    {
        Destroy(message);
    }
}
