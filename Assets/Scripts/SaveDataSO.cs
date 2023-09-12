using UnityEngine;

[CreateAssetMenu(menuName = "Save File", fileName = "Save File")]
public class SaveDataSO : ScriptableObject
{
    [SerializeField] int LevelReached;

    public int levelReached
    {
        get { return LevelReached; }
        set { LevelReached = value; }
    }
}
