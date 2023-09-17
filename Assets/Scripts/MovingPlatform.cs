using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    [SerializeField] private int StartingPoint;

    [SerializeField] private Transform[] Points;

    private int i = 0;

    private void Start()
    {
        transform.position = Points[StartingPoint].position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if(i == Points.Length)
            { 
                i = 0; 
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") && transform.position.y < collision.transform.position.y)
            collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
