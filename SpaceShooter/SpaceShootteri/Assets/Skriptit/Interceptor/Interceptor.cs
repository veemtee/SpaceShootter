﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interceptor : MonoBehaviour
{
    public Transform targetbox;
    public GameObject[] gunSpawns;
    public GameObject bullet;

    private float lastfire = 0.0f;
    public float firerate;
    int shotIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NOH!?");
    }

    // Update is called once per frame
    void Update()
    {
        lastfire = Time.time + firerate;

        Instantiate(bullet, gunSpawns[shotIndex].transform.position, gunSpawns[shotIndex].transform.rotation);
        shotIndex++;
        if (shotIndex > 1)
            shotIndex = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("NOH!?");
        if (other.tag == ("Player"))
        {
            
            lastfire = Time.time + firerate;

            Instantiate(bullet, gunSpawns[shotIndex].transform.position, gunSpawns[shotIndex].transform.rotation);
            shotIndex++;
            if (shotIndex > 1)
                shotIndex = 0;
        }
    }
}   