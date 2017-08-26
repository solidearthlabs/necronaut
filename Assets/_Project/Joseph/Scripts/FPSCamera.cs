using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public float horSensitivity = 10.0f;
    public float verSensitivity = 10.0f;

    public float viewLimit = 80.0f;

    private float horInput;
    private float verInput;

    private float rotateY = 0f;



    // Use this for initialization
    void Update ()
    {
        horInput = Input.GetAxis("Mouse X");
        verInput = Input.GetAxis("Mouse Y");

        rotateY += transform.localEulerAngles.y + verInput * verSensitivity;

        float rotateX = transform.localEulerAngles.x + horInput * horSensitivity;
        //rotateY = Mathf.Clamp(rotateY, -viewLimit, viewLimit);

        transform.localEulerAngles = new Vector3(-rotateY, rotateX, 0);


    }
	
	// Update is called once per frame
	void LateUpdate ()
    {


    }
}
