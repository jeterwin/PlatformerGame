using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;
using System.Reflection;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string SaveFolderPath;

    [SerializeField] private SaveDataSO SaveDataSO;

    public SaveDataSO GetData
    {
        get { return SaveDataSO; }
    }
    void Awake()
    {
        Instance = this;
        SaveFolderPath = Application.persistentDataPath;
        
        GetGameData();
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

        string JsonData = JsonConvert.SerializeObject(SaveDataSO, Formatting.Indented);
        File.WriteAllText(SaveFilePath, JsonData);
    }
    public void GetGameData()
    {
        // Load the data from a specific checkpoint
        string SaveFilePath = Path.Combine(SaveFolderPath, "saveData.json");
        if(File.Exists(SaveFilePath))
        {
            string JsonData = File.ReadAllText(SaveFilePath);
            SaveDataSO Data = JsonConvert.DeserializeObject<SaveDataSO>(JsonData);
            SaveDataSO.GetCoins = Data.GetCoins;
            SaveDataSO.GetHealth = Data.GetHealth;
            SaveDataSO.GetMaxHealth = Data.GetMaxHealth;
            SaveDataSO.GetMissilesCount = Data.GetMissilesCount;
            SaveDataSO.levelReached = Data.levelReached;

            return;
        }
        SaveDataSO NewSave = ScriptableObject.CreateInstance<SaveDataSO>();
        SaveDataSO.GetCoins = NewSave.GetCoins;
        SaveDataSO.GetHealth = NewSave.GetHealth;
        SaveDataSO.GetMaxHealth = NewSave.GetMaxHealth;
        SaveDataSO.GetMissilesCount = NewSave.GetMissilesCount;
        SaveDataSO.levelReached = NewSave.levelReached;

        string NewData = JsonConvert.SerializeObject(SaveDataSO, Formatting.Indented);
        File.WriteAllText(SaveFilePath, NewData);
        // Use the loaded data to restore the game state
        /* Set player position, health, inventory, etc. */
    }
}