using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    string message;
    float delay;

    public void MakeMessage(string message1, float delay1)
    {
        message = message1;
        delay = delay1;
        StartCoroutine("Message");
    }

    public void ClearMessage()
    {
        subtitleText.text = "";
    }

    IEnumerator Message()
    {
        subtitleText.text = message;
        yield return new WaitForSeconds(delay);
        subtitleText.text = "";
    }
}
