using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DemoWorld))]
public class DemoWorldEditor : Editor
{
    DemoWorld main;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        GUILayout.Space(10);

        main = (DemoWorld)target;

        if (main.map.Length != main.MapRange)
        {
            UpdateMapArray();
        }

        GUILayout.TextArea("Map matrix");
        GUILayout.Space(10);

        DrawMapMatrix();
    }
    void UpdateMapArray()
    {
        main.map = new Map[main.MapRange];
        for (int i = 0; i < main.MapRange; i++)
        {
            main.map[i] = new Map {
                x = new bool[main.MapRange]
            };
        }
    }
    void DrawMapMatrix()
    {
        GUILayout.BeginVertical();
        for (int v = 0; v < main.MapRange; v++)
        {
            GUILayout.BeginHorizontal();
            for (int h = 0; h < main.MapRange; h++)
            {
                main.map[v].x[h] = EditorGUILayout.Toggle("", main.map[v].x[h], GUILayout.Width(20), GUILayout.Height(20));
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}