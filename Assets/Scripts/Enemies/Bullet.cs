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
        GetComponent<SpriteRenderer>().flipX = Direction == 1 ? false : true;
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        rb2d.AddForce(Vector2.right * BulletMovespeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
    
