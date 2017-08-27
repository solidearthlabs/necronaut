using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomAudioClip : MonoBehaviour {
    public AudioClip[] audioClipsOnSpawn;
    public AudioClip[] audioClipsOnDie;
    private AudioSource audioSource;
    
	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.LogError("audioSource is not set!!");

        if (audioClipsOnSpawn != null && audioClipsOnSpawn.Length > 0)
        {
            int clipNum = Random.Range(0, audioClipsOnSpawn.Length);
            audioSource.clip = audioClipsOnSpawn[clipNum];
            audioSource.Play();
        }
    }

	
    // Use this for initialization
	void OnDestroy()
    {
        if (audioSource == null)
            Debug.LogError("audioSource is not set!!");

        if (audioClipsOnDie!= null && audioClipsOnDie.Length > 0)
        {
            int clipNum = Random.Range(0, audioClipsOnDie.Length);
            audioSource.clip = audioClipsOnDie[clipNum];
            audioSource.Play();
        }
    }
}
