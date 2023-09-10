using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScriptMobile : MonoBehaviour
{
    public static PlayerScriptMobile Instance;

    public Animator Animator;

    public Rigidbody2D rb;

    [SerializeField] SpriteRenderer SpriteRenderer;

    [Header("Movement Variables")]

    public float MoveSpeed = 6;

    public float JumpHeight = 2;

    public float Health = 30;

    [SerializeField] Image HeartBar;

    [SerializeField] Image FullHeartBar;

    [Header("Sound Effects")]

    [SerializeField] AudioSource AudioSource;

    [SerializeField] AudioClip JumpSFX;

    [SerializeField] AudioClip DeathSFX;

    Animator HealthAnimator;

    int MovingLeft = 0, MovingRight = 0;

    bool CanTakeDamage = true;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Health = PlayerPrefs.GetInt("Health", 3);
        FullHeartBar.fillAmount = Health / PlayerPrefs.GetInt("MaxHealth", 6);
        HeartBar.fillAmount = Health / PlayerPrefs.GetInt("MaxHealth", 6);

        HealthAnimator = HeartBar.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    bool IsMoving
    {
        get { return rb.velocity.x != 0; }
    }
    public void Move()
    {
        rb.velocity = MovingLeft == 1 ? 
            new Vector2(-MoveSpeed, rb.velocity.y) : MovingRight == 1 ?
            new Vector2(MoveSpeed, rb.velocity.y) :  new Vector2(rb.velocity.x, rb.velocity.y);

        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        MovementState State;

        if(rb.velocity.x > 0)
        {
            State = MovementState.Walking;
            SpriteRenderer.flipX = false;
        }
        else if(rb.velocity.x < 0)
        {
            State = MovementState.Walking;
            SpriteRenderer.flipX = true;
        }
        else
        {
            State = MovementState.Idle;
        }

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
    public IEnumerator TakeDamage(int Damage)
    {
        if(CanTakeDamage)
        {

        }
        else
            yield return null;
       //Play animation
       //Update bar
       //Make invincible for a bit
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
