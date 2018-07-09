using UnityEngine;
using UnityEditor;
public class Tools{
    //1：MenmItem添加菜单项
    [MenuItem("Tools/test/test1")]
    static void test1() {
        Debug.Log("x");
    }

    [MenuItem("Window/test2")]
    static void test2() {
        Debug.Log("xx");
    }
    //最后一个参数表示优先级
    [MenuItem("GameObject/test3",false,10)]
    static void test3() {
        Debug.Log("xxx");
    }

    //2：Selection 类获取Hierarchy视图选择的物体
    [MenuItem("Tools/DelGameObject")]
    static void DelGameObject0() {
        Debug.Log(Selection.activeGameObject);
        
        //如下删除操作不可通过ctrl+z撤销
        //GameObject.DestroyImmediate(Selection.activeGameObject);
        
        //3：使用Undo类
        //如下删除操作可通过ctrl+z撤销
        Undo.DestroyObjectImmediate(Selection.activeGameObject);
    }

    //4 设置快捷键
    [MenuItem("Tools/ShowName _t",false,0)]
    static void ShowName(){
        Debug.Log("T ShowName.....");
    }
    //% ctrl  # shift  & alt
    [MenuItem("Tools/ShowName1 % _t", false, 0)]
    static void ShowName1()
    {
        Debug.Log("ctrl+T ShowName1.....");
    }

    //5：添加不可操作某个菜单项
    [MenuItem("Tools/DelGameObjectxxxx",false, 0)]
    static void DelGameObjectxxxx()
    {
        Debug.Log(Selection.activeGameObject);
        Undo.DestroyObjectImmediate(Selection.activeGameObject);
    }
    //验证方法，返回true才可操作菜单栏中此项
    [MenuItem("Tools/DelGameObjectxxxx", true, 0)]
    static bool DelGameObjectyyy()
    {
        if (Selection.activeGameObject)
            return true;
        else return false;
    }
}
