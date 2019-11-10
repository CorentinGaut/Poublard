using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public GameObject groundGO;
    DisableActiveRagdoll disableActiveRagdoll;
    float defaultYForce;
    public float stairYForce = 75f;

    private void Start()
    {
        disableActiveRagdoll = GetComponentInParent<DisableActiveRagdoll>();
        defaultYForce = transform.parent.GetComponent<AddPermanentForces>().yForce;
    }
    private void OnTriggerStay(Collider other)
    {
        if(groundGO != null && groundGO.name.Contains("Stair")) return;
        if (other.tag != "ground") return;
        groundGO = other.gameObject;
    } 
    
    private void OnTriggerExit(Collider other)
    {
        if(groundGO == null) return;
        if (other.tag != "ground") return;
        groundGO = null;
    }

    private void Update()
    {
        if(groundGO == null && !disableActiveRagdoll.disableActiveRagdoll)
        {
            disableActiveRagdoll.disableActiveRagdoll = true;
        } else if (groundGO != null && groundGO.name.Contains("Stair"))
        {
            transform.parent.GetComponent<AddPermanentForces>().yForce = stairYForce;
        } else
        {
            transform.parent.GetComponent<AddPermanentForces>().yForce = defaultYForce;
        }
    }
}
