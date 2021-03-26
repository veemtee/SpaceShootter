using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBoatSpawner : MonoBehaviour
{

    public GameObject[] boatSpawnPoints;
    public GameObject missileboat;
    int index;
    bool canSpawn = true;
    int bomberCounter;
    public int bomberCOunterTarget;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        if (canSpawn == true)
        {
            StartCoroutine(SpawnBomber());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SpawnBomber()
    {
        if (canSpawn == true)
        {
            Instantiate(missileboat, boatSpawnPoints[index].transform.position, boatSpawnPoints[index].transform.rotation);
            index++;
            bomberCounter++;
            if (index > 1)
                index = 0;
            yield return new WaitForSeconds(spawnDelay);

            if (bomberCounter > bomberCOunterTarget)
            {
                canSpawn = false;
            }
        }
    }
}
