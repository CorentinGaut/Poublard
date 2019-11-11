using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PoublardRagdoll : MonoBehaviour
{
    public SoundPlayer soundPlayerPrefab;
    public AudioClip respawnSound;

    public Quaternion angleDirection;
    public Vector3 vecDirection;
    public int controllerNumber;
    public float jumpMultiplicator = 1f, punchMultiplicator = 1f, speedMultiplicator = 1f;
    public float punchForce = 150f, jumpForce = 1500f, walkForce = 600;
    public bool dead = false, respawn = false;
    Vector3[] defaultPosChildren;
    Quaternion[] defaultRotationChildren;
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
        defaultRotationChildren = new Quaternion[tr_children.Length];
        for (int i = 0; i < tr_children.Length; i++)
        {
            defaultPosChildren[i] = tr_children[i].position;
            defaultRotationChildren[i] = tr_children[i].localRotation;
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

    public void PrepareRespawn()
    {
        CancelInvoke("StartRespawn");
        Invoke("StartRespawn", 5f);
    }

    void StartRespawn()
    {
        respawn = true;
    }

    public void ChangeJumpMultiplicator(float newMultiplicator = 1.5f, float time = 15f)
    {
        jumpMultiplicator = newMultiplicator;
        CancelInvoke("ReinitJumpMultiplicator");
        Invoke("ReinitJumpMultiplicator", time);
    }
    public void ChangePunchMultiplicator(float newMultiplicator = 3f, float time = 15f)
    {
        punchMultiplicator = newMultiplicator;
        CancelInvoke("ReinitPunchMultiplicator");
        Invoke("ReinitPunchMultiplicator", time);
    }
    public void ChangeSpeedMultiplicator(float newMultiplicator = 2f, float time = 15f)
    {
        speedMultiplicator = newMultiplicator;
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

            SoundPlayer spawnSoundPlayer = Instantiate(soundPlayerPrefab, gameObject.transform.position, Quaternion.identity);
            spawnSoundPlayer.timeBeforeDestroy = 1f;
            spawnSoundPlayer.loop = false;
            spawnSoundPlayer.volume = 0.4f;
            spawnSoundPlayer.audioClip = respawnSound;

        } else
        {
            transform.Find("Left Foot").GetComponent<AddPermanentForces>().zForce = walkForce;
            transform.Find("Right Foot").GetComponent<AddPermanentForces>().zForce = walkForce;
        }
    }

    IEnumerator Respawn()
    {
        Array.ForEach(GetComponentsInChildren<Collider>(), x => x.enabled = false);
        float timer = 0;
        float totalTime = 1f;
        Transform[] tr_children = GetComponentsInChildren<Transform>();
        Vector3[] finalPosChildren = new Vector3[tr_children.Length];
        Quaternion[] finalRotationChildren = new Quaternion[tr_children.Length];
        for (int i = 0; i < tr_children.Length; i++)
        {
            finalPosChildren[i] = tr_children[i].position;
            finalRotationChildren[i] = tr_children[i].localRotation;
        }

        while (timer < totalTime)
        {
            yield return null;
            timer += Time.deltaTime;
            
            for (int i = 0; i < tr_children.Length; i++)
            {
                tr_children[i].position = Vector3.Lerp(finalPosChildren[i], defaultPosChildren[i], timer / totalTime);
                tr_children[i].localRotation = Quaternion.Lerp(finalRotationChildren[i], defaultRotationChildren[i], timer / totalTime);
            }
        }
        GameObject newRagdoll = Instantiate(prefab, transform.position, transform.rotation, transform.parent);
        newRagdoll.name = name;
        PoublardRagdoll newPoublardRagdoll = newRagdoll.GetComponent<PoublardRagdoll>();
        newPoublardRagdoll.controllerNumber = controllerNumber;
        newPoublardRagdoll.dead = false;
        newPoublardRagdoll.respawn = false;
        newPoublardRagdoll.angleDirection = new Quaternion();
        newPoublardRagdoll.vecDirection = Vector3.zero;
        Array.ForEach(newRagdoll.GetComponentsInChildren<Collider>(), x => x.enabled = true);
        Destroy(gameObject);
    }
}
