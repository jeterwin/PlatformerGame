using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelGenerator")]
public class LevelList : ScriptableObject
{
    public List<Level> LevelLists = new();

    [System.Serializable]
    public class Level
    {
        public string LevelName;

        public int LevelID;

        public bool IsCompleted = false;

        public bool IsLocked = false;
    }
}
