using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{

    public GameObject bulletPrefab;


    public enum AttackStyle { fire, shockwave}
    //public enum AttackStyle { fire, blob, swarm, lightning, shockwave, bomb }
    /// <summary>
    /// Holds each of the bullets: (GameObject, AttackStyle, aimDirection)
    /// </summary>
    public static List<Bullet> bullets = new List<Bullet>();
    public float bulletSpeed = 0.5f;
    public float timeBetweenFiring = 5f;
    public float timeUntilStart = 10f;
    public float timeBetweenAttackChange = 15f;
    public AttackStyle attackStyle = AttackStyle.fire;
    public float aimAccuracy = 3f;  // aim is off by up to this amount on either side of the player

    //apply to gun
    // TODO: add other attack styles
    //public int bulletNumber = 1;
    //public float inaccuracy = 0;
    //public int heat = 30;
    //public int cooldown = 0;

    //public int chargePercent = 0;
    //public int windupReq = 60;

    //apply to bullet iself
    //public float size = 1; //currently does nothing
    //public float fireForce = 1000;

    //public float startVelocity = 1000;

    private CubeManager cubeManager;
    private bool debug = true;
    private float debugSeconds = 1;
    private float lastDebugTime = 0;

    //private Quaternion aimDirection;
    private GameObject player;
    private GameObject[] shots;

    void Start()
    {
        if (bulletPrefab == null)
            Debug.LogError("bullet is not defined!!");

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("couldn't find player!!");

        cubeManager = GameObject.FindObjectOfType<CubeManager>();
        if (cubeManager== null)
            Debug.LogError("couldn't find cubeManager.  Must have one in the scene");

        StartCoroutine(Attack());
    }

    /// <summary>
    ///  Implements a bullet game object class.
    /// </summary>
    public class Bullet
    {
        public GameObject obj;
        public AttackStyle attackStyle;
        public Vector3 aimDirection;
        public GameObject targetObj;
        //public float velocity;
        public float creationTime = Time.fixedTime;
        public float bulletListIndex;
        public Bullet(GameObject go, AttackStyle style, Vector3 dir, GameObject targ)
        {
            obj = go;
            attackStyle = style;
            aimDirection = dir;
            targetObj = targ;
            //velocity = startingVelocity;
            bulletListIndex = bullets.Count;
        }
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
                fireBullet(player);
            }
        }
    }

    /// <summary>
    /// Instantiates a new bullet from the bulletPrefab and adds to the bullets list
    /// </summary>
    /// <param name="target"></param>
    void fireBullet(GameObject target)
    {
        //float offset = transform.localScale.x / 1.9f;  // instantiate just outside of the boss boundary
        Vector3 aimTarget = target.transform.position;

        // boss isn't a perfect shot, pick a random location within the aimAccuracy
        if (aimAccuracy != 0)
        {
            var axis = Random.Range(0, 2);
            float offset = Random.Range(-aimAccuracy, aimAccuracy);
            switch (axis)
            {
                case 0:
                    aimTarget.x -= offset;
                    break;
                case 1:
                    aimTarget.y -= offset;
                    break;
                case 2:
                    aimTarget.z -= offset;
                    break;
                default:
                    break;
            }
        }
        Vector3 direction = aimTarget - transform.position;
        //Vector3 bulletStartPos = transform.localPosition + transform.localScale / 2;
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(direction));
    
        Bullet bullet = new Bullet(bulletGO, attackStyle, direction, target);
        bullets.Add(bullet);

        if (debug)
            Debug.LogFormat("Instantiated boss bullet at location {0} in direction {1} (boss location is {2})", transform.position, direction, transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        // TODO: probably a better way to do this
        bullets.RemoveAll(b => b.obj == null); // remove any missing bullet which may have been destroyed from a collision 

        foreach (var bullet in bullets)
        {
            if (bullet.obj != null) {

                // TODO: optimize this 
                var diff = bullet.obj.transform.position;
                bullet.obj.transform.position += bullet.obj.transform.forward * (bulletSpeed * 0.1f) * Time.deltaTime;
                diff -= bullet.obj.transform.position;

                if (debug)
                {
                    if (Time.fixedTime - lastDebugTime > debugSeconds)
                    {
                        Debug.LogFormat("bullet position = {0} (diff {1})", bullet.obj.transform.position, diff);
                        lastDebugTime = Time.fixedTime;
                    }
                }
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
                    //bulletNumber = 1;
                    //inaccuracy = 0;
                    //heat = 20;
                    //windupReq = 0;
                    //size = 1;
                    //fireForce = 1000;
                    break;
                }


        }
        //shot = shots[(int)attackStyle];
    }


}
