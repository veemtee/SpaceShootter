using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMoveContinuous : MonoBehaviour
{

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
    public Text outputText;

    public GameObject player;
    public float speed;
    

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentTouchPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    stopTouch = true;
                    player.transform.Translate(Vector2.left * speed *Time.deltaTime);
                }


                else if (Distance.x > swipeRange)
                {
                    stopTouch = true;
                    player.transform.Translate(Vector2.right * speed * Time.deltaTime);
                }

                else if (Distance.y > -swipeRange)
                {
                    stopTouch = true;
                    player.transform.Translate(Vector2.down * speed * Time.deltaTime);
                }

                else if (Distance.y > swipeRange)
                {
                    stopTouch = true;
                    outputText.text = "Down";
                    player.transform.Translate(Vector2.up * speed * Time.deltaTime);
                }

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                outputText.text = "Tap";
            }
        }
    }

    
}
