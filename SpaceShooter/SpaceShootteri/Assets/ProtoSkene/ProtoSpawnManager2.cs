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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(waveCountDown);

        waveCountDown -= Time.deltaTime;

        if (nextWave < waveCountDown)
        {
            //Debug.Log("wafeIF");
            Spawnwave();
            nextWave++;
        }

    }

    public void Spawnwave()
    {
        Debug.Log(waveToSpawn[nextWave]);
        Instantiate(waveToSpawn[nextWave]);
        waveCountDown = timeBetweenWaves[nextWave];
    }
}
