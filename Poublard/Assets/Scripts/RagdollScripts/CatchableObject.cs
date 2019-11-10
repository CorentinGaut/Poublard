using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObject : MonoBehaviour
{
    Rigidbody _rigidbody;
    float defaultMass;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        defaultMass = _rigidbody.mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetComponent<ConfigurableJoint>() == null)
        {
            _rigidbody.mass = defaultMass;
        } else
        {
            _rigidbody.mass = 0.01f;
        }
    }
}
