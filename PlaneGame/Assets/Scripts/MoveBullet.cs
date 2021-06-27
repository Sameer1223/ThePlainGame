using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{

    public Vector3 hitPoint;
    //public GameObject dirt;
    //public GameObject blood;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized*speed);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall"){
            //collision.gameObject.GetComponent<Health>().currentHealth -= 20;
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Wall"){
            Debug.Log("Cringe");
        }
        //Destroy(this.gameObject);
    }

}
