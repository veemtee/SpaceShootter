using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoMeteoriittiDamagejaSpawn : MonoBehaviour
{
    public GameObject[] meteorite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Tuhoutuminen()
    {

        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Instantiate(meteorite[Random.Range(0, meteorite.Length)], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
