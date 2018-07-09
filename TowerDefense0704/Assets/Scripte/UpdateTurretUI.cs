using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UpdateTurretUI : MonoBehaviour,IPointerClickHandler,IPointerDownHandler {

    public GameObject TurretManger;
    public void OnPointerClick(PointerEventData eventData)
    {
        TurretManger.GetComponent<TurretManger>().UpdateTurretFunction();
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    // Use this for initialization
    void Start () {
        TurretManger = GameObject.Find("TurretManger");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
