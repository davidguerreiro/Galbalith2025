using System.Collections;
using UnityEngine;

public class RestrictPlayerControl : Command
{
    public PlayerController playerController;

    /// <summary>
    /// Execute command.
    /// </summary>
    public override void ExecuteCommand()
    {
        if (runningCommand == null)
        {
            runningCommand = StartCoroutine(ExecuteRoutineCommand());
        }
    }

    /// <summary>
    /// Execute command routine.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public override IEnumerator ExecuteRoutineCommand()
    {
        playerController.RestrictPlayerControl();

        runningCommand = null;
        yield break;
    }
}
