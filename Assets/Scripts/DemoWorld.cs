using UnityEngine;
using UnityEngine.UI;
public class DemoWorld : MonoBehaviour
{
    [SerializeField] BuildConfig CFG;

    [Range(4, 16)] public int MapRange = 8;
    [SerializeField][Range(1f, 10f)] float TileSize = 1f;
    [SerializeField] float MarkYoffset;
    [HideInInspector] public Map[] map;
    GameObject[,] Marks;
    MeshRenderer[,] MarksMaterial;
    [SerializeField] LayerMask MarkMask;
    [SerializeField] GameObject Mark;
    Material StandardMarkMaterial, SelectedMarkMaterial;
    float MapLenght;
    Vector2Int oldSelect;
    bool PosSelected;

    GameObject BuildButtonPrefab;
    [SerializeField] Transform ButtonsGroup;
    BuildButton[] buttons;

    BuildButton Selected;
    int SelectedId;
    private void Awake()
    {
        Input.multiTouchEnabled = false;

        Marks = new GameObject[MapRange, MapRange];
        MarksMaterial = new MeshRenderer[MapRange, MapRange];
        MapLenght = MapRange * TileSize;

        LoadCFG();

        CreateMarksField();
        CreateButtons();
    }
    void LoadCFG()
    {
        StandardMarkMaterial = CFG.StandardMarkMaterial;
        SelectedMarkMaterial = CFG.SelectedMarkMaterial;
        BuildButtonPrefab = CFG.BuildButtonPrefab;
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
                    if (Selected != null)
                    {
                        MarksMaterial[x, y].material = SelectedMarkMaterial;
                        oldSelect = new Vector2Int(x, y);
                        PosSelected = true;
                    }
                    else
                    {
                        MarksMaterial[oldSelect.x, oldSelect.y].material = StandardMarkMaterial;
                        PosSelected = false;
                    }
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
                Build();
            }
            MarksMaterial[oldSelect.x, oldSelect.y].material = StandardMarkMaterial;
        }
    }
    void CreateMarksField()
    {
        for (int x = 0; x < MapRange; x++)
        {
            for (int y = 0; y < MapRange; y++)
            {
                if (map[x].x[y])
                {
                    Marks[x, y] = Instantiate(Mark, transform.position + new Vector3(x * TileSize - MapLenght / 2 + 1, MarkYoffset, y * TileSize - MapLenght / 2 + 1), Quaternion.identity);
                    Vector3 Size = Vector3.one * (TileSize * .85f);
                    Size.y = TileSize * .1f;
                    Marks[x, y].transform.localScale = Size;
                    Marks[x, y].name = x.ToString() + "/" + y.ToString();
                    Marks[x, y].transform.parent = this.transform;
                    MarksMaterial[x, y] = Marks[x, y].GetComponent<MeshRenderer>();
                }
            }
        }
    }
    void CreateButtons()
    {
        buttons = new BuildButton[CFG.Buildings.Length];
        for (int i = 0; i < CFG.Buildings.Length; i++)
        {
            GameObject NewButton = Instantiate(BuildButtonPrefab, ButtonsGroup);
            BuyBuildButton buyBuildButton = NewButton.GetComponent<BuyBuildButton>();
            buyBuildButton.Setup(i, this);
            buttons[i] = new BuildButton{ButtonObject = NewButton, buyBuildButton = buyBuildButton };
        }
        RefreshButtons();
    }
    void RefreshButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float money = float.MaxValue; //upd
            if (Selected != null)
            {
                if (Selected == buttons[i])
                {
                    buttons[i].buyBuildButton.SetOutline(ButtonState.Selected);
                }
            }
            else if (money > CFG.Buildings[i].Price)
            {
                buttons[i].buyBuildButton.SetOutline(ButtonState.Main);
            }
            else
            {
                buttons[i].buyBuildButton.SetOutline(ButtonState.Close);
            }
        }
    }
    public void SelectBuild(int id)
    {
        SelectedId = id;
        if (Selected == buttons[id])
        {
            Selected = null;
        }
        else
        {
            Selected = buttons[id];
        }
        RefreshButtons();
    }
    void Build()
    {
        if (Selected != null)
        {
            Instantiate(CFG.Buildings[SelectedId].Prefab, new Vector3(oldSelect.x * TileSize - MapLenght / 2f, transform.position.y + MarkYoffset + CFG.Buildings[SelectedId].YOffset, oldSelect.y * TileSize - MapLenght / 2f) + new Vector3(1, 0, 1), Quaternion.identity);
            Selected = null;
            PosSelected = false;
            RefreshButtons();
        }
    }
}
[System.Serializable]
public class Map
{
    public bool[] x;
    public bool[] isEmployed; //не работает, новый класс вместо бул
}
[System.Serializable]
public class BuildButton
{
    public GameObject ButtonObject;
    public BuyBuildButton buyBuildButton;
}
public enum ButtonState { Main, Selected, Close } 