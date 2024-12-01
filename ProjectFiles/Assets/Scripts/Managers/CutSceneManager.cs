using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public GameObject CutSceneRig;
    public Camera PlayerRigCamera;
    public AudioListener PlayerRigListener;

    public LayerMask nothingLayer;
    public LayerMask defaultLayer;

    public void CreateCutSceneRig(Vector3 CutSceneRigPosition, Quaternion CutSceneRigRotation)
    {
        if (CutSceneRigObject.Instance == null)
        {
            Instantiate(CutSceneRig, CutSceneRigPosition, CutSceneRigRotation);
            CutSceneRigObject.Instance.gameObject.GetComponentInChildren<Camera>().enabled = true;
            CutSceneRigObject.Instance.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            PlayerRigCamera.enabled = false;
            PlayerRigListener.enabled = false;
            Player.Instance.locomotionEnabledLayers = nothingLayer;
        }
    }

    public void DestroyCutSceneRig()
    {
        if (CutSceneRigObject.Instance != null)
        {
            CutSceneRigObject.Instance.gameObject.GetComponentInChildren<Camera>().enabled = false;
            CutSceneRigObject.Instance.gameObject.GetComponentInChildren<AudioListener>().enabled = false;
            PlayerRigCamera.enabled = true;
            PlayerRigListener.enabled = true;
            Destroy(CutSceneRigObject.Instance.gameObject);
            Player.Instance.locomotionEnabledLayers = defaultLayer;
        }
    }
}
