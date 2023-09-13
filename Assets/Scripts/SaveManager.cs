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
        int LevelReached;
        int Health;
        int MaxHealth;

        public int SetLevelReached
        {
            get { return LevelReached; }
            set { LevelReached = value; }
        }
        public int SetHealth
        {
            get { return Health; }
            set { Health = value; }
        }
        public int SetMaxHealth
        {
            get { return MaxHealth; }
            set {  MaxHealth = value; }
        }
    }
    void Awake()
    {
        Instance = this;
        SaveFolderPath = Application.persistentDataPath;
        
        SaveData SaveData1 = GetGameData();
        SaveDataSO.levelReached = SaveData1.SetLevelReached;
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
        SaveData.SetLevelReached = SceneManager.GetActiveScene().buildIndex + 1;

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
        NewSaveData.SetLevelReached = 1;
        NewSaveData.SetHealth = 3;
        NewSaveData.SetMaxHealth = 6;

        string NewData = JsonConvert.SerializeObject(NewSaveData);
        File.WriteAllText(SaveFilePath, NewData);
        return NewSaveData;
        // Use the loaded data to restore the game state
        /* Set player position, health, inventory, etc. */
    }
}