using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public float horSensitivity = 10.0f;
    public float verSensitivity = 10.0f;

    public float upperLimit = 80.0f;
    public float lowerLimit = 80.0f;

    private float horInput;
    private float verInput;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");




    }
}
