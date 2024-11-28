using UnityEngine;
[CreateAssetMenu(fileName = "BuildConfig", menuName = "Game/New BuildConfig")]
public class BuildConfig : ScriptableObject
{
    [SerializeField] private Material _StandardMarkMaterial;
    [SerializeField] private Material _SelectedMarkMaterial;
    [SerializeField] private GameObject _BuildButtonPrefab;
    [SerializeField] private Color _BaseButtonColor;
    [SerializeField] private Color _SelectedButtonColor;
    [SerializeField] private Color _CloseButtonColor;
    [SerializeField] private Construction[] _Buildings;
    [SerializeField] private LayerMask _MarkMask;
    [SerializeField] private GameObject _Mark;


    public Material StandardMarkMaterial => this._StandardMarkMaterial;
    public Material SelectedMarkMaterial => this._SelectedMarkMaterial;
    public GameObject BuildButtonPrefab => this._BuildButtonPrefab;
    public Color BaseButtonColor => this._BaseButtonColor;
    public Color SelectedButtonColor => this._SelectedButtonColor;
    public Color CloseButtonColor => this._CloseButtonColor;
    public Construction[] Buildings => this._Buildings;
    public LayerMask MarkMask => this._MarkMask;
    public GameObject Mark => this._Mark;
}
[System.Serializable]
public class Construction
{
    public float Price;
    public GameObject Prefab;
    public float YOffset;
    public float NextLayerYOffset;
}