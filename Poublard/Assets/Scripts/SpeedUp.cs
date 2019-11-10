using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PoublardRagdoll>().ChangeSpeedMultiplicator();
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
