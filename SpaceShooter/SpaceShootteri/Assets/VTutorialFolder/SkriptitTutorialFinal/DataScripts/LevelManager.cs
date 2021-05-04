using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Medals medals = new Medals();
    public int TotalEnemy, enemyKilled, TotalRescue, humanRescued;

    public UnityEvent onGameEnd;

    private void Awake()
    {
        instance = this;
        medals.untouched = false;
    }

    public void RegisterEnemy()
    {
        TotalEnemy++;
    }
    
    public void RegisterRescua()
    {
        TotalRescue++;
    }

    public void AddEnemyKill()
    {
        enemyKilled++;
    }

    public void AddRescue()
    {
        humanRescued++;
    }

    public void PlayerHit()
    {
        medals.untouched = false;
    }

    public void GameEnd()
    {
        StartCoroutine(CountDelay());
    }

    IEnumerator CountDelay()
    {
        yield return new WaitForSeconds(0.25f);

        if (enemyKilled == TotalRescue)
            medals.kill = true;

        if (humanRescued == TotalRescue)
            medals.rescue = true;

        onGameEnd.Invoke();
    }
}

[System.Serializable]

public class Medals
{
    public bool rescue, kill, untouched;
}

