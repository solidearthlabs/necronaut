using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {
    public float xDirMovement = 10;
    public float yDirMovement = 1;
    public float zDirMovement = 10;
    public Vector3 maxOffset = new Vector3 ( 10,2,10);

    //public bool sineMovement = true;
    public float targetResetTime = 10f;
    public float horSpeed = 0.1f;
    public float vertSpeed = 0.1f;
    public float distThreshold = 1f; // when boss get within 1f of target then that's close enough

    private Vector3 tmpPos;
    private Vector3 targetPos = new Vector3 (0,0,0);
    private bool targetDefined = false;
    private float xRand,yRand,zRand;
    private Vector3 origLocation;
    private float xCurrOffset, yCurrOffset, zCurrOffset;

    // Use this for initialization
    void Start () {
        origLocation = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        if (!targetDefined) {
            tmpPos = transform.position;
            xRand = Random.Range(-xDirMovement, xDirMovement);
            yRand = Random.Range(-yDirMovement, yDirMovement);
            zRand = Random.Range(-zDirMovement, zDirMovement);
            xCurrOffset = Mathf.Abs(xRand - tmpPos.x);
            yCurrOffset = Mathf.Abs(yRand - tmpPos.y);
            zCurrOffset = Mathf.Abs(zRand - tmpPos.z);

            // if goes beyond the bounds then set the target position to the originally location
            if (xCurrOffset > maxOffset.x)
                xRand = origLocation.x;
            if (yCurrOffset > maxOffset.y)
                yRand = origLocation.y;
            if (zCurrOffset > maxOffset.z)
                zRand = origLocation.z;

            targetPos = new Vector3(xRand, yRand, zRand);
            targetDefined = true;
            Debug.LogFormat("Boss Target defined == {0} (currentPos == {1})", targetPos,transform.position);
        } else {
            if (Vector3.Distance(transform.position, targetPos) < distThreshold)
            {
                targetDefined = false;
            } else
            {
                tmpPos = transform.position;
                tmpPos.x = Mathf.Lerp(tmpPos.x, targetPos.x, Time.deltaTime * horSpeed);
                tmpPos.y = Mathf.Lerp(tmpPos.y, targetPos.y, Time.deltaTime * vertSpeed);
                tmpPos.z = Mathf.Lerp(tmpPos.z, targetPos.z, Time.deltaTime * horSpeed);

                transform.position = tmpPos;
            }
        }
	}
}
