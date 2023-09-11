using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int Damage = 1;

    public float Movespeed = 2f;

    public float JumpMultiplier = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Health.Instance.StartCoroutine(Health.Instance.TakeDamage(Damage, JumpMultiplier, false));
        }
    }
}
