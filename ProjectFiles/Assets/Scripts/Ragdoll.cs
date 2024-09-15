using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public GameObject LeftHandObject;
    public GameObject LeftHandObjectInner;
    public GameObject RightHandObject;
    public GameObject RightHandObjectInner;
    public GameObject HeadObject;
    public GameObject HeadObjectInner;

    void Awake()
    {
        LeftHandObject.transform.position = GorillaLocomotion.Player.Instance.leftHandTransform.position;
        RightHandObject.transform.position = GorillaLocomotion.Player.Instance.leftHandTransform.position;
        HeadObject.transform.position = GorillaLocomotion.Player.Instance.GorillaCamera.transform.position;

        LeftHandObject.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.OuterLayerColor;
        RightHandObject.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.OuterLayerColor;
        HeadObject.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.InnerLayerColor;

        LeftHandObjectInner.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.InnerLayerColor;
        RightHandObjectInner.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.InnerLayerColor;
        HeadObjectInner.GetComponent<MeshRenderer>().material.color = GorillaLocomotion.Player.Instance.InnerLayerColor;
    }
}
