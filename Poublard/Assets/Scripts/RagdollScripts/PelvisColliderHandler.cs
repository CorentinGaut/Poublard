using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelvisColliderHandler : MonoBehaviour
{

    public DisableActiveRagdoll disableActiveRagdoll;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ground")
        {
            Invoke("ReactivateActiveRagdoll", 1f);
            Debug.Log("ZZZ");            
        }
    }

    void ReactivateActiveRagdoll()
    {
        disableActiveRagdoll.disableActiveRagdoll = false;
    }
}
