using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins = 0;

    public int MaxCoins = 0;

    public AudioSource AudioSource;

    [SerializeField] GameObject EndScreen;

    private void Awake()
    {
         Instance = this;
    }

    public void EndLevel()
    {
        if(Coins == MaxCoins)
        {
            EndScreen.SetActive(true);
        }
    }
}
