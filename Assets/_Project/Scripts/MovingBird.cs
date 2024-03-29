﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBird : MonoBehaviour {
    public Vector2 horSpeed = new Vector2 ( 2, 2 );
    public float verSpeed = 0.5f;
    
    public float minHeight = 0.1f;
    public float maxHeight = 2f;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float twistSpeed = 2;
    public float maxTwistTime = 1;

    private float horSpeedMult = 0.01f;
    private Vector3 tmpPos;
    private UnityEngine.AI.NavMeshAgent nav;
    private Transform player;
    private float height;
    private Transform body;
    
    private Vector3 tmpAngle, startAngle;
    private float lastTwistTime = 0;
    private float lastTime = 0;
   
    
    private Vector3 goalAngle = new Vector3 (0,0,0);

	// Use this for initialization
	void Start () {
        tmpPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = transform.GetChild(0);
        startAngle = transform.eulerAngles;

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    private void Update()
    {
        nav.SetDestination(player.position);
        body.localEulerAngles = Vector3.Lerp(body.localEulerAngles, goalAngle, Time.deltaTime * twistSpeed);
    }

    void FixedUpdate()
    {
        tmpPos = body.position;
        //tmpPos.x += Random.Range(0,1);
        //tmpPos.z += horSpeed.y*horSpeedMult;

        height = (Mathf.Sin(Time.time * verSpeed) + 1) / 2;
        height = Mathf.Lerp(minHeight, maxHeight, height);

        tmpPos.y = height;
        body.position = tmpPos;


        if (Time.time  - lastTwistTime >  maxTwistTime && goalAngle.x-startAngle.x < 0.01f)
        {
            //Debug.Log("goal angle == " + goalAngle);
            // randomly rotate body every twistTime
            goalAngle = body.localEulerAngles;
            goalAngle.y = Random.Range(minAngle, maxAngle);
            lastTwistTime = Time.time;
        }
    }
}
