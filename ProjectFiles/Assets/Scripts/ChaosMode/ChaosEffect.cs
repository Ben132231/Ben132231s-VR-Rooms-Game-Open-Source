using System.Collections;
using UnityEngine;

public enum ChaosEffectType
{
    None,
    GravityChange,
    TimeScale,
    EntitySpawning,
    WorldChanging,
    Message
}

public abstract class ChaosEffect : ScriptableObject
{
    public string EventName;
    public float duration = 20f;
    public ChaosEffectType chaosEffectType;

    public void Activate()
    {
        OnActivate();
        if (duration > 0)
        {
            CoroutineRunner.Instance.StartCoroutine(DeactivateAfterTime());
        }
    }

    public void Deactivate()
    {
        OnDeactivate();
    }

    public IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(duration);
        OnDeactivate();
    }

    protected abstract void OnActivate();

    protected abstract void OnDeactivate();
}