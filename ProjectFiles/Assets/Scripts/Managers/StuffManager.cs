using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StuffManager : MonoBehaviour
{
    private static StuffManager _instance;

    public static StuffManager Instance { get { return _instance; } }

    public A87SpawnScript a87SpawnScript;
    public Transform JokeSpawnTransform;
    public bool IsCheating;
    public bool HasUsedCheckpoints;

    [Header("Managers")]
    public FastAudioManager fastAudioManager;
    public CutSceneManager cutSceneManager;
    public SubtitleManager subtitleManager;

    [Header("Screen Effects")]
    public Animator DeathScreenEffect;
    public Animator a108ScreenEffect;
    public Animator a176ScreenEffect;
    public PostProcessVolume a330StaticEffect;

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
