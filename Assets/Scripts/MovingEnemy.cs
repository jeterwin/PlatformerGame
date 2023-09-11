using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : EnemyAI
{
    [SerializeField] Transform[] PatrolPoints;

    int i = 0;

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
}
