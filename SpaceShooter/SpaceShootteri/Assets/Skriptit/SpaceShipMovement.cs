using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipMovement : MonoBehaviour
{

    public Joystick joysick;
    public float speed;
    public GameObject spaceShip;

    public GameObject bullet;
    public GameObject bulletSpawn;

    public Button firebutton;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joysick.Horizontal >= .2f)
        {
            spaceShip.transform.Translate(Vector2.right * speed  * Time.deltaTime);
        }
        if (joysick.Horizontal <= -.2f)
        {
            spaceShip.transform.Translate(Vector2.right * -speed  * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector2.right * 0);
        }


        if (joysick.Vertical >= .2f)
        {
            spaceShip.transform.Translate(Vector2.up * speed  * Time.deltaTime);
        }
        if (joysick.Vertical <= -.2f)
        {
            spaceShip.transform.Translate(Vector2.up * -speed  * Time.deltaTime);
        }
        else
        {
            spaceShip.transform.Translate(Vector2.up * 0);
        }
    }

    public void Shoot()
    {
        Debug.Log("bang!");
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }
}
