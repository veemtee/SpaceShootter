using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    public GameObject explosion;

    public GameController gameController;
    //public AudioSource audios;

    void Start()
    {
        rig.velocity = transform.forward * speed;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //audios.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        gameController.ScoreCount(3);
        Debug.Log("lisääscoreajooko");
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
