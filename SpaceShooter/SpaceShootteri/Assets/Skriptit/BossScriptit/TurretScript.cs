using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform hero;
    //private Rigidbody heroRb;
    public GameObject bullet;
    public Transform btrTorni;
    public float timeBetweenShots;
    public float startTimeBtwShots;
    public GameObject bulletSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        //hero = GameObject.Find("Player");
        //heroRb = hero.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 relativePos = hero.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(relativePos, new Vector3(0, 0, 0));
        //transform.rotation = rotation * Quaternion.Euler(0, 1, 0);

        //Vector3 relativePosition = hero.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.right);
        //transform.rotation = rotation;

        //btrTorni.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Vector3 heroDirection = transform.position - hero.transform.position;
        //float angle = Mathf.Atan2(heroDirection.z, heroDirection.x) * Mathf.Rad2Deg;
        transform.LookAt(hero, Vector3.forward);
        //float adjustedAngle = Mathf.Round(((angle + 90f) * -1) / 45.0f) * 45.0f;
        //transform.localRotation = Quaternion.Euler(0, adjustedAngle, 0);

        //Vector3 direction = new Vector3((hero.position.x - transform.position.x), (hero.position.y - transform.position.y), (hero.position.z - transform.position.z));
        //transform.localRotation = Quaternion.Euler(direction);
        //btrTorni.rotation = Quaternion.Euler(hero.position.x, hero.position.y , hero.position.z);

        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            timeBetweenShots = startTimeBtwShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
