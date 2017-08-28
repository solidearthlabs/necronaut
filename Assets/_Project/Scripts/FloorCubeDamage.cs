using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeDamage : MonoBehaviour {
    public bool isRumbling = false;
    public string target = "Player";
    public float damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (isRumbling && other.CompareTag(target))
        {
            Health targethealth = other.GetComponent<Health>();
            if (targethealth)
            {
                targethealth.DamageHealth(damage);
            }

        }

    }
}
