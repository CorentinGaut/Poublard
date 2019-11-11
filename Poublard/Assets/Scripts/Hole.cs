using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float ejectionForce;
    public GameObject exit;
    public Vector3 ejectionVector;
    public float maxAngle;

    private void Start()
    {
        ejectionVector = exit.transform.up;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            IEnumerator coroutine;
            coroutine = Ejection(other.gameObject);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator Ejection(GameObject cc)
    {
        //cc.SetActive(false);
        Collider[] cols = cc.transform.parent.GetComponentsInChildren<Collider>();
        Renderer[] rends = cc.transform.parent.GetComponentInParent<Transform>().GetComponentsInChildren<Renderer>();
        foreach (Collider c in cols)
        {

            c.enabled = false;
        }

        foreach (Renderer r in rends)
        {
            r.enabled = false;
        }

        cc.gameObject.GetComponent<Rigidbody>().velocity = (gameObject.transform.position - cc.transform.position)*2;


        yield return new WaitForSeconds(1.0f);

        cc.gameObject.transform.position = exit.transform.position - Vector3.down*5;
        cc.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        float angle = UnityEngine.Random.Range(-maxAngle*Mathf.Deg2Rad, maxAngle * Mathf.Deg2Rad);

        cc.GetComponent<Rigidbody>().velocity = (ejectionVector*ejectionForce + new Vector3(Mathf.Cos(angle) * ejectionForce, ejectionForce, Mathf.Sin(angle) * ejectionForce));
        foreach (Renderer r in rends)
        {
            r.enabled = true;
        }       
        yield return new WaitForSeconds(0.2f);



        foreach (Collider c in cols)
        {
            c.enabled = true;

        }
        //cc.SetActive(true);
    }
}
