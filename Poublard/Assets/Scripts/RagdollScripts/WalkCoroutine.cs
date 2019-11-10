using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCoroutine : MonoBehaviour
{
    public AddPermanentForces leftFoot, rightFoot;
    public float force = 250f;
    public Coroutine walkCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        walkCoroutine = StartCoroutine(ChangeColor());
        leftFoot.zForce = force;
        rightFoot.zForce = force;
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            leftFoot.AddZForce();
            yield return new WaitForSeconds(0.4f);
            rightFoot.AddZForce();
        }
    }
}
