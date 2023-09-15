using System.Collections;
using UnityEngine;

public class CannonEnemy : EnemyAI
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float FireRate;
    [SerializeField] Direction Direction;
    [SerializeField] Transform CannonMuzzle;

    float ShootTimer;
    private void Update()
    {
        UpdateTimers();
        if (ShootTimer > 0f) { return; }
        StartCoroutine(ShootBullet());
    }

    private void UpdateTimers()
    {
        ShootTimer -= Time.deltaTime;
    }

    IEnumerator ShootBullet()
    {
        ShootTimer = FireRate;
        GameObject Bullet = Instantiate(BulletPrefab, CannonMuzzle);
        Bullet.GetComponent<Bullet>().SetDirection = (int)Direction;
        yield return null;
    }
}

enum Direction
{
    Right = 1,
    Left = -1
}