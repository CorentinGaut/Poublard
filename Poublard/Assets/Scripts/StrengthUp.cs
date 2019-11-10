using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUp : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<CharController>().StrengthUp();
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
