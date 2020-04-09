using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    //Components
    MoveComponent moveComponent;
    Rigidbody2D playerRB;

    //Variables
    public Vector2 direction;
    private Vector2 keyDirection;
    public int thrust = 5;
    public bool IsKeyDown
    {
        get
        {
            if (keyDirection.sqrMagnitude == 0) return false;
            return true;
        }
    }
    public bool IsJumping { get; set; }

    private void Awake()
    {
        AssignComponents();
        SetUpController();
    }

    void AssignComponents()
    {
        playerRB = GetComponent<Rigidbody2D>();
        moveComponent = new MoveComponent();
    }

    private void SetUpController()
    {
        playerRB.freezeRotation = true;
        direction = new Vector2(0, 0);
        keyDirection = new Vector2(0, 0);
        IsJumping = false;  
    }

    ICommand GetMoveCommandFromKey()
    {
        Command command = null;

        if (Input.GetKey(KeyCode.D))
        {
            command = new MoveRightCommand();
            //keyDirection.x += 1;
            keyDirection.x = moveComponent.X;
        }
        if (Input.GetKey(KeyCode.A))
        {
            command = new MoveLeftCommand();
            //keyDirection.x += -1;
            keyDirection.x = -moveComponent.X;
        }

        return command;
    }

    void GetJumpFromKey()
    {
        if (Input.GetKeyDown(KeyCode.W) && !IsJumping)
        {
            playerRB.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //keyDirection.y += 1;
            IsJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
        {
            playerRB.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //keyDirection.y += 1;
            IsJumping = true;
        }
    }

    void UpdateMovement()
    {
        keyDirection.x = keyDirection.y = 0;

        ICommand command = GetMoveCommandFromKey();
        if (command != null)
        {
            command.Execute(moveComponent);
        }
   
        GetJumpFromKey();

        direction += keyDirection;
        direction.Normalize();
    }

    private void Update()
    {
        UpdateMovement();
    }

}
