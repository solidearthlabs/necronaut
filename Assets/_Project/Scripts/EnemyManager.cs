using UnityEngine;

public class EnemyManager : MonoBehaviour
{
//    public Health health;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int maxEnemies = 5;
    private int numEnemies;

    void Start ()
    {
        numEnemies = 0;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //if(health.currentHealth <= 0f)
        //{
        //    return;
        //}
        
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if (numEnemies < maxEnemies)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            numEnemies++;
        }
    }
}
