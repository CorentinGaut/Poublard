using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    [HideInInspector]
    public ConfigurableJoint joint;

    RotateToDirection rotateToDirection;
    PoublardRagdoll poublardRagdoll;

    void Start()
    {
        rotateToDirection = transform.parent.GetComponentInChildren<RotateToDirection>();
        poublardRagdoll = GetComponentInParent<PoublardRagdoll>();
    }

    // Update is called once per frame
    void Update()
    {
        //un-catch
        bool catchButtonPressed = Input.GetButtonDown("Character " + poublardRagdoll.controllerNumber + " LeftThumb") && name == "LeftForearm";
        catchButtonPressed = catchButtonPressed || Input.GetButtonDown("Character " + poublardRagdoll.controllerNumber + " RightThumb") && name == "RightForearm";
        if (catchButtonPressed && joint != null)
        {
            Destroy(joint);
            joint = null;
            rotateToDirection.catchState = RotateToDirection.CatchState.none;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string[] goodTag = { "catchable", "Player", "member" };
        if (joint == null && Array.IndexOf(goodTag, collision.collider.tag) != -1 && rotateToDirection.catchState != RotateToDirection.CatchState.none)
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
