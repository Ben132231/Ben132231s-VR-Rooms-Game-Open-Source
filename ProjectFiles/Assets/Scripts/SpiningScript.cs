using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningScript : MonoBehaviour
{
    public float SpinSpeed;

    void Update()
    {
        transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
    }
}
