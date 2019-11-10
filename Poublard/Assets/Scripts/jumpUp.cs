using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpUp : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.GetComponent<PoublardRagdoll>().ChangeJumpMultiplicator();
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
