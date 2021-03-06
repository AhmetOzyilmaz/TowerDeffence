﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Enemy;
    private GameObject Copy;

    public float spawnRate = 1.0f;
    float timeLeftToSpawn;


    // Use this for initialization
    void Start()
    {
        timeLeftToSpawn = spawnRate;
        Copy = Enemy;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToSpawn -= Time.deltaTime;
        if (timeLeftToSpawn < 0 )
        {
            Spawn();
            timeLeftToSpawn = spawnRate;
        }
    }


    void Spawn()
    {
        EnemySoldier[] zombies = FindObjectsOfType<EnemySoldier>();

        if (zombies.Length > 0)
        {
            Copy = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
            Copy.active = true;
        }
    }
}
