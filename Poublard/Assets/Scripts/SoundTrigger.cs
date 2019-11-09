using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<GameManager>().GetComponent<AudioSource>().clip = audioClip;
        GameObject.FindObjectOfType<GameManager>().GetComponent<AudioSource>().Play();
    }
}
