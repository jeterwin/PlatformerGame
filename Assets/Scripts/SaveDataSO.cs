using UnityEngine;

[CreateAssetMenu(menuName = "Save File", fileName = "Save File")]
public class SaveDataSO : ScriptableObject
{
    [SerializeField] int LevelReached = 1;

    [SerializeField] int Health = 3;

    [SerializeField] int MaxHealth = 6;

    [SerializeField] int Coins = 10;
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

    public int GetCoins
    {
        get { return Coins; }
        set { Coins = value; }
    }
}
