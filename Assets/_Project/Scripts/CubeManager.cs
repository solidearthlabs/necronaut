using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour {
    public bool continuousDestroy = false;
    public float destroyTime = 3;
    public int minCubes = 5;
    public Animation animation;
    
    public List<GameObject> floorCubes = new List<GameObject>();
    public float rumbleSpeed= 0.2f;
    public int rumbleTimes = 4;
    public float rumbleHeight = 0.2f;

    private Renderer rend;

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
            StartCoroutine(RumbleCube(cube.gameObject));
            Debug.LogFormat("cube x,y,z {0}", cube.transform.position);
            //rend = GetComponent<Renderer>();
            //rend.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(0.1f);

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
        StartCoroutine(DestroyCube(index));
        yield return 0;
    }

    IEnumerator DestroyCube(int index)
    {
        GameObject cube = floorCubes[index];
        StartCoroutine(RumbleCube(cube.gameObject));
        yield return new WaitForSeconds(1.5f);
        Destroy(cube);
        floorCubes.RemoveAt(index); // remove any missing bullet which may have been destroyed from a collision 
        yield return 0;
    }

    IEnumerator RumbleCube(GameObject cubeGO)
    {
        rend = cubeGO.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
        StartCoroutine(moveCubeUpDown(cubeGO));
        yield return new WaitForSeconds(1);
        rend = cubeGO.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.black);
        yield return 0;
    }
    IEnumerator moveCubeUpDown(GameObject cubeGO)
    {
        var startPos = cubeGO.transform.position;
        Vector3 curPos = startPos;

        for (int i = 0; i < rumbleTimes; i++)
        {
            curPos.y += rumbleHeight;
            cubeGO.transform.position = curPos;
            yield return new WaitForSeconds(rumbleSpeed);
            curPos.y = startPos.y;
            cubeGO.transform.position = curPos;
            yield return new WaitForSeconds(rumbleSpeed);
            curPos.y -= rumbleHeight;
            cubeGO.transform.position = curPos;
            yield return new WaitForSeconds(rumbleSpeed);
            curPos.y = startPos.y;
            cubeGO.transform.position = curPos;
        }
        yield return 1;
    }
}
