using UnityEngine;

public class EnemyManager : MonoBehaviour
{
//    public Health health;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int maxEnemies = 5;
    public static int numEnemies;

    void Start ()
    {
        numEnemies = 0;
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            GameObject[] gObjects = GameObject.FindGameObjectsWithTag("Respawn");
            for (int i = 0; i < gObjects.Length; i++)
            {
                spawnPoints[i] = gObjects[i].transform;
            }
        }
        if (spawnPoints == null || spawnPoints.Length == 0)
            Debug.LogError("Cannot find any spawnpoints!!");
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
