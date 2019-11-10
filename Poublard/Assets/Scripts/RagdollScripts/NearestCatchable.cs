using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestCatchable : MonoBehaviour
{
    public GameObject nearestCatchableObject;

    private void OnTriggerStay(Collider other)
    {
        Catch leftCatch = transform.parent.parent.Find("LeftForearm").GetComponent<Catch>(), rightCatch = transform.parent.parent.Find("RightForearm").GetComponent<Catch>();
        if(leftCatch.joint != null && rightCatch.joint != null)
        {
            return;
        }
        if(other.tag == "catchable")
        {
            if (leftCatch.joint != null && leftCatch.joint.gameObject == nearestCatchableObject)
            {
                return;
            }
            else if (rightCatch.joint != null && rightCatch.joint.gameObject == nearestCatchableObject)
            {
                return;
            }
            if (nearestCatchableObject == null)
            {
                nearestCatchableObject = other.gameObject;
            } else
            {
                Vector3 pelvisPosition = transform.parent.position;
                float distOtherCollider = Vector3.Distance(other.transform.position, pelvisPosition);
                float distCurrentCollider = Vector3.Distance(nearestCatchableObject.transform.position, pelvisPosition);
                if(distOtherCollider < distCurrentCollider)
                {
                    nearestCatchableObject = other.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == nearestCatchableObject)
        {
            nearestCatchableObject = null;
        }
    }
}
