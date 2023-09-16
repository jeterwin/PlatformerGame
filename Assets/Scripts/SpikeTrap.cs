using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] int Damage = 1;

    [SerializeField] float JumpMultiplier = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health.Instance.StartCoroutine(Health.Instance.TakeDamage(Damage, JumpMultiplier, false));
    }
}
