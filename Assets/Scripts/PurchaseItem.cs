using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchaseItem : MonoBehaviour
{
    [SerializeField] private PurchasableType PurchasableType;

    [SerializeField] private TextMeshProUGUI PriceText;

    [SerializeField] private TextMeshProUGUI OwnedText;

    private void Start()
    {
        PriceText.text = ((int)PurchasableType).ToString();
        OwnedText.text = "Owned: " + SaveManager.Instance.GetData.GetMissilesCount.ToString();
    }
    public void Purchase()
    {
        Shop.Instance.Purchase(PurchasableType);
    }
}
