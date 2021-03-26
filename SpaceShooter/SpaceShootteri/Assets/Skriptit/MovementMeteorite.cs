using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMeteorite : MonoBehaviour
{
    float downspeed;
    float sideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        downspeed = Random.Range(2, 8);
        sideSpeed = Random.Range(-5, 5);
        Invoke("ded", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * downspeed * Time.deltaTime);
        transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
    }

    void ded()
    {
        Destroy(gameObject);
    }

}
