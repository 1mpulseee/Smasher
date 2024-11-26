using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemoWorld : MonoBehaviour
{
    [Range(4, 16)] public int MapRange = 8;
    [SerializeField][Range(1f, 10f)] float TileSize = 1f;
    [SerializeField] float MarkYoffset;
    [HideInInspector] public Map[] map;
    GameObject[,] Marks;
    MeshRenderer[,] MarksMaterial;
    [SerializeField] LayerMask MarkMask;
    [SerializeField] GameObject Mark;
    [SerializeField] Material StandardMarkMaterial, SelectedMarkMaterial;
    float MapLenght;
    Vector2Int oldSelect;
    bool PosSelected;
    private void Awake()
    {
        Input.multiTouchEnabled = false;

        Marks = new GameObject[MapRange, MapRange];
        MarksMaterial = new MeshRenderer[MapRange, MapRange];
        MapLenght = MapRange * TileSize;
        for (int x = 0; x < MapRange; x++)
        {
            for (int y = 0; y < MapRange; y++)
            {
                if (map[x].x[y])
                {
                    Marks[x, y] = Instantiate(Mark, transform.position + new Vector3(x * TileSize - MapLenght / 2 + 1, MarkYoffset, y * TileSize - MapLenght / 2 + 1), Quaternion.identity);
                    Vector3 Size = Vector3.one * (TileSize * .85f);
                    Size.y = TileSize * .15f;
                    Marks[x, y].transform.localScale = Size;
                    Marks[x, y].name = x.ToString() + "/" + y.ToString();
                    MarksMaterial[x, y] = Marks[x, y].GetComponent<MeshRenderer>();
                }
            }
        }
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, MarkMask))
            {
                Vector2 pos = new(hit.point.x - transform.position.x, hit.point.z - transform.position.z);
                if (Mathf.Max(Mathf.Abs(pos.x), Mathf.Abs(pos.y)) < MapLenght/2f)
                {
                    string[] s = hit.transform.name.Split("/");
                    int x = int.Parse(s[0]);
                    int y = int.Parse(s[1]);
                    if (oldSelect != new Vector2Int(x,y))
                    {
                        MarksMaterial[oldSelect.x, oldSelect.y].material = StandardMarkMaterial;
                    }
                    MarksMaterial[x, y].material = SelectedMarkMaterial;
                    oldSelect = new Vector2Int(x,y);
                    PosSelected = true;
                }
            }
            else
            {
                MarksMaterial[oldSelect.x, oldSelect.y].material = StandardMarkMaterial;
                PosSelected = false;
            }
        }
        else
        {
            if (PosSelected)
            {
                Debug.Log("build");
                PosSelected = false;
            }
            MarksMaterial[oldSelect.x, oldSelect.y].material = StandardMarkMaterial;
        }
    }
}
[System.Serializable]
public class Map
{
    public bool[] x;
}
