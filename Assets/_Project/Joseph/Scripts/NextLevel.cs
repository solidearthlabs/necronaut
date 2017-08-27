using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int next;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Proceed()
    {
        SceneManager.LoadScene(next);
    }

    public void Leave()
    {
        Application.Quit();
    }

}
