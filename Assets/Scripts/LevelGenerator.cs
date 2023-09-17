using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    public GameObject LoadingScreen;

    public LevelList LevelList;

    [SerializeField] private Sprite CompletedLevelSprite;

    [SerializeField] private Sprite UncompletedLevelSprite;

    [SerializeField] private Sprite LockedLevelSprite;

    [SerializeField] private GameObject LevelPrefab;

    [SerializeField] private Transform LevelsGrid;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        int MaxLevel = SaveManager.Instance.GetSaveData.levelReached;
        Debug.Log(MaxLevel);
        for(int i = 1; i <= MaxLevel; i++)
        {
            LevelList.LevelLists[i - 1].IsLocked = false;
        }
         for(int i = 1; i <= MaxLevel - 1; i++)
        {
            LevelList.LevelLists[i - 1].IsCompleted = true;
        }
        for(int i = 0; i < LevelList.LevelLists.Count;i++)
        {
            GameObject CurrentLevel = Instantiate(LevelPrefab, LevelsGrid);
            LevelHolder LevelHolder = CurrentLevel.GetComponent<LevelHolder>();

            LevelHolder.LevelImage.sprite = LevelList.LevelLists[i].IsCompleted ? CompletedLevelSprite : LevelList.LevelLists[i].IsLocked ? LockedLevelSprite : UncompletedLevelSprite;
            LevelHolder.LevelID = LevelList.LevelLists[i].LevelID;
        }
    }

    public IEnumerator StartLoading(int LevelID)
    {
        if(!LevelList.LevelLists[LevelID - 1].IsLocked)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(LevelID);
            LoadingScreen.SetActive(true);

            while(!operation.isDone)
            {
                yield return null;
            }
        }
        else
            yield return null;

    }
}
