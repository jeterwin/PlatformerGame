using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }

    [SerializeField] private ParticleSystem SuccessParticleSystem;

    [SerializeField] private Image HealthImage;

    [SerializeField] private TextMeshProUGUI CoinsText;

    [SerializeField] private TextMeshProUGUI MissilesCount;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitializeUpgrades();
    }

    private void InitializeUpgrades()
    {
        CoinsText.text = "Coins: " + SaveManager.Instance.GetSaveData.GetCoins;
        HealthImage.fillAmount = (float)SaveManager.Instance.GetSaveData.GetHealth / SaveManager.Instance.GetSaveData.GetMaxHealth;
    }

    public void Upgrade(UpgradeType upgradeType)
    {
        bool successful = false;
        switch(upgradeType)
        {
            case UpgradeType.Health:
                if(SaveManager.Instance.GetSaveData.GetCoins >= (int)upgradeType && SaveManager.Instance.GetSaveData.GetHealth < SaveManager.Instance.GetSaveData.GetMaxHealth)
                {
                    HealthImage.fillAmount = (float)SaveManager.Instance.GetSaveData.GetHealth / SaveManager.Instance.GetSaveData.GetMaxHealth;
                    successful = true;
                }
                break;
        }
        if(!successful) { return; }
        UpgradeStat(upgradeType);
    }
    public void Purchase(PurchasableType PurchasableType)
    {
        bool successful = false;
        switch (PurchasableType)
        {
            case PurchasableType.Missile:
                if (SaveManager.Instance.GetSaveData.GetCoins >= (int)PurchasableType.Missile)
                {
                    SaveManager.Instance.GetSaveData.GetMissilesCount += 1;
                    MissilesCount.text = "Owned: " + SaveManager.Instance.GetSaveData.GetMissilesCount.ToString();
                    successful = true;
                }
                break;
        }
        if (!successful) { return; }
        PurchaseItem(PurchasableType);
    }

    private void PurchaseItem(PurchasableType PurchasableType)
    {
        SaveManager.Instance.GetSaveData.GetCoins -= (int)PurchasableType;
        CoinsText.text = "Coins: " + SaveManager.Instance.GetSaveData.GetCoins;
        SuccessfulPurchase();
    }

    private void UpgradeStat(UpgradeType UpgradeType)
    {
        SaveManager.Instance.GetSaveData.GetCoins -= (int)UpgradeType;
        SaveManager.Instance.GetSaveData.GetHealth += 1;
        SuccessfulPurchase();
    }
    void SuccessfulPurchase()
    {
        SaveManager.Instance.SaveGame();
        SuccessParticleSystem.Play();
    }
}

public enum UpgradeType
{
    Health = 5
}

public enum PurchasableType
{
    Missile = 3
}