using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldownSpeed;
    public float fireRate;
    public GameObject bullet;
    public GameObject shootPoint;
    public AudioSource gunshot;
    public AudioClip singleShot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpeed += Time.deltaTime * 60f;
        if (Input.GetButton("Fire1")){
            if (cooldownSpeed>=fireRate){
                Shoot();
                cooldownSpeed = 0;
            }
        }
    }

    void Shoot(){
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        if( Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity)){
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<MoveBullet>().hitPoint =  hit.point;
        }

        
    }
}
