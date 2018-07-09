using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (true == Physics.Raycast(transform.position, transform.forward, out hit,10)) {
            Debug.Log("Raycast true");
        }
        Debug.DrawRay(transform.position, transform.forward* 10, Color.yellow);
        //transform.position += transform.forward * Time.deltaTime;
        //Debug.Log(transform.eulerAngles);
        //Debug.Log(transform.rotation);
        //Debug.Log(transform.forward);
        //Debug.Log(transform.localPosition);
        //Debug.Log(transform.position);
    }
}
