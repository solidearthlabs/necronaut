using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour {
    public bool continuousDestroy = true;
    public float destroyTime = 3;
    public int minCubes = 5;
    public Animation animation;

    private List<GameObject> floorCubes = new List<GameObject>();
    int index;
    
    // Use this for initialization
    void Start () {
        floorCubes = GameObject.FindGameObjectsWithTag("FloorCube").ToList();
        if (continuousDestroy)
            StartCoroutine (ContinousDestroy()); 
        else
            Invoke("DestroyRandomCube", destroyTime);

    }
    
    IEnumerator ContinousDestroy()
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

    IEnumerator DestroyRandomCube() {
        index = Random.Range(0, floorCubes.Count-1);

        //Animator animator = floorCubes[index].AddComponent<Animator>();
        
        //animator.animation = animation;

        Destroy(floorCubes[index]);
        yield return "";
	}
}
