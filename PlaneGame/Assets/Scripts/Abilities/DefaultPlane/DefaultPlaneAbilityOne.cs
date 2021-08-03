using UnityEngine;

public class DefaultPlaneAbilityOne : PlaneAbility
{
    public DefaultPlaneAbilityOne() : base(2) {}

    public override void TriggerAbility()
    {
        Debug.Log("Default Plane Ability One");
    }
}