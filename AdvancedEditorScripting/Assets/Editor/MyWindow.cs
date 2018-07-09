using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow {

    [MenuItem("Window/show my window")]
    static void ShowMyWindow() {
        MyWindow window = EditorWindow.GetWindow<MyWindow>();
        window.Show();
    }

    private string Name ="";
    void OnGUI() {
        GUILayout.Label("这是我的窗口");
        Name = GUILayout.TextField(Name);
        if (GUILayout.Button("创建")) {
            GameObject obj = new GameObject(Name);
            Undo.RegisterCreatedObjectUndo(obj,"CreatObject");
        }
    }
}
