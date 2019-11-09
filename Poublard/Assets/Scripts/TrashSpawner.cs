using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> objects;
    public LevelManager lvlManager;

    public int nbTrashSpawned;

    public float minPosX;
    public float minPosZ;
    public float maxPosX;
    public float maxPosZ;

    public float ejectionDistance;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager.totalNbTrash += nbTrashSpawned;
        SpawnTrash();
    }

    private void SpawnTrash()
    {
        for(int i = 0;i<nbTrashSpawned;i++)
        {
            GameObject go = Instantiate(objects[UnityEngine.Random.Range(0, objects.Count)]);
            go.transform.position = new Vector3(UnityEngine.Random.Range(minPosX, maxPosX), 0,UnityEngine.Random.Range(minPosZ, maxPosZ));
            float angle = UnityEngine.Random.Range(-Mathf.PI, Mathf.PI);
            go.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Cos(angle)*ejectionDistance, ejectionDistance,  Mathf.Sin(angle)*ejectionDistance),ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
