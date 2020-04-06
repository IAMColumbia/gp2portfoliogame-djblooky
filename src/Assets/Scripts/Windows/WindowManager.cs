using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private int numOfWindows { get; set; }

    private Player player;
    private List<MovableWindow> windows;

    private void Awake() //get things from scene while level manager doesnt exist
    {
        GetWindowsFromScene();
        GetPlayerFromScene();
    }

    private void GetPlayerFromScene()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void GetWindowsFromScene() //creates list of windows from scene
    {
        windows = new List<MovableWindow>();
        List<GameObject> windowsInScene = GameObject.FindGameObjectsWithTag("WindowContainer").ToList();
        foreach (GameObject window in windowsInScene)
        {
            windows.Add(window.GetComponent<MovableWindow>());
        }
        numOfWindows = windowsInScene.Count;
    }

    private void Update()
    {
        UpdateWindows();
        //CheckForPlayerInWindow();
    }

    private void UpdateWindows()
    {
        MovableWindow currentWindow;
        for(int i =0; i < windows.Count; i++)
        {
            currentWindow = windows[i];

            for (int j = 0; j < windows.Count; j++)
            {
                if(currentWindow != windows[j])
                    UpdateStates(currentWindow, windows[j]);
            }
        }
    }

    void CheckForPlayerInWindow()
    {
        foreach(MovableWindow w in windows)
        {
            if (w.transform.Find("WindowFrame").GetComponent<SpriteRenderer>().sprite.bounds.Contains(player.transform.position)) //if player is in window bounds
            {
                w.player = player;
                w.player.gameObject.transform.SetParent(w.gameObject.transform); //parent player to this window
            }
            else
            {
                player.transform.SetParent(null);
            }
          
        }

    }

    private void UpdateStates(MovableWindow w1, MovableWindow w2)
    {
        w1.UpdateState(w2.controller.IsMouseDown);
        w2.UpdateState(w1.controller.IsMouseDown);
    }

    #region use_with_level_manager
    private GameObject windowPrefab;

    public WindowManager(Player p)
    {
        player = p;
    }

    void AssignwindowPrefab()
    {
        //windowPrefab =  
    }

    public void CreateWindows()
    {
        for (int i = 0; i < numOfWindows; i++)
        {
            CreateWindow();
        }
    }

    private void CreateWindow() //params - window start position, window x/y scale 
    {
        MovableWindow window = windowPrefab.GetComponent<MovableWindow>();
        windows.Add(window);
    }

    #endregion

}
