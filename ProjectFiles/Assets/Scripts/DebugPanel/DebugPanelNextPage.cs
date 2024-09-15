using UnityEngine;

public class DebugPanelNextPage : MonoBehaviour
{
    public GameObject PageToEnable;
    public GameObject[] PagesToDisable;

    void OnDebugNextPage()
    {
        PageToEnable.SetActive(true);
        foreach (var pages in PagesToDisable)
        {
            pages.SetActive(false);
        }
    }
}
