using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public GameObject CharacterPrefab;

    private PlayerController controller;
    public Vector2 Direction = new Vector2(0, 0);
    public float Speed = 5f;
    public bool alive = true;
    public bool win = false;

    public Character character { get; protected set; }

    private Vector3 moveTranslation;

    // Start is called before the first frame update
    void Start()
    {
        CreateCharacter();
    }

    private void CreateCharacter()
    {
        controller = GetComponent<PlayerController>();

        if (controller == null)
        {
            Debug.LogWarning("GetComponent of type " + typeof(PlayerController) + " failed on " + this.name, this);
        }

        character = new UnityCharacter(CharacterPrefab);
    }

    private void Update()
    {
        UpdatePlayerController();
        UpdatePlayerMovement();
        UpdateBasedOnState();
    }

    private void UpdateBasedOnState()
    {
        switch (character.State)
        {
            case CharacterState.Stopped:
                this.Direction = new Vector2(0, 0);
                break;
            case CharacterState.Moving:
                this.Direction = controller.direction;
                break;
            case CharacterState.Jumping:
                break;
        }
    }

    void OnBecameInvisible()
    {
        alive = false;
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            controller.IsJumping = false;
            //this.Direction = new Vector2(0, 0);
        }

        if (collision.CompareTag("Door"))
        {
            win = true;
        }
    }

    private void UpdatePlayerMovement()
    {
        this.moveTranslation = new Vector3(this.Direction.x, this.Direction.y) * Time.deltaTime * this.Speed;
        this.transform.position += new Vector3(this.moveTranslation.x, this.moveTranslation.y);
    }

    private void UpdatePlayerController()
    {
        if (controller.IsKeyDown)
        {
            this.Direction = this.controller.direction;
            character.State = CharacterState.Moving;
        }
        if (controller.IsJumping)
        {
            character.State = CharacterState.Jumping;
        }
        else
        {
            character.State = CharacterState.Stopped;
        }

        
    }
}
