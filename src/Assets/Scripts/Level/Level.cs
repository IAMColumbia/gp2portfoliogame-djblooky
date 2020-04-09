using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(WindowManager))]
public class Level : MonoBehaviour
{
    public Player player; 
    private WindowManager windowManager;
    public TextMeshProUGUI LevelText;

    private void Awake()
    {
        windowManager = GetComponent<WindowManager>(); //TO DO: move to constructor after level manager created?
        GetPlayerFromScene();
        LevelText.text = "Level 1";
    }

    private void GetPlayerFromScene()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
 
    void Update()
    {
        CheckForLose();
        CheckForWin();
    }

    void CheckForLose()
    {
        if (!player.alive)
        {
            LevelText.text = "Game Over! ";
            RestartGame();
        }
    }

    void CheckForWin()
    {
        if (player.win)
        {
            LevelText.text = "You Win! ";
            RestartGame();
        }     
    }

    void RestartGame()
    {
        LevelText.text += "Press space to restart";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }

    }

    #region use_with_level_manager
    private Vector2 playerStartPos = new Vector2(0, 0); //change this

    public Level()
    {
        //windowManager = GetComponent<WindowManager>();
    }

    void SpawnPlayer()
    {
        player = Instantiate(player, playerStartPos, Quaternion.identity); //TODO: instantiate from Character prefab
    }

    void CreateLevel()
    {
        //exit door position
        //door.locked = true/false

        windowManager.CreateWindows();
        //create platforms
    }
    #endregion
}
