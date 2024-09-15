using UnityEngine;

[CreateAssetMenu(menuName = "ChaosEffects/SlowModeEffect")]
public class SlowModeEffect : ChaosEffect
{
    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.GravityChange;
    }

    protected override void OnActivate()
    {
        Time.timeScale = 0.5f;
    }

    protected override void OnDeactivate()
    {
        Time.timeScale = 1f;
    }
}
