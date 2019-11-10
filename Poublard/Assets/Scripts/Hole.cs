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
            coroutine = Ejection(other.gameObject.GetComponent<CharController>());
            StartCoroutine(coroutine);
        }
    }

    IEnumerator Ejection(CharController cc)
    {
        cc.enabled = false;
        Collider[] cols = cc.GetComponents<Collider>();
        foreach(Collider c in cols)
        {
            c.enabled = false;
        }

        cc.gameObject.GetComponent<Rigidbody>().velocity = (gameObject.transform.position - cc.transform.position)*2;


        yield return new WaitForSeconds(3.0f);

        cc.gameObject.transform.position = exit.transform.position - Vector3.down * 3;
        cc.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        float angle = UnityEngine.Random.Range(-maxAngle*Mathf.Deg2Rad, maxAngle * Mathf.Deg2Rad);

        foreach (Collider c in cols)
        {
            c.GetComponent<Rigidbody>().AddForce(ejectionVector + new Vector3(Mathf.Cos(angle) * ejectionForce, ejectionForce, Mathf.Sin(angle) *ejectionForce), ForceMode.Impulse);
        }
        
        yield return new WaitForSeconds(1.5f);
        foreach (Collider c in cols)
        {
            c.enabled = true;
        }
        cc.enabled = true;
    }
}
