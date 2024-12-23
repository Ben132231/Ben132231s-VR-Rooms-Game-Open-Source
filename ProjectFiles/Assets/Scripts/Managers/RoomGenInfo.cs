using UnityEngine;

public class RoomGenInfo : MonoBehaviour
{
    private static RoomGenInfo _instance;

    public static RoomGenInfo Instance { get { return _instance; } }

    public RoomGen roomGen;
    public int DoorNumber;
    public string Section = "A";
    public int EndingRoomNumber = 399;
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
