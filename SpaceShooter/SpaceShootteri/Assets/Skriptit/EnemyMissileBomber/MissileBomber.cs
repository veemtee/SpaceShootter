using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBomber : MonoBehaviour
{
    public int bomberHealth;
    public int bomberCurrentHealth;
    public bool deadOrAlive = false;
    public GameController gameController;

    public GameObject explosion;
    public GameObject isoExplosion;

    public GameObject[] sarjaExplosion;
    int expIndex;
    public GameObject finalExplosion;

    public GameObject missile1;
    public GameObject missile1Spawn;
    public GameObject missile2;
    public GameObject missile2Spawn;

    public Rigidbody bomberRb;
    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        bomberCurrentHealth = bomberHealth;

        //Invoke("ShootMissiles", 2f);

        Invoke("Movement", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bomberCurrentHealth <= 0)
        {
            if (deadOrAlive == true)
            {
                Instantiate(explosion, sarjaExplosion[expIndex].transform.position, sarjaExplosion[expIndex].transform.rotation);
                expIndex++;
                if (expIndex > 5)
                    expIndex = 0;
                Invoke("Tuhoutuminen", 1.0f);
            }
        }
    }

    void Movement()
    {
        bomberRb.velocity = transform.forward * speed;
        Invoke("ShootMissiles", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {

            bomberCurrentHealth--;
            Destroy(other.gameObject);

        }
        if (other.tag == "RailGun")
        {

            bomberCurrentHealth -= 50;
            Destroy(other.gameObject);

        }

        if (other.tag == "Boundary")
        {
            return;
        }
        
        if (other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

    void Tuhoutuminen()
    {
        gameController.ScoreCount(6667);
        
        Instantiate(isoExplosion, finalExplosion.transform.position,finalExplosion.transform.rotation);

        Destroy(gameObject);
    }

    public void ShootMissiles()
    {
        //Debug.Log("shootmissilessa");
        speed = 150000f;
        bomberRb.AddRelativeForce(transform.forward * speed * Time.deltaTime);
        bomberRb.AddForce(transform.right * -30000f * Time.deltaTime);
        // missile1.SetActive(true);
        Instantiate(missile1, missile1Spawn.transform.position, missile1Spawn.transform.rotation);
        missile1Spawn.SetActive(false);
        Instantiate(missile2, missile2Spawn.transform.position, missile2Spawn.transform.rotation);
        missile2Spawn.SetActive(false);


    }
}
