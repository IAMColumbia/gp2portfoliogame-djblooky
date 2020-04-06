using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class WindowController : MonoBehaviour
{
    
    private const float distanceFromCamera = 10.0f;
    private Vector3 offset;

    public Vector2 Position { get; set; }

    private void Awake()
    {
        SetUpWindowController();
    }

    void SetUpWindowController()
    {
        offset = new Vector3(0, 0, 0);
        Position = new Vector2(transform.position.x, transform.position.y);
        //TO DO: fix offset
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private bool isMouseDown = false;

    public bool IsMouseDown
    {
        get
        {
            if (isMouseDown)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private bool isColliding = false;
    public bool IsColliding
    {
        get
        {
         if (isColliding)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }

    private void SetMouseOffset()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        SetMouseOffset();    
    }

    private void OnMouseUp()
    {
        offset = Vector3.zero;
        isMouseDown = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
        Position = Camera.main.ScreenToWorldPoint(newPosition) + offset; 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "WindowContainer" && col.GetType() == typeof(BoxCollider2D)) //if colliding with another window
        {
            isColliding = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "WindowContainer" && col.GetType() == typeof(BoxCollider2D)) 
        {
            isColliding = false;
        }  
    }
}
