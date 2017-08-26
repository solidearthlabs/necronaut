using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFire : MonoBehaviour
{

    public GameObject shot;
    public float fireForce = 1000;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(shot, transform.position, transform.rotation)as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * fireForce);
        }
    }
}
