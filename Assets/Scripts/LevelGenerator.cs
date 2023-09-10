using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public LevelList LevelList;

    [SerializeField] Sprite CompletedLevelSprite;

    [SerializeField] Sprite UncompletedLevelSprite;

    [SerializeField] Sprite LockedLevelSprite;

    [SerializeField] GameObject LevelPrefab;

    [SerializeField] Transform LevelsGrid;

    private void Start()
    {
        int MaxLevel = SettingsScript.Instance.CurrentLevel;
        for(int i = 1; i <= MaxLevel; i++)
        {
            LevelList.LevelLists[i - 1].IsLocked = false;
        }
        for(int i = 0; i < LevelList.LevelLists.Count;i++)
        {
            GameObject CurrentLevel = Instantiate(LevelPrefab, LevelsGrid);
            LevelHolder LevelHolder = CurrentLevel.GetComponent<LevelHolder>();

            LevelHolder.LevelImage.sprite = LevelList.LevelLists[i].IsCompleted ? CompletedLevelSprite : LevelList.LevelLists[i].IsLocked ? LockedLevelSprite : UncompletedLevelSprite;
            LevelHolder.LevelName = LevelList.LevelLists[i].LevelName;
            //CurrentLevel.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
        }
    }
}
