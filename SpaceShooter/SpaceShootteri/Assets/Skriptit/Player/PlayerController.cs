using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Boundary
{
    public float xmin, xMax, zMin, Zmax;
}

public class PlayerController : MonoBehaviour // IPointerDownHandler, IPointerUpHandler
{
    public Joystick joysick;
    public Button plasma;
    public Button railgun;

    public Rigidbody rig;
    //public Transform rig2;
    public float speed = 1;
    public Boundary boundary;
    public float tilt;
    public float panning;

    public GameObject bullet;
    public GameObject[] sarjaSpawn;
    public GameObject railgunSpawn;
    public GameObject railBolt;
    public GameObject spaceShip;


    int shotIndex = 0;
    public float fireRate;
    private float lastFire = 0.0f;

    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public bool deadorAlive = false;

    public GameObject explosion;

    public AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        print(joysick.Vertical);
        //print(joysick.Horizontal);

        if (joysick.Horizontal <= .2f)
        {
            spaceShip.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (joysick.Horizontal >= -.2f)
        {
            spaceShip.transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector2.right * 0);
        }


        if (joysick.Vertical <= .2f)
        {
            spaceShip.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (joysick.Vertical >= -.2f)
        {
            spaceShip.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector3.forward * 0);
        }

        /* if (Input.GetButton("Fire1") && Time.time > lastFire)
         {
             lastFire = Time.time + fireRate;

             Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
             //suuliekki.Play();
             shotIndex++;
             if (shotIndex > 3)
                 shotIndex = 0;
         } */


    }

    private void FixedUpdate()
    {
        if (armoryCurrentHealth <= 0)
        {
            if (deadorAlive == true)
            {
                Invoke("Tuhoutuminen", 0.0f);
            }
        }

        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHor, 0.0f, moveVer);
        rig.velocity = movement * speed;


        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xmin, boundary.xMax), 0.0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.Zmax));

        rig.rotation = Quaternion.Euler(rig.rotation.x,/* 0.0f*/ rig.velocity.x * panning + 180, rig.velocity.x * tilt);
    }

    

    private void OnTriggerEnter(Collider VihuBullet)
    {
        
            Debug.Log("PlayerControllervihubullet");
            armoryCurrentHealth--;
            Destroy(VihuBullet.gameObject);

    }

    void Tuhoutuminen()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ShootRailgun()
    {
        Debug.Log("bang!");
        Instantiate(railBolt, railgunSpawn.transform.position, railgunSpawn.transform.rotation);
    }


    public void shootPlasme()
    {
            lastFire = Time.time + fireRate;

            Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
            //suuliekki.Play();
            shotIndex++;
            if (shotIndex > 3)
                shotIndex = 0; 
    }
}
