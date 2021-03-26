using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMeteorite : MonoBehaviour
{

    float rotx;
    float roty;
    float rotz;

    // Start is called before the first frame update
    void Start()
    {
        rotx = Random.Range(1, -1);
        roty = Random.Range(1, -1);
        rotz = Random.Range(1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotx, roty, rotz, Space.Self);
    }
}
