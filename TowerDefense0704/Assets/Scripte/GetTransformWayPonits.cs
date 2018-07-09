using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransformWayPonits : MonoBehaviour {

    public static Transform[] WayPoints;


    
    void Awake() {
        WayPoints = new Transform[transform.childCount];//赋值语句等只能在方法中执行  
        for (int i =0; i < transform.childCount; i++){
            WayPoints[i] = transform.GetChild(i);
            //Debug.Log(WayPoints[i].position);
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
