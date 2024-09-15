using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public float maxDistance = 60f;

    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[0] = maxDistance;
        distances[6] = maxDistance;
        distances[8] = maxDistance;
        distances[9] = maxDistance;
        camera.layerCullSpherical = true;
        camera.layerCullDistances = distances;
    }
}
