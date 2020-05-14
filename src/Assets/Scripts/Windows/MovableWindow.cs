using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWindow : MonoBehaviour
{
    public WindowController controller;
    public Player player;
    private Color OriginalFrameColor;

    public Window window { get; protected set; }

    //List<MovableWindow> windowsConnectedToThisOne;

    private void Awake()
    { 
        OriginalFrameColor = this.transform.gameObject.GetComponentInChildren<SpriteRenderer>().color; //set original window color
       // GetComponentInChildren<PolygonCollider2D>().enabled = true; //enable polygon collider
    }

    private void GetPlayerFromScene()
    {
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {
       // GetPlayerFromScene();
        CreateWindow();
    }

    void CreateWindow()
    {
        controller = GetComponent<WindowController>();

        if (controller == null)
        {
            Debug.LogWarning("GetComponent of type " + typeof(WindowController) + " failed on " + this.name, this);
        }

        window = new UnityWindow(this.gameObject);
        window.name = this.name;
    }

    // Update is called once per frame
    void Update()
    { 
        UpdateWindowBasedOnState();
    }

    public void UpdateState(bool isOtherWindowMouseDown)
    {
        switch (window.State)
        {
            case WindowState.Still:
                if (controller.IsColliding) { window.State = WindowState.NearAnotherWindow; }
                if (controller.IsMouseDown && !controller.IsColliding) { window.State = WindowState.BeingDragged; }
                if ((isOtherWindowMouseDown || controller.IsMouseDown) && controller.IsColliding) { window.State = WindowState.NearAnotherWindow; }
                break;
            case WindowState.NearAnotherWindow:   
                if ( controller.IsMouseDown && !controller.IsColliding) { window.State = WindowState.BeingDragged; }
                if ((!isOtherWindowMouseDown && !controller.IsMouseDown) && controller.IsColliding) { window.State = WindowState.Connected; }
                if (!controller.IsMouseDown && !controller.IsColliding) { window.State = WindowState.Released; }
                break;

            case WindowState.BeingDragged:
                if (controller.IsMouseDown && controller.IsColliding) { window.State = WindowState.NearAnotherWindow; }
                if (!controller.IsMouseDown && !controller.IsColliding) { window.State = WindowState.Released; }
                break;
            case WindowState.Connected:
                if (!controller.IsMouseDown && !controller.IsColliding) { window.State = WindowState.Released; }
                if (controller.IsMouseDown && controller.IsColliding) { window.State = WindowState.NearAnotherWindow; }
                break;
           
        }
    }

    private void ChangeFrameToColor(Color color) 
    {
        transform.gameObject.GetComponentInChildren<SpriteRenderer>().color = color;
    }

    private void ChangeFrameToColor(GameObject g, Color color)
    {
        g.transform.gameObject.GetComponentInChildren<SpriteRenderer>().color = color;
    }

    private void UpdateWindowBasedOnState()
    {
        switch (this.window.State)
        {
            case WindowState.Still: ChangeFrameToColor(OriginalFrameColor);     
                break;
            case WindowState.Connected:
                ChangeFrameToColor(new Color(0, 100, 0)); //green
                //GetComponentInChildren<PolygonCollider2D>().enabled = false;
                break;
            case WindowState.BeingDragged:
                ChangeFrameToColor(new Color(0,0,100)); //normal blue
                this.transform.position = this.controller.Position;
                break;
            case WindowState.NearAnotherWindow: //both windows change same color
                ChangeFrameToColor(new Color(255,0,0));
                this.transform.position = this.controller.Position;
                break;
            case WindowState.Released:
                //GetComponentInChildren<PolygonCollider2D>().enabled = true;
                window.State = WindowState.Still;
                break;
        }
    }

    #region Player In Window

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(this.transform); //parent player to window
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //unparent player
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    #endregion


}
