using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
    public float cooldownSpeed;
    public float fireRate;
    public GameObject bullet;
    public GameObject shootPoint;
    public AudioSource gunshot;
    public AudioClip singleShot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpeed += Time.deltaTime * 60f;
        if (Input.GetButton("Fire1")){
            //Debug.Log("Button pressed");
            if (cooldownSpeed>=fireRate){
                Shoot();
                cooldownSpeed = 0;
            }
        }
    }

    void Shoot(){
        //Debug.Log("Bullet fired");
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
        if( Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity)){
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<MoveBullet>().hitPoint =  hit.point;
        }
    }
}

