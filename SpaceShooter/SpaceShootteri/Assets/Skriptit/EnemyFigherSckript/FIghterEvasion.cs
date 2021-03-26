using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIghterEvasion : MonoBehaviour
{
    public Vector2 startWait;
    public float dodge;
    public float tilt;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public float smoothing;
    public Boundary boundary;
    public float speed;
    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rig;



    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.velocity = transform.forward * speed;

        currentSpeed = rig.velocity.z;
        
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        { 
            targetManeuver = Random.Range (25, dodge ) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
    
    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rig.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rig.velocity = new Vector3(newManeuver, 0.0f,currentSpeed);
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xmin, boundary.xMax), 0.0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.Zmax));

        rig.rotation = Quaternion.Euler(0.0f, 0.0f, rig.velocity.x * -tilt);    
        
    }
}
