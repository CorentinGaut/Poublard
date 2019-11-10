using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    [HideInInspector]
    public ConfigurableJoint joint;

    RotateToDirection rotateToDirection;

    void Start()
    {
        rotateToDirection = transform.parent.GetComponentInChildren<RotateToDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        bool catchButtonPressed = Input.GetButtonDown("Fire3") && name == "LeftForearm";
        catchButtonPressed = catchButtonPressed || Input.GetButtonDown("Jump") && name == "RightForearm";
        if (catchButtonPressed && joint != null)
        {
            Destroy(joint);
            joint = null;
            rotateToDirection.catchState = RotateToDirection.CatchState.none;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(joint == null && collision.collider.tag == "catchable" && rotateToDirection.catchState != RotateToDirection.CatchState.none)
        {
            collision.collider.transform.localRotation = Quaternion.Euler(0, 0, 0);

            Vector3 impactPoint = collision.contacts[0].point;

            joint = collision.collider.gameObject.AddComponent<ConfigurableJoint>();
            joint.xMotion = ConfigurableJointMotion.Locked;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;
            joint.angularXMotion = ConfigurableJointMotion.Locked;
            joint.angularYMotion = ConfigurableJointMotion.Locked;
            joint.angularZMotion = ConfigurableJointMotion.Locked;
            SoftJointLimit sjl = new SoftJointLimit();
            sjl.limit = 10f;
            sjl.contactDistance = 2.3f;
            joint.linearLimit = sjl;
            joint.connectedBody = GetComponent<Rigidbody>();
            joint.breakForce = 700;
            joint.breakTorque = 2000;
            rotateToDirection.catchState = RotateToDirection.CatchState.none;
        }
    }

}
