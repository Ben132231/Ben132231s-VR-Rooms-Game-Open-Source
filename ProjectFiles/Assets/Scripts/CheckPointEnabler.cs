using System.Collections;
using UnityEngine;

public class CheckPointEnabler : MonoBehaviour, ISaving
{
    [Header("A-50")]
    public GameObject A50_Mesh;
    public Collider A50_Collider;

    [Header("A-100")]
    public GameObject A100_Mesh;
    public Collider A100_Collider;

    [Header("A-150")]
    public GameObject A150_Mesh;
    public Collider A150_Collider;

    [Header("A-200")]
    public GameObject A200_Mesh;
    public Collider A200_Collider;

    [Header("A-300")]
    public GameObject A300_Mesh;
    public Collider A300_Collider;

    public void Save()
    {

    }

    public void FinishSave()
    {
        
    }

    public void Load()
    {
        StartCoroutine(ShowCheckPoints());
    }

    IEnumerator ShowCheckPoints()
    {
        yield return new WaitForSeconds(2f);
        if (SavingManager.gameData.Reach_A50)
        {
            A50_Mesh.SetActive(true);
            A50_Collider.enabled = true;
        }
        if (SavingManager.gameData.Reach_A100)
        {
            A100_Mesh.SetActive(true);
            A100_Collider.enabled = true;
        }
        if (SavingManager.gameData.Reach_A150)
        {
            A150_Mesh.SetActive(true);
            A150_Collider.enabled = true;
        }
        if (SavingManager.gameData.Reach_A200)
        {
            A200_Mesh.SetActive(true);
            A200_Collider.enabled = true;
        }
        if (SavingManager.gameData.Reach_A300)
        {
            A300_Mesh.SetActive(true);
            A300_Collider.enabled = true;
        }
    }
}
