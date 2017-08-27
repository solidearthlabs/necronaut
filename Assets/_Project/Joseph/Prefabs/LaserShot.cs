using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    float range = 1000;
    bool ray;
	// Use this for initialization
	void Start ()
    {
        LineRenderer laser = GetComponent<LineRenderer>();

        RaycastHit Hit = new RaycastHit();

        ray = Physics.Raycast(transform.position, Vector3.forward, out Hit, range);

        laser.SetPosition(0, transform.position);

        if (ray)
        {
            laser.SetPosition(1, Hit.point);
        }
        else
        {
            laser.SetPosition(1, transform.position*range);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
