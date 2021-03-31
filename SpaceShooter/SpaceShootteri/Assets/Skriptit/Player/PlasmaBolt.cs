using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBolt : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    public GameObject explosion;
    public ParticleSystem plasmaEffect;

    public PointManager gameController;

    void Start()
    {
        rig.velocity = transform.forward * speed;
        //gameController = GameObject.Find("PointManager").GetComponent<PointManager>();
        plasmaEffect.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        gameController.ScoreCount(3);
        //Debug.Log("lisääscoreajooko");
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
