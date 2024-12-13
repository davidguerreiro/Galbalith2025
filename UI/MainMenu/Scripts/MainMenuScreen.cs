using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [Header("Settings")]
    public bool closeWithCancel;

    protected MainMenu mainMenu;

    /// <summary>
    /// Open screen.
    /// </summary>
    /// <param name="mainMenu">MainMenu</param>
    /// <param name="gameSystem">GameSystem</param>
    /// <param name="gameManager">GameManger</param>
    public virtual void Open(MainMenu mainMenu, GameSystem gameSystem = null, GameManager gameManager = null)
    {

    }

    /// <summary>
    /// Get if can screen be closed when pressing
    /// cancel button.
    /// </summary>
    /// <returns>bool</returns>
    public bool CanBeClosedWithCancel()
    {
        return closeWithCancel;
    }
}
