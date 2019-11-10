using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPermanentForces : MonoBehaviour
{
    public bool xForceEnabled = false, yForceEnabled = false, zForceEnabled = false;
    public bool xForceEnabledFromRotation = false, yForceEnabledFromRotation = false, zForceEnabledFromRotation = false;
    public bool xTorqueEnabled = false, yTorqueEnabled = false, zTorqueEnabled = false;
    [Range(-5000, 5000)]
    public float xForce, yForce, zForce;
    [Range(-5000, 5000)]
    public float xTorque, yTorque, zTorque;
    PoublardRagdoll poublardRagdoll;


    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        poublardRagdoll = GetComponentInParent<PoublardRagdoll>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion rotation = transform.localRotation;
        if (xForceEnabled)
        {
            _rigidbody.AddForce(rotation * new Vector3(xForce, 0, 0));
        }
        if (yForceEnabled)
        {
           _rigidbody.AddForce(new Vector3(0, yForce, 0));
        }
        if (zForceEnabled)
        {
            _rigidbody.AddForce(rotation * new Vector3(0, 0, zForce));
        }

        if (xForceEnabledFromRotation)
        {
            _rigidbody.AddForce(poublardRagdoll.angleDirection * new Vector3(xForce, 0, 0));
        }
        if (yForceEnabledFromRotation)
        {
            _rigidbody.AddForce(poublardRagdoll.angleDirection * new Vector3(0, yForce, 0));
        }
        if (zForceEnabledFromRotation)
        {
            _rigidbody.AddForce(poublardRagdoll.angleDirection * new Vector3(0, 0, zForce));
        }

        if (xTorqueEnabled)
        {
            _rigidbody.AddTorque(new Vector3(xTorque, 0, 0));
        }
        if (yTorqueEnabled)
        {
           _rigidbody.AddTorque(new Vector3(0, yTorque, 0));
        }
        if (zTorqueEnabled)
        {
            _rigidbody.AddTorque(new Vector3(0, 0, zTorque));
        }
    }

    public void AddXForce()
    {
        Quaternion rotation = transform.localRotation;
        _rigidbody.AddForce(new Vector3(xForce, 0, 0));
    }
    public void AddYForce()
    {
        Quaternion rotation = transform.localRotation;
        _rigidbody.AddForce(new Vector3(0, yForce, 0));
    }
    public void AddZForce()
    {
        Quaternion rotation = transform.parent.Find("Pelvis").transform.rotation;
        
        Vector3 stickDir = new Vector3(0, Mathf.Atan2(Input.GetAxis("Character " + poublardRagdoll.controllerNumber + " Vertical"), Input.GetAxis("Character " + poublardRagdoll.controllerNumber + " Horizontal")) * 180 / Mathf.PI, 0);

        float x = Input.GetAxis("Character " + poublardRagdoll.controllerNumber + " Horizontal");
        float y = Input.GetAxis("Character " + poublardRagdoll.controllerNumber + " Vertical");
        if (x != 0.0f || y != 0.0f)
        {
            poublardRagdoll.angleDirection = Quaternion.Euler(0, (Mathf.Atan2(-y, x) * Mathf.Rad2Deg) + 90f, 0);
            Vector3 force = poublardRagdoll.speedMultiplicator * zForce * (poublardRagdoll.angleDirection * new Vector3(0, 0, 1));
            Debug.DrawRay(transform.position, poublardRagdoll.angleDirection * new Vector3(0, 0, 300), Color.red, 2f);
            _rigidbody.AddForce(force);

        }
    }

    public void AddXTorque()
    {
        _rigidbody.AddTorque(new Vector3(xTorque, 0, 0));
    }
    public void AddYTorque()
    {
        _rigidbody.AddTorque(new Vector3(0, yTorque, 0));
    }
    public void AddZTorque()
    {
        _rigidbody.AddTorque(new Vector3(0, 0, zTorque));
    }
}
