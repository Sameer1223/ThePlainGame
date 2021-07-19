interface IPlane {
    string modelName { get; }
    string planeName { get; }
    int health { get; }
    float speed { get; }
    int fireRate { get; }
    int armour { get; }    
    PlaneAbility abilityOne { get; }
    PlaneAbility abilityTwo { get; }
    PlaneAbility ultimateAbility { get; }
}