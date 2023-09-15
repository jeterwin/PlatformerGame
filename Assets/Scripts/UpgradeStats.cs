using TMPro;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] UpgradeType upgradeType;
    private void Start()
    {
        TextMeshProUGUI Text = GetComponentInChildren<TextMeshProUGUI>();
        Text.text = ((int)upgradeType).ToString();
    }
    public void Upgrade()
    {
        Shop.Instance.Upgrade(upgradeType);
    }
}
