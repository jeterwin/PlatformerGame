using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScriptPC : MonoBehaviour
{
    public Animator animator;

    [SerializeField] InputActionReference playerMovement;

    float hInput;

    private void Awake()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        hInput = playerMovement.action.ReadValue<float>();
    }

}
