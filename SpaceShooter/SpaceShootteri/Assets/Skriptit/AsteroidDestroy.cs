using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public GameController gameController;

    private void Start()
    { 

        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);

        if(other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }

        
        Debug.Log(other.name);
        gameController.score = +1000;
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
