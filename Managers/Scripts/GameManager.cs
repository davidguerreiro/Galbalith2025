using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Status")]
    public bool inGameplay;

    [Header("Game Settings")]
    public bool canOpenMenu;

    [Header("Components")]
    public Player player;

    [Header("UIs")]
    public MainMenu mainMenu;

    private void Start()
    {
        
    }
}
