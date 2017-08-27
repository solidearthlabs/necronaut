using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombshot : MonoBehaviour {


    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
}
