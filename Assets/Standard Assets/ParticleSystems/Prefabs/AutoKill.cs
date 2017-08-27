using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die()
    {
        Destroy(this.gameObject);
    }
}
