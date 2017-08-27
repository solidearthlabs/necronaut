using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour {
    public GameObject bullet;
    public float timeBetweenAttacks = 5f;

    //apply to gun
    public enum bulletStyle { fire, blob, swarm, lightning, shockwave, bomb }
    public bulletStyle bSty = bulletStyle.fire;
    public int bulletNumber = 1;
    public float inaccuracy = 0;
    public int heat = 30;
    public int cooldown = 0;

    public int chargePercent = 0;
    public int windupReq = 60;

    //apply to bullet iself
    public float size = 1; //currently does nothing
    public float fireForce = 1000;
    public float fireSpeed = 0.2f;

    private Quaternion aimDirection;
    private GameObject player;
    private GameObject[] shots;

	// Use this for initialization
	void Start () {
        if (bullet == null)
            Debug.LogError("bullet is not defined!!");

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("couldn't find player!!");

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            // Aim bullet in player's direction.
            aimDirection = Quaternion.LookRotation(player.transform.position);
            fireBullet(aimDirection);
        }
    }

    void fireBullet(Quaternion aimDir)
    {
        Instantiate(bullet);
    }
        // Update is called once per frame
    void Update()
    {
            // Move the projectile forward towards the player's last known direction;
            transform.position += transform.forward * fireSpeed * Time.deltaTime;
    }
    //playerDir = transform.position


    public void attackChange(bulletStyle attack)
    {

        bSty = attack;
        switch (attack) //Update gun stats here
        {
            case bulletStyle.fire:
                {
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 20;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
                    break;
                }
                // TODO: need to implement blob
            case bulletStyle.blob:
                {
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 100;
                    windupReq = 0;
                    size = 3;
                    fireForce = 1200;
                    break;
                }
                // TODO: Need to implement swarm
            case bulletStyle.swarm:
                {
                    bulletNumber = 3;
                    inaccuracy = .5f;
                    heat = 0;
                    windupReq = 0;
                    size = 0.5f;
                    fireForce = 200;
                    break;
                }
                // TODO: Need to implement lightning
            case bulletStyle.lightning:
                {
                    bulletNumber = 10;
                    inaccuracy = 0.1f;
                    heat = 60;
                    windupReq = 0;
                    size = 1;
                    fireForce = 800;
                    break;
                }
                // TODO: Need to implement shockwave
            case bulletStyle.shockwave:
                {
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 0;
                    windupReq = 20;
                    size = 0.5f;
                    fireForce = 2500;
                    break;
                }
            case bulletStyle.bomb:
                {
                    bulletNumber = 6;
                    inaccuracy = 0.2f;
                    heat = 20;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
                    break;
                }


        }
        //shot = shots[(int)bSty];
    }


}
