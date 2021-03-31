using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dead", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
