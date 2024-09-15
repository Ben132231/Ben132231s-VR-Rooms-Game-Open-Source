using UnityEngine;

[CreateAssetMenu(menuName = "ChaosEffects/UpsideDownEffect")]
public class UpsideDownEffect : ChaosEffect
{
    private void OnEnable()
    {
        chaosEffectType = ChaosEffectType.GravityChange;
    }

    protected override void OnActivate()
    {
        Physics.gravity = new Vector3(0, 9.81f, 0);
        GorillaLocomotion.Player.Instance.UpsideDown();
    }

    protected override void OnDeactivate()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        GorillaLocomotion.Player.Instance.StandUpRight();
    }
}
