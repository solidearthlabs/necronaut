using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartIfFalling : MonoBehaviour {
    public float minY = -100f;
    public float checkEverySeconds = 4;
    private void Start()
    {
        StartCoroutine(checkIfFalling());
    }

    // check every few seconds (more efficient than in Update which would check every frame)
    IEnumerator checkIfFalling()
    {
        while (true)
        {
            if (transform.position.y < minY)
            {
                //Destroy(this.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            yield return new WaitForSeconds(checkEverySeconds);
        }
    }
}
