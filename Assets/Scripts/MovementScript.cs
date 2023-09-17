using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public static MovementScript Instance;

    public Animator Animator;

    public Rigidbody2D rb;

    [SerializeField] private SpriteRenderer SpriteRenderer;

    [SerializeField] private ParticleSystem DustParticleSystem;

    [Header("Movement Variables")]

    public float MoveSpeed = 6;

    public float JumpHeight = 2;

    [Header("Gravity Settings")]

    [SerializeField] private float NormalGravityScale;

    [SerializeField] private float MinGravityScale;

    [SerializeField] private float MaxFallSpeed;

    [Header("Sound Effects")]

    [SerializeField] AudioSource AudioSource;

    [SerializeField] private AudioClip JumpSFX;

    private int MovingLeft = 0, MovingRight = 0;

    private bool CanMove = true;
    public bool canMove
    {
        get { return CanMove; }
        set { CanMove = value; }
    }
    public int IsReversed
    {
        get { return SpriteRenderer.flipX ? -1 : 1; } 
    }
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
            transform.Translate(MoveSpeed * Time.deltaTime * Vector2.left);
        else
            if(MovingRight == 1)
                transform.Translate(MoveSpeed * Time.deltaTime * Vector2.right);
        //Falling state
        if(rb.velocity.y < 0)
        {
            SetMinFallingSpeed();
        }
        else if(rb.velocity.y > 0)
        {
            SetNormalFallingSpeed();
        }

        UpdateAnimationState();
    }

    public bool IsGrounded
    {
        get { return rb.velocity.y == 0; }
    }
    private void SetNormalFallingSpeed()
    {
        rb.gravityScale = NormalGravityScale;
    }

    private void SetMinFallingSpeed()
    {
        rb.gravityScale = MinGravityScale;
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -MaxFallSpeed));
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

        if((int)State == 1 && IsGrounded)
            DustParticleSystem.Play();
        Animator.SetInteger("State", (int)State);
    }
    public void Jump()
    {
        if(IsGrounded)
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
