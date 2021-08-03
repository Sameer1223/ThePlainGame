using UnityEngine;

public class TestSecondaryPlaneUltimateAbility : PlaneAbility
{
    public TestSecondaryPlaneUltimateAbility() : base(6) {}

    public override void TriggerAbility()
    {
        Debug.Log("TestSecondary Plane Ultimate Ability");
    }
}