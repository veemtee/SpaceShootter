using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnRotator : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void concentraded()
    {
        Debug.Log("concentrated");
        spawn1.transform.localEulerAngles = new Vector3(0, -180, 0);
        spawn2.transform.localEulerAngles = new Vector3(0, -179, 0);
        spawn3.transform.localEulerAngles = new Vector3(0, -181, 0);
        spawn4.transform.localEulerAngles = new Vector3(0, -179, 0);
    }

    public void speaded()
    {
        Debug.Log("spreaded");
        spawn1.transform.localEulerAngles = new Vector3(0, -190, 0);
        spawn2.transform.localEulerAngles = new Vector3(0, -182, 0);
        spawn3.transform.localEulerAngles = new Vector3(0, -190, 0);
        spawn4.transform.localEulerAngles = new Vector3(0, -182, 0);
    }
}
