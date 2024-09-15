using UnityEngine;

public class CheckIfTestExist : MonoBehaviour
{
    public GameObject Wall2;
    GameObject TestEntity;

    // Update is called once per frame
    void Update()
    {
        TestEntity = GameObject.Find("TestA12(Clone)");
        if (TestEntity == null)
        {
            Wall2.SetActive(false);
        }
        else
        {
            Wall2.SetActive(true);
        }
    }
}
