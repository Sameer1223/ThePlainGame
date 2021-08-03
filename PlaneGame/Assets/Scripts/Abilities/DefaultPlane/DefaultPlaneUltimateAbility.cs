using UnityEngine;

public class DefaultPlaneUltimateAbility : PlaneAbility
{
    public DefaultPlaneUltimateAbility() : base(6) {}

    public override void TriggerAbility()
    {
        Debug.Log("Default Plane Ultimate Ability");
    }
}