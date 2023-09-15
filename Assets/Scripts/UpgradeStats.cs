using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] UpgradeType upgradeType;

    public void Upgrade()
    {
        Shop.Instance.Upgrade(upgradeType);
    }
}
