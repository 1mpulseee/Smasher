using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWorld : MonoBehaviour
{
    [Range(4, 16)] public int MapRange = 8;
    [HideInInspector] public Map[] map;
}
[System.Serializable]
public class Map
{
    public bool[] x;
}
