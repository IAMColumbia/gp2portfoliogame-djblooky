using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
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
        SetUpController();
    }

    private void SetUpController()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        direction = new Vector2(0, 0);
        keyDirection = new Vector2(0, 0);
        IsJumping = false;

    }

    private void Update()
    {
        keyDirection.x = keyDirection.y = 0;

        //Keyboard
        if (Input.GetKey(KeyCode.D))
        {
            keyDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            keyDirection.x += -1;
        }

        if (Input.GetKeyDown(KeyCode.W) && !IsJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //keyDirection.y += 1;
            IsJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //keyDirection.y += 1;
            IsJumping = true;
        }

        direction += keyDirection;
        direction.Normalize();
    }

}
