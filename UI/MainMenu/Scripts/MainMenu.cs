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
    public GameManager gameManager;

    private AudioComponent audio;
    private Rewired.Player rewiredPlayer;


    public void Init()
    {
        audio = GetComponent<AudioComponent>();
        rewiredPlayer = ReInput.players.GetPlayer(0);
    }
}
