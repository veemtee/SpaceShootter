using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 1f;

    Quaternion rotateToTarget;
    Vector3 suunta;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        suunta = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg;
        rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);
        rigidbody.velocity = new Vector2(suunta.x * 2, suunta.y * 2);
    }
}
