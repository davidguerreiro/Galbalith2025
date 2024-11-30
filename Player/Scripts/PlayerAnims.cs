using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;

    private PlayerController _playerController;

    // Update is called once per frame
    void Update()
    {
        CheckMoveAnim();
    }
    private void FixedUpdate()
    {
    }

    /// <summary>
    /// Check moving anim status.
    /// </summary>
    public void CheckMoveAnim()
    {
        if (anim != null && _playerController != null)
        {
            anim.SetBool("IsMoving", _playerController.isMoving);
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <param name="playerController">PlayerController</param>
    public void Init(PlayerController playerController)
    {
        this._playerController = playerController;
    }
}