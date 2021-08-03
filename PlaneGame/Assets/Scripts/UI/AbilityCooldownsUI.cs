using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownsUI : MonoBehaviour {
    public BasePlane plane;
    public Text abilityOneCooldown;
    public Text abilityTwoCooldown;
    public Text ultimateAbilityCooldown;
    
    public Color red = new Color32(250, 68, 84, 255);
    public Color green = new Color32(0, 255, 196, 255);

    public void OnPlaneSelection(){
        plane = PlaneSelection.player;
    }

    void Update() {
        abilityOneCooldown.text = plane.getAbilityOne().getCooldown() == 0 ? "A" : Mathf.RoundToInt(plane.getAbilityOne().getCooldown()).ToString();
        abilityOneCooldown.color = plane.getAbilityOne().getCooldown() == 0 ? green : red;
        abilityTwoCooldown.text = plane.getAbilityTwo().getCooldown() == 0 ? "B" : Mathf.RoundToInt(plane.getAbilityTwo().getCooldown()).ToString();
        abilityTwoCooldown.color = plane.getAbilityTwo().getCooldown() == 0 ? green : red;
        ultimateAbilityCooldown.text = plane.getUltimateAbility().getCooldown() == 0 ? "C" : Mathf.RoundToInt(plane.getUltimateAbility().getCooldown()).ToString();
        ultimateAbilityCooldown.color = plane.getUltimateAbility().getCooldown() == 0 ? green : red;
    }
}