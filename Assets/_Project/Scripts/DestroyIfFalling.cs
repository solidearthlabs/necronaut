using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfFalling : MonoBehaviour {
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
                Destroy(this.gameObject);
            yield return new WaitForSeconds(checkEverySeconds);
        }
    }
}
