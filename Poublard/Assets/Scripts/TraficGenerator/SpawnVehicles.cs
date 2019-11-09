using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicles : MonoBehaviour
{
    public GameObject[] vehicles;
    public float TimerSpawnMin = 2.0f;
    public float TimerSpawnMax = 5.0f;

    private float TimerRand;
    private float Timer = 0.0f;
    private GameObject randVehicles;
    // Start is called before the first frame update
    void Start()
    {
        TimerRand = RandomTimerSpawn();
        randVehicles = vehicles[0];
        Instantiate(randVehicles, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= TimerRand)
        {
            RandomVehicles();
            Instantiate(randVehicles, transform.position, transform.rotation);
            TimerRand = RandomTimerSpawn();
            Timer = 0.0f;
        }
        
    }

    void RandomVehicles()
    {
        int rand = Random.Range(0, vehicles.Length);
        randVehicles = vehicles[rand];
    }
    float RandomTimerSpawn()
    {
        return Random.Range(TimerSpawnMin, TimerSpawnMax);
    }
}
