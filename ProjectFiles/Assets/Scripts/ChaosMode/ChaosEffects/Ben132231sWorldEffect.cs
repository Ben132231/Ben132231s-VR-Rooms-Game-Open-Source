using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ChaosEffects/Ben132231sWorldEffect")]
public class Ben132231sWorldEffect : ChaosEffect
{
    List<GameObject> rootObjects = new List<GameObject>();
    float Timer;

    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.WorldChanging;
    }

    protected override void OnActivate()
    {
        SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; i++)
        {
            MeshRenderer[] allMeshes = rootObjects[i].GetComponentsInChildren<MeshRenderer>();

            for (int m = 0; m < allMeshes.Length; m++)
            {
                allMeshes[m].material = ChaosStuffManager.Instance.BensWorldMat;
            }
        }
    }

    protected override void OnDeactivate()
    {
        
    }
}
