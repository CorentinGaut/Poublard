using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PoublardRagdoll : MonoBehaviour
{
    public Quaternion angleDirection;
    public Vector3 vecDirection;
    public int controllerNumber;
    public float jumpMultiplicator = 1f, punchMultiplicator = 1f, speedMultiplicator = 1f;
    public float punchForce = 150f, jumpForce = 1500f;
    public bool dead = false, respawn = false;
    Vector3[] defaultPosChildren;
    public GameObject prefab;
    Coroutine respawnCoroutine;

    private void Awake()
    {
        if(prefab == null)
        {
            prefab = gameObject;
        }
        Transform[] tr_children = GetComponentsInChildren<Transform>();
        defaultPosChildren = new Vector3[tr_children.Length];
        for (int i = 0; i < tr_children.Length; i++)
        {
            defaultPosChildren[i] = tr_children[i].position;
        }
    }

    void ReinitJumpMultiplicator()
    {
        jumpMultiplicator = 1f;
    }
    void ReinitPunchMultiplicator()
    {
        punchMultiplicator = 1f;
    }
    void ReinitSpeedMultiplicator()
    {
        speedMultiplicator = 1f;
    }

    public void ChangeJumpMultiplicator(float newMultiplicator = 1.5f, float time = 5f)
    {
        jumpMultiplicator = newMultiplicator;
        CancelInvoke("ReinitJumpMultiplicator");
        Invoke("ReinitJumpMultiplicator", time);
    }
    public void ChangePunchMultiplicator(float newMultiplicator = 3f, float time = 5f)
    {
        punchMultiplicator = newMultiplicator;
        CancelInvoke("ReinitPunchMultiplicator");
        Invoke("ReinitPunchMultiplicator", time);
    }
    public void ChangeSpeedMultiplicator(float newMultiplicator = 2f, float time = 5f)
    {
        jumpMultiplicator = newMultiplicator;
        CancelInvoke("ReinitSpeedMultiplicator");
        Invoke("ReinitSpeedMultiplicator", time);
    }

    private void Update()
    {
        if (dead)
        {
            Array.ForEach(GetComponentsInChildren<ConfigurableJoint>(), x => Destroy(x));
            Destroy(transform.Find("Pelvis").GetComponent<AddPermanentForces>());
            Destroy(GetComponentInChildren<FallDetection>());
            //Destroy(this);
        }
        if (dead && respawn)
        {
            respawn = false;
            dead = false;
            respawnCoroutine = StartCoroutine(Respawn());
            
        }
    }

    IEnumerator Respawn()
    {
        Array.ForEach(GetComponentsInChildren<Collider>(), x => x.enabled = false);
        float timer = 0;
        float totalTime = 1f;
        Transform[] tr_children = GetComponentsInChildren<Transform>();
        Vector3[] finalPosChildren = new Vector3[tr_children.Length];
        for (int i = 0; i < tr_children.Length; i++)
        {
            finalPosChildren[i] = tr_children[i].position;
        }

        while (timer < totalTime)
        {
            yield return null;
            timer += Time.deltaTime;
            
            for (int i = 0; i < tr_children.Length; i++)
            {
                tr_children[i].position = Vector3.Lerp(finalPosChildren[i], defaultPosChildren[i], timer / totalTime);
            }
        }
        GameObject newRagdoll = Instantiate(prefab, transform.position, transform.rotation, transform.parent);
        newRagdoll.name = name;
        newRagdoll.GetComponent<PoublardRagdoll>().controllerNumber = controllerNumber;
        newRagdoll.GetComponent<PoublardRagdoll>().dead = false;
        newRagdoll.GetComponent<PoublardRagdoll>().respawn = false;
        Array.ForEach(newRagdoll.GetComponentsInChildren<Collider>(), x => x.enabled = true);
        Destroy(gameObject);
    }
}
