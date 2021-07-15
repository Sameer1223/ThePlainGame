using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public float fireRate;
    public GameObject bullet;
    public GameObject shootPoint;
    public AudioSource gunshot;
    public AudioClip singleShot;

    private float cooldownSpeed = 0f;

    void OnEnable(){
        fireRate = PlaneSelection.player.getFireRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= cooldownSpeed){
                cooldownSpeed = Time.time + 1f / fireRate;
                Shoot();
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

