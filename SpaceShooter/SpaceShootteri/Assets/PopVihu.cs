﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopVihu : MonoBehaviour
{
    public GameObject explosion;
    public GameObject popBolt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
