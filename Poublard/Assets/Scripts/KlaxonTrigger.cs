using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlaxonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.parent.GetComponent<AudioSource>().Play();
        }
    }
}
