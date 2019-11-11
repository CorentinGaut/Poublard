using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    public float timeBeforeDestroy;
    public bool loop;
    public float volume;

    private float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().loop = loop;
        GetComponent<AudioSource>().volume = volume;
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }   
}
