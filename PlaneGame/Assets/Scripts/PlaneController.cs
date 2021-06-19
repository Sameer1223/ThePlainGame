using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject plane;

    //Constants
    public const int minSpeed = 10, maxSpeed = 30;
    public const int speedChange = 10;

    //[Attributes]
    // Speed and acceleration values
    private float activeForwardSpeed = 20f;
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

    // Update is called once per frame
    void Update()
    {
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
        //Debug.Log("Allow Rudder: " + allowRudder + " Pitch: " + pitch + " Roll: " +  roll);
        rudderInput = Mathf.Lerp(rudderInput, allowRudder ? Input.GetAxisRaw("Horizontal") : 0, rudderAcceleration * Time.deltaTime);


        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, rudderInput * rudderSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
        
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Mathf.Clamp(activeForwardSpeed + 
        Input.GetAxisRaw("Vertical") * speedChange, minSpeed, maxSpeed), forwardAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
    }
}

