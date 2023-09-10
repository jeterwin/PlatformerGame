using System.Collections;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] ItemType ItemType;
    
    [SerializeField] AudioClip SFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ItemType == ItemType.Coin)
            PickupCoin();
        else
            PickupHealth();

    }

    void PickupCoin()
    {
        CoinManager.Instance.Coins += 1;
        CoinManager.Instance.AudioSource.PlayOneShot(SFX);
        CoinManager.Instance.EndLevel();
        Destroy(gameObject);
    }

    void PickupHealth()
    {
        PlayerScriptMobile.Instance.Health += 10;
        CoinManager.Instance.AudioSource.PlayOneShot(SFX);
        Destroy(gameObject);
    }
}

enum ItemType
{
    Coin,
    Health
}
