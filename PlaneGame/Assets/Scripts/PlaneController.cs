using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    //Constants
    public const int minSpeed = 10, maxSpeed = 30;
    public const int speedChange = 10;

    //Attributes
    private float activeForwardSpeed = 20f;
    private float forwardAcceleration = 2.5f;

    private float rollInput;
    private float rollSpeed = 90f, rollAcceleration = 3.5f;

    private float rudderInput;
    private float rudderSpeed = 90f, rudderAcceleration = 3.5f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    // Start is called before the first frame update
    void Start(){
        //screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse location
        //lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        // Get distance from cursor to centre of screen
        //mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        rudderInput = Mathf.Lerp(rudderInput, Input.GetAxisRaw("Horizontal"), rudderAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, rudderInput * rudderSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
        
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Mathf.Clamp(activeForwardSpeed + 
        Input.GetAxisRaw("Vertical") * speedChange, minSpeed, maxSpeed), forwardAcceleration * Time.deltaTime);

        Debug.Log(activeForwardSpeed);
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
    }
}

