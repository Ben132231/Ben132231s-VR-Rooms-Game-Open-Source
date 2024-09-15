using UnityEngine;

public class RoomGenManager : MonoBehaviour
{
    private static RoomGenManager _instance;

    public static RoomGenManager Instance { get { return _instance; } }

    public int DoorNumber;
    public string Section = "A";
    public GameObject CurrentGeneratedRoom;
    public Transform EndOfRoomPoint;
    public Transform DestroyPoint;
    public Transform EntitySpawnPoint;
    public bool DisableEntitySpawning = false;
    public Light SunLight;
    public float SkyIntensity;

    [Header("Entity Stuff")]
    public Transform A154SpawnTransform;

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
