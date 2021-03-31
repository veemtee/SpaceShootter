using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public PlayerController pc;

    public Text scoreText;
    public int score;

    public AudioSource audios;
    public AudioSource audios2;
    public AudioClip gameOverClip;

    public int currentScore;
    public int newScore;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newScore > currentScore + 100)
        {
            audios.Play();
        }
        if (pc == null && gameOver == false)
        {
            Debug.Log("kuolisko");
            GameOver();
        }
    }

    public void ScoreCount(int localScore)
    {
        score += localScore;
        scoreText.text = score.ToString();
        currentScore = score;
        newScore = score + localScore;
    }

    public void GameOver()
    {
        audios2.PlayOneShot(gameOverClip);
        gameOver = true;
    }
}
