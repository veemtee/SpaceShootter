using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    //private GameController gameController;

    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public bool deadorAlive = false;
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
       /* GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("cantfind gamecontrolleriaaa");
        } */
    }

    private void Update()
    {
        if (armoryCurrentHealth <= 0)
        {
            if (deadorAlive == true)
            {
                Invoke("Tuhoutuminen", 0.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);

        /* if (other.tag == "Boundary")
         {
             return;
         } 
         if (other.tag == "VihuBolt")
         {
             return;
         }
         if (other.tag == "Enemy")
         {
             return;
         }
         Instantiate(explosion, transform.position, transform.rotation);*/

        if (other.tag == "Bullet")
        {
            armoryCurrentHealth--;
            //Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }   
    }

    void Tuhoutuminen()
    {
        gameController.ScoreCount(555);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
