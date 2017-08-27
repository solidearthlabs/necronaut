using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    // TODO: to make multiplayer should turn player into array or list
    GameObject player;
    Health playerHealth;
    Health enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <Health> ();
        enemyHealth = GetComponent<Health>();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth._currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth._currentHealth <= 0)
        {
            //StartCoroutine(Die(),0);
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth._currentHealth > 0)
        {
            playerHealth.DamageHealth(attackDamage);
        }
    }
}
