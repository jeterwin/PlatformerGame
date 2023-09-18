using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float BulletMovespeed;
    
    static int Direction;

    public int SetDirection
    {
        set { Direction = value; }
    }
    private void Start()
    {
        BulletMovespeed *= Direction;
        GetComponent<SpriteRenderer>().flipX = Direction != 1;
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        rb2d.AddForce(BulletMovespeed * Time.deltaTime * Vector2.right, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
    
