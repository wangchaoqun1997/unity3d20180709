using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MessageBox : ScriptableWizard {

    public int changSpeedValue = 10;
    //创建对话框
    [MenuItem("Tools/CreateWizard")]
    static void CreateW() {
        //ScriptableWizard.DisplayWizard<MessageBox>("统一修改速度","ButtonName");
        ScriptableWizard.DisplayWizard<MessageBox>("统一修改速度", "ButtonName（类似应用）", "ButtonName（类似修改）");
    }

    //当Wizard创建时调用
    void OnEnable() {
        //取出保存的值，下次打开窗口可以是上次修改后的值
        changSpeedValue = EditorPrefs.GetInt("key of changspeedvalue in database")+1;
    }


    //按钮的点击事件
    void OnWizardCreate() {
        Debug.Log("click");
        GameObject[] GameObjs = Selection.gameObjects;
        foreach (GameObject obj in GameObjs) {
            //获取游戏对象上的CubeScript脚步组件
            CubeScript cubesc = obj.GetComponent<CubeScript>();
            if (cubesc != null)
            {
                //记录对cubes脚本的修改，这样就可以ctrl+z回退
                Undo.RecordObject(cubesc,"chang speed");

                cubesc.Speed += changSpeedValue;
                EditorPrefs.SetInt("Key Of changSpeedValue in database", changSpeedValue);
            }
        }
    }

    void OnWizardOtherButton() {
        Debug.Log("点击ButtonName（类似修改）触发");
    }

    //当前字段值修改时会调用
    void OnWizardUpdate() {
        errorString = null;
        helpString = null;
        if (Selection.gameObjects.Length > 0)
        {
            //显示提示信息1
            helpString = "选择了" + Selection.gameObjects.Length + "游戏对象";
            //显示提示信息2
            ShowNotification(new GUIContent("选择了" + Selection.gameObjects.Length + "游戏对象"));
        }
        else {
            //显示错误信息
            errorString = "请至少选择一个游戏对象";
        }

    }

    //当Selection变化时调用
    void OnSelectionChange() {
        OnWizardUpdate();
    }

}
