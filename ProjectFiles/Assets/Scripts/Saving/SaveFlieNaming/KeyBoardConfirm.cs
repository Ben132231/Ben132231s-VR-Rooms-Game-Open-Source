using UnityEngine.UI;
using UnityEngine;

public class KeyBoardConfirm : MonoBehaviour
{
	public KeyBoardManager keyBoardManager;
	public AudioClip KeyPressSound;
	public AudioClip NoInputSound;

	public Button[] AllKeys;

    public void Confirm()
	{
		if (keyBoardManager.UsernameInput != "")
		{
            foreach (var key in AllKeys)
            {
				key.interactable = false;
			}
			keyBoardManager.SetUsername();
			StuffManager.Instance.fastAudioManager.CreateFastAudio(KeyPressSound, transform.position, 0.4f, Random.Range(0.8f, 1.2f), 999f, true);
		}
		else
		{
			StuffManager.Instance.fastAudioManager.CreateFastAudio(NoInputSound, transform.position, 0.4f, 1f, 999f, true);
			keyBoardManager.UsernameText.text = "Name can't be nothing.";
		}
	}
}
