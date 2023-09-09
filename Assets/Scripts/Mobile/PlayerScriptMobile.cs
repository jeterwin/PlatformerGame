using UnityEngine;
using UnityEngine.UI;

public class PlayerScriptMobile : MonoBehaviour
{
    public Animator Animator;

    public Rigidbody2D rb;

    public float MoveSpeed = 6;

    public float JumpHeight = 2;

    public float Health = 100;

    [SerializeField] Transform HeartBar;

    [SerializeField] GameObject HeartUI;

    int MovingLeft = 0, MovingRight = 0;

    private void Start()
    {
        for(int i = 1; i <= Health / 33.3f; i++)
        {
            Instantiate(HeartUI, HeartBar);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = MovingLeft == 1 ? 
            new Vector2(-MoveSpeed, rb.velocity.y) : MovingRight == 1 ?
            new Vector2(MoveSpeed, rb.velocity.y) :  new Vector2(rb.velocity.x, rb.velocity.y);
    }
    public void Jump()
    {
        if(rb.velocity.y == 0)
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
    }
    public void MoveLeft()
    {
        MovingLeft = 1;
    }

    public void MoveRight()
    {
        MovingRight = 1;
    }
    
    public void StopMoving()
    {
        MovingRight = MovingLeft = 0;
    }

}
