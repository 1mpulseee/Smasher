using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ClearComponents))]
public class ClearComponentsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ClearComponents main = (ClearComponents)target;
        if (GUILayout.Button("Clear"))
        {
            Rigidbody[] Components = main.gameObject.GetComponentsInChildren<Rigidbody>();
            if (Components == null) return;
            for (int i = 0; i < Components.Length; i++)
            {
                DestroyImmediate(Components[i]);
            }
        }
    }
}