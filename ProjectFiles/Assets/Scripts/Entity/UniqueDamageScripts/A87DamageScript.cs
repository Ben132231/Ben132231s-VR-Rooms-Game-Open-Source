using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A87DamageScript : MonoBehaviour
{
    public GameObject selfObject;

    public int[] RandomValue = new int[]
    {
        40,
        45,
        50,
        55,
        60,
        65,
    };

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Player.Instance.DamagePlayer(RandomValue[Random.Range(0, RandomValue.Length)]);
            Destroy(selfObject);
        }
    }
}
