using System.Collections;
using UnityEngine;

public class KeyBoardKeyInput : MonoBehaviour
{
	public KeyBoardManager keyBoardManager;
	public AudioClip KeyPressSound;

    public void KeyInput(string Letter)
	{
		if (Letter == "Clear")
		{
			keyBoardManager.UsernameInput = "";
		}
		else
		{
			keyBoardManager.UsernameInput += Letter;
			StuffManager.Instance.fastAudioManager.CreateFastAudio(KeyPressSound, transform.position, 0.4f, Random.Range(0.8f, 1.2f), 999f, true);
		}
	}
}
