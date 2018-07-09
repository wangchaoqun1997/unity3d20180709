using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MoveCamera : MonoBehaviour {

    public GameObject MoveObject;
    public float MoveSpeed = 40;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float HorizontalVal = Input.GetAxis("Horizontal");
        float VerticalVal = Input.GetAxis("Vertical");

        //MoveObject.transform.position += new Vector3(HorizontalVal*Time.deltaTime* MoveSpeed, 0, VerticalVal * Time.deltaTime * MoveSpeed);
        MoveObject.transform.Translate(new Vector3(HorizontalVal * Time.deltaTime * MoveSpeed, 0, VerticalVal * Time.deltaTime * MoveSpeed),Space.World);

        float ZoomInOut = Input.GetAxis("Mouse ScrollWheel");
        MoveObject.transform.Translate(new Vector3(0, 0, ZoomInOut * Time.deltaTime * 100*MoveSpeed), Space.Self);
    }
}
