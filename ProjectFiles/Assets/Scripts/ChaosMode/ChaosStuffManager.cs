using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosStuffManager : MonoBehaviour
{
    private static ChaosStuffManager _instance;
    public static ChaosStuffManager Instance { get { return _instance; } }

    [Header("Chaos Effect Stuff")]
    public GameObject[] Entities;
    public GameObject MessageBoard;
    public Material BensWorldMat;

    [Header("Chaos Mode Messages")]
    public string[] LyingMessages;

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
