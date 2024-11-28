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

        if (main.map == null)
        {
            UpdateMapArray();
        }
        else if (main.map.Length != main.MapRange)
        {
            UpdateMapArray();
        }

        GUILayout.TextArea("Map matrix");
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Full"))
        {
            for (int v = 0; v < main.MapRange; v++)
            {
                for (int h = 0; h < main.MapRange; h++)
                {
                    main.map[v].tile[h].x = true;
                }
            }
        }
        if (GUILayout.Button("Clear"))
        {
            UpdateMapArray();
        }
        GUILayout.EndHorizontal();
        DrawMapMatrix();
    }
    void UpdateMapArray()
    {
        main.map = new Map[main.MapRange];
        for (int i = 0; i < main.MapRange; i++)
        {
            main.map[i] = new Map {
                tile = new Tile[main.MapRange],
            };
            for (int y = 0; y < main.MapRange; y++)
            {
                main.map[i].tile[y] = new Tile { isEmployed = false, x = false, YOffset = 0f };
            }
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
                main.map[v].tile[h].x = EditorGUILayout.Toggle("", main.map[v].tile[h].x, GUILayout.Width(20), GUILayout.Height(20));
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}