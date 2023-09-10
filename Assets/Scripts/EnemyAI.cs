using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] bool BasicAI;

    [SerializeField] int Damage;

    [SerializeField] float Movespeed;

    [SerializeField] Transform[] PatrolPoints;

    [SerializeField] Rigidbody2D Rb;

    [SerializeField] Animator Animator;

    private int i = 0;

    private void Start()
    {
        transform.position = PatrolPoints[i].position;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, PatrolPoints[i].position) < .02f)
        {
            i++;
            if(i == PatrolPoints.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[i].position, Movespeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Player"))
        {
            //Do damage and update hearts
            PlayerScriptMobile.Instance.StartCoroutine(PlayerScriptMobile.Instance.TakeDamage(Damage));
        }
    }
}
