using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableActiveRagdoll : MonoBehaviour
{
    public bool disableActiveRagdoll = false;
    Rigidbody pelvisRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        pelvisRigidBody = transform.Find("Pelvis").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pelvisRigidBody.transform.localPosition.z > 1.5f)
        {
            disableActiveRagdoll = true;
        }

        if (disableActiveRagdoll)
        {
            pelvisRigidBody.freezeRotation = false;
            pelvisRigidBody.angularDrag = 0;
            pelvisRigidBody.drag = 0;
            pelvisRigidBody.mass = 10;
        }
        else
        {
            pelvisRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            pelvisRigidBody.angularDrag = 20;
            pelvisRigidBody.drag = 10;
            pelvisRigidBody.mass = 1;
        }
    }
}
