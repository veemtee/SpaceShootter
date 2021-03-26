using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy;
        public int enemyCount;
        public float spawnRate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves;
    public float waveCountDown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //chek if enemies live or time counter has passed
            if(EnemyIsAlive()== false)
            {
                //begin new round

            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(Spawnwave(waves[nextWave]));
            }
            
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log(" wave completed");
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if(nextWave +1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("all waves complete");
        }
        else
        {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive()
    {
        //tähän ehkä ennemmin timerin tarkastus

        searchCountdown -= Time.deltaTime;
        if (searchCountdown<=0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        

        return true;
    }

    IEnumerator Spawnwave (Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f); // _wave.delay);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.RandomRange(0, spawnPoints.Length)];
        Instantiate(_enemy, transform.position, transform.rotation);
        Debug.Log("Spawning enemy" + _enemy.name);
    }
}
