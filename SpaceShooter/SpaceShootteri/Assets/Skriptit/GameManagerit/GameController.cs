using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Asteroid;
    public Vector3 spawnValue;
    public int waveCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public int score;
    public AudioSource audios;
    public AudioSource audios2;
    public AudioClip gameOverClip;
    public PlayerController pc;

    public int currentScore;
    public int newScore;
    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine (SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(newScore > currentScore +100)
        {
            audios.Play();
        }
        if (pc == null && gameOver == false)
        {
            Debug.Log("kuolisko");
            GameOver();
            
        }
        
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < waveCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Asteroid[Random.Range(0, Asteroid.Length)], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            //yield return new WaitForSeconds(waveWait);
        }
      
    }

    public void ScoreCount(int localScore)
    {
        score += localScore;
        scoreText.text = score.ToString();
        currentScore = score;
        newScore = score + localScore;
    }

    public void GameOver ()
    {

        audios2.PlayOneShot(gameOverClip);
        gameOver = true;
    }
}
