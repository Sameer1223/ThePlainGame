using UnityEngine;

public class TestSecondaryPlaneAbilityOne : PlaneAbility
{
    public TestSecondaryPlaneAbilityOne() : base(2) {}

    public override void TriggerAbility()
    {
        Debug.Log("TestSecondary Plane Ability One");
    }
}