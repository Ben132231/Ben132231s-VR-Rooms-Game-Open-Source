using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            Application.Quit();
        }
    }
}
