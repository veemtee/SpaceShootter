﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabScript : MonoBehaviour
{
    public float spawnDelay;
    public int spawnAmount;
    public Transform spawnPoints;
    public GameObject vihuSpawnTyyppi;
    public float spawnTimer;

    public int spawnIndex = 0;

    //public GameObject[] vihuReitti;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnDelay;
        //Debug.Log("Spawnprefab Start");
        InvokeRepeating("Spawnaa", 0f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAmount == 0)
        {
            Destroy(gameObject);
        }
           // spawnTimer -= Time.deltaTime;
        
    }

    public void Spawnaa()
    {
        
            Instantiate(vihuSpawnTyyppi, spawnPoints.transform.position, spawnPoints.transform.rotation);
        spawnAmount--;
         
    }
}

