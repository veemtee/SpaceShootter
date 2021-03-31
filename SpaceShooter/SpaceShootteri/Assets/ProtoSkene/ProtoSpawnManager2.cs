using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoSpawnManager2 : MonoBehaviour
{
    public GameObject[] waveToSpawn;
    public float[] timeBetweenWaves;
    public float waveCountDown;

    public int nextWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves[nextWave];
        //Debug.Log(timeBetweenWaves[nextWave]);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waveCountDown);

        waveCountDown -= Time.deltaTime;

        if (waveCountDown <= 0)
        {
            //Debug.Log("wafeIF");
            
            nextWave++;

            //Spawnwave();
            Instantiate(waveToSpawn[nextWave]);

            waveCountDown = timeBetweenWaves[nextWave];
        }

    }

    public void Spawnwave()
    {
        Debug.Log(waveToSpawn[nextWave]);
        
       
    }
}
