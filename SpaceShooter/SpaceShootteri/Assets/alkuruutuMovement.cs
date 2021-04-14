using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alkuruutuMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Translate(Vector3.forward * 1000f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
