sealed class DefaultPlane : IPlane
{
    public string modelName { 
        get { return "DefaultPlane"; } 
    }

    public string planeName {
        get { return "Default Plane"; }
    }

    public int health {
        get { return 100; }
    }

    public float speed {
        get { return 30f; }
    }

    public int fireRate {
        get { return 20; }
    }

    public int armour {
        get { return 50; }
    }

    public PlaneAbility abilityOne { 
        get { return new DefaultPlaneAbilityOne(); } 
    }

    public PlaneAbility abilityTwo { 
        get { return new DefaultPlaneAbilityTwo(); } 
    }

    public PlaneAbility ultimateAbility { 
        get { return new DefaultPlaneUltimateAbility(); } 
    }
}

