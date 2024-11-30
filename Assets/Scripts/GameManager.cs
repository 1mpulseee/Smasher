using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public bool GameStarted;
    DestructionBuild[] builds;
    int buildsCount;
    int TotalDest
    {
        get
        {
            return _TotalDest;
        }
        set
        {
            _TotalDest = value;
            LevelCompletionBar.fillAmount = (float)value / ((float)buildsCount * LevelCompletionPercent);
            Debug.Log((float)value / ((float)buildsCount * LevelCompletionPercent));
        }
    }
    int _TotalDest;
    [SerializeField][Range(0f, 1f)] float LevelCompletionPercent = .75f;
    [SerializeField] Image LevelCompletionBar;
    private void Awake()
    {
        instance = this;
        builds = GetComponentsInChildren<DestructionBuild>();
        buildsCount = builds.Length;
        TotalDest = 0;
        Invoke("StartGame", 2f);
    }
    public void StartGame()
    {
        GameStarted = true;
    }
    public void BuildingDestroyed() => TotalDest++;
}
