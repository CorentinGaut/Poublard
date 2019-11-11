using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject[] powerUpsPrefabs;

    public float minPopTime = 10f;
    public float maxPopTime = 10f;
    float popTime;
    public float limitLeft = -40f, limitRight = 40f, limitUp = 40f, limitDown = -15f, altitude = 40f;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        popTime = Random.Range(minPopTime, maxPopTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= popTime)
        {
            Vector3 pUpPos = new Vector3(Random.Range(limitLeft, limitRight), altitude, Random.Range(limitDown, limitUp));
            Instantiate(powerUpsPrefabs[Random.Range(0, powerUpsPrefabs.Length)], pUpPos, new Quaternion(), transform);
            timer = 0;
            popTime = Random.Range(minPopTime, maxPopTime);
        }
    }
}
