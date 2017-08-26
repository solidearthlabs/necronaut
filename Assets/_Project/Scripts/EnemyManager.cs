using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
//    public Health health;
    public GameObject enemy;
    public float spawnTime = 3f;
    public float spawnTimeOffset = 0;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public int maxEnemies = 5;
    public static int numEnemies;
    public string respawnTag = "Respawn";
    public bool continuousSpawn = true;

    void Start ()
    {
        numEnemies = 0;
        if (spawnPoints.Count == 0)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag(respawnTag).ToList();
        }
        if (spawnPoints.Count == 0)
            Debug.LogError("Cannot find any spawnpoints!!");

        if (continuousSpawn)
            InvokeRepeating("Spawn", spawnTime+spawnTimeOffset, spawnTime);
        else
            Invoke("Spawn",spawnTime+spawnTimeOffset);
    }


    void Spawn ()
    {
        //if(health.currentHealth <= 0f)
        //{
        //    return;
        //}
        
        int spawnPointIndex = Random.Range (0, spawnPoints.Count);
        if (numEnemies < maxEnemies)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
            numEnemies++;
        }
    }
}
