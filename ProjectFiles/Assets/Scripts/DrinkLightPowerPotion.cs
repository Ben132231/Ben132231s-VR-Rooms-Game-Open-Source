using UnityEngine;
using System.Collections;

public class DrinkLightPowerPotion : MonoBehaviour
{
    public Color ChangedColor;
    public Color ChangedOuterSphereColor;
    public Color ChangedInnerSphereColor;
    public int IndexToChangeLightPower;

    public AudioClip PotionDrinkingSound;
    public AudioClip PotionEffectFinishSound;

    Collider SelfCollider;
    MeshRenderer SelfMesh;
    MeshRenderer[] OtherMeshes;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            StartCoroutine(UsePotion());
            SelfCollider.enabled = false;
            SelfMesh.enabled = false;
            foreach (var otherMeshes in OtherMeshes)
            {
                otherMeshes.enabled = false;
            }
        }
    }

    void Awake()
    {
        SelfCollider = GetComponent<Collider>();
        SelfMesh = GetComponent<MeshRenderer>();
        OtherMeshes = GetComponentsInChildren<MeshRenderer>();
    }

    IEnumerator UsePotion()
    {
        // Audio Stuff
        StuffManager.Instance.fastAudioManager.CreateFastAudio(PotionDrinkingSound, Camera.main.transform.position, 0.4f, 1f, 10f, true);

        yield return new WaitForSeconds(3.5f);

        SelfMesh.enabled = true;
        Player.Instance.DisableAllLightPowers();
        Player.Instance.ToggleLights(false);

        foreach (var otherMeshes in OtherMeshes)
        {
            if (!otherMeshes.gameObject.name.Contains("Potion_Liquid") && !otherMeshes.gameObject.name.Contains("Cork"))
            {
                otherMeshes.enabled = true;
            }
        }

        yield return new WaitForSeconds(4.5f);

        Player.Instance.SetCurrentHeadSpotLight(IndexToChangeLightPower);
        Player.Instance.ToggleLights(true);
        Player.Instance.ChangeLightsColors(ChangedColor);
        Player.Instance.ChangeHandSpheresColor(ChangedOuterSphereColor, ChangedInnerSphereColor);
        StuffManager.Instance.fastAudioManager.CreateFastAudio(PotionEffectFinishSound, Camera.main.transform.position, 0.4f, 1f, 10f, true);
    }
}
