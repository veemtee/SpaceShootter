using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlasmaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("PlayerRoot").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        InvokeRepeating("FireMe", 0, 0.1f);
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        CancelInvoke("FireMe");
    }

    void FireMe()
    {
        //Debug.Log("firing" + Time.time);
        playerController.shootPlasme();
    }
}
