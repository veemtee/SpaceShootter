using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipTower : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;

    public Transform target;
    public Transform partToRotate;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

        //var lookPos = target.transform.position - transform.position;
        //lookPos.z = 0;
        //var rotation = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
}
