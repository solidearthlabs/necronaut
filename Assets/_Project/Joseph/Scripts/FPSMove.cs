using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour
{

    public float moveSpeed = 10.0f;
    public float accel = 0f;
    public float accelRate = 1.0f;
    public float accelMax = 5.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 1f;
    public float baseFall = -1.5f;

    private CharacterController controller;

    Vector3 movement;


	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (controller.isGrounded)
        {
            float horInput = Input.GetAxis("Horizontal") * moveSpeed;
            float verInput = Input.GetAxis("Vertical") * moveSpeed;

            movement = Vector3.zero;
            Vector3 movedir = new Vector3(horInput, 0, verInput);
            movement = transform.TransformDirection(movedir);
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            if (Input.GetButton("Jump"))
            {
                movement.y = jumpSpeed;
            }
        }
        else
        {

            float horInput = Input.GetAxis("Horizontal") * moveSpeed;
            float verInput = Input.GetAxis("Vertical") * moveSpeed;

            Vector3 movedir = new Vector3(horInput, 0, verInput);
            float temp = movement.y;
            movement = transform.TransformDirection(movedir);
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            movement.y = temp;

            if ((Input.GetButton("Jump")) == false && movement.y > 0)
            {
                movement.y = Mathf.Lerp(movement.y,0,0.1f);
            }
        }

        movement.y -= gravity * Time.deltaTime;





        controller.Move(movement * Time.deltaTime);
        

    }
}
