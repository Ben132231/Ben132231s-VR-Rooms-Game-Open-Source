using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingTutorial : MonoBehaviour
{
    public GameObject Barrior;
    public AudioClip CorrectSound;
    bool once;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!once)
            {
                once = true;
                Barrior.SetActive(false);
                StuffManager.Instance.fastAudioManager.CreateFastAudio(CorrectSound, transform.position, 0.4f, 1f, 999f, true);
            }
        }
    }
}
