using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneRigObject : MonoBehaviour
{
    private static CutSceneRigObject _instance;

    public static CutSceneRigObject Instance { get { return _instance; } }

    public Transform GorillaCutSceneTransform;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
