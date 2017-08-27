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
    public enum shootStyle { normal=0, charge=1, rapid=2}
    public shootStyle sSty = shootStyle.normal;
    public int bulletNumber = 1;
    public float inaccuracy = 0;
    public int heat = 30;
    public int cooldown = 0;

    public int chargePercent = 0;

    public int windupReq = 60;



    //apply to bullet iself

    public int size = 1;
    public int shotSpeed = 1;
    public float fireForce = 1000;

    //



    // Use this for initialization
    void Start ()
    {
        shot = shots[(int)bSty];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown != 0)
        {
            cooldown--;
        }

        switch (sSty)
        {
            case (shootStyle.normal):
            {
                    if (Input.GetMouseButtonDown(0) && cooldown == 0)
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
                    break;
            }
            case (shootStyle.charge):
            {
                    if (Input.GetMouseButton(0) && cooldown == 0 && chargePercent < 100)
                    {
                        chargePercent++;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    { 
                       


                        //chargePercent powers up the shot



                        for (int i = 0; i < bulletNumber; i++)
                            {
                                Vector3 inaccurate = Random.insideUnitSphere * inaccuracy;
                                Quaternion inacc = Quaternion.Euler(inaccurate);
                                GameObject bullet = Instantiate(shot, transform.position, transform.rotation * inacc) as GameObject;
                                bullet.GetComponent<Rigidbody>().AddForce((transform.forward + inaccurate) * fireForce);
                            }

                        chargePercent = 0;
                    }
                    break;
            }
            case (shootStyle.rapid):
            {
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
                    break;
            }



        }






    }






}
