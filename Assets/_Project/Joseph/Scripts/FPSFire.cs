using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSFire : MonoBehaviour
{
    public GameObject[] shots;
    public GameObject shot;

    public AudioSource audio;
    public AudioClip[] sounds;


    //apply to gun
    public enum bulletStyle { normal=0, fire=1, laser=2, bomb=3}
    public bulletStyle bSty = bulletStyle.normal;
    public int bulletNumber = 1;
    public float inaccuracy = 0;
    public int heat = 30;
    public int cooldown = 0;

    public int chargePercent = 0;
    public int windupReq = 60;


    public int ammo = 100;
    public int ammocap = 100;
    public int ammocost = 0;
    public Slider ammobar;



    //apply to bullet iself

    public float size = 1; //currently does nothing
    public float fireForce = 1000;
    public int damage;
    public int lifetime;
    public bool piercing;

    //

        //ADD LASER

    // Use this for initialization
    void Start ()
    {
        GunChange(0);
        ammobar.maxValue = ammocap;
        ammobar.value = ammo;

        audio = GetComponent<AudioSource>();

        audio.clip = sounds[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown != 0)
        {
            cooldown--;
        }

        if (Input.GetMouseButton(0) && cooldown == 0 && ammobar.value > 0)
        {
            if (chargePercent >= windupReq)
            {
                cooldown = heat;

                ammo -= ammocost;
                ammobar.value -= ammocost;



                for (int i = 0; i < bulletNumber; i++)
                {
                    Vector3 inaccurate = Random.insideUnitSphere * inaccuracy;
                    Quaternion inacc = Quaternion.Euler(inaccurate);
                    GameObject bullet = Instantiate(shot, transform.position, transform.rotation * inacc) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce((transform.forward + inaccurate) * fireForce);
                    bullet.GetComponent<Transform>().localScale *= size;
                    ShotBehavior bulletProps = bullet.GetComponent<ShotBehavior>();

                    bulletProps.lifeTime = lifetime;
                    bulletProps.damage = damage;
                    bulletProps.piercing = piercing;
                    if (!audio.isPlaying)
                    {
                        audio.Play();
                    }
                    

                }

            }
            else
            {
                chargePercent++;
            }


        }
        else if (chargePercent > 0)
        {
            chargePercent--;
        }
            



    }


    public void GunChange(int card)
    {
        ammo = 100;
        ammobar.value = ammo;

        audio.clip = sounds[card];

        switch (card) //Update gun stats here
        {
            case 0:
                {
                    bSty = bulletStyle.normal;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 20;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
                    lifetime = 60;
                    damage = 10;
                    piercing = false;
                    ammocost = 0;
                    
                    break;
                }
            case 1:
                {
                    bSty = bulletStyle.fire;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 100;
                    windupReq = 0;
                    size = 5;
                    fireForce = 1200;
                    lifetime = 120;
                    damage = 100;
                    piercing = true;
                    ammocost = 5;
                    break;
                }
            case 2:
                {
                    bSty = bulletStyle.fire;
                    bulletNumber = 3;
                    inaccuracy = .5f;
                    heat = 0;
                    windupReq = 0;
                    size = 0.5f;
                    fireForce = 200;
                    lifetime = 20;
                    damage = 10;
                    piercing = false;
                    ammocost = 1;
                    break;
                }
            case 3:
                {
                    bSty = bulletStyle.normal;
                    bulletNumber = 10;
                    inaccuracy = 0.1f;
                    heat = 60;
                    windupReq = 0;
                    size = 1;
                    fireForce = 800;
                    lifetime = 60;
                    damage = 30;
                    piercing = false;
                    ammocost = 5;
                    break;
                }
            case 4:
                {
                    bSty = bulletStyle.normal;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 0;
                    windupReq = 20;
                    size = 0.5f;
                    fireForce = 2500;
                    lifetime = 60;
                    damage = 2;
                    piercing = true;
                    ammocost = 1;
                    break;
                }
            case 5:
                {
                    bSty = bulletStyle.normal;
                    bulletNumber = 6;
                    inaccuracy = 0.2f;
                    heat = 20;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
                    lifetime = 30;
                    damage = 20;
                    piercing = false;
                    ammocost = 5;
                    break;
                }
            case 6:
                {

                    bSty = bulletStyle.bomb;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 40;
                    windupReq = 0;
                    size = 2;
                    fireForce = 1000;
                    lifetime = 120;
                    damage = 75;
                    piercing = false;
                    ammocost = 5;
                    break;
                }
            case 7:
                {
                    bSty = bulletStyle.fire;
                    bulletNumber = 20;
                    inaccuracy = 1;
                    heat = 30;
                    windupReq = 0;
                    size = 1;
                    fireForce = 2000;
                    lifetime = 60;
                    damage = 50;
                    piercing = true;
                    ammocost = 25;
                    break;
                }
            case 8:
                {
                    bSty = bulletStyle.normal;
                    bulletNumber = 25;
                    inaccuracy = 0.25f;
                    heat = 2;
                    windupReq = 60;
                    size = 1;
                    fireForce = 3000;
                    lifetime = 60;
                    damage = 15;
                    piercing = true;
                    ammocost = 1;
                    break;
                }

                

        }
        shot = shots[(int)bSty];
    }



}
