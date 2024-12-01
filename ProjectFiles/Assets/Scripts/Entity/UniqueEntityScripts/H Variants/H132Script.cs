using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class H132Script : MonoBehaviour
{
    public Image[] H132Sprites;
    public AudioSource audioSource;
    public AudioClip LineAudioClip;
    public AudioClip MagicAudioClip;
    public Animator animator;
    public Animator animator2;
    public float EntitySpawnDis = 150f;
    public float EntitySpawnDis2 = 350f;

    int MaxEntitysToPick;
    int EntityToPick;

    [Header("Entity Prefabs and Spawn Scripts")]
    public GameObject A12Prefab;
    public GameObject A38Prefab;
    public GameObject A60Prefab;
    public GameObject A108Prefab;
    public GameObject A176Prefab;
    public GameObject A200Prefab;
    public GameObject A228Prefab;

    void Awake()
    {
        foreach (var sprites in H132Sprites)
        {
            sprites.enabled = true;
        }
        MaxEntitysToPick = 12;
        EntityToPick = Random.Range(1, MaxEntitysToPick);
        StartCoroutine(BeginSummoning());
    }

    IEnumerator BeginSummoning()
    {
        if (EntityToPick == 1)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A12Anim");
            animator2.Play("A132_A38Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A38Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 2)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A12Anim");
            animator2.Play("A132_A60Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A60Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 3)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A38Anim");
            animator2.Play("A132_A60Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A38Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A60Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 4)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A60Anim");
            animator2.Play("A132_A87Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A60Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            StuffManager.Instance.a87SpawnScript.ForceSpawn();
            Destroy(gameObject);
        }
        else if (EntityToPick == 5)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A60Anim");
            animator2.Play("A132_A108Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A60Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A108Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            StuffManager.Instance.a108ScreenEffect.Play("A108_ScreenEffectAnim");
            Destroy(gameObject);
        }
        else if (EntityToPick == 6)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A12Anim");
            animator2.Play("A132_A108Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A108Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            StuffManager.Instance.a108ScreenEffect.Play("A108_ScreenEffectAnim");
            Destroy(gameObject);
        }
        else if (EntityToPick == 7)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A176Anim");
            animator2.Play("A132_A38Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A176Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A38Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 8)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A176Anim");
            animator2.Play("A132_A200Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A176Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A200Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, 4.5f), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 9)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A12Anim");
            animator2.Play("A132_A200Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Instantiate(A200Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, 4.5f), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 10)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A12Anim");
            animator2.Play("A132_A12Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A12Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 11)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A228Anim");
            animator2.Play("A132_A38Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A228Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A38Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (EntityToPick == 12)
        {
            yield return new WaitForSeconds(3f);
            animator.Play("A132_A228Anim");
            animator2.Play("A132_A60Anim");
            yield return new WaitForSeconds(3f);
            audioSource.PlayOneShot(LineAudioClip);
            yield return new WaitForSeconds(5f);
            foreach (var sprites in H132Sprites)
            {
                sprites.enabled = false;
            }
            audioSource.PlayOneShot(MagicAudioClip);
            yield return new WaitForSeconds(2f);
            Instantiate(A228Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis), Quaternion.identity);
            Instantiate(A60Prefab, RoomGenInfo.Instance.DestroyPoint.position + new Vector3(0, 0, -EntitySpawnDis2), Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
