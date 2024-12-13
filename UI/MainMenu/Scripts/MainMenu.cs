using System.Collections;
using Rewired;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Status")]
    public bool opened;

    [Header("Screen Control")]
    public int activeScreen;
    public MainMenuScreen[] screens;

    [Header("Components")]
    public GameSystem gameSystem;
    public FadeElement background;

    private AudioComponent audio;
    private Rewired.Player rewiredPlayer;
    private GameManager gameManager;
    private Coroutine openMenu;

    private void Update()
    {
        if (gameManager)
        {
            if (gameManager.canOpenMenu)
            {
                ReadPlayerInput();
            }
        }
    }

    /// <summary>
    /// Init main menu.
    /// </summary>
    /// <param name="gameManager"></param>
    public void Init(GameManager gameManager)
    {
        audio = GetComponent<AudioComponent>();
        rewiredPlayer = ReInput.players.GetPlayer(0);

        this.gameManager = gameManager;
    }

    /// <summary>
    /// Open menu coroutine.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator OpenMenu()
    {
        opened = true;

        audio.PlaySound(0);
        background.FadeIn();

        yield return new WaitForSecondsRealtime(.5f);

        gameManager.PauseGame();
        OpenMenuScreen(0);

        openMenu = null;
    }

    /// <summary>
    /// CloseMenu.
    /// </summary>
    public void CloseMenu()
    {
        CloseAllScreens();

        audio.PlaySound(0);
        background.FadeOut();

        gameManager.ResumeGame();

        opened = false;
    }
    
    /// <summary>
    /// Open menu screen.
    /// </summary>
    /// <param name="screen"></param>
    public void OpenMenuScreen(int screen = 0)
    {
        // close previously openend screen.
        CloseAllScreens();
        screens[screen].gameObject.SetActive(true);
        screens[screen].Open(this, gameSystem, gameManager);
    }

    /// <summary>
    /// Close all menu screens.
    /// </summary>
    public void CloseAllScreens()
    {
        foreach (MainMenuScreen screen in screens)
        {
            if (screen.gameObject.activeSelf)
            {
                screen.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Read player input.
    /// </summary>
    private void ReadPlayerInput()
    {
        if (rewiredPlayer.GetButtonDown("Menu") && openMenu == null)
        {
            if (!opened)
            {
                openMenu = StartCoroutine(OpenMenu());
            }
            else
            {
                CloseMenu();
            }
        }
    }
}
