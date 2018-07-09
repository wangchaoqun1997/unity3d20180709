using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public float Speed = 1.0f;
    //1:在组件上右击出现选项  运行不运行都出现 不需要引入UnityEditor命名空间
    //其实就是添加方法的右击菜单选项
    [ContextMenu("Set Speed8")]
    void SetSpeed8()
    {
        Speed = 8.0f;
    }


    //2:添加属性或字段的右击菜单选项
    [ContextMenuItem("Item Name","FunctionName")]
    public float Scal = 1.0f;
    void FunctionName() {
        Scal = 10;
        //gameObject.transform.localScale =new Vector3(1,1,1)* Scal;
    }


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += Vector3.forward * Speed * Time.deltaTime;
	}

    void ModifySpeed(float speed) {
        Speed = speed;
    }





}
