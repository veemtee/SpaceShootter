using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float kallistus;
    public float killistys;
    private Rigidbody myRb;

    private Camera cam;
    private float distance;
    private Vector3 velocity, lastPosition, rotation, touchPos, screenToWorld;
    public Transform visualChild;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        myRb = GetComponent<Rigidbody>();

        distance = (cam.transform.position - transform.position).y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = transform.position - lastPosition;

        Liike();

        lastPosition = transform.position;
    }

    void Liike()
    {
        touchPos = Input.mousePosition;
        touchPos.z = distance;

        screenToWorld = cam.ScreenToWorldPoint(touchPos);

        Vector3 movement = Vector3.Lerp(myRb.position, screenToWorld, speed * Time.fixedDeltaTime);

        myRb.MovePosition(movement);

        rotation.z = -velocity.x * kallistus;
        myRb.MoveRotation(Quaternion.Euler(rotation));
        rotation.y = velocity.x * killistys;
        myRb.MoveRotation(Quaternion.Euler(rotation));
    }
}
