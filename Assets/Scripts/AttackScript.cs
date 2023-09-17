using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [Range(0f,4f)]
    [SerializeField] private float AttackCooldown;

    [SerializeField] private GameObject Projectile;

    [SerializeField] private GameObject AttackButton;
 
    private bool CanAttack = true;

    [Range(0f,4f)]
    private float timeLeft;
    private void Start()
    {
        if(SaveManager.Instance.GetSaveData.GetMissilesCount == 0)
            AttackButton.SetActive(false);
    }
    public void Attack()
    {
        if(SaveManager.Instance.GetSaveData.GetMissilesCount < 0 && !CanAttack) { return; }

        CanAttack = false;
        timeLeft = AttackCooldown;
        GameObject Missile = Instantiate(Projectile);
        Missile.GetComponent<Bullet>().SetDirection = MovementScript.Instance.IsReversed == 1 ? 1 : -1;
        Missile.GetComponent<SpriteRenderer>().flipX = MovementScript.Instance.IsReversed == 1 ? false : true;
    }
    private void Update()
    {
        if(CanAttack) { return; }
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            CanAttack = true;
        }
    }
}
