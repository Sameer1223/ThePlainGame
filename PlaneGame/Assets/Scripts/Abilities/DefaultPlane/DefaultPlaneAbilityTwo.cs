using UnityEngine;

public class DefaultPlaneAbilityTwo : PlaneAbility
{
    public DefaultPlaneAbilityTwo() : base(4) {}

    public override void TriggerAbility()
    {
        Debug.Log("Default Plane Ability Two");
    }
}