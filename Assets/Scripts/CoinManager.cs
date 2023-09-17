using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins = 0;

    public int MaxCoins = 0;

    public AudioSource AudioSource;

    public TextMeshProUGUI Text;

    [SerializeField] private GameObject EndScreen;

    private void Awake()
    {
         Instance = this;
    }
    private void Start()
    {
        Text.text = Coins.ToString() + "/" + MaxCoins.ToString();
    }
    //Make function for coins here
    public void UpdateCoinCount()
    {
        Coins++;
        Text.text = Coins.ToString() + "/" + MaxCoins.ToString();        
        if(Coins == MaxCoins)
        {
            SaveManager.Instance.GetSaveData.GetCoins += Coins;
            SaveManager.Instance.SaveGame();
            EndScreen.SetActive(true);
        }
    }
}
