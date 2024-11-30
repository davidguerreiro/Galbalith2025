using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerAnims playerAnims;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Init all player dependencies.
    /// </summary>
    public void Init()
    {
        // init player controller.
        playerController.Init();

        // init player anims.
        playerAnims.Init(playerController);
    }
}
