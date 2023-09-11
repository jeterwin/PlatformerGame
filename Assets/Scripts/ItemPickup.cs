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
        CoinManager.Instance.UpdateCoinCount();
        CoinManager.Instance.AudioSource.PlayOneShot(SFX);
        Destroy(gameObject);
    }

    void PickupHealth()
    {
        Health.Instance.HP += 10;
        CoinManager.Instance.AudioSource.PlayOneShot(SFX);
        Destroy(gameObject);
    }
}

enum ItemType
{
    Coin,
    Health
}
