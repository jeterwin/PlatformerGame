using UnityEngine;

[CreateAssetMenu(menuName = "Save File", fileName = "Save File")]
public class SaveDataSO : ScriptableObject
{
    [SerializeField] private int LevelReached = 1;

    [SerializeField] private int Health = 3;

    [SerializeField] private int MaxHealth = 6;

    [SerializeField] private int Coins = 0;

    [SerializeField] private int Missiles = 0;
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

    public int GetMissilesCount
    {
        get { return Missiles; }
        set { Missiles = value; }
    }
}
