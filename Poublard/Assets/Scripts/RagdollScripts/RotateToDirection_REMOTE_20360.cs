using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToDirection : MonoBehaviour
{
    public float attackRotation = 120f;
    Rigidbody _rigidbody;
    PoublardRagdoll poublardRagdoll;
    NearestCatchable nearestCatchable;
    DisableActiveRagdoll disableActiveRagdoll;
    public SoundPlayer soundPlayerPrefab;
    public AudioClip punchSound;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        poublardRagdoll = GetComponentInParent<PoublardRagdoll>();
        nearestCatchable = GetComponentInChildren<NearestCatchable>();
        disableActiveRagdoll = GetComponentInParent<DisableActiveRagdoll>();
    }

    public enum CatchState
    {
        none,
        leftHand,
        rightHand,
    }
    public CatchState catchState;
    public void StopCatching()
    {
        catchState = CatchState.none;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion angleDirection = poublardRagdoll.angleDirection;
        if (catchState == CatchState.leftHand)
        {
            Rigidbody leftArmRB = transform.parent.Find("LeftForearm").GetComponent<Rigidbody>();
            if (nearestCatchable.nearestCatchableObject == null)
            {
                leftArmRB.AddForce(angleDirection * new Vector3(0, 0, 2f));
            } else
            {
                Vector3 vecDir = Vector3.Normalize(nearestCatchable.nearestCatchableObject.transform.position - leftArmRB.transform.position);
                leftArmRB.AddForce(25f * vecDir);
            }
        } else if (catchState == CatchState.rightHand)
        {
            Rigidbody leftArmRB = transform.parent.Find("LeftForearm").GetComponent<Rigidbody>();
            Rigidbody rightArmRB = transform.parent.Find("RightForearm").GetComponent<Rigidbody>();
            if (nearestCatchable.nearestCatchableObject == null)
            {
                rightArmRB.AddForce(angleDirection * new Vector3(0, 0, 2f));
            }
            else
            {
                Vector3 vecDir = Vector3.Normalize(nearestCatchable.nearestCatchableObject.transform.position - rightArmRB.transform.position);
                rightArmRB.AddForce(25f * vecDir);
            }
        }

        Vector3 localForward = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector3.forward;
        float angle1 = angleDirection.eulerAngles.y, angle2 = transform.localRotation.eulerAngles.z;
        if(angle1 > 180f)
        {
            angle1 -= 360f;
        }
        if (angle2 > 180f)
        {
            angle2 -= 360f;
        }

        //punch
        if (!disableActiveRagdoll.disableActiveRagdoll && Input.GetButtonDown("Character "+ poublardRagdoll.controllerNumber + " Submit"))
        {
            transform.parent.Find("LeftForearm").GetComponent<Rigidbody>().AddForce(angleDirection * new Vector3(0, 0, poublardRagdoll.punchMultiplicator * poublardRagdoll.punchForce));
            transform.parent.Find("RightForearm").GetComponent<Rigidbody>().AddForce(angleDirection * new Vector3(0, 0, poublardRagdoll.punchMultiplicator * poublardRagdoll.punchForce));
            transform.parent.Find("Left Foot").GetComponent<Rigidbody>().AddForce(angleDirection * new Vector3(0, 0, -poublardRagdoll.punchMultiplicator * poublardRagdoll.punchForce));
            transform.parent.Find("Right Foot").GetComponent<Rigidbody>().AddForce(angleDirection * new Vector3(0, 0, -poublardRagdoll.punchMultiplicator * poublardRagdoll.punchForce));

            SoundPlayer spawnSoundPlayer = Instantiate(soundPlayerPrefab, gameObject.transform.position, Quaternion.identity);
            spawnSoundPlayer.timeBeforeDestroy = 1f;
            spawnSoundPlayer.loop = false;
            spawnSoundPlayer.volume = 0.6f;
            spawnSoundPlayer.audioClip = punchSound;
        }
        //jump
        if (!disableActiveRagdoll.disableActiveRagdoll && Input.GetButtonDown("Character " + poublardRagdoll.controllerNumber + " Cancel"))
        {
            transform.parent.GetComponent<DisableActiveRagdoll>().disableActiveRagdoll = true;
            transform.parent.Find("Pelvis").GetComponent<Rigidbody>().AddForce(new Vector3(0, poublardRagdoll.jumpMultiplicator * poublardRagdoll.jumpForce));
        }
        //catch left
        if (!disableActiveRagdoll.disableActiveRagdoll && Input.GetButtonDown("Character " + poublardRagdoll.controllerNumber + " LeftThumb"))
        {
            if (catchState == CatchState.none)
            {
                catchState = CatchState.leftHand;
                Invoke("StopCatching", 2f);
            }
        }
        //catch right
        if (!disableActiveRagdoll.disableActiveRagdoll && Input.GetButtonDown("Character " + poublardRagdoll.controllerNumber + " RightThumb"))
        {
            if (catchState == CatchState.none)
            {
                catchState = CatchState.rightHand;
                Invoke("StopCatching", 2f);
            }
        }

        if (Mathf.Abs(angle1 - angle2) < 10f)
        {
        }
        else
        {
            float diff = Mathf.Abs(angle1 - angle2);
            if(diff > 180)
            {
                diff -= 360;
            }
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, poublardRagdoll.angleDirection.eulerAngles.y), Time.fixedDeltaTime * 15f);
        }

        float rightAxisXValue = Input.GetAxis("Character " + poublardRagdoll.controllerNumber + " RightStickX");
        if (Mathf.Abs(rightAxisXValue) < 0.2f) {
        }
        else if(rightAxisXValue > 0)
        {
            _rigidbody.AddTorque(new Vector3(0, 100f), 0);
        }
        else if(rightAxisXValue < 0)
        {
            _rigidbody.AddTorque(new Vector3(0, -100f), 0);
        }
    }

    public Vector3 ComputeTorque(Quaternion desiredRotation)
    {
        //q will rotate from our current rotation to desired rotation
        Quaternion q = desiredRotation * Quaternion.Inverse(transform.rotation);
        //convert to angle axis representation so we can do math with angular velocity
        Vector3 x;
        float xMag;
        q.ToAngleAxis(out xMag, out x);
        x.Normalize();
        //w is the angular velocity we need to achieve
        Vector3 w = x * xMag * Mathf.Deg2Rad / Time.fixedDeltaTime;
        w -= _rigidbody.angularVelocity;
        //to multiply with inertia tensor local then rotationTensor coords
        Vector3 wl = transform.InverseTransformDirection(w);
        Vector3 Tl;
        Vector3 wll = wl;
        wll = _rigidbody.inertiaTensorRotation * wll;
        wll.Scale(_rigidbody.inertiaTensor);
        Tl = Quaternion.Inverse(_rigidbody.inertiaTensorRotation) * wll;
        Vector3 T = transform.TransformDirection(Tl);
        return T;
    }
}
