using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawingnMeteorites : MonoBehaviour
{
    public GameObject spawner;
    public GameObject[] meteorite;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Spawn()
    {
        Instantiate(meteorite[Random.Range(0, meteorite.Length )], spawner.transform.position, spawner.transform.rotation);
        Invoke("Spawn", 2f);
    }
}
