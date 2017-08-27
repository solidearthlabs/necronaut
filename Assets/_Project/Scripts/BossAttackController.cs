using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{

    public GameObject bulletPrefab;

    /// <summary>
    /// Holds each of the bullets: (GameObject, AttackStyle, aimDirection)
    /// </summary>
    public static List<Bullet> bullets = new List<Bullet>();
    public float timeBetweenFiring = 3f;
    public float timeUntilStart = 10f;
    public float timeBetweenAttackChange = 15f;

    //apply to gun
    // TODO: add other attack styles
    public enum AttackStyle { fire, blob, swarm, lightning, shockwave, bomb }
    public AttackStyle attackStyle = AttackStyle.fire;
    public int bulletNumber = 1;
    public float inaccuracy = 0;
    public int heat = 30;
    public int cooldown = 0;

    public int chargePercent = 0;
    public int windupReq = 60;

    //apply to bullet iself
    public float size = 1; //currently does nothing
    public float fireForce = 1000;
    public float bulletSpeed = 100f;
    public float startVelocity = 1000;

    private Quaternion aimDirection;
    private GameObject player;
    private GameObject[] shots;

    /// <summary>
    ///  Implements a bullet game object class.
    /// </summary>
    public class Bullet
    {
        public GameObject obj;
        public AttackStyle attackStyle;
        public Vector3 aimDirection;
        public GameObject targetObj;
        public float velocity;
        public float creationTime = Time.fixedTime;
        public float bulletListIndex;
        public Bullet(GameObject go, AttackStyle style, Vector3 dir, GameObject targ, float startingVelocity)
        {
            obj = go;
            attackStyle = style;
            aimDirection = dir;
            targetObj = targ;
            velocity = startingVelocity;
            bulletListIndex = bullets.Count;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (bulletPrefab == null)
            Debug.LogError("bullet is not defined!!");

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("couldn't find player!!");

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        float startTime = Time.fixedTime;
        float curTime = startTime;
        while (true)
        {
            if (Time.fixedTime - startTime > timeBetweenAttackChange)
            {
                // TODO: implement attack change
            }

            // Aim bullet in player's direction.
            //aimDirection = Quaternion.LookRotation(player.transform.position);
            
            yield return new WaitForSeconds(timeBetweenFiring);
            if (attackStyle == AttackStyle.fire)
            {
                fireBullet(aimDirection, player);
            }
        }
    }

    /// <summary>
    /// Instantiates a new bullet from the bulletPrefab and adds to the bullets list
    /// </summary>
    /// <param name="aimDir"></param>
    /// <param name="target"></param>
    void fireBullet(Quaternion aimDir, GameObject target)
    {
        //Vector3 offset = transform.localPosition + transform.forward * aimDir;
        float offset = transform.localScale.x / 1.9f;  // instantiate just outside of the boss boundary

        Vector3 direction = player.transform.position - transform.position;
        Vector3 bulletStartPos = transform.localPosition + transform.localScale / 2;
        GameObject bulletGO = Instantiate(bulletPrefab, bulletStartPos, Quaternion.LookRotation(direction));
        Debug.LogFormat("Instantiated boss bullet at location {0} in direction {1} (boss location is {2})", bulletStartPos, direction,transform.position);
        Bullet bullet = new Bullet(bulletGO, attackStyle, direction, target, startVelocity);
        bullets.Add(bullet);
    }
    // Update is called once per frame
    void Update()
    {
        bullets.RemoveAll(b => b.obj == null); // bullet must have been destroyed from a collision
        foreach (var bullet in bullets)
        {
            if (bullet.obj != null) {
                // already in ShotBehavior.cs attached to the bullet prefab
                //if (Time.time - bullet.creationTime > bulletSurvivalTime)
                //{
                //    Destroy(bullet.obj);
                //    bullets.RemoveAll(b => b.obj == null);  // remove destroyed bullet from bullet list
                //    Debug.Log("Destroyed boss bullet");
                //}
                // Move the projectile forward towards the player's last known direction;
                var diff = bullet.obj.transform.position;
                bullet.obj.transform.position += bullet.obj.transform.forward * bulletSpeed * Time.deltaTime;
                diff -= bullet.obj.transform.position;
                Debug.LogFormat("bullet position = {0} (diff {1})", bullet.obj.transform.position, diff);
            }
        }
    }
    //playerDir = transform.position



    public void attackChange(AttackStyle attack)
    {

        attackStyle = attack;
        switch (attack) //Update gun stats here
        {
            case AttackStyle.fire:
                {
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 20;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
                    break;
                }


        }
        //shot = shots[(int)attackStyle];
    }


}
