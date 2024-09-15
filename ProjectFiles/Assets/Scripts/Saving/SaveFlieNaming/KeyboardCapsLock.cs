using UnityEngine;
using TMPro;

public class KeyboardCapsLock : MonoBehaviour
{
    public GameObject Caps;
    public GameObject LowersCaps;
	public TextMeshProUGUI CapsKeyText;
	public AudioClip KeyPressedSound;

    bool toggle;

    void Awake()
    {
		Caps.SetActive(false);
		LowersCaps.SetActive(true);
		CapsKeyText.text = "caps";
		toggle = false;
	}

    public void CapsToggle()
	{
		StuffManager.Instance.fastAudioManager.CreateFastAudio(KeyPressedSound, transform.position, 0.4f, Random.Range(0.8f, 1.2f), 8f, false);
		if (!toggle)
		{
			Caps.SetActive(true);
			LowersCaps.SetActive(false);
			CapsKeyText.text = "CAPS";
			toggle = true;
		}
		else
		{
			Caps.SetActive(false);
			LowersCaps.SetActive(true);
			CapsKeyText.text = "caps";
			toggle = false;
		}
	}
}
