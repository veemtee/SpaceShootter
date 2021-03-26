using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriittiMovement : MonoBehaviour
{
    public GameObject meteoriitti;
    float rotx;
    float roty;
    float rotz;
    float downspeed;
    float sideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotx = Random.Range(2, -2);
        roty = Random.Range(2, -2);
        rotz = Random.Range(2, -2);
        downspeed = Random.Range(2, 4);
        sideSpeed = Random.Range(-1, 1);
        Invoke("ded", 5f);
    }

    // Update is called once per frame
    void Update()
    {
       // meteoriitti.transform.Rotate(rotx, roty, rotz, Space.Self);
        meteoriitti.transform.Translate(Vector3.down * downspeed * Time.deltaTime);
        meteoriitti.transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
        

    }

    void ded()
    {
        Destroy(gameObject);
    }
}
