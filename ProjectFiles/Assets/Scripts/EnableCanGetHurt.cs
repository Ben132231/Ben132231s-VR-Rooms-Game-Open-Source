using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanGetHurt : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            GorillaLocomotion.Player.Instance.CanGetDamage = true;
        }
    }
}
