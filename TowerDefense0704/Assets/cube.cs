using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.forward);
        //Debug.Log(Vector3.forward);
        //Debug.Log(transform.localPosition);
        //Debug.Log(transform.position);
        //本gameobject的本地坐标的z轴一直指向Target.transform
        transform.LookAt(Target.transform);
        //沿着Vector3.forward以Target.transform.position为原点步进10度旋转
        transform.RotateAround(Target.transform.position, Vector3.forward,10.0f);
        //朝Vector3.forward*Time.deltaTime这个向量的大小及方向运动，Spcae.World表示这个向量是在世界坐标系中，Space.Self表示这个向量是在局部坐标系中
        //Vector3.forward就是（0，0，1）
        transform.Translate(Vector3.forward*Time.deltaTime,Space.World);
    }
}
