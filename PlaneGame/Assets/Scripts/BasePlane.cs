public class BasePlane
{
    // Properties
    private string modelName;
    private string planeName;
    private int health;
    private float speed;
    private int fireRate;
    private int armour;
    //private PlaneAbility passiveAbility;
    private PlaneAbility abilityOne;
    private PlaneAbility abilityTwo;
    private PlaneAbility ultimateAbility;

    // Base Plane Constructor
    public BasePlane(string modelName, string planeName, int health, float speed, int fireRate, int armour, 
    PlaneAbility abilityOne, PlaneAbility abilityTwo, PlaneAbility ultimateAbility) {
        this.modelName = modelName;
        this.planeName = planeName;
        this.health = health;
        this.speed = speed;
        this.fireRate = fireRate;
        this.armour = armour;
        this.abilityOne = abilityOne;
        this.abilityTwo = abilityTwo;
        this.ultimateAbility = ultimateAbility;
    }

    // Getters and setters
    public string getModelName() { return this.modelName; }

    public string getPlaneName() { return this.planeName; }
    public void setPlaneName(string planeName){ this.planeName = planeName; }
 
    public int getHealth() { return this.health; }
    public void setHealth(int health){ this.health = health; }
    
    public float getSpeed() { return this.speed; }
    public void setSpeed(float speed){ this.speed = speed; }
    
    public int getFireRate() { return this.fireRate; }
    public void setFireRate(int fireRate){ this.fireRate = fireRate; }
    
    public int getArmour() { return this.armour; }
    public void setArmour(int armour){ this.armour = armour; }

    public PlaneAbility getAbilityOne() { return this.abilityOne; }
    public PlaneAbility getAbilityTwo() { return this.abilityTwo; }
    public PlaneAbility getUltimateAbility() { return this.ultimateAbility; }
}
