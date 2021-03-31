using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornSpawnerScript : MonoBehaviour
{
    public GameObject[] vihualus;
    public Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector2 objectPosition;
    public float speedModifier;
    private bool coroutineAllowed;

    public float spawnDelay;
    public int spawnAmount;
    public int spawnCount;


    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
        spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        vihualus[spawnCount].transform.position = objectPosition;

        if (coroutineAllowed && spawnAmount > 0)
        {
            //StartCoroutine(GoByTheRoute(routeToGo));
            InvokeRepeating("Spawnaa", 0f, spawnDelay);
        }

        if (spawnCount == (spawnAmount -1))
        {
            Invoke("Ded", 4f);
        }


        //Debug.Log(objectPosition);
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;
        Vector2 p0 = routes[routeNum].GetChild(0).position;

        Vector2 p1 = routes[routeNum].GetChild(1).position;

        Vector2 p2 = routes[routeNum].GetChild(2).position;

        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)

        {
            
            tParam += Time.deltaTime * speedModifier;
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            //vihualus[spawnCount].transform.position = objectPosition;
            //transform.LookAt(objectPosition);

            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        coroutineAllowed = true;
    }

    public void Spawnaa()
    {
        Debug.Log("SPAWNAA");
        Instantiate(vihualus[spawnCount], routes[spawnCount].position, routes[spawnCount].rotation);
        //vihualus[spawnCount].transform.SetParent(objectPosition);
        StartCoroutine(GoByTheRoute(routeToGo));
        spawnCount++;

    }

    public void Ded()
    {
        Destroy(gameObject);
    }
}
