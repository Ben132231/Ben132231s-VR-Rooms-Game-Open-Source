using UnityEngine;

public class DebugPanelPreviousPage : MonoBehaviour
{
    public GameObject PageToEnable;
    public GameObject[] PagesToDisable;

    void OnDebugPreviousPage()
    {
        PageToEnable.SetActive(true);
        foreach (var pages in PagesToDisable)
        {
            pages.SetActive(false);
        }
    }
}
