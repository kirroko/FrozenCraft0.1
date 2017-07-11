using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager sounds = null;
    // Unit Sound array
    public AudioClip[] Affirmation; // Moving
    public AudioClip[] Acknowledgement; // building
    public AudioClip[] Deaths; // Explosion
    // Building Sound
    public AudioClip HQ;
    public AudioClip SCVBuilt;

    public AudioSource efxSource;
    public AudioSource BgmSource;
    

    // Use this for initialization
    void Start () {
        sounds = this;
	}

    public void PlayMovement()
    {
        efxSource.clip = Affirmation[Random.Range(0,Affirmation.Length)];
        efxSource.Play();
    }
    public void PlayBuilding()
    {
        efxSource.clip = Acknowledgement[Random.Range(0, Acknowledgement.Length)];
        efxSource.Play();
    }
    public void PlayBuild()
    {
        BgmSource.clip = HQ;
        BgmSource.Play();
    }
    public void PlaySCV()
    {
        BgmSource.clip = SCVBuilt;
        BgmSource.Play();
    }
    public void PlayDeath()
    {
        BgmSource.clip = Deaths[Random.Range(0, Deaths.Length)];
        BgmSource.Play();    
    }
    // Update is called once per frame
    void Update () {
		
	}
}
