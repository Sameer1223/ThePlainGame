sealed class TestSecondaryPlane : IPlane
{
    public string modelName { 
        get { return "TestSecondary"; } 
    }

    public string planeName {
        get { return "Test Secondary"; }
    }

    public int health {
        get { return 150; }
    }

    public float speed {
        get { return 20f; }
    }

    public int fireRate {
        get { return 10; }
    }

    public int armour {
        get { return 100; }
    }

    public PlaneAbility abilityOne { 
        get { return new TestSecondaryPlaneAbilityOne(); } 
    }

    public PlaneAbility abilityTwo { 
        get { return new TestSecondaryPlaneAbilityTwo(); } 
    }

    public PlaneAbility ultimateAbility { 
        get { return new TestSecondaryPlaneUltimateAbility(); } 
    }
}
