using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public static MovementScript Instance;

    public Animator Animator;

    public Rigidbody2D rb;

    [SerializeField] SpriteRenderer SpriteRenderer;

    [Header("Movement Variables")]

    public float MoveSpeed = 6;

    public float JumpHeight = 2;

    [Header("Sound Effects")]

    [SerializeField] AudioSource AudioSource;

    [SerializeField] AudioClip JumpSFX;

    int MovingLeft = 0, MovingRight = 0;

    [HideInInspector]
    public bool CanMove = true;
    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if(!CanMove)
            return;

        if(MovingLeft == 1)
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        else
            if(MovingRight == 1)
                transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        //rb.velocity = MovingLeft == 1 ? 
            //new Vector2(-MoveSpeed, rb.velocity.y) : MovingRight == 1 ?
            //new Vector2(MoveSpeed, rb.velocity.y) :  new Vector2(rb.velocity.x, rb.velocity.y);

        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        MovementState State;

        if(MovingLeft == 1)
        {
            State = MovementState.Walking;
            SpriteRenderer.flipX = true;
        }
        else if(MovingRight == 1)
        {
            State = MovementState.Walking;
            SpriteRenderer.flipX = false;
        }
        else
            State = MovementState.Idle;

        if(rb.velocity.y > .1f)
        {
            State = MovementState.Jumping;
        }

        Animator.SetInteger("State", (int)State);
    }
    public void Jump()
    {
        if(rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            AudioSource.PlayOneShot(JumpSFX);
        }
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

    public enum MovementState
    {
        Idle,
        Walking,
        Jumping,
        Falling
    }

}
