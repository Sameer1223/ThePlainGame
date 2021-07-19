using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneSelection : MonoBehaviour
{
    IPlane[] planes = {
        new DefaultPlane(), 
        new TestSecondaryPlane()
    };
    
    public static BasePlane player;

    // Plane Selection Function
    public void OnPlaneSelect(int choice){
        IPlane selection = planes[choice];
        
        player = new BasePlane(selection.modelName, selection.planeName, selection.health, 
            selection.speed, selection.fireRate, selection.armour, selection.abilityOne, selection.abilityTwo, selection.ultimateAbility);

        SceneManager.LoadScene("GameScene");
    }
}
