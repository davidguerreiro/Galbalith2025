using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Status")]
    public bool inGameplay;
    public bool inBattle;
    public bool paused;

    [Header("Game Settings")]
    public bool canOpenMenu;

    [Header("Components")]
    public Player player;

    [Header("UIs")]
    public MainMenu mainMenu;

    private GameSystem gameSystem;

    private void Start()
    {
        StartCoroutine(Init());
    }

    /// <summary>
    /// Init game components.
    /// </summary>
    public void InitGameComponents()
    {
        mainMenu.Init(this);
    }

    /// <summary>
    /// Init gameplaye.
    /// </summary>
    public void InitGamePlay()
    {
        canOpenMenu = true;
        inGameplay = true;

        player.playerController.AllowPlayerControl();
    }

    /// <summary>
    /// Check if in menu.
    /// </summary>
    /// <returns></returns>
    public bool InMenu()
    {
        return mainMenu.opened;
    }

    /// <summary>
    /// Pause game.
    /// </summary>
    public void PauseGame()
    {
        if (! paused)
        {
            inGameplay = false;
            paused = true;

            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// Resume game.
    /// </summary>
    public void ResumeGame()
    {
        if (paused)
        {
            inGameplay = true;
            paused = false;

            Time.timeScale = 1f;
        }
    }


    /// <summary>
    /// Init gameplay.
    /// </summary>
    public IEnumerator Init()
    {
        yield return new WaitForSeconds(1f);

        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();

        // Init game components like the UI and the player.
        InitGameComponents();

        // Init game play.
        InitGamePlay();
    }
}
