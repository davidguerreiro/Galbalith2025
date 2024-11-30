using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public bool canMove;
    public float moveSpeed;
    public float rotationSpeed;
    public float gravity;

    [HideInInspector]
    public bool isMoving;

    private Rewired.Player _rewiredPlayer;
    private Rigidbody _rigi;
    private CharacterController _controller;
    private Vector3 moveInput;
    private Vector3 velocity;

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    /// <summary>
    /// Move player in game.
    /// </summary>
    private void Move()
    {
        float moveX = _rewiredPlayer.GetAxis("MoveHorizontal");
        float moveZ = _rewiredPlayer.GetAxis("MoveVertical");

        moveInput = new Vector3(moveX, 0, moveZ);
        isMoving = moveInput.sqrMagnitude > 0.01f;

        // rotate.
        if (moveInput.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // apply gravity.
        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMovement = moveInput.normalized * moveSpeed * Time.deltaTime + velocity * Time.deltaTime;
        _controller.Move(finalMovement);
    }

    /// <summary>
    /// Allow player control.
    /// </summary>
    public void AllowPlayerControl()
    {
        canMove = true;
    }

    /// <summary>
    /// Restrict player control.
    /// </summary>
    public void RestrictPlayerControl()
    {
        canMove = false;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    public void Init()
    {
        _rewiredPlayer = ReInput.players.GetPlayer(0);

       _rigi = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }
}
