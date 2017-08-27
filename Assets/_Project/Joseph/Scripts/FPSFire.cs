using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFire : MonoBehaviour
{
    public GameObject[] shots;
    public GameObject shot;


    //apply to gun
    public enum bulletStyle { normal=0, fire=1, laser=2, bomb=3}
    public bulletStyle bSty = bulletStyle.normal;
    public int bulletNumber = 1;
    public float inaccuracy = 0;
    public int heat = 30;
    public int cooldown = 0;

    public int chargePercent = 0;
    public int windupReq = 60;



    //apply to bullet iself

    public float size = 1; //currently does nothing
    public float fireForce = 1000;

    //

        //ADD LASER

    // Use this for initialization
    void Start ()
    {
        GunChange(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown != 0)
        {
            cooldown--;
        }

        if (Input.GetMouseButton(0) && cooldown == 0)
        {
            if (chargePercent >= windupReq)
            {
                cooldown = heat;
                            




                for (int i = 0; i < bulletNumber; i++)
                {
                    Vector3 inaccurate = Random.insideUnitSphere * inaccuracy;
                    Quaternion inacc = Quaternion.Euler(inaccurate);
                    GameObject bullet = Instantiate(shot, transform.position, transform.rotation * inacc) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce((transform.forward + inaccurate) * fireForce);
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
                    break;
                }
            case 1:
                {
                    bSty = bulletStyle.fire;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 100;
                    windupReq = 0;
                    size = 3;
                    fireForce = 1200;
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
                    break;
                }
            case 7:
                {
                    bSty = bulletStyle.laser;
                    bulletNumber = 1;
                    inaccuracy = 0;
                    heat = 30;
                    windupReq = 0;
                    size = 1;
                    fireForce = 1000;
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
                    break;
                }

                

        }
        shot = shots[(int)bSty];
    }



}
