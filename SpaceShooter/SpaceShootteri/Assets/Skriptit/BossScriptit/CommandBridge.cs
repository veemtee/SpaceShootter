using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBridge : MonoBehaviour
{
    public int armoryMaxHealth;
    public int armoryCurrentHealth;
    public GameObject bridge;

    public GameObject Raato;
    public bool deadorAlive = false;
    public ForwardArmory armory;
    public LeftSilo leftSilo;
    public RightSilo righSilo;


    //public GameObject keulaPanssariTrigger;
    //public GameObject muuPanssariTrigger;

    private void Start()
    {
        armoryCurrentHealth = armoryMaxHealth;
    }

    private void Update()
    {
        if(armory.deadorAlive == false && leftSilo.deadorAlive == false && righSilo.deadorAlive == false)
        {
            if (armoryCurrentHealth <= 0)
            {
                if (deadorAlive == true)
                {

                    Instantiate(Raato.gameObject, transform.position, transform.rotation);
                    Invoke("Tuhoutuminen", 0.0f);
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("LuotiOsuPerään");

            armoryCurrentHealth--;

        }

        if (other.tag == "Railgun")
        {
            Debug.Log("kranuOsuPerään");
            armoryCurrentHealth = -21;
        }
    }



    void Tuhoutuminen()
    {
        bridge.SetActive(false);
    }
}
