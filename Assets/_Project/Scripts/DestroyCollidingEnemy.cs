using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestroyCollidingEnemy : MonoBehaviour {
    //private EnemyManager em
    private void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //enemyManagers.select 
            //    .numEnemies--;
        }
    }
}
