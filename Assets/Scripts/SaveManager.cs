using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string SaveFolderPath;

    [SerializeField] SaveDataSO SaveDataSO;

    [Serializable]
    public class SaveData
    {
        public int LevelReached;
    }
    void Awake()
    {
        Instance = this;
        SaveFolderPath = Application.persistentDataPath;
        
        SaveData SaveData1 = GetGameData();
        SaveDataSO.levelReached = SaveData1.LevelReached;
    }
    public SaveDataSO GetSaveData
    {
        get { return SaveDataSO; }
    }
    // Save the game data to a specific slot and checkpoint
    public void SaveGame()
    {
        //Save SaveSlot and Checkpoint to playerprefs, then use to save on current slot
        // Create the save folder if it doesn't exist
        string SaveFilePath = Path.Combine(SaveFolderPath, "saveData.json");
        // Create a SaveData object with your game's data
        SaveData SaveData = new SaveData();
        SaveData.LevelReached = SceneManager.GetActiveScene().buildIndex + 1;

        // Serialize and save the data to a JSON file

        string JsonData = JsonConvert.SerializeObject(SaveData);
        File.WriteAllText(SaveFilePath, JsonData);
    }
    public SaveData GetGameData()
    {
        // Load the data from a specific checkpoint
        string SaveFilePath = Path.Combine(SaveFolderPath, "saveData.json");
        if(File.Exists(SaveFilePath))
        {
            string JsonData = File.ReadAllText(SaveFilePath);

            return JsonConvert.DeserializeObject<SaveData>(JsonData);
        }
        SaveData NewSaveData = new();
        NewSaveData.LevelReached = 1;
        SaveGame();
        return NewSaveData;
        // Use the loaded data to restore the game state
        /* Set player position, health, inventory, etc. */
    }
}