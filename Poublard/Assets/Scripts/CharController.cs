using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public int id;
    public bool isDead = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Play()
    {
        isDead = false;
        gameObject.SetActive(!isDead);
    }
    public void Die()
    {
        isDead = true;
        gameObject.SetActive(!isDead);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Die();
            LevelManager.instance.SpawnPlayer(id);
        }
    }
}
