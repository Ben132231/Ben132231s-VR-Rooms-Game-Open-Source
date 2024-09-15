using UnityEngine;
using UnityEngine.SceneManagement;

public class SendPlayerToLevel : MonoBehaviour
{
    public int SceneIndex;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }

    public void SendToLevel()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
