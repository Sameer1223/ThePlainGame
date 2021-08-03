using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {
    public GameObject planeObject;
    public BasePlane plane;
    public Text healthText;
    public Text altitudeText;
    public Text speedText;

    public void OnPlaneSelection(){
        plane = PlaneSelection.player;
        planeObject = GameObject.Find(plane.getModelName() + "(Clone)");
    }

    void Update() {
        healthText.text = plane.getHealth().ToString();
        speedText.text = Mathf.RoundToInt(plane.getSpeed()).ToString();
        altitudeText.text = Mathf.RoundToInt(planeObject.transform.position.y).ToString();
    }
}