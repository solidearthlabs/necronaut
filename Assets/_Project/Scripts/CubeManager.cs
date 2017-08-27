using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour {
    public bool continuousDestroy = true;
    public float destroyTime = 3;
    public int minCubes = 5;
    public Animation animation;
    
    public List<GameObject> floorCubes = new List<GameObject>();
    int index;
    
    // Use this for initialization
    void Start () {
        floorCubes = GameObject.FindGameObjectsWithTag("FloorCube").ToList();
        if (continuousDestroy)
            StartCoroutine (ContinousDestroy()); 
        else
            Invoke("DestroyRandomCube", destroyTime);

    }

    public IEnumerator TimedRandomDestroy(float swTime)
    {
        float startTime = Time.fixedTime;
        while (Time.fixedTime - startTime < swTime )
        {
            if (floorCubes == null || floorCubes.Count <= minCubes)
                break;
            else
                StartCoroutine(DestroyRandomCube());
            yield return new WaitForSeconds(destroyTime);
        }
    }

    /// <summary>
    /// Sort cubes starting from one end (on horizontal axis)
    /// and cause lines of every other cube to rumble
    /// </summary>
    /// <returns></returns>
    public IEnumerator ShockWave()
    {
        float timeBetweenWaves = 1;

        // sort by x position
        foreach (var cube in floorCubes.OrderBy(c => c.transform.position.x).ToList())
        {
            Debug.LogFormat("cube x,y,z {0}", cube.transform.position);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
    }

    public IEnumerator ContinousDestroy()
    {
        bool done = false;
        while (!done)
        {
            if (floorCubes == null || floorCubes.Count <= minCubes)
                done = true;
            else 
                StartCoroutine(DestroyRandomCube());
            yield return new WaitForSeconds(destroyTime);
        }
    }

    public IEnumerator DestroyRandomCube() {
        index = Random.Range(0, floorCubes.Count-1);

        //Animator animator = floorCubes[index].AddComponent<Animator>();
        
        //animator.animation = animation;

        Destroy(floorCubes[index]);
        yield return "";
	}
}
