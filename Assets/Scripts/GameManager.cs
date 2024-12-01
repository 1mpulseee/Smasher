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
            float FillValue = (float)value / ((float)buildsCount * LevelCompletionPercent);
            LevelCompletionBar.fillAmount = FillValue;
            if (FillValue > 1f)
            {
                Invoke("Win", 1f);
            }
            Debug.Log((float)value / ((float)buildsCount * LevelCompletionPercent));
        }
    }
    int _TotalDest;
    [SerializeField][Range(0f, 1f)] float LevelCompletionPercent = .75f;
    [SerializeField] Image LevelCompletionBar;
    [SerializeField] GameObject WinScreen;
    private void Awake()
    {
        instance = this;
        builds = GetComponentsInChildren<DestructionBuild>();
        buildsCount = builds.Length;
        TotalDest = 0;
        WinScreen.SetActive(false);
        Invoke("StartGame", 2f);
    }
    public void StartGame()
    {
        GameStarted = true;
    }
    public void Win()
    {
        WinScreen.SetActive(true);
    }
    public void BuildingDestroyed() => TotalDest++;
}
