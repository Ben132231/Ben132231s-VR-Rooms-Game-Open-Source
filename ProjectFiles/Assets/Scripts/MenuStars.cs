using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStars : MonoBehaviour
{
    public Transform MenuRigTransform;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - MenuRigTransform.position);
    }
}
