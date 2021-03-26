using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;

    private Rigidbody rb;

    public float turnspeed = 200f;
    public float speed = 20f;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
        var rocketTargetRotation = Quaternion.LookRotation(target.position - transform.position);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turnspeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
