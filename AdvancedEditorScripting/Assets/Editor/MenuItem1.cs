using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeEditor{

    [MenuItem("CONTEXT/CubeScript/dospeed")]
    //MenuCommand是系统传入的在哪个组件上右击
    static void ModifySpeed(MenuCommand cmd) {
        //返回cube游戏对象的CubeScript组件
        CubeScript cubeSc = cmd.context as CubeScript;
        Debug.Log(cubeSc);
        cubeSc.Speed = 3.0f;
    }


    [MenuItem("CONTEXT/BoxCollider/TriggerOn")]
    static void ModifyTrigger0(MenuCommand cmd) {
        BoxCollider BC = cmd.context as BoxCollider;
        BC.isTrigger = true;
    }
    [MenuItem("CONTEXT/BoxCollider/TriggerOff")]
    static void ModifyTrigger1(MenuCommand cmd)
    {
        BoxCollider BC = cmd.context as BoxCollider;
        BC.isTrigger = false;
    }
}
