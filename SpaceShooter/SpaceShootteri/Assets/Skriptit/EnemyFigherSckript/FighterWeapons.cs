using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterWeapons : MonoBehaviour
{
    //private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float fireDelay;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", fireDelay, fireRate);
    }

    

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //audioSource.Play();
    }
}
