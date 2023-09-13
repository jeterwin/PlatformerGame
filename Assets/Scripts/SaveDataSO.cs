using UnityEngine;

[CreateAssetMenu(menuName = "Save File", fileName = "Save File")]
public class SaveDataSO : ScriptableObject
{
    [SerializeField] int LevelReached;

    [SerializeField] int Health;

    [SerializeField] int MaxHealth;
    public int levelReached
    {
        get { return LevelReached; }
        set { LevelReached = value; }
    }

    public int GetHealth
    {
        get { return Health; }
        set { Health = value; } 
    }

    public int GetMaxHealth
    { 
        get { return MaxHealth; }
        set { MaxHealth = value; }
    }
}
