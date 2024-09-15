using UnityEngine;

[CreateAssetMenu(menuName = "ChaosEffects/JupiterGravityEffect")]
public class JupiterGravityEffect : ChaosEffect
{
    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.GravityChange;
    }

    protected override void OnActivate()
    {
        Physics.gravity = new Vector3(0, -24.79f, 0);
    }

    protected override void OnDeactivate()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }
}
