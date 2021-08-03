using UnityEngine;

public class TestSecondaryPlaneAbilityTwo : PlaneAbility
{
    public TestSecondaryPlaneAbilityTwo() : base(4) {}

    public override void TriggerAbility()
    {
        Debug.Log("TestSecondary Plane Ability Two");
    }
}