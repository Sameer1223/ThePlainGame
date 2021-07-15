using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject plane;
    //public Camera cam;

    //Constants
    public const int speedChange = 10;
    public float minSpeed, maxSpeed;

    //[Attributes]
    // Speed and acceleration values
    private float activeForwardSpeed;
    private float forwardAcceleration = 2.5f;

    // Rotation inputs and speed
    private float rollInput;
    private float rollSpeed = 90f, rollAcceleration = 3.5f;

    private float rudderInput;
    private float rudderSpeed = 30f, rudderAcceleration = 1.5f;

    // Mouse control
    public float lookRateSpeed = 45f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    // Rotation values
    private float pitch, roll;

    // Conditions
    private bool allowRudder;

    // Start is called before the first frame update
    void Start(){
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void OnEnable(){
        plane = transform.gameObject;
        activeForwardSpeed = PlaneSelection.player.getSpeed();
        minSpeed = activeForwardSpeed - speedChange;
        maxSpeed = activeForwardSpeed + speedChange;
    }

    // Update is called once per frame
    void Update(){
        MovePlane();
        
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            PlaneSelection.player.getAbilityOne().TriggerAbility();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            PlaneSelection.player.getAbilityTwo().TriggerAbility();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)){
            PlaneSelection.player.getUltimateAbility().TriggerAbility();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)){
            Debug.Log(PlaneSelection.player.getPlaneName() + " " + PlaneSelection.player.getHealth() + " " + PlaneSelection.player.getArmour() + " " +  PlaneSelection.player.getFireRate());
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)){
            Debug.Log(activeForwardSpeed + " " +  minSpeed + " " +  maxSpeed);
        }
    }

    public void MovePlane(){
        // Get mouse location
        lookInput.y = Input.mousePosition.y;

        // Get distance from cursor to centre of screen
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // Get plane rotation
        pitch = plane.transform.localRotation.eulerAngles.x;
        roll = plane.transform.localRotation.eulerAngles.z;

        // Rotation inputs
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        bool allowRudder = (Mathf.Abs(pitch) < 20 || Mathf.Abs(pitch) > 340) && (Mathf.Abs(roll) < 10 || Mathf.Abs(roll) > 350);
        rudderInput = Mathf.Lerp(rudderInput, allowRudder ? Input.GetAxisRaw("Horizontal") : 0, rudderAcceleration * Time.deltaTime);


        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, rudderInput * rudderSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
        
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Mathf.Clamp(activeForwardSpeed + 
        Input.GetAxisRaw("Vertical") * speedChange, minSpeed, maxSpeed), forwardAcceleration * Time.deltaTime);
        //Debug.Log(activeForwardSpeed);
        //Debug.Log("Speed: " + activeForwardSpeed + " Allow Rudder: " + allowRudder + " Pitch: " + pitch + " Roll: " +  roll);
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
    }
}

