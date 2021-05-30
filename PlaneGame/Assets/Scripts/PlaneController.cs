using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Parameters
    public float planeSpeed = 10f;

    void Awake(){
        return;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Mathf.Abs (h) > 0.1f || Mathf.Abs (v) > 0.1f) {
            //multiply by "-h" to correct horizontal direction
			transform.Translate (new Vector3 (planeSpeed * v * Time.deltaTime, 0f, planeSpeed * -h * Time.deltaTime));
		}
    }
}
