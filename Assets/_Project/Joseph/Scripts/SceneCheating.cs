using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCheating : MonoBehaviour
{

    public Transform movieStar;

    public Transform curtains;

    private Vector3 closed;
    public int slides;
    public int limit;

    // Update is called once per frame

    void Start()
    {
        closed = curtains.position;
    } 

    void Update ()
    {
        curtains.position = new Vector3(curtains.position.x, curtains.position.y - 2, curtains.position.z);

        if (curtains.position.y <= -600 && slides < limit)
        {
            slides++;
            curtains.position = closed;
            movieStar.position = new Vector3(movieStar.position.x - 1000, movieStar.position.y, movieStar.position.z);
        }
        else if (curtains.position.y <= -600 && slides >= limit)
        {
            NextLevel Ready = GetComponent<NextLevel>();
            Ready.Proceed();
        }
    }
}
