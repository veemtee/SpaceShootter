using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabScript : MonoBehaviour
{
    public float spawnDelay;
    public int spawnAmount;
    public Transform spawnPoints;
    public GameObject vihuSpawnTyyppi;
    public float spawnTimer;

    public int spawnIndex = 0;
    public int spawnerNumber;

    //public GameObject[] vihuReitti;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnerNumber == 0)
        {
            transform.position = new Vector3(5f, 7.5f, 0);
        }
        else if(spawnerNumber == 1)
        {
            transform.position = new Vector3(-3.7f, 9.3f, 0);
        }
        else if (spawnerNumber == 2)
        {
            transform.position = new Vector3(0.5f, 9f, 0);
        }

        spawnTimer = spawnDelay;
        //Debug.Log("Spawnprefab Start");
        InvokeRepeating("Spawnaa", 0f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAmount == 0)
        {
            CancelInvoke("Spawnaa");
        }
           // spawnTimer -= Time.deltaTime;
        
    }

    public void Spawnaa()
    {
        
            Instantiate(vihuSpawnTyyppi, spawnPoints.transform.position, spawnPoints.transform.rotation);
        spawnAmount--;
         
    }
}

